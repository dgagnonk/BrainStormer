/*
    BrainStormer: Brainstorm your writing.
    Copyright (C) 2015-2017  Daniel Gagnon-King

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System.Speech.Synthesis;

namespace BrainStormerNoPlugins
{
    /*
     * This class takes care of the text-to-speech feature in the word processors.
     * This feature is present predominantly in frmRichText.cs and frmNote.cs
     */
    public class TextToSpeech
    {
        SpeechSynthesizer voice;

        public TextToSpeech()
        {
            voice = new SpeechSynthesizer();
            voice.Rate = 1;
        }

        // Says the text vocally
        public void SayText(string text)
        {
            voice.SpeakAsync(text);
        }

        // Obtains the voice object's state (busy, idle, etc.)
        // This is so that we can properly stop it if needed.
        public SynthesizerState GetState()
        {
            return voice.State;
        }

        // The user may not want to hear the entire text. Stop the speech.
        public void StopSpeech()
        {
            voice.SpeakAsyncCancelAll();
        }

    }
}
