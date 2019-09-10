using UI.Core.Abstractions;

namespace UI.JsonPlaceholder.Pages.Comments
{
    public class CommentsPageElements : PageElements
    {
        private string JsonObjProp(int blockIndex, int propIndex) => $"span.blockInner span.kvov.arrElem:nth-child({blockIndex}) span.objProp:nth-child({propIndex})";

        public string PostId(int blockIndex) => $"{JsonObjProp(blockIndex, 1)}";
        public string Id(int blockIndex) => $"{JsonObjProp(blockIndex, 2)}";
        public string Name(int blockIndex) => $"{JsonObjProp(blockIndex, 3)}";
        public string Email(int blockIndex) => $"{JsonObjProp(blockIndex, 4)}";
        public string Body(int blockIndex) => $"{JsonObjProp(blockIndex, 5)}";
    }
}
