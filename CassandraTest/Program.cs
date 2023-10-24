using Cassandra;

namespace CassandraTest;
class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Hello Cassandra!");

        var cluster = Cluster.Builder().AddContactPoints("192.168.1.61", "192.168.1.50", "192.168.1.58")
                                 .WithPort(9042)
                                 //.WithLoadBalancingPolicy(new DCAwareRoundRobinPolicy("<Data Centre (e.g AWS_VPC_US_EAST_1)>"))
                                 .WithAuthProvider(new PlainTextAuthProvider("cassandra", "cassandra"))
                                 .Build();
        var session = cluster.Connect();
        Console.WriteLine("Connected to cluster: " + cluster.Metadata.ClusterName);

        //var keyspaceNames = session
        //        .Execute("SELECT * FROM system_schema.keyspaces")
        //        .Select(row => row.GetValue<string>("keyspace_name"));

        //Console.WriteLine("Found keyspaces:");
        //foreach (var name in keyspaceNames)
        //{
        //    Console.WriteLine("- {0}", name);
        //}

        session.Execute("INSERT INTO latveria.persone (userid, Nome, Cognome, last_update_timestamp) VALUES (6, 'Renzo','Filini', toTimeStamp(now()));");


        //var righe = session.Execute("SELECT * FROM latveria.persone");

        //Console.WriteLine("Found persone:");
        //foreach (var riga in righe)
        //{
        //    Console.WriteLine("- {0} {1}", riga.GetValue<string>("nome"), riga.GetValue<string>("cognome"));
        //}

        await session.ShutdownAsync();
    }
}

