using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NAudio;
using NAudio.Wave;
using TagLib;


namespace FilesProject
    {
    class MP3Tag
        {
        public string Title { set; get;}
        public string Album { set; get; }
        public string Artist { set; get; }
        public string Year { set; get; }
        public string Genere { set; get; }
        public string Comment { set; get; }
        public string Duration { set; get; }

        
        }

    class MP3Reader
        {
        //string[] musicFiles = Directory.GetFiles(@"C:\Users\Sarah Ouf\Downloads\For Stds\Lab04\Lab10\bin\Debug", "*.mp3");
        string fileName;
        FileStream stream;
        const int SIZE = 128;
        byte[] tagData;
        public MP3Reader(string name)
            {
            tagData = new byte[SIZE];
            this.fileName = name;
            this.stream = new FileStream(this.fileName, FileMode.Open);
            }
        public MP3Tag getTag()
            {
            MP3Tag tag = new MP3Tag();

            stream.Seek(stream.Length - 128, SeekOrigin.Begin);
            stream.Read(tagData, 0, SIZE);
            stream.Close();

            byte b1 = tagData[0];
            byte b2 = tagData[1];
            byte b3 = tagData[2];                                                                                        

            if ((char)b1 != 'T' || (char)b2 != 'A' || (char)b3 != 'G')
                {
                throw new Exception("Not an MP3 Format File");
                }

            for (int i = 3; i < 33; i++)
                {
                if (tagData[i] != 0)
                    tag.Title += (char)tagData[i];

                }
            for (int i = 33; i < 63; i++)
                {
                if (tagData[i] != 0)
                    tag.Artist += (char)tagData[i];
                }
            for (int i = 63; i < 93; i++)
                {
                if (tagData[i] != 0)
                    tag.Album += (char)tagData[i];
                }
            for (int i = 93; i < 97; i++)
                {
                if (tagData[i] != 0)
                    tag.Year += (char)tagData[i];
                }
            for (int i = 97; i < 127; i++)
                {
                if (tagData[i] != 0)
                    tag.Comment += (char)tagData[i];
                }
            tag.Genere = tagData[127].ToString();
            Mp3FileReader reader = new Mp3FileReader(fileName);
            TimeSpan duration = reader.TotalTime;
            tag.Duration = duration.ToString();
            reader.Close();
            return tag;
            }
        }

    class mp3files            
        {
        public string filename { set; get; }
        public MP3Tag tags { set; get; }
        public mp3files(string filename, MP3Tag tags)
            {
            this.filename = filename;     // location
            this.tags = tags;           //information
            }

        public mp3files()
            {

            }
        public string getFile()
            {
            return filename;
            }
        }
    class mp3sorter
    {
        string[] musicFiles = Directory.GetFiles(@"C:\Users\Sarah Ouf\Documents\Visual Studio 2012\Projects\FilesProject\FilesProject\bin\Debug", "*.mp3");
        List<mp3files> mp3s = new List<mp3files>();
        public List<mp3files> getList()
        {
            foreach (string musicFile in musicFiles) //musicFiles: array of the files in the folder
            {                                        //mp3files: class that has the filename and tags of each song
                MP3Reader m = new MP3Reader(musicFile);  //mp3s: list of type mp3sfiles of the songs in folder
                MP3Tag c = m.getTag();
                mp3s.Add(new mp3files(musicFile , c));   
            }
            return mp3s;
        }

        public List<mp3files> getSpecificSort(string textbox , string type)
        {
            if (type == "Artist")
            {
                foreach (string musicFile in musicFiles)
                {
                    MP3Reader m = new MP3Reader(musicFile);
                    MP3Tag c = m.getTag();
                    if (c.Artist == textbox)
                    {
                        mp3s.Add(new mp3files(musicFile, c));     
                    }
                }
            }
            else if (type == "Album")
            {
                foreach (string musicFile in musicFiles)
                {
                    MP3Reader m = new MP3Reader(musicFile);
                    MP3Tag c = m.getTag();
                    if (c.Album == textbox)
                    {
                        mp3s.Add(new mp3files(musicFile, c));      
                    }
                }
            }
            else if (type == "Year")
            {
                foreach (string musicFile in musicFiles)
                {
                    MP3Reader m = new MP3Reader(musicFile);
                    MP3Tag c = m.getTag();
                    if (c.Year == textbox)
                    {
                        mp3s.Add(new mp3files(musicFile, c));      
                    }
                }
            }
            else if (type == "Genre")
            {
                foreach (string musicFile in musicFiles)
                {
                    MP3Reader m = new MP3Reader(musicFile);
                    MP3Tag c = m.getTag();
                    if (c.Genere == textbox)
                    {
                        mp3s.Add(new mp3files(musicFile, c));     
                    }
                }
            }
            else if (type == "Duration")
            {
                foreach (string musicFile in musicFiles)
                {
                    MP3Reader m = new MP3Reader(musicFile);
                    MP3Tag c = m.getTag();
                    if (c.Duration == textbox)
                    {
                        mp3s.Add(new mp3files(musicFile, c));      
                    }
                }
            }
            return mp3s;
        }

        public bool checkCondition(List<string> list)
        {
            int count = 0;
            bool check = false;
            for (int i = 0; i < list.Count() - 1; i++)
            {
                if (list[i] == list[i + 1])
                {
                    count++;
                }
            }
            if (list.Count() - 1 == count)
            {
                check = true;
            }
            else
            {
                check = false;
            }
            return check;
        }
              
        public void writeComment(List<mp3files> list)   // function el data gridview
        {
            int i = 0;
            foreach (mp3files file in list)
            {
                MP3Tag t = file.tags;
                t.Comment = i.ToString();
                i++;
            }       
        }

        public void writeCommentinFile(List<string> listFile)
        {
            for (int i = 0; i < listFile.Count(); i++)
            {
                TagLib.File File = TagLib.File.Create(listFile[i]);
                File.Tag.Comment = i.ToString();  //access comment section in file
                File.Save();
                
            }
        }

        public void writecommentinfile(List<string> listFile)
        {
            for (int i = 0; i < listFile.Count(); i++)
            {

                byte[] y;
                y = new byte[i];
                FileStream stream = new FileStream(listFile[i], FileMode.Open);
                stream.Seek(stream.Length - 97, SeekOrigin.Begin);
                stream.Write(y, 0, i);
                stream.Close();
                i++;
            }
        }

        public void copyFiles(List<string> filename)
        {
            string[] g;
            string targetPath = @"C:\Users\Sarah Ouf\Documents\Visual Studio 2012\Projects\FilesProject\FilesProject\Music";
            string v;
           
            for (int i = 0; i < filename.Count(); i++)
            {
                g = filename[i].Split('\\');
                v=g[g.Count()-1];
                string destFile = System.IO.Path.Combine(targetPath,v);
                string sourcefile = System.IO.Path.Combine(@"C:\Users\Sarah Ouf\Documents\Visual Studio 2012\Projects\FilesProject\FilesProject\bin\Debug", v);
                System.IO.File.Copy(sourcefile, destFile, true);

                
            }
        }
    }

    
    }
