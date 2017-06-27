using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GymApp.Model
{
    //public class News
    //{
    //    public string id { get; set; }
    //    public string type { get; set; }
    //    public string sectionId { get; set; }
    //    public string sectionName { get; set; }
    //    public string webPublicationDate { get; set; }
    //    public string webTitle { get; set; }
    //    public string webUrl { get; set; }
    //    public string apiUrl { get; set; }
    //    public Fields fields { get; set; }
    //    public bool isHosted { get; set; }
    //}

    //public class Fields
    //{
    //    public string headline { get; set; }
    //    public string standfirst { get; set; }
    //    public string trailText { get; set; }
    //    public string byline { get; set; }
    //    public string main { get; set; }
    //    public string body { get; set; }
    //    public string wordcount { get; set; }
    //    public string commentCloseDate { get; set; }
    //    public string commentable { get; set; }
    //    public string firstPublicationDate { get; set; }
    //    public string isInappropriateForSponsorship { get; set; }
    //    public string isPremoderated { get; set; }
    //    public string lastModified { get; set; }
    //    public string productionOffice { get; set; }
    //    public string publication { get; set; }
    //    public string shortUrl { get; set; }
    //    public string shouldHideAdverts { get; set; }
    //    public string showInRelatedContent { get; set; }
    //    public string thumbnail { get; set; }
    //    public string legallySensitive { get; set; }
    //    public string lang { get; set; }
    //    public string bodyText { get; set; }
    //    public string charCount { get; set; }
    //    public string newspaperPageNumber { get; set; }
    //    public string newspaperEditionDate { get; set; }
    //    public string sensitive { get; set; }
    //}

    //public class Response
    //{
    //    public string status { get; set; }
    //    public string userTier { get; set; }
    //    public int total { get; set; }
    //    public int startIndex { get; set; }
    //    public int pageSize { get; set; }
    //    public int currentPage { get; set; }
    //    public int pages { get; set; }
    //    public string orderBy { get; set; }
    //    public List<News> results { get; set; }
    //}

    //public class RootObject
    //{
    //    public Response response { get; set; }
    //}


    public class Fields
    {
        public string headline { get; set; }
        public string standfirst { get; set; }
        public string trailText { get; set; }
        public string byline { get; set; }
        public string main { get; set; }
        public string body { get; set; }
        public string wordcount { get; set; }
        public string commentCloseDate { get; set; }
        public string commentable { get; set; }
        public string firstPublicationDate { get; set; }
        public string isInappropriateForSponsorship { get; set; }
        public string isPremoderated { get; set; }
        public string lastModified { get; set; }
        public string productionOffice { get; set; }
        public string publication { get; set; }
        public string shortUrl { get; set; }
        public string shouldHideAdverts { get; set; }
        public string showInRelatedContent { get; set; }
        public string thumbnail { get; set; }
        public string legallySensitive { get; set; }
        public string lang { get; set; }
        public string bodyText { get; set; }
        public string charCount { get; set; }
    }

    public class News
    {
        public string id { get; set; }
        public string type { get; set; }
        public string sectionId { get; set; }
        public string sectionName { get; set; }
        public string webPublicationDate { get; set; }
        public string webTitle { get; set; }
        public string webUrl { get; set; }
        public string apiUrl { get; set; }
        public Fields fields { get; set; }
        public bool isHosted { get; set; }
    }

    public class Response
    {
        public string status { get; set; }
        public string userTier { get; set; }
        public int total { get; set; }
        public Fields fields { get; set; }
        public List<News> results { get; set; }
    }

    public class RootObject
    {
        public Response response { get; set; }
    }
}


