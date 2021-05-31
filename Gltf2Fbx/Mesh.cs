using System;
using System.IO;
using Assimp;
using Assimp.Configs;

namespace Gltf2Fbx
{
    public class Mesh
    {
        /// <summary>
        /// Loads a gltf mesh, exports it as fbx, creates a vmdl for it
        /// </summary>
        /// <param name="path">Path to the gltf mesh</param>
        public static void LoadAndExport( string path )
        {
            Console.WriteLine( $"Exporting file {path}" );
            
            var context = new AssimpContext();

            // Uncomment this if you don't mind everything running 20x slower
            #if false
            var logStream = new LogStream((msg, userData) =>
            {
                Console.WriteLine($"{msg}");
            });
            logStream.Attach();
            #endif

            var extension = Path.GetExtension( path ).Substring(1);
            var fileData = File.ReadAllBytes( path );
            using var memoryStream = new MemoryStream( fileData );
            memoryStream.Seek(0, SeekOrigin.Begin);

            context.SetConfig( new GlobalScaleConfig( 10f ) );
            
            var scene = context.ImportFile(path,
                PostProcessSteps.Triangulate
                | PostProcessSteps.PreTransformVertices
                | PostProcessSteps.RemoveRedundantMaterials
                | PostProcessSteps.CalculateTangentSpace
                | PostProcessSteps.OptimizeMeshes
                | PostProcessSteps.ValidateDataStructure
                | PostProcessSteps.GenerateNormals
                | PostProcessSteps.FlipUVs
                | PostProcessSteps.GlobalScale);
            
            context.SetConfig( new GlobalScaleConfig( 10f ) );

            var fbxPath = path.Replace( "gltf", "fbx" );
            var vmdlPath = path.Replace( "gltf", "vmdl" );
            
            if ( context.ExportFile( scene, fbxPath, "fbx", PostProcessSteps.GlobalScale ) )
            {
                Console.WriteLine( "\tOK" );
            }
            else
            {
                Console.WriteLine( $"Failed to export {path}" );
            }
            
            // Save vmdl
            var vmdlTemplate = new VmdlTemplate( Path.Join( "models", fbxPath ).Replace( "\\", "/" ) );
            File.WriteAllText( vmdlPath, vmdlTemplate.TransformText() );
            
            // Delete gltf / .bin
            var binPath = path.Replace( "gltf", "bin" );
            File.Delete( path );
            
            // Check if bin exists first
            if ( File.Exists( binPath ) )
                File.Delete( binPath );
        }
    }
}