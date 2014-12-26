using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using System.IO;

namespace LinqToObjects
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        XElement ChickenList;        
        private void Form1_Load(object sender, EventArgs e)
        {
            ChickenList = XElement.Load("Chickens.xml", LoadOptions.SetBaseUri | LoadOptions.SetLineInfo);
            LoadChickenData();
            DisplayChickenData();
            ErrorHandler errorHandler = new ErrorHandler();
            errorHandler.ClearLog();
        }

        /// <summary>
        /// LoadChickenData
        /// Uses Linq to XML to create a datasource.
        /// <remarks>
        /// Linq to XML, Collections, Strongly-typed objects
        /// </remarks>
        /// </summary>
        public void LoadChickenData()
        {
            //This is a demo. Users will be allowed to Reset the application. 
            //Ensure that they get the original list from Chickens.xml
            chickenList.Clear();

            var ChickenData = from c in ChickenList.Elements("Chicken")
                              select c;
            
            foreach (XElement e in ChickenList.Elements("Chicken")) 
            {
                Chickens chicken = new Chickens
                {
                    ID = e.Attribute("ID").Value, 
                    BreedName = e.Element("BreedName").Value,
                    Purpose = e.Element("Purpose").Value,
                    EggLaying = e.Element("EggLaying").Value,
                    EggColor = e.Element("EggColor").Value,
                    EggSize = e.Element("EggSize").Value,
                    ColdHardy = e.Element("ColdHardy").Value,
                    Broody = e.Element("Broody").Value,
                    VeryDocile = e.Element("VeryDocile").Value,
                    Personality = e.Element("Personality").Value
                };
                chickenList.Add(chicken);
            }

            results = chickenList;
            this.lblQueryCount.Text = "Number of records displayed: " + results.Count().ToString();
            DisplayChickenData();

            //AutoResize all columns
            int columns = dgvChickens.Columns.Count;
            foreach (DataGridViewColumn dgvc in dgvChickens.Columns)
            {

                --columns; dgvChickens.AutoResizeColumn(columns);
            };
        }

        /// <summary>
        /// DisplayChickenData
        /// Sets the datasource for the datagrid.
        /// </summary>
        private void DisplayChickenData()
        {
            dgvChickens.DataSource = chickenList.ToList();
        }

        //Need to retain in-memory data; so make the lists global
        List<DataFilter> filterList = new List<DataFilter>();
        List<Chickens> chickenList = new List<Chickens>();
        List<Chickens> results = new List<Chickens>();

        /// <summary>
        /// ParseQueryString
        /// Parses the user-defined query string.
        /// </summary>
        /// <remarks>
        /// String manipulation, Collections, Strongly-typed objects
        /// </remarks>
        /// <param name="query">user-defined query string</param>
        private void ParseQueryString(string query)
        {
            string[] filterTypes = { "PURPOSE", "EGGLAYING", 
                                       "EGGSIZE", "COLDHARDY", "BROODY", "VERYDOCILE"};

            char[] delimiters = { ';', ':', ',' };
            string[] filters = { };
            try
            {
                //query sample => EggLaying:Excellent;EggColor:Brown,White;EggSize:Extra Large
                if (query.Contains(';'))
                {
                    //parse at ";"
                    filters = query.Split(delimiters[0]);

                    foreach (string f in filters)
                    {
                        foreach (string ft in filterTypes)
                        {
                            if (f.Contains(ft))
                            {
                                //parse at ":"
                                string[] stripElement = f.Split(delimiters[1]);

                                DataFilter df = new DataFilter
                                {
                                    //parse at ","
                                    filterString = stripElement[1].Split(delimiters[2]),
                                    filterType = ft
                                };
                                filterList.Add(df);
                            }
                        }
                    }
                }
                else
                {
                    filters = query.Split(delimiters[1]);

                            DataFilter df = new DataFilter
                            {
                                //parse at ","
                                filterType = filters[0].ToString(),
                                filterString = filters[1].Split(delimiters[2])
                            };
                            filterList.Add(df);
                }
            }
            catch (System.IndexOutOfRangeException)
            {
                //we accept that invalid filters cannot be parsed corectly
            }
            catch (Exception ex)
            {
                ErrorHandler errorHandler = new ErrorHandler();
                errorHandler.WriteErrorToLog("ParseQueryString(string query) - " + ex.Message,
                    this.txtQuery.Text);
            }
        }

        /// <summary>
        /// ExecuteQuery
        /// Recursive method that executes the user-defined query.
        /// <remarks>
        /// Recursion, Linq to objects, Collections, Strongly-typed objects
        /// </remarks>
        /// </summary>
        private void ExecuteQuery()
        {
            try
            {
                foreach (DataFilter df in filterList)
                {
                    switch (df.filterType)
                    {
                        case "PURPOSE":

                            var _purpose = from p in results
                                           where df.filterString.Contains(p.Purpose.ToUpper())
                                           select p;

                            //Immediate execution [ToList()]: 
                            //because we need to know the number of results
                            _purpose = _purpose.ToList();

                            //Only clear results "after" we use it to perform the next query
                            results.Clear();
                            if (_purpose.Count() > 0)
                            {
                                results = _purpose.ToList();
                            }                            
                            break;
                        case "EGGLAYING":
                            var _egglaying = from e in results
                                             where df.filterString.Contains(e.EggLaying.ToUpper())
                                             select e;
                            _egglaying = _egglaying.ToList();
                            results.Clear();
                            if (_egglaying.Count() > 0)
                            {
                                results = _egglaying.ToList();
                            }
                            break;
                        case "EGGSIZE":
                            var _eggsize = from e in results
                                           where df.filterString.Contains(e.EggSize.ToUpper())
                                           select e;
                            _eggsize = _eggsize.ToList();
                            results.Clear();
                            if (_eggsize.Count() > 0)
                            {
                                results = _eggsize.ToList();
                            }
                            break;
                        case "COLDHARDY":
                            var _coldhardy = from c in results
                                             where df.filterString.Contains(c.ColdHardy.ToUpper())
                                             select c;
                            _coldhardy = _coldhardy.ToList();
                            results.Clear();
                            if (_coldhardy.Count() > 0)
                            {
                                results = _coldhardy.ToList();
                            }
                            break;
                        case "BROODY":
                            var _broody = from b in results
                                          where df.filterString.Contains(b.Broody.ToUpper())
                                          select b;
                            _broody = _broody.ToList();
                            results.Clear();
                            if (_broody.Count() > 0)
                            {
                                results = _broody.ToList();
                            }
                            break;
                        case "VERYDOCILE":
                            var _verydocile = from v in results
                                           where df.filterString.Contains(v.VeryDocile.ToUpper())
                                           select v;
                            _verydocile = _verydocile.ToList();
                            results.Clear();
                            if (_verydocile.Count() > 0)
                            {
                                results = _verydocile.ToList();
                            }
                            break;  
                    }

                    //Remove the portion of the query that's already been executed, then call
                    //ExecuteQuery (recursive) to continue processing the query string.
                    filterList.Remove(df);
                    ExecuteQuery();
                }
                    
                chickenList.Clear();
                foreach (Chickens c in results)
                {
                    chickenList.Add(c);
                }

                //Display filtered results
                this.lblQueryCount.Text = "Number of records displayed: " + chickenList.Count().ToString();
                dgvChickens.DataSource = chickenList;
                dgvChickens.Refresh();
            }
            catch (System.InvalidOperationException)
            {
                //we understand and accept that the collection will be modified
            }
            catch (Exception ex)
            {
                ErrorHandler errorHandler = new ErrorHandler();       
                errorHandler.WriteErrorToLog("ExecuteQuery() - " + ex.Message, 
                    this.txtQuery.Text);
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            LoadChickenData();
            string query = this.txtQuery.Text.ToUpper();
            ParseQueryString(query);
            ExecuteQuery();
            this.txtQuery.Clear();
            this.txtQuery.Focus();
        }

        private void DisplayInfo(string info)
        {
            //display an info form
            if (info == "About Filtering")
            {
                StringBuilder s = new StringBuilder();
                s.AppendLine("Author: Michelle Edmondson");
                s.AppendLine("Email: medmondson2014@gmail.com");
                s.AppendLine();
                s.AppendLine("=====Tips!=====");
                s.AppendLine("1. The filter query textbox has sample data you can run immediately.");
                s.AppendLine("2. Clicking the 'Reset this demo' link will also reset the sample data in the textbox.");
                s.AppendLine("3. You can leave this window open if you need to refer back to it.");
                s.AppendLine("4. Use colons to construct filter/value pairs.");
                s.AppendLine("5. Use commas to assign multiple values to a filter.");
                s.AppendLine("6. Use semi-colons to filter based on multiple filter/value pairs.");
                s.AppendLine("7. Filtering is not case-sensitive.");
                s.AppendLine("8. Spaces should be avoided in your filter query, unless it's part of a value, such as => eggsize:very large");
                s.AppendLine();
                s.AppendLine("=====You can filter based on the following criteria[value] sets:=====");
                s.AppendLine("Purpose [Dual, Egg-laying, Meat, Ornamental]");
                s.AppendLine("EggLaying [Good, Very Good, Excellent, Poor, Fair]");
                s.AppendLine("EggSize [Tiny (bantam), Medium, Small, Large, Extra Large]");
                s.AppendLine("ColdHardy [Yes, No]");
                s.AppendLine("Broody [Yes, No]");
                s.AppendLine("VeryDocile [Yes, No]");
                s.AppendLine();
                s.AppendLine("=====Examples of valid filter constructions:=====");
                s.AppendLine("Example => Filter:Value");
                s.AppendLine("Example => Filter:Value1,Value2");
                s.AppendLine("Example => Filter1:Value1,Value2;Filter2:Value1");
                s.AppendLine();
                s.AppendLine("=====Sample Scenarios: Copy and paste them into the filter textbox.=====");
                s.AppendLine("Scenario => If you were looking for breeds with the intention of using them for meat, you might use following filter:");
                s.AppendLine("     purpose:dual,meat");
                s.AppendLine("Scenario => If you were looking for breeds with the intention of using them for eggs, you might use following filter:");
                s.AppendLine("     purpose:egg-laying;egglaying:excellent,very good;eggsize:extra large,large;broody:yes");
                s.AppendLine("Scenario => If you were looking for breeds with the intention of using them for eggs and meat, you might use following filter:");
                s.AppendLine("     purpose:dual;egglaying:excellent,very good;eggsize:extra large,large");
                s.AppendLine("Scenario => If you were looking for breeds with the intention of keeping them as pets, you might use following filter:");
                s.AppendLine("     purpose:ornamental;verydocile:yes");

                frmInfo _frmInfo = new frmInfo(s.ToString());
                _frmInfo.Text = info;
                _frmInfo.Show();
            }
            else
            {
                StringBuilder s = new StringBuilder();
                s.AppendLine("Author: Michelle Edmondson");
                s.AppendLine("Email: medmondson2014@gmail.com");
                s.AppendLine();
                s.AppendLine("Purpose: Software Development Portfolio");
                s.AppendLine();
                s.AppendLine("Things to note in this demo: ");
                s.AppendLine("1. Linq to XML");
                s.AppendLine("2. Linq to Objects");
                s.AppendLine("3. Recursion");
                s.AppendLine("4. String Manipulation");
                s.AppendLine("5. Collections");
                s.AppendLine("6. Strongly-typed Objects");
                s.AppendLine("7. Error Logging");

                frmInfo _frmInfo = new frmInfo(s.ToString());
                _frmInfo.Text = info;
                _frmInfo.ShowDialog();
            }
        }
        private void lnkReset_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoadChickenData();
            DisplayChickenData();
            this.txtQuery.Text = "Purpose:Egg-laying,Dual;EggLaying:Good,Very Good,Excellent";
            this.txtQuery.Focus();
        }


        private void lnkAboutDemo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DisplayInfo("About Demo");
        }

        private void lnkFilterInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DisplayInfo("About Filtering");
        }        
    }

    /// <summary>
    /// ErrorHandler
    /// Writes to an error log. 
    /// <remarks>
    /// Error logging
    /// </remarks>
    /// </summary>
    public class ErrorHandler
    {
        private string errorMessage { get; set; }
        private string errorQuery { get; set; }
        private string path = "errorLog.txt";

        public void WriteErrorToLog(string em, string eq)
        {
            errorMessage = em;
            errorQuery = eq;

            if (File.Exists(path))
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(errorMessage);
                    sw.WriteLine("Query - " + errorQuery);
                    sw.Close();
                }
                
            }
        }
        public void ClearLog()
        {
            if (File.Exists(path))
            {
                StreamWriter sw = new StreamWriter(path);
                sw.Write("");
                sw.Close();
            }          
        }
    }

    public struct DataFilter
    {
        public string filterType { get; set; }
        public string[] filterString { get; set; }
    }
    public struct Chickens
    {
        public string ID { get; set; }
        public string BreedName { get; set; }
        public string Purpose { get; set; }
        public string EggLaying { get; set; }
        public string EggColor { get; set; }
        public string EggSize { get; set; }
        public string ColdHardy { get; set; }
        public string Broody { get; set; }
        public string VeryDocile { get; set; }
        public string Personality { get; set; }
    }
}
