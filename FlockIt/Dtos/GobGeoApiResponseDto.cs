using System.Collections.Generic;

namespace FlockIt.Dtos
{
    public class GobGeoApiResponseDto
    {
        //{"cantidad":1,"inicio":0,"parametros":{"nombre":"Córdoba"},"provincias":[{"centroide":{"lat":-32.142932663607,"lon":-63.8017532741662},"id":"14","nombre":"Córdoba"}],"total":1}


        public class Centroide
        {
            public double lat { get; set; }
            public double lon { get; set; }
        }

        public class Provincia
        {
            public Centroide centroide { get; set; }
            public int id { get; set; }
            public string nombre { get; set; }
        }

        public class Root
        {
            public int cantidad { get; set; }
            public int inicio { get; set; }
            public List<Provincia> provincias { get; set; }
            public int total { get; set; }
        }
    }
}
