using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace Jazzimage
{
	static class TransformVoting
	{
		static Dictionary<string, double> _colorVotes = new Dictionary<string, double>();
		static Dictionary<string, double> _coordVotes = new Dictionary<string, double>();
		static Dictionary<int, double> _numTransformVotes = new Dictionary<int, double>();
		static Dictionary<string, Type> _colorTransforms = new Dictionary<string, Type>();
		static Dictionary<string, Type> _coordTransforms = new Dictionary<string, Type>();

		static TransformVoting()
		{
			// Color Transforms
			_colorTransforms.Add(typeof(AlterBlue).FullName, typeof(AlterBlue));
			_colorTransforms.Add(typeof(AlterGreen).FullName, typeof(AlterGreen));
			_colorTransforms.Add(typeof(AlterRed).FullName, typeof(AlterRed));
			_colorTransforms.Add(typeof(Circle).FullName, typeof(Circle));
			_colorTransforms.Add(typeof(FuzzAlpha).FullName, typeof(FuzzAlpha));
			_colorTransforms.Add(typeof(GradientCircle).FullName, typeof(GradientCircle));
			_colorTransforms.Add(typeof(GradientCrazyCircle).FullName, typeof(GradientCrazyCircle));
			_colorTransforms.Add(typeof(GradientX).FullName, typeof(GradientX));
			_colorTransforms.Add(typeof(GradientY).FullName, typeof(GradientY));
			_colorTransforms.Add(typeof(GreyscaleX).FullName, typeof(GreyscaleX));
			_colorTransforms.Add(typeof(GreyscaleY).FullName, typeof(GreyscaleY));
			_colorTransforms.Add(typeof(HorizontalStripe).FullName, typeof(HorizontalStripe));
			_colorTransforms.Add(typeof(VerticalStripe).FullName, typeof(VerticalStripe));

			// Coord Transforms
			_coordTransforms.Add(typeof(BulgeX).FullName, typeof(BulgeX));
			_coordTransforms.Add(typeof(BulgeY).FullName, typeof(BulgeY));
			_coordTransforms.Add(typeof(Fisheye).FullName, typeof(Fisheye));
			_coordTransforms.Add(typeof(Fuzz).FullName, typeof(Fuzz));
			_coordTransforms.Add(typeof(MoveOrigin).FullName, typeof(MoveOrigin));
			_coordTransforms.Add(typeof(Rotate).FullName, typeof(Rotate));
			_coordTransforms.Add(typeof(SineX).FullName, typeof(SineX));
			_coordTransforms.Add(typeof(SineY).FullName, typeof(SineY));
			_coordTransforms.Add(typeof(Swirl).FullName, typeof(Swirl));
			_coordTransforms.Add(typeof(TiltX).FullName, typeof(TiltX));
			_coordTransforms.Add(typeof(TiltY).FullName, typeof(TiltY));
			_coordTransforms.Add(typeof(ZigZagX).FullName, typeof(ZigZagX));
			_coordTransforms.Add(typeof(ZigZagY).FullName, typeof(ZigZagY));
			_coordTransforms.Add(typeof(ZoomOut).FullName, typeof(ZoomOut));

			for (int i = 4; i <= 32; i++)
			{
				_numTransformVotes.Add(i, 1.0);
			}

			// Initialize votes (pre-fill the vote objects in case we add new transforms in the future)
			foreach (string transform in _colorTransforms.Keys)
			{
				_colorVotes.Add(transform, 1.0);
			}

			foreach (string transform in _coordTransforms.Keys)
			{
				_coordVotes.Add(transform, 1.0);
			}

			LoadVotes();
		}

		public static TransformParent GetColorTransform()
		{
			double voteTotal = 0.0;

			foreach (string transform in _colorVotes.Keys)
			{
				voteTotal += _colorVotes[transform];
			}

			double num = RandomNumberProvider.GetDouble() * voteTotal;

			string selectedTransform = null;

			foreach (string transform in _colorVotes.Keys)
			{
				if (num < _colorVotes[transform])
				{
					selectedTransform = transform;
					break;
				}

				num = num - _colorVotes[transform];
			}

			Type transformType = _colorTransforms[selectedTransform];

			TransformParent ret = (TransformParent)Activator.CreateInstance(transformType);

			return ret;
		}

		public static TransformParent GetCoordTransform()
		{
			double voteTotal = 0.0;

			foreach (string transform in _coordVotes.Keys)
			{
				voteTotal += _coordVotes[transform];
			}

			double num = RandomNumberProvider.GetDouble() * voteTotal;

			string selectedTransform = null;

			foreach (string transform in _coordVotes.Keys)
			{
				if (num < _coordVotes[transform])
				{
					selectedTransform = transform;
					break;
				}

				num = num - _coordVotes[transform];
			}

			Type transformType = _coordTransforms[selectedTransform];

			TransformParent ret = (TransformParent)Activator.CreateInstance(transformType);

			return ret;
		}

		public static int GetNumTransforms()
		{
			double voteTotal = 0.0;

			foreach (int numTransform in _numTransformVotes.Keys)
			{
				voteTotal += _numTransformVotes[numTransform];
			}

			double num = RandomNumberProvider.GetDouble() * voteTotal;

			int selectedNumTransform = -1;

			foreach (int numTransform in _numTransformVotes.Keys)
			{
				if (num < _numTransformVotes[numTransform])
				{
					selectedNumTransform = numTransform;
					break;
				}

				num = num - _numTransformVotes[numTransform];
			}

			return selectedNumTransform;
		}

		public static void RecordVotes(List<TransformParent> transforms, int numTransforms, double voteAmount)
		{
			foreach (TransformParent transform in transforms)
			{
				string transformName = transform.GetType().FullName;

				// Try color votes
				if (_colorVotes.ContainsKey(transformName))
				{
					_colorVotes[transformName] += voteAmount;
				}

				// Try coord votes
				if (_coordVotes.ContainsKey(transformName))
				{
					_coordVotes[transformName] += voteAmount;
				}
			}

			// numTransform vote
			if (voteAmount > 0)
			{
				_numTransformVotes[numTransforms] += 1.0;
			}
			else
			{
				_numTransformVotes[numTransforms] -= 1.0;
			}

			NormalizeVotes();
			SaveVotes();
		}

		static void SaveVotes()
		{
			var fileName = GetConfigFileName();

			StreamWriter file = new StreamWriter(fileName, false);

			foreach (string transform in _colorVotes.Keys)
			{
				file.WriteLine(transform);
				file.WriteLine(_colorVotes[transform]);
			}

			foreach (string transform in _coordVotes.Keys)
			{
				file.WriteLine(transform);
				file.WriteLine(_coordVotes[transform]);
			}

			foreach (int numTransforms in _numTransformVotes.Keys)
			{
				file.WriteLine(numTransforms);
				file.WriteLine(_numTransformVotes[numTransforms]);
			}

			file.Close();
		}

		static void LoadVotes()
		{
			var fileName = GetConfigFileName();

			if (!File.Exists(fileName))
			{
				SaveVotes();
				return;
			}

			StreamReader file = new StreamReader(fileName);

			string transformName = file.ReadLine();
			string transformVoteStr = file.ReadLine();

			while (transformName != null && transformVoteStr != null)
			{
				double transformVote = Convert.ToDouble(transformVoteStr);

				// Try color votes
				if (_colorVotes.ContainsKey(transformName))
				{
					_colorVotes[transformName] = transformVote;
				}

				// Try coord votes
				if (_coordVotes.ContainsKey(transformName))
				{
					_coordVotes[transformName] = transformVote;
				}

				// Try numTransform
				int transformNameInt;
				if (Int32.TryParse(transformName, out transformNameInt))
				{
					_numTransformVotes[transformNameInt] = transformVote;
				}

				transformName = file.ReadLine();
				transformVoteStr = file.ReadLine();
			}

			NormalizeVotes();
		}

		/// <summary>
		/// Ensure the least popular transforms won't drop to zero
		/// </summary>
		static void NormalizeVotes()
		{
			// Colors
			double highestColorVote = 0.0;

			foreach (string transform in _colorVotes.Keys)
			{
				if (_colorVotes[transform] > highestColorVote)
				{
					highestColorVote = _colorVotes[transform];
				}
			}

			double minColorVote = highestColorVote / 25.0;

			foreach (string transform in _colorVotes.Keys)
			{
				if (_colorVotes[transform] < minColorVote)
				{
					_colorVotes[transform] = minColorVote;
				}
			}

			// Coords
			double highestCoordVote = 0.0;

			foreach (string transform in _coordVotes.Keys)
			{
				if (_coordVotes[transform] > highestCoordVote)
				{
					highestCoordVote = _coordVotes[transform];
				}
			}

			double minCoordVote = highestCoordVote / 25.0;

			foreach (string transform in _coordVotes.Keys)
			{
				if (_coordVotes[transform] < minCoordVote)
				{
					_coordVotes[transform] = minCoordVote;
				}
			}

			// numTransforms
			double highestNumVote = 0.0;

			foreach (int numTransform in _numTransformVotes.Keys)
			{
				if (_numTransformVotes[numTransform] > highestNumVote)
				{
					highestNumVote = _numTransformVotes[numTransform];
				}
			}

			double minNumVote = highestNumVote / 25.0;

			for (int i = 4; i <= 32; i++)
			{
				if (_numTransformVotes[i] < minNumVote)
				{
					_numTransformVotes[i] = minNumVote;
				}
			}
		}

		static string GetConfigFileName()
		{
			var fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "JazzImage.txt");

			return fileName;
		}
	}
}
