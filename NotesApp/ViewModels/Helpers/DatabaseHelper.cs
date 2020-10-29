using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NotesApp.ViewModels.Helpers
{
    public class DatabaseHelper
    {
        public static string dbFile = Path.Combine(Environment.CurrentDirectory, "noteDb.db");

      
        public static async Task<bool> Insert<T>(T item)
        {
            
            //bool result = false;
            //using (SQLiteConnection conn = new SQLiteConnection(dbFile))
            //{
            //    conn.CreateTable<T>();
            //    int RowNumber = conn.Insert(item);

            //    result = RowNumber > 0 ? true : false;
            //}
            //return result;

            bool result = false;
            try
            {
                await App.mobileServiceClient.GetTable<T>().InsertAsync(item);

                return result = true;
            }
            catch (Exception ex)
            {
                return result;
            }

        }

        public static async Task<bool> Update<T>(T item)
        {
            //bool result = false;
            //using (SQLiteConnection conn = new SQLiteConnection(dbFile))
            //{
            //    conn.CreateTable<T>();
            //    int RowNumber = conn.Update(item);
            //    result = RowNumber > 0 ? true : false;
            //}
            //return result;

            bool result = false;
            try
            {
                await App.mobileServiceClient.GetTable<T>().UpdateAsync(item);
                return result = true;
            }
            catch (Exception ex)
            {
                return result;
            }
        }

        public static async Task<bool> Delete<T>(T item)
        {
            //bool result = false;
            //using (SQLiteConnection conn = new SQLiteConnection(dbFile))
            //{
            //    conn.CreateTable<T>();
            //    int RowNumber = conn.Delete(item);
            //    result = RowNumber > 0 ? true : false;
            //}
            //return result;

            bool result = false;

            try
            {
                await App.mobileServiceClient.GetTable<T>().DeleteAsync(item);
                return result = true;
            }
            catch(Exception ex)
            {
                return result;
            }
        }
    }
}
