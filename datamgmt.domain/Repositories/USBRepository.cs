using datamgmt.domain.DataModels.Admin;
using datamgmt.domain.DbContexts;
using datamgmt.domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datamgmt.domain.Repositories
{
    public class USBRepository : IUSBRepository, IDisposable
    {
        private DataMgmtDbContext context;
        public USBRepository(DataMgmtDbContext context)
        {
            this.context = context;
        }

        public void DeleteSupplier(int Id)
        {
            USBException supplier = context.USBException.Find(Id);
            context.USBException.Remove(supplier);
        }

        public async Task<IEnumerable<USBException>> FindUSB(string searchFirst, string searchEmail, string searchLast, string search511)
        {
            var count = 0;
            var filteredList = new List<USBException>();
            var list2Temp = new List<USBException>();
            var list3Temp = new List<USBException>();
            var list4Temp = new List<USBException>();
            if (searchFirst != null)
            {
                searchFirst = searchFirst.ToLower();
            }
            if (searchLast != null)
            {
                searchLast = searchLast.ToLower();
            }
            if (searchEmail != null)
            {
                searchEmail = searchEmail.ToLower();
            }
            if (search511 != null)
            {
                search511 = searchEmail.ToLower();
            }
            filteredList = await context.USBException.Where(s =>
                   (s.FirstName.Contains(searchFirst)) || searchFirst == null).ToListAsync();

            if(searchFirst != null)
            {
                count++;
            }
            if(searchLast != null)
            {
                count++;
            }
            if(searchEmail != null)
            {
                count++;
            }
            if(search511 != null)
            {
                count++;
            }



            if (count == 2)
            {
                var list2 = await FindUSBTwoOptions(searchFirst, searchEmail, searchLast, search511);
                list2Temp = (List<USBException>)list2;
            }
            else if (count == 3)
            {
                var list3 = await FindUSBThreeOptions(searchFirst, searchEmail, searchLast, search511);
                list3Temp = (List<USBException>)list3;
            }
            else if (count == 4)
            {
                var list4 = await FindUSBfourOptions(searchFirst, searchEmail, searchLast, search511);
                list4Temp = (List<USBException>)list4;
            }
            else if (count == 1)
            {

             
                    //Else iterate through each paramter checking for if they are null or not
                    if (searchFirst != null)
                    {
                        filteredList = await context.USBException.Where(s =>
                       (s.FirstName.Contains(searchFirst)) || searchFirst == null).ToListAsync();
                    }
                    if (searchEmail != null)
                    {
                        filteredList = await context.USBException.Where(s =>
                        (s.EmailID.Contains(searchEmail)) || searchEmail == null).ToListAsync();
                    }

                    if (searchLast != null)
                    {
                        filteredList = await context.USBException.Where(s =>
                        (s.LastName.Contains(searchLast)) || searchLast == null).ToListAsync();
                    }

                    if (search511 != null)
                    {
                        filteredList = await context.USBException.Where(s =>
                        (s.Abbott511.Contains(search511)) || search511 == null).ToListAsync();
                    }
                

            }


            if (count == 2)
            {
                filteredList = (List<USBException>)list2Temp;
            }
            else if(count == 3)
            {
                filteredList = (List<USBException>)list3Temp;
            }
            else if(count == 4)
            {
                filteredList = (List<USBException>)list4Temp;
            }
            return filteredList;
        }

        public async Task<IEnumerable<USBException>> FindUSBTwoOptions(string searchFirst, string searchEmail, string searchLast, string search511)
        {

            var list = context.USBException.ToList();
            list = list.ConvertAll(m => new USBException
            {
                FirstName = m.FirstName?.ToLower(),
                LastName = m.LastName?.ToLower(),
                Abbott511 = m.Abbott511?.ToLower(),
                UPI = m.UPI,
                EmailID = m.EmailID?.ToLower(),
                Country = m.Country,
                RequestedDate = m.RequestedDate,
                ArcherException = m.ArcherException,
                AddOrRemove = m.AddOrRemove,
                ID = m.ID,
                ItemType = m.ItemType,
                Path = m.Path,
                Organization = m.Organization,
                ReadWrite = m.ReadWrite
            });

            //Else iterate through each paramter checking for if they are null or not
            if (searchFirst != null && searchEmail != null)
            {
                list =  list.Where(s =>
                            (s.FirstName.Contains(searchFirst))).ToList();

                list = list.Where(j =>
                            (j.EmailID.Contains(searchEmail))).ToList();
            }
            if (searchFirst != null && searchLast != null)
            {
                list = list.Where(s =>
                            s.FirstName.Contains(searchFirst)).ToList();


                list = list.Where(j =>
                           (j.LastName.Contains(searchLast))).ToList();

            }
            if (searchFirst != null && search511 != null)
            {
                list = list.Where(s =>
                            (s.FirstName.Contains(searchFirst))).ToList();


                list = list.Where(j =>
                           (j.Abbott511.Contains(search511))).ToList();
            }
            if (searchEmail != null && searchLast != null)
            {
                list = list.Where(s =>
                            (s.EmailID.Contains(searchEmail))).ToList();


                list = list.Where(j =>
                           (j.LastName.Contains(searchLast))).ToList();
            }
            if (searchEmail != null && search511 != null)
            {
                list = list.Where(s =>
                            (s.EmailID.Contains(searchEmail))).ToList();


                list = list.Where(j =>
                           (j.Abbott511.Contains(search511))).ToList();
            }
            if (searchLast != null && search511 != null)
            {
                list = list.Where(s =>
                            (s.LastName.Contains(searchLast))).ToList();


                list = list.Where(j =>
                           (j.Abbott511.Contains(search511))).ToList();
            }


            return list;
        }

        public async Task<IEnumerable<USBException>> FindUSBThreeOptions(string searchFirst, string searchEmail, string searchLast, string search511)
        {

            var list = new List<USBException>();
            list = context.USBException.ToList();
            list = list.ConvertAll(m => new USBException
            {
                FirstName = m.FirstName?.ToLower(),
                LastName = m.LastName?.ToLower(),
                Abbott511 = m.Abbott511?.ToLower(),
                UPI = m.UPI,
                EmailID = m.EmailID?.ToLower(),
                Country = m.Country,
                RequestedDate = m.RequestedDate,
                ArcherException = m.ArcherException,
                AddOrRemove = m.AddOrRemove,
                ID = m.ID,
                ItemType = m.ItemType,
                Path = m.Path,
                Organization = m.Organization,
                ReadWrite = m.ReadWrite
            });

            //Else iterate through each paramter checking for if they are null or not
            if (searchFirst != null && searchEmail != null && searchLast != null)
            {
                list = list.Where(s =>
                            (s.FirstName.Contains(searchFirst))).ToList();

                list = list.Where(j =>
                            (j.EmailID.Contains(searchEmail))).ToList();

                list = list.Where(j =>
                            (j.LastName.Contains(searchLast))).ToList();

            }
            if (searchFirst != null && searchLast != null && search511 != null)
            {
                list = list.Where(s =>
                            (s.FirstName.Contains(searchFirst))).ToList();


                list = list.Where(j =>
                            (j.LastName.Contains(searchLast))).ToList();

                list = list.Where(j =>
                            (j.Abbott511.Contains(search511))).ToList();

            }
            if (searchFirst != null && searchEmail != null && search511 != null)
            {
                list = list.Where(s =>
                            (s.FirstName.Contains(searchFirst))).ToList();


                list = list.Where(j =>
                            (j.EmailID.Contains(searchEmail))).ToList();

                list = list.Where(j =>
                            (j.Abbott511.Contains(search511))).ToList();

            }
            if (searchEmail != null && searchLast != null && search511 != null)
            {
                list = list.Where(s =>
                            (s.LastName.Contains(searchLast))).ToList();


                list = list.Where(j =>
                            (j.EmailID.Contains(searchEmail))).ToList();

                list = list.Where(j =>
                            (j.Abbott511.Contains(search511))).ToList();

            }



            return list;
        }


        public async Task<IEnumerable<USBException>> FindUSBfourOptions(string searchFirst, string searchEmail, string searchLast, string search511)
        {

            var list = new List<USBException>();
            list = context.USBException.ToList();
            list = list.ConvertAll(m => new USBException
            {
                FirstName = m.FirstName?.ToLower(),
                LastName = m.LastName?.ToLower(),
                Abbott511 = m.Abbott511?.ToLower(),
                UPI = m.UPI,
                EmailID = m.EmailID?.ToLower(),
                Country = m.Country,
                RequestedDate = m.RequestedDate,
                ArcherException = m.ArcherException,
                AddOrRemove = m.AddOrRemove,
                ID = m.ID,
                ItemType = m.ItemType,
                Path = m.Path,
                Organization = m.Organization,
                ReadWrite = m.ReadWrite
            });

            //Else iterate through each paramter checking for if they are null or not
            if (searchFirst != null && searchEmail != null && search511 != null && searchLast != null)
            {
                list = list.Where(s =>
                            (s.FirstName.Contains(searchFirst))).ToList();

                list = list.Where(j =>
                            (j.LastName.Contains(searchLast))).ToList();

                list = list.Where(j =>
                            (j.EmailID.Contains(searchEmail))).ToList();

                list = list.Where(j =>
                            (j.Abbott511.Contains(search511))).ToList();



            }



            return list;
        }


        public async Task<IEnumerable<USBException>> GetSupplier()
        {
            return await context.USBException.ToListAsync();
        }

        public USBException GetSupplierByID(int supplierId)
        {
            return context.USBException.Find(supplierId);
        }

        public void InsertSupplier(USBException supplier)
        {
            context.USBException.Add(supplier);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateSupplier(USBException supplier)
        {
            context.Entry(supplier).State = EntityState.Modified;
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Task<IEnumerable<USBException>> FindSupplier(string searchString)
        {
            throw new NotImplementedException();
        }
    }
}
