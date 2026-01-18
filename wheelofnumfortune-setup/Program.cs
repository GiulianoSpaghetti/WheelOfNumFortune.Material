using System;
using WixSharp;

namespace wheelofnumfortune_setup
{
    internal class Program
    {
        static void Main()
        {
            {
                Project project = new Project("wheelofnumfortune.avalonia",
                                  new Dir(@"[ProgramFiles64Folder]\\wheelofnumfortune.avalonia",
                                      new DirFiles(@"*.*"),
                                      new Dir("runtimes",
                                          new Dir("win-x64",
                                                new Dir("native",
                                                    new File("runtimes\\win-x64\\native\\av_libglesv2.dll"),
                                                    new File("runtimes\\win-x64\\native\\libHarfBuzzSharp.dll"),
                                                    new File("runtimes\\win-x64\\native\\libSkiaSharp.dll")
                                                )
                                            )
                                     )
                            ),
                            new Dir(@"%ProgramMenu%",
                             new ExeFileShortcut("Wheel of numerone's fortune", "[ProgramFiles64Folder]\\wheelofnumfortune.avalonia\\wheelofnumfortune.Desktop.exe", "") { WorkingDirectory = "[INSTALLDIR]" }
                          )//,
                           //new Property("ALLUSERS","0")
                );

                project.GUID = new Guid("0ED16B86-0A70-E994-3BBF-1F853749E14B");
                project.Version = new Version("0.4.1.4");
                project.Platform = Platform.x64;
                project.SourceBaseDir = "E:\\wheelofnumfortune.material\\wheelofnumfortune.Desktop\\bin\\Release\\net10.0-windows10.0.26100.0";
                project.LicenceFile = "LICENSE.rtf";
                project.OutDir = "C:\\Users\\numer\\Downloads";
                project.ControlPanelInfo.Manufacturer = "Giulio Sorrentino";
                project.ControlPanelInfo.Name = "WheelOfNumFortune.Material";
                project.ControlPanelInfo.HelpLink = "https://www.opencode.net/numerone/WheelOfNumFortune-Material/-/issues";
                project.Description = "Programma di enigmistica che consiste nello scoprire una frase caricata da internet scoprendo manualmente una lettera per volta nel dialetto material di google di avalonia";
                //            project.Properties.SetValue("ALLUSERS", 0);
                project.BuildMsi();
            }
        }
    }
}
