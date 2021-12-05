using GameHero.Model.Data;
using System;
using System.Collections.Generic;
using System.IO;

namespace GameHero.Model.IO.Implementation
{
    public class SaveLoadLogin : ISaveLoadLogin
    {
        private const string FILE_NAME = @"D:\itstep\oop\OOP-task-15-Game-hero\save\LoginSave.data";
        public IList<Login> Read()
        {
            TextReader stream = null;
            IList<Login> logins = new List<Login>();

            try
            {
                stream = new StreamReader(new BufferedStream(new FileStream(FILE_NAME, FileMode.OpenOrCreate)));

                while (stream.Peek() != -1)
                {
                    logins.Add(new Login(stream.ReadLine()));
                }
            }
            catch (IOException exc)
            {
                Console.WriteLine(exc);
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }

            return logins;
        }

        public void Write(IList<Login> logins)
        {
            TextWriter stream = null;

            try
            {
                stream = new StreamWriter(new BufferedStream(new FileStream(FILE_NAME, FileMode.Create)));

                foreach (Login item in logins)
                {
                    stream.WriteLine(item.UserLogin);
                }
            }
            catch (IOException exc)
            {
                Console.WriteLine(exc);
            }
            finally
            {
                if (stream != null)
                {
                    stream.Flush();
                    stream.Close();
                }
            }
        }
    }
}
