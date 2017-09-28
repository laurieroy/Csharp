using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Challenge_EpicSpiesAssignment
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // initialize first load values to today, assignment in 2 weeks, duration of 1 week
            if (!Page.IsPostBack)
            {
                lastAssCalendar.SelectedDate = DateTime.Now.Date;
                nextAssCalendar.SelectedDate = DateTime.Now.Date.AddDays(15);
                nextAssCalendar.VisibleDate = DateTime.Now.Date.AddDays(15);
                endAssCalendar.SelectedDate = DateTime.Now.Date.AddDays(22);
                endAssCalendar.VisibleDate = DateTime.Now.Date.AddDays(22);
            }
            Page.MaintainScrollPositionOnPostBack = true;
        }

        protected void okButton_Click(object sender, EventArgs e)
        {
            // declare vars
            double union = 14;
            double dblbudget = 0;
            double dblassDays = 0;
            lastAssCalendar.SelectedDate = DateTime.Now.Date;

            DateTime dtlast = lastAssCalendar.SelectedDate; 
            DateTime dtnext = nextAssCalendar.SelectedDate;
            DateTime dtend = endAssCalendar.SelectedDate;

            // check to be sure Union rules followed for next assignment time
            // Daily rate is $500. If assigned > 21 days, $1000 bonus
            TimeSpan tsduration = (dtnext.Subtract(dtlast));
            double intervaldays = tsduration.Days;

            if (intervaldays > union)
            {
                dblassDays = dtend.Subtract(dtnext).Days;
                dblbudget = 500 * dblassDays;
                dblbudget = (dblassDays > 21) ? dblbudget += 1000 : dblbudget;

                resultLabel.Text = String.Format("Assignment of {1} to {2} is authorized. Budget Total: {0:C}",
                dblbudget, spyNameTextBox.Text, newOpNameTextBox.Text);
            }
            else
            {
                resultLabel.Text = "Error: Must allow at least two weeks between previous assignment and new assignment. ";
                DateTime reccomendStart = lastAssCalendar.SelectedDate.AddDays(15);
                nextAssCalendar.SelectedDate = reccomendStart;
                nextAssCalendar.VisibleDate = reccomendStart;
            }

        }
    }
}