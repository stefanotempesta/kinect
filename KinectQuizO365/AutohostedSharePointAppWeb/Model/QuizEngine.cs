using SP = Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutohostedSharePointAppWeb.Model
{
    public class QuizEngine
    {
        private SP.ClientContext _context;

        public QuizEngine(SP.ClientContext context)
        {
            _context = context;
        }

        public IEnumerable<Quiz> Load()
        {
            IList<Quiz> quizzes = new List<Quiz>();

            Quiz geography = CreateNew("Australia");
            Quiz history = CreateNew("Geography");
            Quiz english = CreateNew("Math");

            quizzes.Add(geography);
            quizzes.Add(history);
            quizzes.Add(english);

            return quizzes.AsEnumerable();
        }

        public Quiz CreateNew(string title)
        {
            if (!QuizExists(title))
            {
                SP.ListCreationInformation info = new SP.ListCreationInformation();
                info.Title = title;
                info.TemplateType = (int)SP.ListTemplateType.GenericList;

                SP.List list = _context.Web.Lists.Add(info);
                list.Update();
                _context.ExecuteQuery();

                AddFields(list);

                return new Quiz(_context, list);
            }
            else
            {
                return new Quiz(_context, title);
            }
        }

        private bool QuizExists(string title)
        {
            return _context.Web.Lists.GetByTitle(title) != null;
        }

        private void AddFields(SP.List list)
        {
            SP.Field fieldAnswer = list.Fields.AddFieldAsXml(
                "<Field Type='Text' Name='Answer' DisplayName='Correct Answer' />",
                true,
                SP.AddFieldOptions.DefaultValue);

            SP.Field fieldOption1 = list.Fields.AddFieldAsXml(
                "<Field Type='Text' Name='Option1' DisplayName='Option 1' />",
                true,
                SP.AddFieldOptions.DefaultValue);

            SP.Field fieldOption2 = list.Fields.AddFieldAsXml(
                 "<Field Type='Text' Name='Option2' DisplayName='Option 2' />",
                 true,
                 SP.AddFieldOptions.DefaultValue);
            
            _context.Load(list.Fields);
            _context.ExecuteQuery();
        }
    }
}