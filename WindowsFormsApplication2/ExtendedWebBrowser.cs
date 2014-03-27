using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;

using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using mshtml;

namespace WindowsFormsApplication2
{
    public class ExtendedWebBrowser : WebBrowser
    {
        bool renavigating = false;

        static public string needUrl = "http://kpita.me/girls";
        static public int doingPageLoaded = 0;
        static public int logged = 1;

    
        public string UserAgent { get; set; }

        public ExtendedWebBrowser()
        {
            DocumentCompleted += SetupBrowser;

            //this will cause SetupBrowser to run (we need a document object)
            Navigate("about:blank");
        }

        void SetupBrowser(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            DocumentCompleted -= SetupBrowser;
            SHDocVw.WebBrowser xBrowser = (SHDocVw.WebBrowser)ActiveXInstance;
            xBrowser.BeforeNavigate2 += BeforeNavigate;
            DocumentCompleted += PageLoaded;
            NewWindow += new System.ComponentModel.CancelEventHandler(WinFormBrowser_NewWindow);
            
            ScriptErrorsSuppressed = true;
        }

        private void LinkClicked(object sender, EventArgs e)
        {

            HtmlElement link = Document.ActiveElement;
            needUrl = link.GetAttribute("href");
        }

       
        void WinFormBrowser_NewWindow(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
         //   Navigate(needUrl);
            
        }

        Dictionary<string, int> girls = new Dictionary<string,int>();
        const int maxGlobT = 100;
        int globT = maxGlobT;


        public static Dictionary<string,int>  CheatGirls = new Dictionary<string,int>();
        public static List<int> ModuloGirls = new List<int>();//how fast them grow 1- 100%, 2 - 50%
        //List<int> CurModGirls = new List<int>();
        public static List<int> CurAllGirls = new List<int>();
        public static void CheatGirlsInit() {
            CheatGirls.Add("едорец",0);
            ModuloGirls.Add(1);
            CurAllGirls.Add(0);

            CheatGirls.Add("имарчук",1);
            ModuloGirls.Add(1);
            CurAllGirls.Add(0);

            CheatGirls.Add("одоп",2); // Водопьянова
            ModuloGirls.Add(1);
            CurAllGirls.Add(0);

            CheatGirls.Add("Доценко",3);
            ModuloGirls.Add(1);
            CurAllGirls.Add(0);
        }
        bool FoundCheatGirl(string where, IHTMLElement good, IHTMLElement bad) {

            foreach (string el in CheatGirls.Keys)
            {
                if (where.Contains(el))
                {
                    int i = CheatGirls[el];

                    CurAllGirls[i]++;
                    int curMod = CurAllGirls[i] % ModuloGirls[i];

                    if (curMod == 0)
                    {
                        doWaitClick(good);
                    }
                    else
                    {
                        doWaitClick(bad);
                    }

                    Thread.Sleep(2500);
                    return true;
                }
            }
            return false;

        }

        public static Dictionary<string, int> BlackGirls = new Dictionary<string, int>();
        public static List<int> CurBlackGirls = new List<int>();

        public static void BlackGirlsInit()
        {
            BlackGirls.Add("Голуб", 0);
            CurBlackGirls.Add(0);

            BlackGirls.Add("Li", 1);
            CurBlackGirls.Add(0);

        }

        bool FoundBlackGirl(string where, IHTMLElement thats_she, IHTMLElement another)
        {

            foreach (string el in BlackGirls.Keys)
            {
                if (where.Contains(el))
                {
                    int i = BlackGirls[el];

                    CurBlackGirls[i]--;
                    
                    doWaitClick(another);

                    Thread.Sleep(2500);
                    return true;
                }
            }
            return false;

        }

        static public int All = 0, Che = 0;
        

        void doWaitClick(IHTMLElement what) {
            what.click();
          //  Thread.Sleep(700);
        }


        void PageLoaded(object sender, WebBrowserDocumentCompletedEventArgs e){
            doingPageLoaded = 1;
            PageLoadedUderWrapper( sender,  e);
            doingPageLoaded = 0;
        }

        void PageLoadedUderWrapper(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
           // doingPageLoaded = 1;

         //   Thread.Sleep(500);

            //HtmlElementCollection links = Document.Links;
            //    foreach (HtmlElement var in links)
            //    {
            //    var.AttachEventHandler("onclick", LinkClicked);
            //    }
            
            
            var login = Document.GetElementById("login_btn");
            if (login != null)
            {
                logged = 0;
                var log = Document.GetElementById("login_btn").DomElement as IHTMLElement;
                doWaitClick(log);
               // doingPageLoaded = 0;
                Thread.Sleep(1200);
                logged = 1;
                return;
            }
           
            HtmlDocument doc = Document;
            //if (e.Url.ToString().Contains("vk.com"))
            //{
            //    var els = doc.GetElementsByTagName("li");
            //    foreach(HtmlElement el in els){
            //        if (el.GetAttribute("className") == "mmi_logout")
            //        {
            //            var t = el.FirstChild;
            //            t.InvokeMember("Click");
            //        }
            //    }
            //    //HtmlDocument doc = Document;
            //    //HtmlElement username = doc.GetElementById("email");
            //    //if (username != null)
            //    //{
            //    //    HtmlElement password = doc.GetElementById("pass");
            //    //    var submit = doc.GetElementsByTagName("input")[2];

            //    //    username.InnerText = "380950971964";
            //    //    password.InnerText = "0405Mari!";
            //    //    submit.InvokeMember("click");
            //    //}
            //   // Navigate("kpita.me/top100");
            //}
            if (e.Url.ToString().Contains("kpita.me") && e.Url.ToString().Contains("girls")) {
                girls.Clear();
                foreach (HtmlElement el in Document.Links) {
                    if (el.GetAttribute("className") == "rateitem")
                    {
                        girls.Add(el.Children[1].InnerText,Convert.ToInt32(el.Children[0].InnerText));
                    }
                }
                needUrl = "kpita.me";
                globT = maxGlobT;
                Thread.Sleep(3000);
              //  Navigate(needUrl);
            }


            if (e.Url.ToString().Contains("kpita.me") && !e.Url.ToString().Contains("girls"))
            {
               // Thread.Sleep(3000);
                if (globT-- > 0)
                {
                    var el1 = Document.GetElementById("desc1");
                    var el2 = Document.GetElementById("desc2");
                    string name1, name2;
                    if (el1 != null && el1.InnerText != null)
                    {
                        
                        name1 = el1.InnerText.Split(' ').Last();
                        All++;
                        //using (System.IO.StreamWriter sw = new System.IO.StreamWriter("C:/Temp/output.txt")) {
                        //    sw.WriteLine("{0} {1}",All++,Che);
                        //}
                    }
                    else
                    {
                        globT++;
                   //     doingPageLoaded = 0;
                        return;
                    }
                    if (el2 != null && el2.InnerText != null)
                    {
                        name2 = el2.InnerText.Split(' ').Last();
                    }
                    else
                    {
                        globT++;
                //        doingPageLoaded = 0;
                        return;
                    }
                    IHTMLElement vi1 = Document.GetElementById("vote1img").DomElement as IHTMLElement;
                    IHTMLElement vi2 = Document.GetElementById("vote2img").DomElement as IHTMLElement;

                    if (FoundCheatGirl(name1, vi1, vi2)) return;
                    if (FoundCheatGirl(name2, vi2, vi1)) return;

                   // if (FoundBlackGirl(name1, vi1, vi2)) return;
                   // if (FoundBlackGirl(name2, vi2, vi1)) return;
/*
                    if (name1.Contains("Федорец") || name1.Contains("Римарчук") || name1.Contains("одоп"))
                    {
                        //using (System.IO.StreamWriter sw = new System.IO.StreamWriter("C:/Temp/output.txt"))
                        //{
                        //    sw.WriteLine("{0} {1}", All, Che++);
                        //}
                        Che++;
                        doWaitClick(vi1);
                        doingPageLoaded = 0;
                        return; 
                    }
                    if (name2.Contains("Федорец") || name2.Contains("Римарчук") || name2.Contains("одоп"))
                    {
                        //using (System.IO.StreamWriter sw = new System.IO.StreamWriter("C:/Temp/output.txt"))
                        //{
                        //    sw.WriteLine("{0} {1}", All, Che++);
                        //}
                        Che++;
                        doWaitClick(vi2);
                        doingPageLoaded = 0;
                        return; 
                    }
             */
                    if (false)
                    {
                        //doingPageLoaded = 0;
                        return;
                    }
                   // var sm = girls.Keys.Where( x => x.Contains("Федорец")).ToList().Count;

                    
                    int vote1 = (girls.Keys.Where(x => x.Contains(name1)).ToList().Count > 0) ? girls[girls.Keys.Where(x => x.Contains(name1)).ToList()[0]] : 0;
                    int vote2 = (girls.Keys.Where(x => x.Contains(name2)).ToList().Count > 0) ? girls[girls.Keys.Where(x => x.Contains(name2)).ToList()[0]] : 0;
                    string key1 ="", key2= "";
                    if (vote1 > 0 )
                        key1 = girls.Keys.Where(x => x.Contains(name1)).ToList()[0];
                    if (vote2 > 0) 
                        key2 = girls.Keys.Where(x => x.Contains(name2)).ToList()[0];
                    
                    if (vote1 > vote2)
                    {
                        doWaitClick(vi2);
                        if (vote2 > 0)
                        {
                            girls[key2]++;
                        }
                        
                    }
                    else
                    {
                        doWaitClick(vi1);
                        if (vote1 > 0)
                        {
                            girls[key1]++;
                        }

                        
                    }
                    needUrl = "kpita.me";
                  
                }
                else
                {
                    needUrl = "kpita.me/girls";
                  
                }
            }
            //doingPageLoaded = 0;

            //{
            //    //var login = doc.GetElementById("login_btn").FirstChild;
            //    //if (login != null)
            //    //{
            //    //    login.InvokeMember("click");
            //    //}
            //    //else
            //    //{

            //    //    Vote();

            //    //}
            //    //Navigate("kpita.me/top100");
            //}
            //if (e.Url.ToString().Contains("kpita.me") && e.Url.ToString().Contains("girls")) { 
            //    //read();
            //    var b = doc.Body;
            //    int i = 1;
            //}

        }

        void BeforeNavigate(object pDisp, ref object url, ref object flags, ref object targetFrameName,
            ref object postData, ref object headers, ref bool cancel)
        {
            //Thread.Sleep(1000);
            if (!string.IsNullOrEmpty(UserAgent))
            {
                if (!renavigating)
                {
                    headers += string.Format("User-Agent: {0}\r\n", UserAgent);
                    renavigating = true;
                    cancel = true;
                    Navigate((string)url, (string)targetFrameName, (byte[])postData, (string)headers);
                }
                else
                {
                    renavigating = false;
                }
            }
        }
    }
}
