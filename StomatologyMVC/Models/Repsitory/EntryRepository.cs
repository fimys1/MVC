using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace StomatologyMVC.Models
{
    public class EntryRepository : IDisposable
    {
        ApplicationDbContext appContext = null;
        public EntryRepository()
        {
            appContext = new ApplicationDbContext();
        }

        public void Create(Entry item)
        {
            appContext.Entries.Add(item);
        }

        public void Assept(int id)
        {
            Entry entr = appContext.Entries.Find(id);
            if (entr != null)
            {
                entr.State = EnumsState.Accepted;
                appContext.Entry(entr).State = EntityState.Modified;
            }            
        }

        public void Change(int id, DateTime date)
        {
            Entry entr = appContext.Entries.Find(id);
            if (entr != null)
            {
                entr.DateTime = date;
                appContext.Entry(entr).State = EntityState.Modified;
            }            
        }

        public void Denied(int id, string couse)
        {
            Entry entr = appContext.Entries.Find(id);
            if (entr != null)
            {
                entr.Couse = couse;
                entr.State = EnumsState.Denied;
                appContext.Entry(entr).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            Entry entr = appContext.Entries.Find(id);
            if (entr != null)
                appContext.Entries.Remove(entr);
        }

        public Entry GetItem(int id)
        {
            return appContext.Entries.Find(id);
        }

        public IEnumerable<Entry> GetItemsList()
        {
            return appContext.Entries;
        }

        public void Save()
        {
            appContext.SaveChanges();
        }

        public void Update(Entry item)
        {
            Entry temp = appContext.Entries.Find(item.Id);
            if (temp != null)
            {
                temp.UserId = item.UserId;
                temp.State = item.State;
                temp.Couse = item.Couse;
                temp.DateTime = item.DateTime;
                temp.Cabinet = item.Cabinet;
                temp.Complaint = item.Complaint;
                appContext.Entry(temp).State = System.Data.Entity.EntityState.Modified;
            }
        }

        public void Dispose()
        {
            appContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}