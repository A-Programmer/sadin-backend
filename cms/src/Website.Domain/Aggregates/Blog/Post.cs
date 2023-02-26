using System.Runtime.Serialization;
using KSFramework.Primitives;
using Website.Domain.Aggregates.Blog.ValueObjects;

namespace Website.Domain.Aggregates.Blog;

[Serializable]
public sealed class Post : AggregateRootWithSoftDelete, ISerializable
{

    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue(nameof(Id), Id);
        info.AddValue(nameof(Title), Title);
        info.AddValue(nameof(SeoTitle), SeoTitle);
        info.AddValue(nameof(Description), Description);
        info.AddValue(nameof(SeoDescription), SeoDescription);
        info.AddValue(nameof(Content), Content);
        info.AddValue(nameof(ImageUrl), ImageUrl);
        info.AddValue(nameof(Status), Status);
        info.AddValue(nameof(Slug), Slug);
        info.AddValue(nameof(UserId), UserId);
        info.AddValue(nameof(Categories), Categories);
        info.AddValue(nameof(Keywords), Keywords);
        info.AddValue(nameof(Comments), Comments);
        info.AddValue(nameof(Views), Views);
    }
    public PostTitle Title { get; private set; }
    public PostSeoTitle SeoTitle { get; private set; }
    public PostDescription Description { get; private set; }
    public PostSeoDescription SeoDescription { get; private set; }
    public PostContent Content { get; private set; }
    public PostImageUrl ImageUrl { get; private set; }
    public bool Status { get; private set; }
    public PostSlug Slug { get; private set; }

    public Guid UserId { get; private set; }
    // TODO : add user property

    public IReadOnlyCollection<PostsCategories> Categories => _categories;
    private List<PostsCategories> _categories = new();

    public IReadOnlyCollection<PostsKeywords> Keywords => _keywords;
    private List<PostsKeywords> _keywords = new();

    public IReadOnlyCollection<Comment> Comments => _comments;
    private List<Comment> _comments = new();

    public IReadOnlyCollection<View> Views => _views;
    private List<View> _views = new();
    public long AllViewsCount
    {
        get
        {
            return _views.Count;
        }
    }
    public long UniqueViewsCount
    {
        get
        {
            return _views.Distinct().Count();
        }
    }


    public Post(Guid id, PostTitle title, PostSeoTitle seoTitle, PostDescription description,
                PostSeoDescription seoDescription, PostContent content, PostImageUrl imageUrl,
                bool status)
        : base(id)
    {
        Title = title ?? throw  new KSArgumentNullException($"{nameof(title)}");
        Description = description ?? throw  new KSArgumentNullException($"{nameof(description)}");
        Content = content ?? throw  new KSArgumentNullException($"{nameof(content)}");
        ImageUrl = imageUrl ?? throw  new KSArgumentNullException($"{nameof(imageUrl)}");
        Status = status;
        Slug = PostSlug.Create(title.Value);
        SeoTitle = !string.IsNullOrEmpty(seoTitle.Value) ? seoTitle : PostSeoTitle.Create(title.Value);
        SeoDescription = !string.IsNullOrEmpty(seoDescription.Value) ? seoDescription : PostSeoDescription.Create(description.Value);
    }

    public static Post Create(PostTitle title, PostSeoTitle seoTitle, PostDescription description,
                            PostSeoDescription seoDescription, PostContent content, PostImageUrl imageUrl,
                            bool status) => new(Guid.NewGuid(), title, seoTitle, description, seoDescription, content, imageUrl, status);

    public void Update(PostTitle title, PostSeoTitle seoTitle, PostDescription description,
                        PostSeoDescription seoDescription, PostContent content, PostImageUrl imageUrl,
                        bool status)
    {
        Title = title ?? throw  new KSArgumentNullException($"{nameof(title)}");
        Description = description ?? throw  new KSArgumentNullException($"{nameof(description)}");
        Content = content ?? throw  new KSArgumentNullException($"{nameof(content)}");
        ImageUrl = imageUrl ?? throw  new KSArgumentNullException($"{nameof(imageUrl)}");
        Status = status;
        SeoTitle = !string.IsNullOrEmpty(seoTitle.Value) ? seoTitle : PostSeoTitle.Create(title.Value);
        SeoDescription = !string.IsNullOrEmpty(seoDescription.Value) ? seoDescription : PostSeoDescription.Create(description.Value);
    }
    
    public void SetCategories(Guid[] categoriesIds)
    {
        _categories.Clear();

        foreach (var categoryId in categoriesIds)
            _categories.Add(new PostsCategories(this.Id, categoryId));
    }

    public void SetKeywords(Guid[] keywordsIds)
    {
        _keywords.Clear();
        foreach (var keywordId in keywordsIds)
            _keywords.Add(new PostsKeywords(this.Id, keywordId));
    }


    public void UpdateSlug(PostSlug slug) => Slug = slug;

    public void Publish() => Status = true;
    
    public void Draft() => Status = false;

    public void SetUserId(Guid userId) => UserId = userId;

    public void AddComment(Comment comment) => _comments.Add(comment);

    public void RemoveComment(Comment comment) => _comments.Remove(comment);

    public void AddView(View view) => _views.Add(view);
    
    protected Post(Guid id)
        : base(id)
    {
    }
}