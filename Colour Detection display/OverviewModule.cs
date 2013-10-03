using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Colour_Detection_display
{
    class OverviewModule : TabPage
    {
        ListView listView = new ListView();
        char stringDelimiter = ':';
        
        public OverviewModule(string name)
        {
            this.Name = "tpg" + name;
            this.Text = name;

            System.Windows.Forms.ColumnHeader colName = new System.Windows.Forms.ColumnHeader();
            System.Windows.Forms.ColumnHeader colValue = new System.Windows.Forms.ColumnHeader();
            System.Windows.Forms.ColumnHeader colAvg = new System.Windows.Forms.ColumnHeader();

            colName.Text = "Name";
            colName.Width = 230;
            
            colValue.Text = "Value";
            colValue.Width = 100;

            colAvg.Text = "Average";
            colAvg.Width = 100;

            listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            colName, colValue, colAvg});
            listView.Dock = System.Windows.Forms.DockStyle.Fill;
            listView.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            listView.GridLines = true;
            listView.Name = "lstOverview";
            listView.View = System.Windows.Forms.View.Details;

            this.Controls.Add(listView);

            ListItem a = new ListItem("test", "5");
            listView.Items.Add(a);

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

                ListItem item = findItemInList(name);
                if (item == null)
                {
                    item = new ListItem(name, value);
                    listView.Items.Add(item);
                }
                else
                {
                    item.updateValue(value);
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

        private class ListItem : ListViewItem
        {
            public static LinkedList<ListItem> itemList = new LinkedList<ListItem>();
            private long updateTime, averageUpdateTime;
            public string name;
            int value;
            int average;

            static int averageLength = 10;
            static int averageDelayTime = 1000;

            public ListItem(string newName, string newValue)
            {
                updateTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                name = newName;
                value = Convert.ToInt32(newValue);
                average = 0;

                this.Text = name;
                this.SubItems.Add(value.ToString());
                this.SubItems.Add(average.ToString());

                itemList.AddLast(this);
            }

            public void updateValue(string newValue)
            {
                long currentTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                value = Convert.ToInt32(newValue);

                average -= average / averageLength;
                average += value / averageLength;

                this.SubItems[1].Text = value.ToString();

                if (currentTime > averageUpdateTime + averageDelayTime)
                {
                    this.SubItems[2].Text = average.ToString();
                    averageUpdateTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                }

                updateTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            }

            public Boolean expired()
            {
                long currentTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                return (currentTime > updateTime + 5000);
            }
        }
    }
}
