using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using NAudio;
using NAudio.Wave;
using TagLib;

namespace FilesProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        //array shaeel el files ely fel order
        string[] musicFiles = Directory.GetFiles(@"C:\Users\Sarah Ouf\Documents\Visual Studio 2012\Projects\FilesProject\FilesProject\bin\Debug", "*.mp3");
        List<mp3files> mp3s = new List<mp3files>();
       
        private void button1_Click(object sender, EventArgs e)    //button artist
        {
            string textbox;                  //textbox with name
            string type = comboBoxSort.Text.ToString();         //combobox with type of name
            mp3sorter m = new mp3sorter();                      //m is object from from mp3sorter class
            if (string.IsNullOrEmpty(textBox1.Text))
            {

                mp3s = m.getList();                         //sorts the music files normally, takes the musicfile and get the tags of it and then puts it and the filename in the mp3s list
                
                mp3s = mp3s.OrderBy(o => o.tags.Artist.ToString()).ToList();// o be3mal excess ll hagat eli gowa el mp3s"filename , tags"
                m.writeComment(mp3s);                        //writecomment fn takes the mp3s list and loops through it to writes the order of the songs in the comment section
                List<MP3Tag> tag = new List<MP3Tag>();
                foreach (mp3files file in mp3s)    //only tags to show in datagridview
                {
                    tag.Add(file.tags);
                }
                dataGridView1.DataSource = tag;
            }

            else if (!string.IsNullOrEmpty(textBox1.Text))
            {
                textbox = textBox1.Text.ToString();
                mp3s = m.getSpecificSort(textbox, type); //getSpecificSort checks the textbox and the type sent to it to know what the collection of files to be used(album , year , genre) and puts the final list in mp3s
                // el list el etsft bs msh sorted
                List<string> artist = new List<string>();
                foreach (mp3files file in mp3s)
                {
                    MP3Tag tag = file.tags;
                    artist.Add(tag.Artist);
                }
                bool cond = m.checkCondition(artist);
                if (cond == true)
                {
                    MessageBox.Show("all the songs are by the same artist the sort will be by title");
                    mp3s = mp3s.OrderBy(o => o.tags.Title.ToString()).ToList();
                }
                else if (cond == false)
                {
                    mp3s = mp3s.OrderBy(o => o.tags.Artist.ToString()).ToList();
                }
                m.writeComment(mp3s);
                List<MP3Tag> tag1 = new List<MP3Tag>();
                foreach (mp3files file in mp3s)
                {
                    tag1.Add(file.tags);
                }
                dataGridView1.DataSource = tag1;
            }
            List<string> filename = new List<string>();   //writes the order of the song in the comment section in the file
            foreach (mp3files file in mp3s)
            {
                filename.Add(file.filename);
            }
            m.writeCommentinFile(filename);
            m.copyFiles(filename);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }




        //List<string> filename = new List<string>();
        private void buttontitle_Click(object sender, EventArgs e) //button title
        {

            string textbox;
            string type = comboBoxSort.Text.ToString();
            mp3sorter m = new mp3sorter();
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                mp3s = m.getList();
                mp3s = mp3s.OrderBy(o => o.tags.Title.ToString()).ToList();
                m.writeComment(mp3s);
                List<MP3Tag> tag = new List<MP3Tag>();
                foreach (mp3files file in mp3s)
                {
                    tag.Add(file.tags);
                }
                dataGridView1.DataSource = tag;
                
                List<string> filename = new List<string>();
                foreach (mp3files file in mp3s)
                {
                    filename.Add(file.filename);
                }
                m.writeCommentinFile(filename);
                m.copyFiles(filename);
             //   m.writecommentinfile(filename);

             //   m.copyFiles(filename);
            }
            else if (!string.IsNullOrEmpty(textBox1.Text))
            {
                textbox = textBox1.Text.ToString();
                mp3s = m.getSpecificSort(textbox, type);
                mp3s = mp3s.OrderBy(o => o.tags.Title.ToString()).ToList();
                m.writeComment(mp3s);
                List<MP3Tag> tag = new List<MP3Tag>();
                foreach (mp3files file in mp3s)
                {
                    tag.Add(file.tags);
                }
                dataGridView1.DataSource = tag;
                List<string> filename = new List<string>();
                foreach (mp3files file in mp3s)
                {
                    filename.Add(file.filename);
                }
                m.writeCommentinFile(filename);
                m.copyFiles(filename);
            }

        }

        private void buttonyear_Click(object sender, EventArgs e)
        {
            string textbox;
            string type = comboBoxSort.Text.ToString();
            mp3sorter m = new mp3sorter();
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                mp3s = m.getList();
                mp3s = mp3s.OrderBy(o => o.tags.Year.ToString()).ToList();
                m.writeComment(mp3s);
                List<MP3Tag> tag = new List<MP3Tag>();
                foreach (mp3files file in mp3s)
                {
                    tag.Add(file.tags);
                }
                dataGridView1.DataSource = tag;
                List<string> filename = new List<string>();
                foreach (mp3files files in mp3s)
                {
                    filename.Add(files.filename);
                }
                m.writeCommentinFile(filename);
                m.copyFiles(filename);
            }
            else if (!string.IsNullOrEmpty(textBox1.Text))
            {
                textbox = textBox1.Text.ToString();
                mp3s = m.getSpecificSort(textbox, type);
                List<string> year = new List<string>();
                foreach (mp3files file in mp3s)
                {
                    MP3Tag tag = file.tags;
                    year.Add(tag.Year);
                }
                bool cond = m.checkCondition(year);
                if (cond == true)
                {
                    MessageBox.Show("all the files are in the same year the sort will be on the title");
                    mp3s = mp3s.OrderBy(o => o.tags.Title.ToString()).ToList();
                }
                else if (cond == false)
                {
                    mp3s = mp3s.OrderBy(o => o.tags.Year.ToString()).ToList();
                }
                m.writeComment(mp3s);
                List<MP3Tag> tag1 = new List<MP3Tag>();
                foreach (mp3files file in mp3s)
                {
                    tag1.Add(file.tags);
                }
                dataGridView1.DataSource = tag1;
                List<string> filename = new List<string>();
                foreach (mp3files file in mp3s)
                {
                    filename.Add(file.filename);
                }
                m.writeCommentinFile(filename);
                m.copyFiles(filename);
            }
        }

        private void buttonalbum_Click(object sender, EventArgs e)
        {
            string textbox;
            string type = comboBoxSort.Text.ToString();
            mp3sorter m = new mp3sorter();
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                mp3s = m.getList();
                mp3s = mp3s.OrderBy(o => o.tags.Album.ToString()).ToList();
                m.writeComment(mp3s);
                List<MP3Tag> tag = new List<MP3Tag>();
                foreach (mp3files file in mp3s)
                {
                    tag.Add(file.tags);
                }
                dataGridView1.DataSource = tag;
                List<string> filename = new List<string>();
                foreach (mp3files files in mp3s)
                {
                    filename.Add(files.filename);
                }
                m.writeCommentinFile(filename);
                m.copyFiles(filename);
            }
            else if (!string.IsNullOrEmpty(textBox1.Text))
            {
                textbox = textBox1.Text.ToString();
                mp3s = m.getSpecificSort(textbox, type);
                List<string> album = new List<string>();
                foreach (mp3files file in mp3s)
                {
                    MP3Tag tag = file.tags;
                    album.Add(tag.Album);
                }
                bool cond = m.checkCondition(album);
                if (cond == true)
                {
                    MessageBox.Show("all the files are from the same album the sort will be on the title");
                    mp3s = mp3s.OrderBy(o => o.tags.Title.ToString()).ToList();
                }
                else if (cond == false)
                {
                    mp3s = mp3s.OrderBy(o => o.tags.Album.ToString()).ToList();
                }
                m.writeComment(mp3s);
                List<MP3Tag> tag1 = new List<MP3Tag>();
                foreach (mp3files file in mp3s)
                {
                    tag1.Add(file.tags);
                }
                dataGridView1.DataSource = tag1;
                List<string> filename = new List<string>();
                foreach (mp3files file in mp3s)
                {
                    filename.Add(file.filename);
                }
                m.writeCommentinFile(filename);
                m.copyFiles(filename);
            }

        }

        private void buttongenre_Click(object sender, EventArgs e)
        {
            string textbox;
            string type = comboBoxSort.Text.ToString();
            mp3sorter m = new mp3sorter();
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                mp3s = m.getList();
                mp3s = mp3s.OrderBy(o => o.tags.Genere.ToString()).ToList();
                m.writeComment(mp3s);
                List<MP3Tag> tag = new List<MP3Tag>();
                foreach (mp3files file in mp3s)
                {
                    tag.Add(file.tags);
                }
                dataGridView1.DataSource = tag;
                List<string> filename = new List<string>();
                foreach (mp3files files in mp3s)
                {
                    filename.Add(files.filename);
                }
                m.writeCommentinFile(filename);
                m.copyFiles(filename);
            }

            else if (!string.IsNullOrEmpty(textBox1.Text))
            {
                textbox = textBox1.Text.ToString();
                mp3s = m.getSpecificSort(textbox, type);
                List<string> genre = new List<string>();
                foreach (mp3files file in mp3s)
                {
                    MP3Tag tag = file.tags;
                    genre.Add(tag.Genere);
                }
                bool cond = m.checkCondition(genre);
                if (cond == true)
                {
                    MessageBox.Show("all the files are with the same genre the sort will be on the title");
                    mp3s = mp3s.OrderBy(o => o.tags.Title.ToString()).ToList();
                }
                else if (cond == false)
                {
                    mp3s = mp3s.OrderBy(o => o.tags.Genere.ToString()).ToList();
                }
                m.writeComment(mp3s);
                List<MP3Tag> tag1 = new List<MP3Tag>();
                foreach (mp3files file in mp3s)
                {
                    tag1.Add(file.tags);
                }
                dataGridView1.DataSource = tag1;
                List<string> filename = new List<string>();
                foreach (mp3files file in mp3s)
                {
                    filename.Add(file.filename);
                }
                m.writeCommentinFile(filename);
                m.copyFiles(filename);
            }
        }

        private void buttonDuration_Click(object sender, EventArgs e)
        {
            string textbox;
            string type = comboBoxSort.Text.ToString();
            mp3sorter m = new mp3sorter();
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                mp3s = m.getList();
                mp3s = mp3s.OrderBy(o => o.tags.Duration.ToString()).ToList();
                m.writeComment(mp3s);
                List<MP3Tag> tag = new List<MP3Tag>();
                foreach (mp3files file in mp3s)
                {
                    tag.Add(file.tags);
                }
                dataGridView1.DataSource = tag;
                List<string> filename = new List<string>();
                foreach (mp3files files in mp3s)
                {
                    filename.Add(files.filename);
                }
                m.writeCommentinFile(filename);
                m.copyFiles(filename);
            }
            else if (!string.IsNullOrEmpty(textBox1.Text))
            {
                textbox = textBox1.Text.ToString();
                mp3s = m.getSpecificSort(textbox, type);
                List<string> duration = new List<string>();
                foreach (mp3files file in mp3s)
                {
                    MP3Tag tag = file.tags;
                    duration.Add(tag.Duration);
                }
                bool cond = m.checkCondition(duration);
                if (cond == true)
                {
                    MessageBox.Show("all the files are with the same duration the sort will be on the title");
                    mp3s = mp3s.OrderBy(o => o.tags.Title.ToString()).ToList();
                }
                else if (cond == false)
                {
                    mp3s = mp3s.OrderBy(o => o.tags.Duration.ToString()).ToList();
                }
                m.writeComment(mp3s);
                List<MP3Tag> tag1 = new List<MP3Tag>();
                foreach (mp3files file in mp3s)
                {
                    tag1.Add(file.tags);
                }
                dataGridView1.DataSource = tag1;
                List<string> filename = new List<string>();
                foreach (mp3files file in mp3s)
                {
                    filename.Add(file.filename);
                }
                m.writeCommentinFile(filename);
                m.copyFiles(filename);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
         
        }
    }
}