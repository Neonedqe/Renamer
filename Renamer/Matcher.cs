using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Renamer
{
    internal class Matcher
    {
        static string Version = "V1.0";

        public static void matcher(List<string> files, string oldName, string newFileName)
        {

            string arg1 = oldName;
            string arg2 = newFileName;

            bool changeOnAll = ((arg1.Contains("*") && arg2.Contains("*")) && ((arg1.IndexOf("*") == 0 && arg2.IndexOf("*") == 0) || (arg1.IndexOf("*") == arg1.Length - 1 && arg2.IndexOf("*") == arg2.Length - 1)));
            //wenn beide argumente *davor oder danach enthalten suffix/präfix bei allen dateien ändern/löschen
            if (changeOnAll)
            {

                //wenn arg2 nur * also "leer" ist suffix/präfix wird bei allen gelöscht
                if (arg2.Length == 1)
                {
                    //suffix löschen wenn * am anfang
                    if (arg1.IndexOf("*") == 0)
                    {

                        foreach (string file in files)
                        {
                            string name = file.Substring(file.LastIndexOf("\\") + 1);
                            string path = file.Substring(0, file.LastIndexOf("\\") + 1);
                            string oldSuffix = arg1.Substring(1);
                            string newName = "";

                            if (name.Contains(oldSuffix))
                            {

                                string[] removedSuffix = name.Split(oldSuffix, StringSplitOptions.RemoveEmptyEntries);
                                newName = removedSuffix[0];

                                try
                                {
                                    string destFile = Path.Combine(path, newName);
                                    File.Move(file, destFile);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex);
                                    Console.WriteLine("Something went wrong!");
                                }
                            }


                        }
                    }
                    else
                    {
                        //präfix löschen
                        foreach (string file in files)
                        {
                            string name = file.Substring(file.LastIndexOf("\\") + 1);
                            string path = file.Substring(0, file.LastIndexOf("\\") + 1);
                            string oldPräfix = arg1.Substring(0, arg1.LastIndexOf("*"));
                            string newName = "";

                            if (name.Contains(oldPräfix))
                            {
                                string[] removedPräfix = name.Split(oldPräfix, StringSplitOptions.RemoveEmptyEntries);
                                foreach (string str in removedPräfix)
                                    newName += str;

                                try
                                {
                                    string destFile = Path.Combine(path, newName);
                                    File.Move(file, destFile);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex);
                                    Console.WriteLine("Something went wrong!");
                                }
                            }
                        }
                    }


                }
                else
                {
                    //suffix bei allen dateien ändern
                    if (arg1.IndexOf("*") == 0)
                    {

                        foreach (string file in files)
                        {
                            string name = file.Substring(file.LastIndexOf("\\") + 1);
                            string path = file.Substring(0, file.LastIndexOf("\\") + 1);
                            string oldSuffix = arg1.Substring(1);
                            string newSuffix = arg2.Substring(1);
                            string newName = "";

                            if (name.Contains(oldSuffix))
                            {
                                string[] removedSuffix = name.Split(oldSuffix, StringSplitOptions.RemoveEmptyEntries);
                                newName = removedSuffix[0] + newSuffix;

                                try
                                {
                                    string destFile = Path.Combine(path, newName);
                                    File.Move(file, destFile);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex);
                                    Console.WriteLine("Something went wrong!");
                                }
                            }


                        }
                    }
                    else
                    {
                        //präfix bei allen dateien ändern
                        foreach (string file in files)
                        {
                            string name = file.Substring(file.LastIndexOf("\\") + 1);
                            string path = file.Substring(0, file.LastIndexOf("\\") + 1);
                            string oldPräfix = arg1.Substring(0, arg1.LastIndexOf("*"));
                            string newPräfix = arg2.Substring(0, arg2.LastIndexOf("*"));
                            string newName = "";

                            if (name.Contains(oldPräfix))
                            {
                                string[] removedPräfix = name.Split(oldPräfix);
                                foreach(string str in removedPräfix)
                                {
                                    if(str == "" || str == " ")
                                    {
                                        newName += newPräfix;
                                    }else
                                    {
                                        newName += str;
                                    }
                                }
                                newName = newPräfix + removedPräfix[removedPräfix.Length - 1];

                                try
                                {
                                    string destFile = Path.Combine(path, newName);
                                    File.Move(file, destFile);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex);
                                    Console.WriteLine("Something went wrong!");
                                }
                            }
                        }
                    }

                }

            }
            else
            {
                //nur Dateiname von eins durch 2 überschreiben
                if (File.Exists(Path.Combine(Directory.GetCurrentDirectory(), arg1)))
                {
                    try
                    {
                        string sourceFile = Path.Combine(Directory.GetCurrentDirectory(), arg1);
                        string destFile = Path.Combine(Directory.GetCurrentDirectory(), arg2);
                        File.Move(arg1, arg2);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        Console.WriteLine("Something went wrong!");
                    }

                }
                else
                {
                    Console.WriteLine("File does not exist!");
                }

            }

        }
    }
}
