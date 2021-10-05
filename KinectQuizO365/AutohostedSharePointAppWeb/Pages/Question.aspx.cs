using SP = Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AutohostedSharePointAppWeb.Model;

namespace AutohostedSharePointAppWeb.Pages
{
    public partial class Question : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SP.ClientContext context = Session["SPContext"] as SP.ClientContext;

            if (context != null)
            {
                Quiz quiz = new Quiz(context, Request["quizCollection"]);
                quizTitle.Text = quiz.Title;

                questionList.DataSource = quiz.GetQuestions();
                questionList.DataBind();
            }
        }
    }
}