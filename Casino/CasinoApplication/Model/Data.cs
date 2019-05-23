using CasinoData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoApplication.Model
{
    public static class Data
    {
        private static DataRepository dataRepository;

        public static DataRepository DataRepository {
            get => dataRepository;
        }

        private static DataService dataService;

        public static DataService DataService {
            get => dataService;
        }

        public static void RegisterDataRepository(DataRepository _dataRepository)
        {
            dataRepository = _dataRepository;
            dataRepository.DataContext = new DataContext();
            dataRepository.Fill();
            dataService = new DataService(dataRepository);
        }
    }
}
