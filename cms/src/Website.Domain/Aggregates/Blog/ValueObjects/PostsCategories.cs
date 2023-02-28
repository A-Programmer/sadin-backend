// using System.Runtime.Serialization;
// using KSFramework.Primitives;
//
// namespace Website.Domain.Aggregates.Blog.ValueObjects;
//
// [Serializable]
// public class PostsCategories : ValueObject, ISerializable
// {
//     public PostsCategories(Guid postId, Guid categoryId)
//     {
//         PostId = postId;
//         CategoryId = categoryId;
//     }
//
//     protected PostsCategories()
//     {
//     }
//
//     public Guid PostId { get; private set; }
//     public Post Post { get; protected set; }
//
//     public Guid CategoryId { get; private set; }
//     public Category Category { get; protected set; }
//
//
//     public void GetObjectData(SerializationInfo info, StreamingContext context)
//     {
//         info.AddValue(nameof(PostId), PostId);
//         info.AddValue(nameof(Post), Post);
//         info.AddValue(nameof(CategoryId), CategoryId);
//         info.AddValue(nameof(Category), Category);
//     }
//
//     protected override IEnumerable<object> GetEqualityComponents()
//     {
//         yield return PostId;
//         yield return CategoryId;
//     }
// }
