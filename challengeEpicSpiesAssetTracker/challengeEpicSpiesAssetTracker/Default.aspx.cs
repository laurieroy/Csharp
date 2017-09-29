using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace challengeEpicSpiesAssetTracker
{
    public partial class Default : System.Web.UI.Page
    {
        int [] acts;
        int [] votes;
        string [] names;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                names = new string[0];
                votes = new int[0];
                acts = new int[0];
                ViewState.Add("Names", names);
                ViewState.Add("Votes", votes);
                ViewState.Add("Acts", acts);

            }
        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            string[] names = (string[])ViewState["Names"];
            int[] votes = (int[])ViewState["Votes"];
            int[] acts = (int[])ViewState["Acts"];

            Array.Resize(ref names, names.Length + 1);  // this seems horribly inefficient
            Array.Resize(ref acts, acts.Length + 1);
            Array.Resize(ref votes, votes.Length + 1);

            int newestItem = names.GetUpperBound(0); // Get highest index, and place values
            names[newestItem] = nameTextBox.Text;
            votes[newestItem] = int.Parse(riggedTextBox.Text);
            acts[newestItem] = int.Parse(actsTextBox.Text);

            ViewState["Names"] = names; // reset in memory
            ViewState["Votes"] = votes;
            ViewState["Acts"] = acts;
       
            resultLabel.Text = String.Format("Total elections rigged: {0}<br /> " +
                           "Average Acts of Subterfuge per Asset: {1:N2}<br />(Last Asset you Added:{2})", +
                           votes.Sum(), acts.Average(), names[newestItem]);

            nameTextBox.Text = ""; // clear out for next entry
            riggedTextBox.Text = "";
            actsTextBox.Text = "";
                                
        }
    }
}