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
    public static class SpeechGrammar
    {
        static SpeechGrammar()
        {
            _grammars = new Dictionary<Language, Grammar>()
            {
                { Language.English, BuildGrammarEnglish() },
                { Language.Italian, BuildGrammarItalian() }
            };
        }

        public static Grammar GetGrammar(Language language)
        {
            return _grammars[language];
        }

        private static Grammar BuildGrammarEnglish()
        {
            var choices = new Choices();
            choices.Add("Apple");
            choices.Add("Ice cream");
            choices.Add("Ball");
            choices.Add("Car");
            choices.Add("Butterfly");
            choices.Add("Fish");

            return new Grammar(new GrammarBuilder(choices)) { Name = "English" };
        }

        private static Grammar BuildGrammarItalian()
        {
            var choices = new Choices();
            choices.Add("Mela");
            choices.Add("Gelato");
            choices.Add("Palla");
            choices.Add("Auto");
            choices.Add("Farfalla");
            choices.Add("Pesce");

            return new Grammar(new GrammarBuilder(choices)) { Name = "Italian" };
        }

        public static string GetIsoLanguage(Language language)
        {
            switch (language)
            {
                case Language.English:
                    return "en-GB";

                case Language.Italian:
                    return "en-GB";

                default:
                    return "en-GB";
            }
        }
        
        private static IDictionary<Language, Grammar> _grammars;
    }

    public enum Language
    {
        English,
        Italian
    }
}
