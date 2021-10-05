using Microsoft.Speech.Recognition;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KinectQuizDesktop.Model
{
    public class MySpeechRecognizer
    {
        public MySpeechRecognizer(Language language)
        {
            _language = language;
        }

        public string Recognize()
        {
            string text = null;
            string isoLang = SpeechGrammar.GetIsoLanguage(_language);
            
            using (SpeechRecognitionEngine engine =
                new SpeechRecognitionEngine(CultureInfo.GetCultureInfo(isoLang)))
            {
                engine.LoadGrammar(SpeechGrammar.GetGrammar(_language));
                engine.SetInputToDefaultAudioDevice();

                RecognitionResult result = engine.Recognize();
                text = result != null ? result.Text : null;
            }

            return text;
        }

        public IEnumerable<RecognizerInfo> GetInstalledVoices()
        {
            return SpeechRecognitionEngine.InstalledRecognizers().AsEnumerable();
        }

        private RecognizerInfo GetRecognizer(Language language)
        {
            return GetInstalledVoices().FirstOrDefault(
                info => info.Culture.TwoLetterISOLanguageName == SpeechGrammar.GetIsoLanguage(language));
        }

        private Language _language;
    }
}
