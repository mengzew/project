using System;
using AVFoundation;
using AudioToolbox;
using Foundation;
using UIKit;

namespace project
{
	public class sound_manager
	{
		#region Private Variables
		private AVAudioPlayer backgroundMusic;
		private string backgroundSong = "";
		#endregion

		#region Computed Properties
		public float BackgroundMusicVolume
		{
			get { return backgroundMusic.Volume; }
			set { backgroundMusic.Volume = value; }
		}

		public bool MusicOn { get; set; } = true;
		public float MusicVolume { get; set; } = 0.5f;

		public bool EffectsOn { get; set; } = true;
		public float EffectsVolume { get; set; } = 1.0f;
		#endregion


		#region Constructors
		public sound_manager()
		{
			//initialize
			ActivateAudioSession();
		}
		#endregion

		#region Public Methods
		//make loopback in music track til it's leaving from this background
		public void ActivateAudioSession()
		{
			// Initialize Audio
			var session = AVAudioSession.SharedInstance();
			session.SetCategory(AVAudioSessionCategory.Ambient);
			session.SetActive(true);
		}

		public void DeactivateAudioSession()
		{
			var session = AVAudioSession.SharedInstance();
			session.SetActive(false);
		}

		public void ReactivateAudioSession()
		{
			var session = AVAudioSession.SharedInstance();
			session.SetActive(true);
		}

		public void PlayBackgroundMusic(string filename)
		{
			NSUrl songURL;

			// Music enabled?
			if (!MusicOn) return;

			// Any existing background music?
			if (backgroundMusic != null)
			{
				//Stop and dispose of any background music
				backgroundMusic.Stop();
				backgroundMusic.Dispose();
			}

			// Initialize background music
			songURL = new NSUrl("Sounds/" + filename);
			NSError err;
			backgroundMusic = new AVAudioPlayer(songURL, "mp3", out err);
			backgroundMusic.Volume = MusicVolume;
			backgroundMusic.FinishedPlaying += delegate
			{
				backgroundMusic = null;
			};
			backgroundMusic.NumberOfLoops = -1;
			backgroundMusic.Play();
			backgroundSong = filename;

		}

		public void StopBackgroundMusic()
		{

			// If any background music is playing, stop it
			backgroundSong = "";
			if (backgroundMusic != null)
			{
				backgroundMusic.Stop();
				backgroundMusic.Dispose();
			}
		}

		public void SuspendBackgroundMusic()
		{

			// If any background music is playing, stop it
			if (backgroundMusic != null)
			{
				backgroundMusic.Stop();
				backgroundMusic.Dispose();
			}
		}

		public void RestartBackgroundMusic()
		{

			// Music enabled?
			if (!MusicOn) return;

			// Was a song previously playing?
			if (backgroundSong == "") return;

			// Restart song to fix issue with wonky music after sleep
			PlayBackgroundMusic(backgroundSong);
		}
		#endregion
	}
}

