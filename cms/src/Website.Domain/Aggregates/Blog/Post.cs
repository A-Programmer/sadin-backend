using System.Runtime.Serialization;
using KSFramework.Primitives;
using Website.Domain.Aggregates.Blog.ValueObjects;

namespace Website.Domain.Aggregates.Blog;

[Serializable]
public sealed class Post : AggregateRootWithSoftDelete, ISerializable
{
    public PostTitle Title { get; private set; }
    public PostSeoTitle SeoTitle { get; private set; }
    public PostDescription Description { get; private set; }
    public PostSeoDescription SeoDescription { get; private set; }
    public PostContent Content { get; private set; }
    public PostImageUrl ImageUrl { get; private set; }
    public PostSlug Slug { get; private set; }

    public bool IsPublished { get; private set; }

    public DateTimeOffset CreatedAt { get; private set; }
    public DateTimeOffset? UpdatedAt { get; private set; }

    public Guid UserId { get; private set; }
    // TODO : add user property

    public IReadOnlyCollection<Category> Categories => _categories;
    private List<Category> _categories = new();

    public IReadOnlyCollection<Keyword> Keywords => _keywords;
    private List<Keyword> _keywords = new();

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
                bool isPublished)
        : base(id)
    {
        Title = title ?? throw  new KSArgumentNullException($"{nameof(title)}");
        Description = description ?? throw  new KSArgumentNullException($"{nameof(description)}");
        Content = content ?? throw  new KSArgumentNullException($"{nameof(content)}");
        ImageUrl = imageUrl ?? throw  new KSArgumentNullException($"{nameof(imageUrl)}");
        IsPublished = isPublished;
        Slug = PostSlug.Create(title.Value);
        SeoTitle = !string.IsNullOrEmpty(seoTitle.Value) ? seoTitle : PostSeoTitle.Create(title.Value);
        SeoDescription = !string.IsNullOrEmpty(seoDescription.Value) ? seoDescription : PostSeoDescription.Create(description.Value);
        CreatedAt = DateTimeOffset.Now;
    }

    public static Post Create(PostTitle title, PostSeoTitle seoTitle, PostDescription description,
                            PostSeoDescription seoDescription, PostContent content, PostImageUrl imageUrl,
                            bool status) => new(Guid.NewGuid(), title, seoTitle, description, seoDescription, content, imageUrl, status);

    public void Update(PostTitle title, PostSeoTitle seoTitle, PostDescription description,
                        PostSeoDescription seoDescription, PostContent content, PostImageUrl imageUrl,
                        bool isPublished)
    {
        Title = title ?? throw  new KSArgumentNullException($"{nameof(title)}");
        Description = description ?? throw  new KSArgumentNullException($"{nameof(description)}");
        Content = content ?? throw  new KSArgumentNullException($"{nameof(content)}");
        ImageUrl = imageUrl ?? throw  new KSArgumentNullException($"{nameof(imageUrl)}");
        IsPublished = isPublished;
        SeoTitle = !string.IsNullOrEmpty(seoTitle.Value) ? seoTitle : PostSeoTitle.Create(title.Value);
        SeoDescription = !string.IsNullOrEmpty(seoDescription.Value) ? seoDescription : PostSeoDescription.Create(description.Value);
        SetUpdateDate();
    }
    
    public Post AddCategory(Category category)
    {
        _categories.Add(category);
        return this;
    }

    public Post SetKeywords(Keyword keyword)
    {
        _keywords.Add(keyword);
        return this;
    }

    public Post SetUpdateDate()
    {
        UpdatedAt = DateTimeOffset.Now;
        return this;
    }

    public Post UpdateSlug(PostSlug slug)
    {
        Slug = slug;
        return SetUpdateDate();
    }

    public Post Publish()
    {
        IsPublished = true;
        return SetUpdateDate();
    }

    public Post Draft()
    {
        IsPublished = false;
        return SetUpdateDate();
    }

    public Post SetUserId(Guid userId)
    {
        UserId = userId;
        return this;
    }

    public void AddComment(Comment comment) => _comments.Add(comment);

    public void RemoveComment(Comment comment) => _comments.Remove(comment);

    public void AddView(View view) => _views.Add(view);
    
    protected Post(Guid id)
        : base(id)
    {
    }
    
    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue(nameof(Id), Id);
        info.AddValue(nameof(Title), Title);
        info.AddValue(nameof(SeoTitle), SeoTitle);
        info.AddValue(nameof(Description), Description);
        info.AddValue(nameof(SeoDescription), SeoDescription);
        info.AddValue(nameof(Content), Content);
        info.AddValue(nameof(ImageUrl), ImageUrl);
        info.AddValue(nameof(IsPublished), IsPublished);
        info.AddValue(nameof(Slug), Slug);
        info.AddValue(nameof(CreatedAt), CreatedAt);
        info.AddValue(nameof(UpdatedAt), UpdatedAt);
        info.AddValue(nameof(UserId), UserId);
        info.AddValue(nameof(Categories), Categories);
        info.AddValue(nameof(Keywords), Keywords);
        info.AddValue(nameof(Comments), Comments);
        info.AddValue(nameof(Views), Views);
    }
}