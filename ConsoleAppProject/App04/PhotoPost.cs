using System;
using System.Collections.Generic;
using System.Xml.Linq;


namespace ConsoleAppProject.App04
{
    ///<summary>
    /// This class stores information about a post in a social network. 
    /// The main part of the post consists of a photo and a caption. 
    /// Other data, such as author and time, are also stored.
    ///</summary>
    /// <author>
    /// Michael Kölling and David J. Barnes
    /// @version 0.1
    /// </author>
    public class PhotoPost : Post
    {

        // the name of the image file
        public String Filename { get; set; }
        
        // a one line image caption
        public String Caption { get; set; }

        ///<summary>
        /// Constructor for objects of class PhotoPost.
        ///</summary>
        /// <param name="author">
        /// The username of the author of this post.
        /// </param>
        /// <param name="caption">
        /// A caption for the image.
        /// </param>
        /// <param name="filename">
        /// The filename of the image in this post.
        /// </param>
        public PhotoPost(String author, String filename, String caption)
        {
            Username = author;
            this.Filename = filename;
            this.Caption = caption;
            Timestamp = DateTime.Now;

            likes = 0;
            comments = new List<String>();
        }

        ///<summary>
        /// Display the details of this post.
        /// 
        /// (Currently: Print to the text terminal. This is simulating display 
        /// in a web browser for now.)
        ///</summary>
        public override void Display()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine($"    Filename: [{Filename}]");
            Console.WriteLine($"    Caption: {Caption}");
            Console.WriteLine();
            Console.WriteLine($"    PostID:         {PostId}");
            Console.WriteLine($"    Author:         {Username}");
            Console.WriteLine($"    Time Elpased:   {FormatElapsedTime(Timestamp)}");
            Console.WriteLine();

            if (likes > 0)
            {
                Console.WriteLine($"    Likes: -  {likes}  people like this.");
            }
            else
            {
                Console.WriteLine();
            }

            if (comments.Count == 0)
            {
                Console.WriteLine("    No comments.");
            }
            else
            {
                Console.WriteLine("    Comments:");
                foreach (string comment in comments)
                {
                    Console.WriteLine($"    {comment}  ");
                }
            }
        }
    }
}
