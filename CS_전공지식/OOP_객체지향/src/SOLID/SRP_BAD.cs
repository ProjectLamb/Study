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

    public String printJson() { return json_encode(getData()); }

    public String printString()
    {
        return $"{this.title} {this.date.setFormat("Y-m-d H:i:s")} {this.author.fullName()} {this.content}";
    }
}

//여기서 주요 문제는 
//필요한 경우 다양한 형식, json, html 등으로 인쇄를 담당한다는 것입니다. 
//그럼 이것이 어떻게 개선될 수 있는지 봅시다.