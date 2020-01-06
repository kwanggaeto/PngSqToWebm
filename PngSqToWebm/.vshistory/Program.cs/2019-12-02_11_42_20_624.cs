using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PngSqToWebm
{
    public class Program
02
{
03
    [STAThreadAttribute]
04
    public static void Main()
05
    {
06
        AppDomain.CurrentDomain.AssemblyResolve += OnResolveAssembly;
07
        App.Main();
08
    }
09
 
10
    private static Assembly OnResolveAssembly(object sender, ResolveEventArgs args)
11
    {
12
        Assembly executingAssembly = Assembly.GetExecutingAssembly();
13
        AssemblyName assemblyName = new AssemblyName(args.Name);
14
 
15
        string path = assemblyName.Name + ".dll";
16
        if (assemblyName.CultureInfo.Equals(CultureInfo.InvariantCulture) == false)
17
        {
18
            path = String.Format(@"{0}\{1}", assemblyName.CultureInfo, path);
19
        }
20
 
21
        using (Stream stream = executingAssembly.GetManifestResourceStream(path))
22
        {
23
            if (stream == null)
24
                return null;
25
 
26
            byte[] assemblyRawBytes = new byte[stream.Length];
27
            stream.Read(assemblyRawBytes, 0, assemblyRawBytes.Length);
28
            return Assembly.Load(assemblyRawBytes);
29
        }
30
    }
31
}

}
