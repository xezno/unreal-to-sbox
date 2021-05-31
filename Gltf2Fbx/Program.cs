using System;
using System.IO;

namespace Gltf2Fbx
{
    public static class Program
    {
        public static void Main( string[] args )
        {
            RecursivelyLoadAndExport( "." );
        }

        /// <summary>
        /// Recursively load and export all meshes in a directory (and its sub-directories)
        /// </summary>
        /// <param name="root">The root folder to start with</param>
        private static void RecursivelyLoadAndExport( string root )
        {
            Console.WriteLine( $"Exporting from {root}" );
            foreach ( var directory in Directory.GetDirectories( root ) )
            {
                RecursivelyLoadAndExport( directory );
            }

            foreach ( var file in Directory.GetFiles( root ) )
            {
                if ( file.EndsWith("gltf") )
                    Mesh.LoadAndExport( file );
            }
        }
    }
}