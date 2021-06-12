using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern_Repository
{
    public class StreamingContentRepository
    {
        //CRUD goes here
        private readonly List<StreamingContent> _contentDirectory = new List<StreamingContent>();

        //create 
        public void AddContentToDirectory(StreamingContent content)
        {
            _contentDirectory.Add(content);


        }

        //READ
        //get all of our Streaming Content objects from our directory 

        public List<StreamingContent> GetAllStreamingContent()
        {
            return _contentDirectory;
        }

        //get streaming content by title.

        public StreamingContent GetContentByTitle(string title)
        {
            foreach (StreamingContent item in _contentDirectory)
            {
                if (item.Title == title)
                {
                    return item;
                }
            }

            return null;
        }
        //UPDATE

        public void UpdateStreamingContentDescription(string title, string description)
        {
            StreamingContent content = GetContentByTitle(title);

            content.Description = description;
           
        }

        //DELETE

       // public bool DeleteExistingContent()
        public bool DeleteContentByTitle(string title)
        {
            StreamingContent content = GetContentByTitle(title);
            
            if (content == null)
            {
                return false;
            }

            int sizeOfListBefore = _contentDirectory.Count;
            _contentDirectory.Remove(content);

            if (sizeOfListBefore > _contentDirectory.Count)
            {
                return true;
            }
            else
            {
                return false;
            }

        }



    }
}
