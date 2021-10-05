using SP = Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutohostedSharePointAppWeb.Model
{
    public class Quiz
    {
        public Quiz(SP.ClientContext context, string title)
        {
            _context = context;
            _quiz = context.Web.Lists.GetByTitle(title);
            Title = title;
        }

        public Quiz(SP.ClientContext context, SP.List list)
        {
            _quiz = list;
            Title = list.Title;
        }

        public string Title { get; private set; }

        public void AddQuestion(string title, string answer, string option1, string option2)
        {
            SP.ListItemCreationInformation info = new SP.ListItemCreationInformation();
            SP.ListItem item = _quiz.AddItem(info);

            item["Title"] = title;
            item["Answer"] = answer;
            item["Option1"] = option1;
            item["Option2"] = option2;

            item.Update();
            _context.ExecuteQuery();
        }

        public SP.ListItemCollection GetQuestions()
        {
            SP.CamlQuery query = SP.CamlQuery.CreateAllItemsQuery(100);
            SP.ListItemCollection questions = _quiz.GetItems(query);

            _context.Load(questions); 
            _context.ExecuteQuery();

            return questions;
        }

        private SP.ClientContext _context;
        private SP.List _quiz;
    }
}