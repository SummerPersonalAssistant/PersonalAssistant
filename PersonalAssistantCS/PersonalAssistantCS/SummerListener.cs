using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech;
using System.Speech.Recognition;

namespace PersonalAssistantCS
{
    class SummerListener
    {
        private SpeechRecognitionEngine _recognizer;
        private Action<string> _listenCallback;

        public SummerListener(Action<string> listenCallback)
        {
            _recognizer = null;
            _recognizer = new SpeechRecognitionEngine();
            _recognizer.SetInputToDefaultAudioDevice();
            _recognizer.LoadGrammar(new DictationGrammar());
            _recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(recognizer_SpeechRecognized);
            _recognizer.RecognizeAsync(RecognizeMode.Multiple);
            _listenCallback = listenCallback;
        }

        // The callback called when a sentence is recognized
        private void recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string text = e.Result.Text;
            _listenCallback.Invoke(text);
        }
    }
}
