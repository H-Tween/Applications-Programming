using ConsoleAppProject.Helpers;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleAppProject.App04Attempt1
{
    ///<summary>
    /// The Post class stores news posts for the news feed in a social network 
    /// application.
    /// 
    /// Display of the posts is currently simulated by printing the details to the
    /// terminal. (Later, this should display in a browser.)
    /// 
    /// This version does not save the data to disk, and it does not provide any
    /// search or ordering functions.
    ///</summary>
    ///<author>
    ///  Michael Kölling and David J. Barnes
    ///  version 0.1
    ///</author> 
    public class Post
    {
        public readonly List<MessagePost> messages;
        public readonly List<PhotoPost> photos;

        // Fields
        public int likes;
        public List<String> comments;

        // Properties
        public DateTime Timestamp { get; set; }
        public String Username { get; set; }

        ///<summary>
        /// Construct an empty news feed.
        ///</summary>
        public Post()
        {
            messages = new List<MessagePost>();
            photos = new List<PhotoPost>();
        }

        ///<summary>
        /// Add a comment to this post.
        /// </summary>
        /// <param name="text">
        /// The new comment to add.
        /// </param>        
        public void AddComment(String text)
        {
            comments.Add(text);
        }

        /// <summary>
        /// Record one more 'Like' indication from a user.
        /// </summary>
        public void Like()
        {
            likes++;
        }

        ///<summary>
        /// Record that a user has withdrawn his/her 'Like' vote.
        ///</summary>
        public void Unlike()
        {
            if (likes > 0)
            {
                likes--;
            }
        }

        public string InputName()
        {
            Console.Write("Enter your name > ");
            string name = Console.ReadLine();
            return name;
        }



        ///<summary>
        /// Add a text post to the news feed.
        /// 
        /// @param text  The text post to be added.
        ///</summary>
        public void PostMessage()
        {
            string author = InputName();

            Console.Write("Please enter your text > ");
            string text = Console.ReadLine();

            MessagePost message = new MessagePost(author, text);

            messages.Add(message);
        }

        ///<summary>
        /// Add a photo post to the news feed.
        /// 
        /// @param photo  The photo post to be added.
        ///</summary>
        public void PostImage()
        {
            string author = InputName();

            Console.Write("Please enter your image filename > ");
            string filename = Console.ReadLine();

            Console.Write("Please enter your image caption > ");
            string caption = Console.ReadLine();

            PhotoPost post = new PhotoPost(author, filename, caption);

            photos.Add(post);
        }

        ///<summary>
        /// Show the news feed. Currently: print the news feed details to the
        /// terminal. (To do: replace this later with display in web browser.)
        ///</summary>
        public virtual void Display()
        {
            // display all text posts
            foreach (MessagePost message in messages)
            {
                message.Display();
                Console.WriteLine();   // empty line between posts
            }

            // display all photos
            foreach (PhotoPost photo in photos)
            {
                photo.Display();
                Console.WriteLine();   // empty line between posts
            }
        }

        public void DisplayMenu()
        {
            bool quit = false;

            string[] choices = new string[] { "Add Message", "Add Photo", "Display All", "Quit" };

            do
            {
                int choice = ConsoleHelper.SelectChoice(choices);

                switch (choice)
                {
                    case 1: PostMessage(); break;
                    case 2: PostImage(); break;
                    case 3: Display(); break;
                    case 4: quit = true; break;
                }
            } while (!quit);



        }
        /// <summary>
        /// Create a string describing a time point in the past in terms 
        /// relative to current time, such as "30 seconds ago" or "7 minutes ago".
        /// Currently, only seconds and minutes are used for the string.
        /// </summary>
        /// <param name="time">
        /// The time value to convert (in system milliseconds)
        /// </param> 
        /// <returns>
        /// A relative time string for the given time
        /// </returns> 
        public String FormatElapsedTime(DateTime time)
        {
            DateTime current = DateTime.Now;
            TimeSpan timePast = current - time;

            long seconds = (long)timePast.TotalSeconds;
            long minutes = seconds / 60;

            if (minutes > 0)
            {
                return minutes + " minutes ago";
            }
            else
            {
                return seconds + " seconds ago";
            }
        }
    }

}
