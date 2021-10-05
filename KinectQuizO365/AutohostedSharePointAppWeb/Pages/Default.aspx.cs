using AutohostedSharePointAppWeb.Model;
using SP = Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AutohostedSharePointAppWeb.Pages
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var contextToken = TokenHelper.GetContextTokenFromRequest(Page.Request);
            var hostWeb = Page.Request["SPHostUrl"];

            SP.ClientContext context = TokenHelper.GetClientContextWithContextToken(hostWeb, contextToken, Request.Url.Authority);
            Session["SPContext"] = context;

            LoadQuizCollection(context);
        }

        private void LoadQuizCollection(SP.ClientContext context)
        {
            QuizEngine engine = new QuizEngine(context);
            IEnumerable<Quiz> quizzes = engine.Load();

            quizCollection.DataSource = quizzes;
            quizCollection.DataBind();
        }
    }
}