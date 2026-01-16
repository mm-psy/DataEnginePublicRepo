# DataEngine

**DataEngine** is a .NET-based service that dynamically generates complete **Asset Administration Shell (AAS)** submodels by combining standardized templates with real-time data.
It integrates with **Eclipse BaSyx** and follows **IDTA specifications** to ensure interoperability.
When a submodel is requested, DataEngine retrieves its template, queries the **Plugin** for semantic ID values, and populates the structure automatically.
It supports nested and hierarchical data models, providing ready-to-use submodels for visualization or API consumption.
In short, DataEngine acts as the **core orchestration layer** that transforms static AAS templates into live digital representations.

# QuickStart

### 1. Clone the repositories:

```bash
# Clone DataEngine project
git clone <DataEngine_Repo_URL>
# Clone Plugin project
git clone <ReferencePlugin_Repo_URL>
```

**📂 Folder Structure should look like**
```
    root-folder/                    # your chosen root folder 
    │
    ├── AasTwin.DataEngine/        # This folder will automatically created when you clone the DataEngine repository
    └── AasTwin.Plugin/            # This folder will automatically created when you clone the Plugin repository
```

### 2. Start the Application
In the AasTwin.DataEngine directory run the following command and open http://localhost:8080/aas-ui/ 
```bash
cd AasTwin.DataEngine
docker-compose up -d
```

If you want to further configure your DataEngine instance, go to our [example directory](../AasTwin.DataEngine/example/README.md).

<!-- test1 -->
