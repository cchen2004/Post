using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Forms;
using System.IO;
using System.Web.Script.Serialization;

namespace Post
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            label1.Text = "";
            label2.Text = "";
            label3.Text = "";
            label5.Text = "";
            label6.Text = "";
            label7.Text = "";
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            label2.Text = "";
            label3.Text = "";
            label5.Text = "";
            label6.Text = "";
            label7.Text = "";

            //Open a dialog to select a csv file
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                TbUploadFile.Text = openFileDialog1.FileName;
        }

        private void BtnOutput_Click(object sender, EventArgs e)
        {
            string strFileName = TbUploadFile.Text;
            bool isDetailedMode = cbDetailedMode.Checked;
            bool isCSV = cbCSV.Checked;
            bool isJSON = cbJSON.Checked;

            if (!isCSV && !isJSON)
            {
                MessageBox.Show("Select a file type.");
                return;
            }

            FileFormat(strFileName);

            FileProcess(@"C:\temp.csv", isDetailedMode, isCSV, isJSON);
        }

        //Add a new timestamp_new column, sort by timestamp_new and likes
        private void FileFormat(string filepath)
        {
            try
            {
                using (var reader = new StreamReader(filepath))
                {
                    int i = 0;
                    int len = 0;

                    var timestamp_new = "";

                    StringBuilder builder = new StringBuilder();

                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');
                        len = values.Length;

                        if (i == 0)
                            builder.AppendLine(line + ",timestamp_new"); //Add column header
                        else //Format date in timestamp column and put to the "timestamp_new" column
                        {
                            var timestamp = values[len - 1].ToString().Split(' ');

                            timestamp_new = timestamp[1].ToString() + " " + timestamp[2].ToString() + " " + timestamp[4].ToString();

                            var date_new = DateTime.Parse(timestamp_new);

                            DateTime dt = new DateTime();
                            dt = Convert.ToDateTime(date_new);

                            var date = dt.ToString("yyyy-MM-dd");

                            builder.AppendLine(line + "," + date.ToString());
                        }
                        i++;
                    }

                    //Save to temp.csv
                    WriteToCVS(@"C:\temp.csv", builder.ToString());

                    //sort temp.csv
                    string[] lines = File.ReadAllLines(@"C:\temp.csv");
                    var data = lines.Skip(1);

                    //Sort by "timestamp_new" and "likes"
                    var sorted = data.Select(line => new
                    {
                        SortKey = (line.Split(',')[line.Split(',').Length - 1]),
                        SortKeyThenBy = Int32.Parse(line.Split(',')[line.Split(',').Length - 5]),
                        Line = line
                    })
                    .OrderBy(x => x.SortKey).ThenByDescending(x => x.SortKeyThenBy)
                    .Select(x => x.Line);

                    //Save sorted data to temp.csv
                    File.WriteAllLines(@"C:\temp.csv", lines.Take(1).Concat(sorted));
                }
            }
            catch (Exception ex)
            {
                throw new Exception("DateFormat function failed: " + ex.Message);
            }
        }

        //Create the output files
        private void FileProcess(string filepath, bool isDetailedMode, bool isCSV, bool isJSON)
        {
            try
            {
                //Read temp.csv
                using (var reader = new StreamReader(filepath))
                {
                    var id = "";
                    var title = "";
                    var privacy = "";
                    int likes = 0;
                    int likes_highest = 0;
                    int views = 0;
                    int comments = 0;
                    var timestamp = "";
                    var timestamp_new = "";
                    var timestamp_new_temp = "";
                    int len = 0;
                    int j = 0;
                    var line_new = "";
                    List<Post> list_top_posts = new List<Post> { };
                    List<Post> list_other_posts = new List<Post> { };
                    List<Post> list_daily_top_posts = new List<Post> { };

                    StringBuilder builder_top_posts = new StringBuilder();
                    StringBuilder builder_other_posts = new StringBuilder();
                    StringBuilder builder_daily_top_posts = new StringBuilder();

                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');
                        len = values.Length;

                        //Create header
                        if (j == 0)
                        {
                            line_new = values[0];

                            if (isDetailedMode)
                                line_new += "," + values[1] + "," + values[2] + "," + values[3] + "," + values[4] + "," + values[5] + "," + values[6];


                            builder_top_posts.AppendLine(line_new);
                            builder_other_posts.AppendLine(line_new);
                            builder_daily_top_posts.AppendLine(line_new);
                        }
                        else
                        {
                            id = values[0].ToString();

                            title = "";

                            for (int i = 1; i <= len - 7; i++)
                            {
                                title += values[i];

                                if (i != len - 7)
                                    title += ",";
                            }

                            privacy = values[len - 6].ToString();
                            likes = Int32.Parse(values[len - 5]);
                            views = Int32.Parse(values[len - 4]);
                            comments = Int32.Parse(values[len - 3]);
                            timestamp = values[len - 2].ToString();
                            timestamp_new = values[len - 1].ToString();

                            line_new = id;

                            if (isDetailedMode)
                                line_new += "," + title + "," + privacy + "," + likes + "," + views + "," + comments + "," + timestamp;

                            if (isTopPosts(privacy, comments, views, title))
                            {
                                //For csv format
                                if (isCSV)
                                {
                                    builder_top_posts.AppendLine(line_new); //put top posts to builder_top_posts
                                }

                                //For JSON format
                                if (isJSON)
                                {
                                    if (isDetailedMode)
                                        list_top_posts.Add(new Post { id = id, privacy = privacy, likes = likes, views = views, comments = comments, timestamp = timestamp });
                                    else
                                        list_top_posts.Add(new Post { id = id });
                                }
                            }
                            else
                            {
                                //For csv format
                                if (isCSV)
                                {
                                    builder_other_posts.AppendLine(line_new); //put remaining posts to builder_other_posts
                                }

                                //For JSON format
                                if (isJSON)
                                {
                                    if (isDetailedMode)
                                        list_other_posts.Add(new Post { id = id, privacy = privacy, likes = likes, views = views, comments = comments, timestamp = timestamp });
                                    else
                                        list_other_posts.Add(new Post { id = id });
                                }
                            }

                            if (timestamp_new != timestamp_new_temp) //Since the temp.csv file ordered by date and the 'likes' (descending), so the top row must be one of the top posts for the new day
                            {
                                //For csv format
                                if (isCSV)
                                {
                                    builder_daily_top_posts.AppendLine(line_new); //put daily top posts to builder_daily_top_posts
                                }

                                //For JSON format
                                if (isJSON)
                                {
                                    if (isDetailedMode)
                                        list_daily_top_posts.Add(new Post { id = id, privacy = privacy, likes = likes, views = views, comments = comments, timestamp = timestamp });
                                    else
                                        list_daily_top_posts.Add(new Post { id = id });
                                }

                                likes_highest = likes;
                            }
                            else if (likes == likes_highest)
                                builder_daily_top_posts.AppendLine(line_new); //if found a post with the same 'likes', put daily the posts to builder_daily_top_posts

                            timestamp_new_temp = timestamp_new;
                        }

                        j++;
                    }

                    //Create output files
                    if (isCSV)
                    {
                        WriteToCVS(@"C:\posts_top_posts.csv", builder_top_posts.ToString());
                        WriteToCVS(@"C:\posts_other_posts.csv", builder_other_posts.ToString());
                        WriteToCVS(@"C:\posts_daily_top_posts.csv", builder_daily_top_posts.ToString());

                        label1.Text = "posts_top_posts.csv is created under C drive.";
                        label2.Text = "posts_other_posts.csv is created under C drive.";
                        label3.Text = "posts_daily_top_posts.csv is created under C drive.";
                    }

                    if (isJSON)
                    {
                        WriteToCVS(@"C:\posts_top_posts.json", list_top_posts.ToJSON());
                        WriteToCVS(@"C:\posts_other_posts.json", list_other_posts.ToJSON());
                        WriteToCVS(@"C:\posts_daily_top_posts.json", list_daily_top_posts.ToJSON());

                        label5.Text = "posts_top_posts.json is created under C drive.";
                        label6.Text = "posts_other_posts.json is created under C drive.";
                        label7.Text = "posts_daily_top_posts.json is created under C drive.";
                    }
                }

                //Delete the temp.csv if exists
                if (File.Exists(@"C:\temp.csv"))
                {
                    File.Delete(@"C:\temp.csv");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("FileProcess function failed: " + ex.Message);
            }
        }

        private bool isTopPosts(string privacy, int comments, int views, string title)
        {
            if (privacy.ToLower() == "public" && comments > 10 && views > 9000 && title.Replace("\"\"", " ").Replace("\"", "").Length < 40)
                return true;
            else
                return false;
        }

        private void WriteToCVS(string filepath, string input)
        {
            File.WriteAllText(filepath, input);
        }

        private void cbDetailedMode_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "";
            label2.Text = "";
            label3.Text = "";
            label5.Text = "";
            label6.Text = "";
            label7.Text = "";
        }

        private void cbCSV_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "";
            label2.Text = "";
            label3.Text = "";
            label5.Text = "";
            label6.Text = "";
            label7.Text = "";
        }

        private void cbJSON_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "";
            label2.Text = "";
            label3.Text = "";
            label5.Text = "";
            label6.Text = "";
            label7.Text = "";
        }
    }

    public class Post
    {
        public string id { get; set; }
        public string title { get; set; }
        public string privacy { get; set; }
        public int likes { get; set; }
        public int views { get; set; }
        public int comments { get; set; }
        public string timestamp { get; set; }
    }


    public static class JSONHelper
    {
        public static string ToJSON(this object obj)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(obj);
        }
    }

}
