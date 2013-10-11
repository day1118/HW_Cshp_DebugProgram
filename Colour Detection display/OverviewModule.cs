using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Colour_Detection_display
{
    class OverviewModule : TabPage
    {
        ListView listView = new ListView();
        char stringDelimiter = ':';

        LinkedList<State> states = new LinkedList<State>();

        public OverviewModule(string name)
        {
            this.Name = "tpg" + name;
            this.Text = name;

            System.Windows.Forms.ColumnHeader colName = new System.Windows.Forms.ColumnHeader();
            System.Windows.Forms.ColumnHeader colValue = new System.Windows.Forms.ColumnHeader();
            System.Windows.Forms.ColumnHeader colAvg = new System.Windows.Forms.ColumnHeader();
            System.Windows.Forms.ColumnHeader colCommment = new System.Windows.Forms.ColumnHeader();

            colName.Text = "Name";
            colName.Width = 230;
            
            colValue.Text = "Value";
            colValue.Width = 100;

            colAvg.Text = "Average";
            colAvg.Width = 100;

            colCommment.Text = "Comment";
            colCommment.Width = 400;

            listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            colName, colValue, colAvg, colCommment});
            listView.Dock = System.Windows.Forms.DockStyle.Fill;
            listView.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            listView.GridLines = true;
            listView.Name = "lstOverview";
            listView.View = System.Windows.Forms.View.Details;

            this.Controls.Add(listView);

            ListItem a = new ListItem("test", "5", "");
            listView.Items.Add(a);

            readStatesFile();

            Timer timer = new Timer();
            timer.Interval = 2000;
            timer.Enabled = true;
            timer.Tick += new EventHandler(TimerTick);
            timer.Start();
        }

        private void TimerTick(Object sender, EventArgs e)
        {
            if (Form1.serialPortOpen)
            {
                ListItem expiredItem = null;
                foreach (ListItem item in ListItem.itemList)
                {
                    if (item.expired())
                    {
                        expiredItem = item;
                    }
                }
                if (expiredItem != null)
                {
                    listView.Items.Remove(expiredItem);
                    ListItem.itemList.Remove(expiredItem);
                    TimerTick(null, null);     // Run again incase there are more!
                }
            }
        }

        public void addData(string text)
        {
            string[] splitText = text.Split(stringDelimiter);

            if (splitText.Length == 2)
            {
                String name = splitText[0];
                String value = splitText[1];
                String comment = "";

                if(name.EndsWith("State"))
                {
                    String stateNameShort = name.Replace("State", "");
                    State tempState = new State("STATE_" + stateNameShort.ToUpper() + "_?", value);
                    LinkedListNode<State> matchingStateNode = states.Find(tempState);

                    if (matchingStateNode != null)
                    {
                        State matchingState = matchingStateNode.Value;
                        comment = matchingState.name;
                    }
                }

                ListItem item = findItemInList(name);
                if (item == null)
                {
                    item = new ListItem(name, value, comment);
                    listView.Items.Add(item);
                }
                else
                {
                    item.updateValue(value, comment);
                }
            }
        }

        private ListItem findItemInList(string name)
        {
            foreach (ListItem item in ListItem.itemList)
            {
                if(item.name.Equals(name, StringComparison.CurrentCultureIgnoreCase))
                {
                    return item;
                }
            }
            return null;
        }

        private void readStatesFile()
        {
            // Read each line of the file into a string array. Each element 
            // of the array is one line of the file. 
            string curentDirectory = Directory.GetCurrentDirectory();
            string gitDirectory = getParent(curentDirectory, 4);
            string projectDirectory = getParent(curentDirectory, 3);
            string configDirectory = gitDirectory + @"\HW_Hockey";
            string configFile1 = configDirectory + @"\states.h";
            string configFile2 = projectDirectory + @"\states.h";

            string[] lines = {};

            if(File.Exists(configFile1))
                lines = System.IO.File.ReadAllLines(configFile1);
            else if (File.Exists(configFile2))
                lines = System.IO.File.ReadAllLines(configFile2);
            
            foreach (String line in lines)
            {
                String tempLine;
                String[] lineParts;
                if (line.StartsWith("#define "))
                {
                    tempLine = line.Replace("#define ", "");
                    if (tempLine.StartsWith("STATE"))
                    {
                        lineParts = tempLine.Split(' ', '\t');
                        if (lineParts.Length >= 2)
                        {
                            String name = lineParts[0];
                            String value = lineParts[lineParts.Length - 1];

                            states.AddLast(new State(name, value));
                        }
                    }
                }
            }
        }

        private string getParent(string path, int depth)
        {
            string parentPath = path;
            for (int i = 0; i < depth; i++)
            {
                parentPath = Directory.GetParent(parentPath).ToString();
            }
            return parentPath;
        }

        private class ListItem : ListViewItem
        {
            public static LinkedList<ListItem> itemList = new LinkedList<ListItem>();
            private long updateTime, averageUpdateTime;
            public string name;
            int value;
            int average;
            String comment;

            static int averageLength = 10;
            static int averageDelayTime = 1000;

            public ListItem(string newName, string newValue, string newComment)
            {
                updateTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                name = newName;
                value = Convert.ToInt32(newValue);
                comment = newComment;
                average = 0;

                this.Text = name;
                this.SubItems.Add(value.ToString());
                this.SubItems.Add(average.ToString());
                this.SubItems.Add(comment);

                itemList.AddLast(this);
            }

            public void updateValue(string newValue, string newComment)
            {
                long currentTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                value = Convert.ToInt32(newValue);
                comment = newComment;

                average -= average / averageLength;
                average += value / averageLength;

                this.SubItems[1].Text = value.ToString();

                if (currentTime > averageUpdateTime + averageDelayTime)
                {
                    this.SubItems[2].Text = average.ToString();
                    averageUpdateTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                }

                this.SubItems[3].Text = comment;

                updateTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            }

            public Boolean expired()
            {
                long currentTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                return (currentTime > updateTime + 5000);
            }
        }

        class State
        {
            public String name;
            String type;
            int value;

            public State(String newName, String newValue)
            {
                name = newName;
                Int32.TryParse(newValue, out value);

                String[] lineParts = newName.Split('_');
                if (lineParts.Length >= 3)
                {
                    if (lineParts[0] == "STATE")
                    {
                        type = lineParts[1];
                    }
                }
            }

            public override bool Equals(object obj)
            {
                State state;
                if(obj is State)
                {
                    state = (State)obj;
                    return (state.type.Equals(this.type) && state.value == this.value);
                }
                else return false;
            }
        }
    }
}
