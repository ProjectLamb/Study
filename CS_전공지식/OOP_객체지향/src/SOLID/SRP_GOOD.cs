class BlogPost
{
    private Author author;
    private string title;
    private string content;
    private DateTime date;
    // ..
    public Dictionary getData()
    {
        Dictionary<string, string> ret = new Dictionary<string, string>();
        ret.Add("author", this.author.fullName());
        ret.Add("title", this.title);
        ret.Add("content", this.content);
        ret.Add("timestamp", this.date.getTimestamp());
        return ret;
    }
}

//BlogPost 클래스에서 인쇄 방법을 제거
interface IPrintableBlogPost
{
    public string print(BlogPost _blogPost);
}

class JsonBlogPostPrinter : IPrintableBlogPost
{
    public string print(BlogPost _blogPost)
    {
        return json_encode(_blogPost.getData());
    }
}

class HtmlBlogPostPrinter : IPrintableBlogPost
{
    public string print(BlogPost _blogPost)
    {
        return $"{_blogPost.getData().title}" +
            $"{_blogPost.getData().date.setFormat("Y-m-d H:i:s")}" +
            $"{_blogPost.getData().author.fullName()}" +
            $"{_blogPost.getData().content}";
    }
}