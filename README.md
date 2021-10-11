# DNSUtility
<!-- PROJECT LOGO -->
<br />
<p align="center">
  <a href="https://github.com/FishiGames/ADTools">
    <img src="https://cdn.worldvectorlogo.com/logos/active-directory-1.svg" alt="Logo">
  </a>

  <p align="center">
    C# Microsoft DNS Utility
    <br />
    <a href="https://github.com/FishiGames/ADTools/issues"><strong>Report Bug »</strong></a>
    <br />
    <br />
  </p>


## Information
For permission-problems: [possible workarounds](https://github.com/FishiGames/DNSUtility/issues/1)

<!-- USAGE EXAMPLES -->
## API-Activation
```csharp
//Import DNSHelper namespace
using DNSHelper;

//DC-Serv | "Admin-User" | "Password"
var dnsUtlity = new DNSUtility("DomainController-01", "FishiGames", "P4ssw0rd12E");
```


## Create DNS-Record example:
```csharp
//Domain | "Subdomain" | "IPv4" | "RecordType"
dnsUtlity.CreateRecord(new DNSRecord("UNREALSHARDS.COM", "googledns", "8.8.8.8", RecordType.A));
```


## Delete DNS-Record example:
```csharp
//Domain | "Subdomain" | "IPv4" | "RecordType"
dnsUtlity.DeleteRecord(new DNSRecord("UNREALSHARDS.COM", "googledns", "8.8.8.8", RecordType.A));
```

<!-- ROADMAP -->
## Roadmap

See the [open issues](https://github.com/FishiGames/DNSUtility/issues) for a list of proposed features (and known issues).


<!-- CONTRIBUTING -->
## Contributing

Contributions are what make the open source community such an amazing place to be learn, inspire, and create. Any contributions you make are **greatly appreciated**.

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request


<!-- LICENSE -->
## License

Distributed under the MIT License. See `LICENSE` for more information.
\
This API is unofficial, and we are in no way affiliated with the Microsoft Corporation.


<!-- CONTACT -->
## Contact

Twitter - [@FishiGames](https://twitter.com/FishiGames)
\
YouTube - [@FishiGames](https://www.youtube.com/channel/UC1DY8vlCtV-5fm41qsO19Qw)
\
Twitch - [@FishiGamesXD](https://twitch.tv/FishiGamesXD)
\
Project Link: [https://github.com/FishiGames/DNSUtility](https://github.com/FishiGames/DNSUtility)
