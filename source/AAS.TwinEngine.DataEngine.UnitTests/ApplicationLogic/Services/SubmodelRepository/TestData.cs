using AAS.TwinEngine.DataEngine.DomainModel.SubmodelRepository;

using AasCore.Aas3_0;

using File = AasCore.Aas3_0.File;
using Key = AasCore.Aas3_0.Key;
using Range = AasCore.Aas3_0.Range;

namespace AAS.TwinEngine.DataEngine.UnitTests.ApplicationLogic.Services.SubmodelRepository;

internal static class TestData
{
    public static MultiLanguageProperty CreateManufacturerName()
    {
        return new MultiLanguageProperty(
          idShort: "ManufacturerName",
          value: [
            new LangStringTextType("en", ""), // left intentionally empty for FillOut tests
        new LangStringTextType("de", "") // left intentionally empty for FillOut tests
          ],
          semanticId: new Reference(
            ReferenceTypes.ExternalReference,
            [
              new Key(KeyTypes.MultiLanguageProperty, "http://example.com/idta/digital-nameplate/manufacturer-name")
            ]
          ),
          qualifiers:
          [
              new Qualifier(
                            type: "ExternalReference",
                            valueType: DataTypeDefXsd.String,
                            value: "One")
          ]);
    }

    public static MultiLanguageProperty CreateManufacturerNameWithOutElements()
    {
        return new MultiLanguageProperty(
          idShort: "ManufacturerName",
          value: null,
          semanticId: new Reference(
            ReferenceTypes.ExternalReference,
            [
              new Key(KeyTypes.MultiLanguageProperty, "http://example.com/idta/digital-nameplate/manufacturer-name")
            ]
          ),
          qualifiers:
          [
              new Qualifier(
                            type: "ExternalReference",
                            valueType: DataTypeDefXsd.String,
                            value: "One")
          ]);
    }

    public static File CreateThumbnail()
    {
        return new File(
          contentType: "image/png",
          idShort: "Thumbnail",
          value: "https://localhost/Thumbnail",
          semanticId: new Reference(
            ReferenceTypes.ExternalReference,
            [
              new Key(KeyTypes.SubmodelElementCollection, "http://example.com/idta/digital-nameplate/thumbnail")
            ]
          )
        );
    }

    public static Blob CreateBlob()
    {
        var data = System.Text.Encoding.UTF8.GetBytes("SGVsbG8sIHdvcmxkIQ==");

        return new Blob(
            contentType: "image/png",
            idShort: "Blob",
            value: data,
            semanticId: new Reference(
                ReferenceTypes.ExternalReference,
                [
                    new Key(KeyTypes.SubmodelElementCollection, "http://example.com/idta/digital-nameplate/blob")
                ]
            )
        );
    }

    public static ReferenceElement CreateReferenceElementWithEmptyValues()
    {
        return new ReferenceElement(
                                    idShort:"ReferenceElementWithEmptyValues",
                                    semanticId:new Reference(
                                                             ReferenceTypes.ExternalReference,
                                                             [
                                                                 new Key(KeyTypes.GlobalReference, "http://example.com/idta/digital-nameplate/reference-element/empty-values")
                                                                 ])
                                    );
    }

    public static ReferenceElement CreateReferenceElementWithModelReferenceElementWithEmptyKey()
    {
        return new ReferenceElement(
                                    idShort: "ReferenceElementWithEmptyValues",
                                    semanticId: new Reference(
                                                              ReferenceTypes.ExternalReference,
                                                              [
                                                                  new Key(KeyTypes.GlobalReference, "http://example.com/idta/digital-nameplate/reference-element/model-reference")
                                                              ]),
                                    value: new Reference(
                                                         ReferenceTypes.ModelReference,
                                                         []
                                                         )
                                   );
    }

    public static ReferenceElement CreateReferenceElementWithExternalReference()
    {
        return new ReferenceElement(
                                    idShort:"ExternalReferenceElement",
                                    semanticId:new Reference(
                                                             ReferenceTypes.ExternalReference,
                                                             [
                                                                 new Key(KeyTypes.GlobalReference, "http://example.com/idta/digital-nameplate/reference-element/external-reference")
                                                                 ]),
                                    value: new Reference(
                                                         ReferenceTypes.ExternalReference,
                                                         [
                                                                new Key(KeyTypes.GlobalReference, "http://example.com/idta/digital-nameplate/reference-element/external-reference-value1"),
                                                                new Key(KeyTypes.FragmentReference, "http://example.com/idta/digital-nameplate/reference-element/external-reference-value2")
                                                             ]
                                                         )
                                    );
    }

    public static ReferenceElement CreateReferenceElementWithModelReference()
    {
        return new ReferenceElement(
                                    idShort: "ModelReferenceReferenceElement",
                                    semanticId:new Reference(
                                                             ReferenceTypes.ExternalReference,
                                                             [
                                                                 new Key(KeyTypes.GlobalReference, "http://example.com/idta/digital-nameplate/reference-element/model-reference")
                                                                 ]),
                                    value: new Reference(
                                                         ReferenceTypes.ModelReference,
                                                         [
                                                                new Key(KeyTypes.Submodel, ""), // left intentionally empty for FillOut tests
                                                                new Key(KeyTypes.SubmodelElementList, "ContactName"),
                                                                new Key(KeyTypes.SubmodelElement, "0"),
                                                                new Key(KeyTypes.Property, "Name")
                                                             ]
                                                         )
                                    );
    }

    public static Range CreateRange()
    {
        return new Range(
                         valueType: DataTypeDefXsd.Double,
                         idShort: "Range",
                         min: "0.0",
                         max: "100.0",
                         semanticId: new Reference(
                                                   ReferenceTypes.ExternalReference,
                                                   [
                                                       new Key(KeyTypes.Range, "http://example.com/idta/digital-nameplate/range")
                                                   ]
                                                  )
                        );
    }

    public static Property CreateContactName()
    {
        return new Property(
          idShort: "ContactName",
          valueType: DataTypeDefXsd.String,
          value: "", // left intentionally empty for FillOut tests
          semanticId: new Reference(
            ReferenceTypes.ExternalReference,
            [
              new Key(KeyTypes.Property, "http://example.com/idta/digital-nameplate/contact-name")
            ]
          ),
          qualifiers:
          [
              new Qualifier(
                            type: "ExternalReference",
                            valueType: DataTypeDefXsd.String,
                            value: "One")
          ]);
    }

    public static SubmodelElementCollection CreateContactInformation()
    {
        return new SubmodelElementCollection(
          idShort: "ContactInformation",
          semanticId: new Reference(
            ReferenceTypes.ExternalReference,
            [
              new Key(KeyTypes.SubmodelElementCollection, "http://example.com/idta/digital-nameplate/contact-information")
            ]
          ),
          qualifiers:
          [
              new Qualifier(
                            type: "ExternalReference",
                            valueType: DataTypeDefXsd.String,
                            value: "ZeroToMany")
          ],
          value: [
            CreateContactName(),
          ]
        );
    }

    public static SubmodelElementList CreateModel3DListWithValues()
    {
        return new SubmodelElementList(
                                       idShort: "Model3D",
                                       semanticId: new Reference(
                                                                 ReferenceTypes.ExternalReference,
                                                                 [
                                                                     new Key(KeyTypes.SubmodelElementList, "http://example.com/idta/digital-nameplate/model-3d")
                                                                 ]
                                                                ),
                                       typeValueListElement: AasSubmodelElements.SubmodelElementCollection,
                                       value: [
                                           CreateModelDataCollection("1"),
                                           CreateModelDataCollection("2")
                                       ],
                                       qualifiers:
                                       [
                                           new Qualifier(
                                                         type: "ExternalReference",
                                                         valueType: DataTypeDefXsd.String,
                                                         value: "ZeroToOne")
                                       ]
                                      );
    }

    private static SubmodelElementCollection CreateModelDataCollection(string suffix)
    {
        return new SubmodelElementCollection(
                                             idShort: $"ModelData{suffix}",
                                             semanticId: new Reference(
                                                                       ReferenceTypes.ExternalReference,
                                                                       [
                                                                           new Key(KeyTypes.SubmodelElementCollection, "http://example.com/idta/digital-nameplate/model-data")
                                                                       ]
                                                                      ),
                                             value: [
                                                 new File(
                                                          contentType: "model/gltf-binary",
                                                          idShort: "ModelFile",
                                                          value: "https://localhost/ModelFile.glb",
                                                          semanticId: new Reference(
                                                                                    ReferenceTypes.ExternalReference,
                                                                                    [
                                                                                        new Key(KeyTypes.File, "http://example.com/idta/digital-nameplate/model-file")
                                                                                    ]
                                                                                   )
                                                         ),
                                                 new File(
                                                 contentType: "model/gltf-binary",
                                                 idShort: "ModelDataFile",
                                                 value: "https://localhost/ModelDataFile.glb",
                                                 semanticId: new Reference(
                                                                           ReferenceTypes.ExternalReference,
                                                                           [
                                                                               new Key(KeyTypes.File, "http://example.com/idta/digital-nameplate/model-file")
                                                                           ]
                                                                          )
                                                 )
                                             ],
                                             qualifiers:
                                             [
                                                 new Qualifier(
                                                               type: "ExternalReference",
                                                               valueType: DataTypeDefXsd.String,
                                                               value: "ZeroToMany")
                                             ]
                                             );
    }

    public static SubmodelElementCollection CreateContactInformationWithOutElements()
    {
        return new SubmodelElementCollection(
          idShort: "ContactInformation",
          semanticId: new Reference(
            ReferenceTypes.ExternalReference,
            [
              new Key(KeyTypes.SubmodelElementCollection, "http://example.com/idta/digital-nameplate/contact-information")
            ]
          ),
          qualifiers:
          [
              new Qualifier(
                            type: "ExternalReference",
                            valueType: DataTypeDefXsd.String,
                            value: "ZeroToMany")
          ],
          value: null
        );
    }

    public static SubmodelElementList CreateContactList()
    {
        return new SubmodelElementList(
          AasSubmodelElements.Property,
          idShort: "ContactList",
          semanticId: new Reference(
            ReferenceTypes.ExternalReference,
            [
              new Key(KeyTypes.SubmodelElementCollection, "http://example.com/idta/digital-nameplate/contact-list")
            ]
          ),
          qualifiers:
            [
            new Qualifier(
            type: "ExternalReference",
            valueType: DataTypeDefXsd.String,
            value: "ZeroToMany")],
          value: [
            CreateContactName(),
        new Property(
          idShort: "ModelName",
          valueType: DataTypeDefXsd.String,
          value: "", // left intentionally empty for FillOut tests
          semanticId: new Reference(
            ReferenceTypes.ExternalReference,
            [
              new Key(KeyTypes.Property, "http://example.com/idta/digital-nameplate/model-name")
            ]
          )
        )
          ]
        );
    }

    public static SubmodelElementList CreateContactListWithOutElements()
    {
        return new SubmodelElementList(
          AasSubmodelElements.Property,
          idShort: "ContactList",
          semanticId: new Reference(
            ReferenceTypes.ExternalReference,
            [
              new Key(KeyTypes.SubmodelElementCollection, "http://example.com/idta/digital-nameplate/contact-list")
            ]
          ),
          qualifiers:
          [
              new Qualifier(
                            type: "ExternalReference",
                            valueType: DataTypeDefXsd.String,
                            value: "ZeroToMany")
          ],
          value: null
        );
    }

    public static Submodel CreateSubmodelWithContactInformationWithOutElements()
    {
        return new Submodel(
          id: "http://example.com/idta/digital-nameplate",
          idShort: "DigitalNameplate",
          semanticId: new Reference(
            ReferenceTypes.ExternalReference,
            [
              new Key(KeyTypes.Submodel, "http://example.com/idta/digital-nameplate/semantic-id")
            ]
          ),
          submodelElements: [
            CreateContactInformationWithOutElements()
            ]);
    }

    public static Submodel CreateSubmodelWithContactListWithOutElements()
    {
        return new Submodel(
          id: "http://example.com/idta/digital-nameplate",
          idShort: "DigitalNameplate",
          semanticId: new Reference(
            ReferenceTypes.ExternalReference,
            [
              new Key(KeyTypes.Submodel, "http://example.com/idta/digital-nameplate/semantic-id")
            ]
          ),
          submodelElements: [
            CreateContactListWithOutElements()
            ]);
    }

    public static Submodel CreateSubmodelWithReferenceElement()
    {
        return new Submodel(
          id: "http://example.com/idta/digital-nameplate",
          idShort: "DigitalNameplate",
          semanticId: new Reference(
            ReferenceTypes.ExternalReference,
            [
              new Key(KeyTypes.Submodel, "http://example.com/idta/digital-nameplate/semantic-id")
            ]
          ),
          submodelElements: [
            CreateReferenceElementWithExternalReference(),
            CreateReferenceElementWithModelReference(),
            CreateReferenceElementWithEmptyValues()
            ]);
    }

    public static Submodel CreateSubmodelWithManufacturerNameWithOutElements()
    {
        return new Submodel(
          id: "http://example.com/idta/digital-nameplate",
          idShort: "DigitalNameplate",
          semanticId: new Reference(
            ReferenceTypes.ExternalReference,
            [
              new Key(KeyTypes.Submodel, "http://example.com/idta/digital-nameplate/semantic-id")
            ]
          ),
          submodelElements: [
            CreateManufacturerNameWithOutElements()
            ]);
    }

    public static SubmodelElementList CreateModel3DListWithoutValues()
    {
        return new SubmodelElementList(
                                       idShort: "Model3D",
                                       semanticId: new Reference(
                                                                 ReferenceTypes.ExternalReference,
                                                                 [
                                                                     new Key(KeyTypes.SubmodelElementList, "http://example.com/idta/digital-nameplate/model-3d")
                                                                 ]
                                                                ),
                                       typeValueListElement: AasSubmodelElements.SubmodelElementCollection,
                                       qualifiers:
                                       [
                                           new Qualifier(
                                                         type: "ExternalReference",
                                                         valueType: DataTypeDefXsd.String,
                                                         value: "ZeroToOne")
                                       ],
                                       value: null
                                      );
    }

    public static Submodel CreateSubmodel()
    {
        return new Submodel(
          id: "http://example.com/idta/digital-nameplate",
          idShort: "DigitalNameplate",
          semanticId: new Reference(
            ReferenceTypes.ExternalReference,
            [
              new Key(KeyTypes.Submodel, "http://example.com/idta/digital-nameplate/semantic-id")
            ]
          ),
          submodelElements: [
            CreateManufacturerName(),
        new Property(
          idShort: "ModelType",
          valueType: DataTypeDefXsd.Double,
          value: "", // left intentionally empty for FillOut tests
          semanticId: new Reference(
            ReferenceTypes.ExternalReference,
            [
              new Key(KeyTypes.Property, "http://example.com/idta/digital-nameplate/model-type")
            ]
          ),
          qualifiers:
          [
              new Qualifier(
                            type: "ExternalReference",
                            valueType: DataTypeDefXsd.String,
                            value: "ZeroToOne")
          ]
                    ),
        CreateContactList(),
        CreateContactInformation(),
        CreateThumbnail(),
        CreateBlob(),
            CreateRange(),
          ]
        );
    }

    public static Submodel CreateSubmodelWithoutExtraElementsNested()
    {
        return new Submodel(
          id: "http://example.com/idta/digital-nameplate",
          idShort: "DigitalNameplate",
          semanticId: new Reference(
            ReferenceTypes.ExternalReference,
            [
              new Key(KeyTypes.Submodel, "http://example.com/idta/digital-nameplate/semantic-id")
            ]
          ),
          submodelElements: [
            CreateContactInformation()
          ]
        );
    }

    public static Submodel CreateSubmodelWithoutExtraElements()
    {
        return new Submodel(
          id: "http://example.com/idta/digital-nameplate",
          idShort: "DigitalNameplate",
          semanticId: new Reference(
            ReferenceTypes.ExternalReference,
            [
              new Key(KeyTypes.Submodel, "http://example.com/idta/digital-nameplate/semantic-id")
            ]
          ),
          submodelElements: [
            CreateManufacturerName()
          ]
        );
    }

    public static Submodel CreateSubmodelWithComplexData()
    {
        return new Submodel(
          id: "http://example.com/idta/digital-nameplate",
          idShort: "DigitalNameplate",
          semanticId: new Reference(
            ReferenceTypes.ExternalReference,
            [
              new Key(KeyTypes.Submodel, "http://example.com/idta/digital-nameplate/semantic-id")
            ]
          ),
          submodelElements: []
        );
    }

    public static Submodel CreateSubmodelWithModel3DList()
    {
        return new Submodel(
                            id: "http://example.com/idta/digital-nameplate",
                            idShort: "DigitalNameplate",
                            semanticId: new Reference(
                                                      ReferenceTypes.ExternalReference,
                                                      [
                                                          new Key(KeyTypes.Submodel, "http://example.com/idta/digital-nameplate/semantic-id")
                                                      ]
                                                     ),
                            submodelElements: [
                                CreateModel3DListWithValues()
                            ]
                           );
    }

    public static readonly SubmodelElementCollection ComplexData = new(
      idShort: "ComplexData",
      semanticId: new Reference(
        ReferenceTypes.ExternalReference,
        [
          new Key(KeyTypes.SubmodelElementList, "http://example.com/idta/digital-nameplate/complex-data")
        ]
      ),
      qualifiers:
      [
          new Qualifier(
                        type: "ExternalReference",
                        valueType: DataTypeDefXsd.String,
                        value: "OneToMany")
      ],
      value: [
        CreateManufacturerName(),
      new Property(
        idShort: "ModelType",
        valueType: DataTypeDefXsd.String,
        value: "", // left intentionally empty for FillOut tests
        semanticId: new Reference(
          ReferenceTypes.ExternalReference,
          [
            new Key(KeyTypes.Property, "http://example.com/idta/digital-nameplate/model-type")
          ]
        ),
        qualifiers:
        [
            new Qualifier(
                          type: "ExternalReference",
                          valueType: DataTypeDefXsd.String,
                          value: "ZeroToOne")
        ]),
      CreateContactList(),
      CreateContactInformation(),
      ]
    );

    public static readonly SemanticTreeNode SubmodelTreeNode = CreateSubmodelTreeNode();

    public static SemanticTreeNode CreateSubmodelTreeNode()
    {
        var semanticTreeNode = new SemanticBranchNode("http://example.com/idta/digital-nameplate/semantic-id", Cardinality.Unknown);

        semanticTreeNode.AddChild(CreateManufacturerNameTreeNode());

        semanticTreeNode.AddChild(CreateModelTypeTreeNode());

        semanticTreeNode.AddChild(CreateContactListTreeNode());

        semanticTreeNode.AddChild(CreateContactInformationTreeNode());

        semanticTreeNode.AddChild(CreateFileTreeNode());

        semanticTreeNode.AddChild(CreateBlobTreeNode());

        semanticTreeNode.AddChild(CreateRangeTreeNode());

        return semanticTreeNode;
    }

    public static SemanticTreeNode CreateSubmodelWithComplexDataTreeNode()
    {
        var semanticTreeNode = new SemanticBranchNode("http://example.com/idta/digital-nameplate/semantic-id", Cardinality.Unknown);

        var complexDataBranchNode1 = new SemanticBranchNode("http://example.com/idta/digital-nameplate/complex-data", Cardinality.ZeroToMany);

        var complexDataBranchNode2 = new SemanticBranchNode("http://example.com/idta/digital-nameplate/complex-data", Cardinality.ZeroToMany);

        semanticTreeNode.AddChild(complexDataBranchNode1);

        semanticTreeNode.AddChild(complexDataBranchNode2);

        complexDataBranchNode1.AddChild(CreateManufacturerNameTreeNode());

        complexDataBranchNode1.AddChild(CreateModelTypeTreeNode());

        complexDataBranchNode1.AddChild(CreateContactListTreeNode());

        complexDataBranchNode1.AddChild(CreateContactInformationTreeNode());

        complexDataBranchNode2.AddChild(CreateManufacturerNameTreeNode("1"));

        complexDataBranchNode2.AddChild(CreateModelTypeTreeNode());

        complexDataBranchNode2.AddChild(CreateContactListTreeNode("1"));

        complexDataBranchNode2.AddChild(CreateContactListTreeNode("2"));

        complexDataBranchNode2.AddChild(CreateContactInformationTreeNode("1"));

        return semanticTreeNode;
    }

    public static SemanticTreeNode CreateManufacturerNameTreeNode(string testObject = "")
    {
        var manufacturerName = new SemanticBranchNode("http://example.com/idta/digital-nameplate/manufacturer-name", Cardinality.One);
        manufacturerName.AddChild(new SemanticLeafNode("http://example.com/idta/digital-nameplate/manufacturer-name_en", $"Test{testObject} Example Manufacturer", DataType.String, Cardinality.ZeroToOne));
        manufacturerName.AddChild(new SemanticLeafNode("http://example.com/idta/digital-nameplate/manufacturer-name_de", $"Test{testObject} Beispiel Hersteller", DataType.String, Cardinality.ZeroToOne));
        return manufacturerName;
    }

    public static SemanticTreeNode CreateModelTypeTreeNode() => new SemanticLeafNode("http://example.com/idta/digital-nameplate/model-type", "22.47", DataType.String, Cardinality.ZeroToOne);

    public static SemanticTreeNode CreateFileTreeNode() => new SemanticLeafNode("http://example.com/idta/digital-nameplate/thumbnail", "https://localhost/TestThumbnail", DataType.String, Cardinality.One);

    public static SemanticTreeNode CreateBlobTreeNode()
    {
        var imagePath = Path.Combine(AppContext.BaseDirectory, "TestData", "Test.png");
        var originalBytes = System.IO.File.ReadAllBytes(imagePath);
        var base64Value = Convert.ToBase64String(originalBytes);

        return new SemanticLeafNode("http://example.com/idta/digital-nameplate/blob", base64Value, DataType.String, Cardinality.One);
    }

    public static SemanticTreeNode CreateRangeTreeNode()
    {
        var rangeElement = new SemanticBranchNode("http://example.com/idta/digital-nameplate/range", Cardinality.One);
        rangeElement.AddChild(new SemanticLeafNode("http://example.com/idta/digital-nameplate/range_min", "10.02", DataType.Number, Cardinality.ZeroToOne));
        rangeElement.AddChild(new SemanticLeafNode("http://example.com/idta/digital-nameplate/range_max", "99.98", DataType.Number, Cardinality.ZeroToOne));
        return rangeElement;
    }

    public static SemanticTreeNode CreateReferenceElementTreeNodeWhereValueIsStringWithoutSeparator() => new SemanticLeafNode("http://example.com/idta/digital-nameplate/reference-element/model-reference", "http://example.com/idta/digital-nameplate", DataType.String, Cardinality.Unknown);

    public static SemanticTreeNode CreateReferenceElementTreeNodeWhereValueIsStringWithSeparator() => new SemanticLeafNode("http://example.com/idta/digital-nameplate/reference-element/model-reference", "http://example.com/idta/digital-nameplate_NamePlate_1", DataType.String, Cardinality.Unknown);

    public static SemanticTreeNode CreateReferenceElementTreeNodeWhereValueIsStringWithSeparatorHasAllValue() => new SemanticLeafNode("http://example.com/idta/digital-nameplate/reference-element/model-reference", "http://example.com/idta/digital-nameplate_NamePlate_1_ManufacturerName", DataType.String, Cardinality.Unknown);

    public static SemanticTreeNode CreateReferenceElementTreeNodeWhereValueIsInMultipleLeafNode()
    {
        var branchNode = new SemanticBranchNode("http://example.com/idta/digital-nameplate/reference-element/model-reference", Cardinality.Unknown);
        branchNode.AddChild(new SemanticLeafNode("http://example.com/idta/digital-nameplate/reference-element/model-reference", "http://example.com/idta/digital-nameplate", DataType.String, Cardinality.Unknown));
        branchNode.AddChild(new SemanticLeafNode("http://example.com/idta/digital-nameplate/reference-element/model-reference", "NamePlate", DataType.String, Cardinality.Unknown));
        branchNode.AddChild(new SemanticLeafNode("http://example.com/idta/digital-nameplate/reference-element/model-reference", "1", DataType.String, Cardinality.Unknown));
        return branchNode;
    }

    public static SemanticTreeNode CreateReferenceElementTreeNodeWhereValueIsInMultipleLeafNodeHasAllValue()
    {
        var branchNode = new SemanticBranchNode("http://example.com/idta/digital-nameplate/reference-element/model-reference", Cardinality.Unknown);
        branchNode.AddChild(new SemanticLeafNode("http://example.com/idta/digital-nameplate/reference-element/model-reference", "http://example.com/idta/digital-nameplate", DataType.String, Cardinality.Unknown));
        branchNode.AddChild(new SemanticLeafNode("http://example.com/idta/digital-nameplate/reference-element/model-reference", "NamePlate", DataType.String, Cardinality.Unknown));
        branchNode.AddChild(new SemanticLeafNode("http://example.com/idta/digital-nameplate/reference-element/model-reference", "1", DataType.String, Cardinality.Unknown));
        branchNode.AddChild(new SemanticLeafNode("http://example.com/idta/digital-nameplate/reference-element/model-reference", "ManufacturerName", DataType.String, Cardinality.Unknown));
        return branchNode;
    }

    public static SemanticTreeNode CreateContactListTreeNode(string testObject = "")
    {
        var contactList = new SemanticBranchNode("http://example.com/idta/digital-nameplate/contact-list", Cardinality.ZeroToMany);
        contactList.AddChild(new SemanticLeafNode("http://example.com/idta/digital-nameplate/contact-name", $"Test{testObject} John Doe", DataType.String, Cardinality.One));
        contactList.AddChild(new SemanticLeafNode("http://example.com/idta/digital-nameplate/model-name", $"Test{testObject} Example Model", DataType.String, Cardinality.ZeroToOne));
        return contactList;
    }

    public static SemanticTreeNode CreateContactInformationTreeNode(string testObject = "")
    {
        var contactInformation = new SemanticBranchNode("http://example.com/idta/digital-nameplate/contact-information", Cardinality.ZeroToMany);
        contactInformation.AddChild(new SemanticLeafNode("http://example.com/idta/digital-nameplate/contact-name", $"Test{testObject} John Doe", DataType.String, Cardinality.One));
        return contactInformation;
    }

    public static MultiLanguageProperty CreateFilledManufacturerName() => new(
      idShort: "ManufacturerName",
      value: [
        new LangStringTextType("en", "Test Example Manufacturer"),
      new LangStringTextType("de", "Test Beispiel Hersteller")
      ],
      semanticId: new Reference(
        ReferenceTypes.ExternalReference,
        [
          new Key(KeyTypes.MultiLanguageProperty, "http://example.com/idta/digital-nameplate/manufacturer-name")
        ]
      )
    );

    public static Property CreateFilledContactName() => new(
      idShort: "ContactName",
      valueType: DataTypeDefXsd.String,
      value: "Test John Doe",
      semanticId: new Reference(
        ReferenceTypes.ExternalReference,
        [
          new Key(KeyTypes.Property, "http://example.com/idta/digital-nameplate/contact-name")
        ]
      ),
      qualifiers:
      [
          new Qualifier(
                        type: "ExternalReference",
                        valueType: DataTypeDefXsd.String,
                        value: "One")
      ]);

    public static Property CreateFilledModelType() => new(
      idShort: "ModelType",
      valueType: DataTypeDefXsd.Double,
      value: "22.47",
      semanticId: new Reference(
        ReferenceTypes.ExternalReference,
        [
          new Key(KeyTypes.Property, "http://example.com/idta/digital-nameplate/model-type")
        ]
      ),
      qualifiers:
      [
          new Qualifier(
                        type: "ExternalReference",
                        valueType: DataTypeDefXsd.String,
                        value: "ZeroToOne")
      ]);

    public static Property CreateFilledModelName() => new(
      idShort: "ModelName",
      valueType: DataTypeDefXsd.String,
      value: "24.75",
      semanticId: new Reference(
        ReferenceTypes.ExternalReference,
        [
          new Key(KeyTypes.Property, "http://example.com/idta/digital-nameplate/model-name")
        ]
      ),
      qualifiers:
      [
          new Qualifier(
                        type: "ExternalReference",
                        valueType: DataTypeDefXsd.String,
                        value: "ZeroToOne")
      ]);

    public static SubmodelElementList CreateFilledContactList() => new(
      AasSubmodelElements.Property,
      idShort: "ContactInformation",
      semanticId: new Reference(
        ReferenceTypes.ExternalReference,
        [
          new Key(KeyTypes.SubmodelElementCollection, "http://example.com/idta/digital-nameplate/contact-information")
        ]
      ),
      value: [
        CreateFilledContactName(),
        CreateFilledModelName()
      ]
    );

    public static File CreateFilledThumbnail() => new(
      contentType: "image/png",
      idShort: "Thumbnail",
      value: "https://localhost/TestThumbnail",
      semanticId: new Reference(
        ReferenceTypes.ExternalReference,
        [
          new Key(KeyTypes.SubmodelElementCollection, "http://example.com/idta/digital-nameplate/thumbnail")
        ]
      )
    );

    public static Blob CreateFilledBlob()
    {
        var imagePath = Path.Combine(AppContext.BaseDirectory, "TestData", "Test.png");
        var originalBytes = System.IO.File.ReadAllBytes(imagePath);

        return new Blob(
            contentType: "image/png",
            idShort: "Blob",
            value: originalBytes,
            semanticId: new Reference(
                ReferenceTypes.ExternalReference,
                [
                    new Key(KeyTypes.SubmodelElementCollection, "http://example.com/idta/digital-nameplate/blob")
                ]
            )
        );
    }

    public static SubmodelElementCollection CreateFilledContactInformation() => new(
      idShort: "ContactInformation",
      semanticId: new Reference(
        ReferenceTypes.ExternalReference,
        [
          new Key(KeyTypes.SubmodelElementCollection, "http://example.com/idta/digital-nameplate/contact-information")
        ]
      ),
      value: [
        CreateFilledContactName()
      ]
    );
    
    public static ReferenceElement CreateFilledReferenceElementWithExternalReference() => new(
        idShort: "ExternalReferenceElement",
        semanticId: new Reference(
            ReferenceTypes.ExternalReference,
            [
                new Key(KeyTypes.GlobalReference, "http://example.com/idta/digital-nameplate/reference-element/external-reference")
            ]
        ),
        value: new Reference(
            ReferenceTypes.ExternalReference,
            [
                new Key(KeyTypes.GlobalReference, "http://example.com/idta/digital-nameplate/reference-element/external-reference-value1"),
                new Key(KeyTypes.FragmentReference, "http://example.com/idta/digital-nameplate/reference-element/external-reference-value2")
            ]
        )
    );

    public static ReferenceElement CreateFilledReferenceElementWithModelReference() => new(
        idShort: "ModelReferenceReferenceElement",
        semanticId: new Reference(
            ReferenceTypes.ExternalReference,
            [
                new Key(KeyTypes.GlobalReference, "http://example.com/idta/digital-nameplate/reference-element/model-reference")
            ]
        ),
        value: new Reference(
            ReferenceTypes.ModelReference,
            [
                new Key(KeyTypes.Submodel, "http://example.com/idta/digital-nameplate"),
                new Key(KeyTypes.SubmodelElementList, "NamePlate"),
                new Key(KeyTypes.SubmodelElement, "1"),
                new Key(KeyTypes.Property, "ManufacturerName")
            ]
        )
    );

    public static Submodel CreateFilledSubmodel() => new(
      id: "http://example.com/idta/digital-nameplate",
      idShort: "DigitalNameplate",
      semanticId: new Reference(
        ReferenceTypes.ExternalReference,
        [
          new Key(KeyTypes.Submodel, "http://example.com/idta/digital-nameplate/semantic-id")
        ]
      ),
      submodelElements: [
        CreateFilledManufacturerName(),
        CreateFilledModelType(),
        CreateFilledContactList(),
        CreateFilledContactInformation(),
        CreateFilledThumbnail(),
        CreateFilledBlob()
      ]
    );

    public static Submodel CreateFilledSubmodelWithOutExtraElements() => new(
      id: "http://example.com/idta/digital-nameplate",
      idShort: "DigitalNameplate",
      semanticId: new Reference(
        ReferenceTypes.ExternalReference,
        [
          new Key(KeyTypes.Submodel, "http://example.com/idta/digital-nameplate/semantic-id")
        ]
      ),
      submodelElements: [
        CreateFilledContactInformation()
      ]
    );

    public static SemanticTreeNode CreateModel3DTreeNode()
    {
        var model3DNode = new SemanticBranchNode("http://example.com/idta/digital-nameplate/model-3d", Cardinality.ZeroToMany);

        model3DNode.AddChild(CreateModelDataTreeNode());
        model3DNode.AddChild(CreateModelDataTreeNode());

        return model3DNode;
    }

    private static SemanticBranchNode CreateModelDataTreeNode()
    {
        var modelDataNode = new SemanticBranchNode("http://example.com/idta/digital-nameplate/model-data", Cardinality.One);
        modelDataNode.AddChild(new SemanticLeafNode(
                                                    "http://example.com/idta/digital-nameplate/model-file",
                                                    "https://localhost/ModelFile.glb",
                                                    DataType.String,
                                                    Cardinality.One
                                                   ));
        modelDataNode.AddChild(new SemanticLeafNode(
                                                    "http://example.com/idta/digital-nameplate/ModelDataFile",
                                                    "https://localhost/ModelDataFile.glb",
                                                    DataType.String,
                                                    Cardinality.One
                                                   ));
        return modelDataNode;
    }
}
