namespace Gltf2Fbx
{
    public partial class VmdlTemplate
    {
        public string FilePath { get; set; }
        
        public VmdlTemplate(string filePath)
        {
            this.FilePath = filePath;
        }
    }
}