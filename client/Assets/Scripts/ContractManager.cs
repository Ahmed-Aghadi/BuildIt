using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Thirdweb;
using UnityEngine;

public class ContractManager : MonoBehaviour
{
    string mapContractAddress = "0x8b00E8128749B22E657620aB845186E6268515B4";
    string mapContractABI = "[\r\n    {\r\n      \"inputs\": [\r\n        {\r\n          \"internalType\": \"uint256\",\r\n          \"name\": \"_size\",\r\n          \"type\": \"uint256\"\r\n        },\r\n        {\r\n          \"internalType\": \"uint256\",\r\n          \"name\": \"_perSize\",\r\n          \"type\": \"uint256\"\r\n        },\r\n        {\r\n          \"internalType\": \"string\",\r\n          \"name\": \"_baseUri\",\r\n          \"type\": \"string\"\r\n        },\r\n        {\r\n          \"internalType\": \"address\",\r\n          \"name\": \"_utilsAddress\",\r\n          \"type\": \"address\"\r\n        }\r\n      ],\r\n      \"stateMutability\": \"nonpayable\",\r\n      \"type\": \"constructor\"\r\n    },\r\n    {\r\n      \"inputs\": [],\r\n      \"name\": \"InvalidLength\",\r\n      \"type\": \"error\"\r\n    },\r\n    {\r\n      \"inputs\": [],\r\n      \"name\": \"InvalidXIndex\",\r\n      \"type\": \"error\"\r\n    },\r\n    {\r\n      \"inputs\": [],\r\n      \"name\": \"InvalidYIndex\",\r\n      \"type\": \"error\"\r\n    },\r\n    {\r\n      \"inputs\": [],\r\n      \"name\": \"LandAlreadyOwned\",\r\n      \"type\": \"error\"\r\n    },\r\n    {\r\n      \"inputs\": [],\r\n      \"name\": \"NotOwner\",\r\n      \"type\": \"error\"\r\n    },\r\n    {\r\n      \"inputs\": [],\r\n      \"name\": \"SizeNotDivisibleByPerSize\",\r\n      \"type\": \"error\"\r\n    },\r\n    {\r\n      \"inputs\": [],\r\n      \"name\": \"ZeroPerSize\",\r\n      \"type\": \"error\"\r\n    },\r\n    {\r\n      \"inputs\": [],\r\n      \"name\": \"ZeroSize\",\r\n      \"type\": \"error\"\r\n    },\r\n    {\r\n      \"anonymous\": false,\r\n      \"inputs\": [\r\n        {\r\n          \"indexed\": true,\r\n          \"internalType\": \"address\",\r\n          \"name\": \"owner\",\r\n          \"type\": \"address\"\r\n        },\r\n        {\r\n          \"indexed\": true,\r\n          \"internalType\": \"address\",\r\n          \"name\": \"spender\",\r\n          \"type\": \"address\"\r\n        },\r\n        {\r\n          \"indexed\": true,\r\n          \"internalType\": \"uint256\",\r\n          \"name\": \"id\",\r\n          \"type\": \"uint256\"\r\n        }\r\n      ],\r\n      \"name\": \"Approval\",\r\n      \"type\": \"event\"\r\n    },\r\n    {\r\n      \"anonymous\": false,\r\n      \"inputs\": [\r\n        {\r\n          \"indexed\": true,\r\n          \"internalType\": \"address\",\r\n          \"name\": \"owner\",\r\n          \"type\": \"address\"\r\n        },\r\n        {\r\n          \"indexed\": true,\r\n          \"internalType\": \"address\",\r\n          \"name\": \"operator\",\r\n          \"type\": \"address\"\r\n        },\r\n        {\r\n          \"indexed\": false,\r\n          \"internalType\": \"bool\",\r\n          \"name\": \"approved\",\r\n          \"type\": \"bool\"\r\n        }\r\n      ],\r\n      \"name\": \"ApprovalForAll\",\r\n      \"type\": \"event\"\r\n    },\r\n    {\r\n      \"anonymous\": false,\r\n      \"inputs\": [\r\n        {\r\n          \"indexed\": true,\r\n          \"internalType\": \"address\",\r\n          \"name\": \"user\",\r\n          \"type\": \"address\"\r\n        },\r\n        {\r\n          \"indexed\": true,\r\n          \"internalType\": \"address\",\r\n          \"name\": \"newOwner\",\r\n          \"type\": \"address\"\r\n        }\r\n      ],\r\n      \"name\": \"OwnershipTransferred\",\r\n      \"type\": \"event\"\r\n    },\r\n    {\r\n      \"anonymous\": false,\r\n      \"inputs\": [\r\n        {\r\n          \"indexed\": true,\r\n          \"internalType\": \"address\",\r\n          \"name\": \"from\",\r\n          \"type\": \"address\"\r\n        },\r\n        {\r\n          \"indexed\": true,\r\n          \"internalType\": \"address\",\r\n          \"name\": \"to\",\r\n          \"type\": \"address\"\r\n        },\r\n        {\r\n          \"indexed\": true,\r\n          \"internalType\": \"uint256\",\r\n          \"name\": \"id\",\r\n          \"type\": \"uint256\"\r\n        }\r\n      ],\r\n      \"name\": \"Transfer\",\r\n      \"type\": \"event\"\r\n    },\r\n    {\r\n      \"inputs\": [\r\n        {\r\n          \"internalType\": \"address\",\r\n          \"name\": \"spender\",\r\n          \"type\": \"address\"\r\n        },\r\n        {\r\n          \"internalType\": \"uint256\",\r\n          \"name\": \"id\",\r\n          \"type\": \"uint256\"\r\n        }\r\n      ],\r\n      \"name\": \"approve\",\r\n      \"outputs\": [],\r\n      \"stateMutability\": \"nonpayable\",\r\n      \"type\": \"function\"\r\n    },\r\n    {\r\n      \"inputs\": [\r\n        {\r\n          \"internalType\": \"address\",\r\n          \"name\": \"owner\",\r\n          \"type\": \"address\"\r\n        }\r\n      ],\r\n      \"name\": \"balanceOf\",\r\n      \"outputs\": [\r\n        {\r\n          \"internalType\": \"uint256\",\r\n          \"name\": \"\",\r\n          \"type\": \"uint256\"\r\n        }\r\n      ],\r\n      \"stateMutability\": \"view\",\r\n      \"type\": \"function\"\r\n    },\r\n    {\r\n      \"inputs\": [],\r\n      \"name\": \"baseUri\",\r\n      \"outputs\": [\r\n        {\r\n          \"internalType\": \"string\",\r\n          \"name\": \"\",\r\n          \"type\": \"string\"\r\n        }\r\n      ],\r\n      \"stateMutability\": \"view\",\r\n      \"type\": \"function\"\r\n    },\r\n    {\r\n      \"inputs\": [\r\n        {\r\n          \"internalType\": \"uint256\",\r\n          \"name\": \"\",\r\n          \"type\": \"uint256\"\r\n        }\r\n      ],\r\n      \"name\": \"getApproved\",\r\n      \"outputs\": [\r\n        {\r\n          \"internalType\": \"address\",\r\n          \"name\": \"\",\r\n          \"type\": \"address\"\r\n        }\r\n      ],\r\n      \"stateMutability\": \"view\",\r\n      \"type\": \"function\"\r\n    },\r\n    {\r\n      \"inputs\": [\r\n        {\r\n          \"internalType\": \"address\",\r\n          \"name\": \"\",\r\n          \"type\": \"address\"\r\n        },\r\n        {\r\n          \"internalType\": \"address\",\r\n          \"name\": \"\",\r\n          \"type\": \"address\"\r\n        }\r\n      ],\r\n      \"name\": \"isApprovedForAll\",\r\n      \"outputs\": [\r\n        {\r\n          \"internalType\": \"bool\",\r\n          \"name\": \"\",\r\n          \"type\": \"bool\"\r\n        }\r\n      ],\r\n      \"stateMutability\": \"view\",\r\n      \"type\": \"function\"\r\n    },\r\n    {\r\n      \"inputs\": [\r\n        {\r\n          \"internalType\": \"uint256\",\r\n          \"name\": \"\",\r\n          \"type\": \"uint256\"\r\n        }\r\n      ],\r\n      \"name\": \"land\",\r\n      \"outputs\": [\r\n        {\r\n          \"internalType\": \"uint256\",\r\n          \"name\": \"xIndex\",\r\n          \"type\": \"uint256\"\r\n        },\r\n        {\r\n          \"internalType\": \"uint256\",\r\n          \"name\": \"yIndex\",\r\n          \"type\": \"uint256\"\r\n        }\r\n      ],\r\n      \"stateMutability\": \"view\",\r\n      \"type\": \"function\"\r\n    },\r\n    {\r\n      \"inputs\": [],\r\n      \"name\": \"landCount\",\r\n      \"outputs\": [\r\n        {\r\n          \"internalType\": \"uint256\",\r\n          \"name\": \"\",\r\n          \"type\": \"uint256\"\r\n        }\r\n      ],\r\n      \"stateMutability\": \"view\",\r\n      \"type\": \"function\"\r\n    },\r\n    {\r\n      \"inputs\": [\r\n        {\r\n          \"internalType\": \"uint256\",\r\n          \"name\": \"\",\r\n          \"type\": \"uint256\"\r\n        },\r\n        {\r\n          \"internalType\": \"uint256\",\r\n          \"name\": \"\",\r\n          \"type\": \"uint256\"\r\n        }\r\n      ],\r\n      \"name\": \"landIds\",\r\n      \"outputs\": [\r\n        {\r\n          \"internalType\": \"uint256\",\r\n          \"name\": \"\",\r\n          \"type\": \"uint256\"\r\n        }\r\n      ],\r\n      \"stateMutability\": \"view\",\r\n      \"type\": \"function\"\r\n    },\r\n    {\r\n      \"inputs\": [\r\n        {\r\n          \"internalType\": \"uint256\",\r\n          \"name\": \"\",\r\n          \"type\": \"uint256\"\r\n        },\r\n        {\r\n          \"internalType\": \"uint256\",\r\n          \"name\": \"\",\r\n          \"type\": \"uint256\"\r\n        }\r\n      ],\r\n      \"name\": \"map\",\r\n      \"outputs\": [\r\n        {\r\n          \"internalType\": \"uint256\",\r\n          \"name\": \"\",\r\n          \"type\": \"uint256\"\r\n        }\r\n      ],\r\n      \"stateMutability\": \"view\",\r\n      \"type\": \"function\"\r\n    },\r\n    {\r\n      \"inputs\": [\r\n        {\r\n          \"internalType\": \"uint256\",\r\n          \"name\": \"xIndex\",\r\n          \"type\": \"uint256\"\r\n        },\r\n        {\r\n          \"internalType\": \"uint256\",\r\n          \"name\": \"yIndex\",\r\n          \"type\": \"uint256\"\r\n        }\r\n      ],\r\n      \"name\": \"mint\",\r\n      \"outputs\": [\r\n        {\r\n          \"internalType\": \"uint256\",\r\n          \"name\": \"\",\r\n          \"type\": \"uint256\"\r\n        }\r\n      ],\r\n      \"stateMutability\": \"nonpayable\",\r\n      \"type\": \"function\"\r\n    },\r\n    {\r\n      \"inputs\": [],\r\n      \"name\": \"name\",\r\n      \"outputs\": [\r\n        {\r\n          \"internalType\": \"string\",\r\n          \"name\": \"\",\r\n          \"type\": \"string\"\r\n        }\r\n      ],\r\n      \"stateMutability\": \"view\",\r\n      \"type\": \"function\"\r\n    },\r\n    {\r\n      \"inputs\": [\r\n        {\r\n          \"internalType\": \"address\",\r\n          \"name\": \"\",\r\n          \"type\": \"address\"\r\n        },\r\n        {\r\n          \"internalType\": \"address\",\r\n          \"name\": \"\",\r\n          \"type\": \"address\"\r\n        },\r\n        {\r\n          \"internalType\": \"uint256[]\",\r\n          \"name\": \"\",\r\n          \"type\": \"uint256[]\"\r\n        },\r\n        {\r\n          \"internalType\": \"uint256[]\",\r\n          \"name\": \"\",\r\n          \"type\": \"uint256[]\"\r\n        },\r\n        {\r\n          \"internalType\": \"bytes\",\r\n          \"name\": \"\",\r\n          \"type\": \"bytes\"\r\n        }\r\n      ],\r\n      \"name\": \"onERC1155BatchReceived\",\r\n      \"outputs\": [\r\n        {\r\n          \"internalType\": \"bytes4\",\r\n          \"name\": \"\",\r\n          \"type\": \"bytes4\"\r\n        }\r\n      ],\r\n      \"stateMutability\": \"nonpayable\",\r\n      \"type\": \"function\"\r\n    },\r\n    {\r\n      \"inputs\": [\r\n        {\r\n          \"internalType\": \"address\",\r\n          \"name\": \"\",\r\n          \"type\": \"address\"\r\n        },\r\n        {\r\n          \"internalType\": \"address\",\r\n          \"name\": \"\",\r\n          \"type\": \"address\"\r\n        },\r\n        {\r\n          \"internalType\": \"uint256\",\r\n          \"name\": \"\",\r\n          \"type\": \"uint256\"\r\n        },\r\n        {\r\n          \"internalType\": \"uint256\",\r\n          \"name\": \"\",\r\n          \"type\": \"uint256\"\r\n        },\r\n        {\r\n          \"internalType\": \"bytes\",\r\n          \"name\": \"\",\r\n          \"type\": \"bytes\"\r\n        }\r\n      ],\r\n      \"name\": \"onERC1155Received\",\r\n      \"outputs\": [\r\n        {\r\n          \"internalType\": \"bytes4\",\r\n          \"name\": \"\",\r\n          \"type\": \"bytes4\"\r\n        }\r\n      ],\r\n      \"stateMutability\": \"nonpayable\",\r\n      \"type\": \"function\"\r\n    },\r\n    {\r\n      \"inputs\": [],\r\n      \"name\": \"owner\",\r\n      \"outputs\": [\r\n        {\r\n          \"internalType\": \"address\",\r\n          \"name\": \"\",\r\n          \"type\": \"address\"\r\n        }\r\n      ],\r\n      \"stateMutability\": \"view\",\r\n      \"type\": \"function\"\r\n    },\r\n    {\r\n      \"inputs\": [\r\n        {\r\n          \"internalType\": \"uint256\",\r\n          \"name\": \"id\",\r\n          \"type\": \"uint256\"\r\n        }\r\n      ],\r\n      \"name\": \"ownerOf\",\r\n      \"outputs\": [\r\n        {\r\n          \"internalType\": \"address\",\r\n          \"name\": \"owner\",\r\n          \"type\": \"address\"\r\n        }\r\n      ],\r\n      \"stateMutability\": \"view\",\r\n      \"type\": \"function\"\r\n    },\r\n    {\r\n      \"inputs\": [],\r\n      \"name\": \"perSize\",\r\n      \"outputs\": [\r\n        {\r\n          \"internalType\": \"uint256\",\r\n          \"name\": \"\",\r\n          \"type\": \"uint256\"\r\n        }\r\n      ],\r\n      \"stateMutability\": \"view\",\r\n      \"type\": \"function\"\r\n    },\r\n    {\r\n      \"inputs\": [\r\n        {\r\n          \"internalType\": \"uint256\",\r\n          \"name\": \"x\",\r\n          \"type\": \"uint256\"\r\n        },\r\n        {\r\n          \"internalType\": \"uint256\",\r\n          \"name\": \"y\",\r\n          \"type\": \"uint256\"\r\n        },\r\n        {\r\n          \"internalType\": \"uint256\",\r\n          \"name\": \"utilId\",\r\n          \"type\": \"uint256\"\r\n        }\r\n      ],\r\n      \"name\": \"placeItem\",\r\n      \"outputs\": [],\r\n      \"stateMutability\": \"nonpayable\",\r\n      \"type\": \"function\"\r\n    },\r\n    {\r\n      \"inputs\": [\r\n        {\r\n          \"internalType\": \"uint256[]\",\r\n          \"name\": \"x\",\r\n          \"type\": \"uint256[]\"\r\n        },\r\n        {\r\n          \"internalType\": \"uint256[]\",\r\n          \"name\": \"y\",\r\n          \"type\": \"uint256[]\"\r\n        },\r\n        {\r\n          \"internalType\": \"uint256[]\",\r\n          \"name\": \"utilId\",\r\n          \"type\": \"uint256[]\"\r\n        }\r\n      ],\r\n      \"name\": \"placeItems\",\r\n      \"outputs\": [],\r\n      \"stateMutability\": \"nonpayable\",\r\n      \"type\": \"function\"\r\n    },\r\n    {\r\n      \"inputs\": [\r\n        {\r\n          \"internalType\": \"uint256\",\r\n          \"name\": \"x\",\r\n          \"type\": \"uint256\"\r\n        },\r\n        {\r\n          \"internalType\": \"uint256\",\r\n          \"name\": \"y\",\r\n          \"type\": \"uint256\"\r\n        }\r\n      ],\r\n      \"name\": \"removeItem\",\r\n      \"outputs\": [],\r\n      \"stateMutability\": \"nonpayable\",\r\n      \"type\": \"function\"\r\n    },\r\n    {\r\n      \"inputs\": [\r\n        {\r\n          \"internalType\": \"address\",\r\n          \"name\": \"from\",\r\n          \"type\": \"address\"\r\n        },\r\n        {\r\n          \"internalType\": \"address\",\r\n          \"name\": \"to\",\r\n          \"type\": \"address\"\r\n        },\r\n        {\r\n          \"internalType\": \"uint256\",\r\n          \"name\": \"id\",\r\n          \"type\": \"uint256\"\r\n        }\r\n      ],\r\n      \"name\": \"safeTransferFrom\",\r\n      \"outputs\": [],\r\n      \"stateMutability\": \"nonpayable\",\r\n      \"type\": \"function\"\r\n    },\r\n    {\r\n      \"inputs\": [\r\n        {\r\n          \"internalType\": \"address\",\r\n          \"name\": \"from\",\r\n          \"type\": \"address\"\r\n        },\r\n        {\r\n          \"internalType\": \"address\",\r\n          \"name\": \"to\",\r\n          \"type\": \"address\"\r\n        },\r\n        {\r\n          \"internalType\": \"uint256\",\r\n          \"name\": \"id\",\r\n          \"type\": \"uint256\"\r\n        },\r\n        {\r\n          \"internalType\": \"bytes\",\r\n          \"name\": \"data\",\r\n          \"type\": \"bytes\"\r\n        }\r\n      ],\r\n      \"name\": \"safeTransferFrom\",\r\n      \"outputs\": [],\r\n      \"stateMutability\": \"nonpayable\",\r\n      \"type\": \"function\"\r\n    },\r\n    {\r\n      \"inputs\": [\r\n        {\r\n          \"internalType\": \"address\",\r\n          \"name\": \"operator\",\r\n          \"type\": \"address\"\r\n        },\r\n        {\r\n          \"internalType\": \"bool\",\r\n          \"name\": \"approved\",\r\n          \"type\": \"bool\"\r\n        }\r\n      ],\r\n      \"name\": \"setApprovalForAll\",\r\n      \"outputs\": [],\r\n      \"stateMutability\": \"nonpayable\",\r\n      \"type\": \"function\"\r\n    },\r\n    {\r\n      \"inputs\": [],\r\n      \"name\": \"size\",\r\n      \"outputs\": [\r\n        {\r\n          \"internalType\": \"uint256\",\r\n          \"name\": \"\",\r\n          \"type\": \"uint256\"\r\n        }\r\n      ],\r\n      \"stateMutability\": \"view\",\r\n      \"type\": \"function\"\r\n    },\r\n    {\r\n      \"inputs\": [\r\n        {\r\n          \"internalType\": \"bytes4\",\r\n          \"name\": \"interfaceId\",\r\n          \"type\": \"bytes4\"\r\n        }\r\n      ],\r\n      \"name\": \"supportsInterface\",\r\n      \"outputs\": [\r\n        {\r\n          \"internalType\": \"bool\",\r\n          \"name\": \"\",\r\n          \"type\": \"bool\"\r\n        }\r\n      ],\r\n      \"stateMutability\": \"view\",\r\n      \"type\": \"function\"\r\n    },\r\n    {\r\n      \"inputs\": [],\r\n      \"name\": \"symbol\",\r\n      \"outputs\": [\r\n        {\r\n          \"internalType\": \"string\",\r\n          \"name\": \"\",\r\n          \"type\": \"string\"\r\n        }\r\n      ],\r\n      \"stateMutability\": \"view\",\r\n      \"type\": \"function\"\r\n    },\r\n    {\r\n      \"inputs\": [\r\n        {\r\n          \"internalType\": \"uint256\",\r\n          \"name\": \"id\",\r\n          \"type\": \"uint256\"\r\n        }\r\n      ],\r\n      \"name\": \"tokenURI\",\r\n      \"outputs\": [\r\n        {\r\n          \"internalType\": \"string\",\r\n          \"name\": \"\",\r\n          \"type\": \"string\"\r\n        }\r\n      ],\r\n      \"stateMutability\": \"view\",\r\n      \"type\": \"function\"\r\n    },\r\n    {\r\n      \"inputs\": [\r\n        {\r\n          \"internalType\": \"address\",\r\n          \"name\": \"from\",\r\n          \"type\": \"address\"\r\n        },\r\n        {\r\n          \"internalType\": \"address\",\r\n          \"name\": \"to\",\r\n          \"type\": \"address\"\r\n        },\r\n        {\r\n          \"internalType\": \"uint256\",\r\n          \"name\": \"id\",\r\n          \"type\": \"uint256\"\r\n        }\r\n      ],\r\n      \"name\": \"transferFrom\",\r\n      \"outputs\": [],\r\n      \"stateMutability\": \"nonpayable\",\r\n      \"type\": \"function\"\r\n    },\r\n    {\r\n      \"inputs\": [\r\n        {\r\n          \"internalType\": \"address\",\r\n          \"name\": \"newOwner\",\r\n          \"type\": \"address\"\r\n        }\r\n      ],\r\n      \"name\": \"transferOwnership\",\r\n      \"outputs\": [],\r\n      \"stateMutability\": \"nonpayable\",\r\n      \"type\": \"function\"\r\n    },\r\n    {\r\n      \"inputs\": [],\r\n      \"name\": \"utilCount\",\r\n      \"outputs\": [\r\n        {\r\n          \"internalType\": \"uint256\",\r\n          \"name\": \"\",\r\n          \"type\": \"uint256\"\r\n        }\r\n      ],\r\n      \"stateMutability\": \"view\",\r\n      \"type\": \"function\"\r\n    },\r\n    {\r\n      \"inputs\": [],\r\n      \"name\": \"utilsAddress\",\r\n      \"outputs\": [\r\n        {\r\n          \"internalType\": \"address\",\r\n          \"name\": \"\",\r\n          \"type\": \"address\"\r\n        }\r\n      ],\r\n      \"stateMutability\": \"view\",\r\n      \"type\": \"function\"\r\n    }\r\n  ]";
    string utilsContractAddress = "0x4b22e4f5cfCb3e648a6F42Fa9D4E55985f9647D1";
    string utilsContractABI = "[\r\n    {\r\n      \"inputs\": [\r\n        {\r\n          \"internalType\": \"string\",\r\n          \"name\": \"_baseUri\",\r\n          \"type\": \"string\"\r\n        }\r\n      ],\r\n      \"stateMutability\": \"nonpayable\",\r\n      \"type\": \"constructor\"\r\n    },\r\n    {\r\n      \"anonymous\": false,\r\n      \"inputs\": [\r\n        {\r\n          \"indexed\": true,\r\n          \"internalType\": \"address\",\r\n          \"name\": \"owner\",\r\n          \"type\": \"address\"\r\n        },\r\n        {\r\n          \"indexed\": true,\r\n          \"internalType\": \"address\",\r\n          \"name\": \"operator\",\r\n          \"type\": \"address\"\r\n        },\r\n        {\r\n          \"indexed\": false,\r\n          \"internalType\": \"bool\",\r\n          \"name\": \"approved\",\r\n          \"type\": \"bool\"\r\n        }\r\n      ],\r\n      \"name\": \"ApprovalForAll\",\r\n      \"type\": \"event\"\r\n    },\r\n    {\r\n      \"anonymous\": false,\r\n      \"inputs\": [\r\n        {\r\n          \"indexed\": true,\r\n          \"internalType\": \"address\",\r\n          \"name\": \"user\",\r\n          \"type\": \"address\"\r\n        },\r\n        {\r\n          \"indexed\": true,\r\n          \"internalType\": \"address\",\r\n          \"name\": \"newOwner\",\r\n          \"type\": \"address\"\r\n        }\r\n      ],\r\n      \"name\": \"OwnershipTransferred\",\r\n      \"type\": \"event\"\r\n    },\r\n    {\r\n      \"anonymous\": false,\r\n      \"inputs\": [\r\n        {\r\n          \"indexed\": true,\r\n          \"internalType\": \"address\",\r\n          \"name\": \"operator\",\r\n          \"type\": \"address\"\r\n        },\r\n        {\r\n          \"indexed\": true,\r\n          \"internalType\": \"address\",\r\n          \"name\": \"from\",\r\n          \"type\": \"address\"\r\n        },\r\n        {\r\n          \"indexed\": true,\r\n          \"internalType\": \"address\",\r\n          \"name\": \"to\",\r\n          \"type\": \"address\"\r\n        },\r\n        {\r\n          \"indexed\": false,\r\n          \"internalType\": \"uint256[]\",\r\n          \"name\": \"ids\",\r\n          \"type\": \"uint256[]\"\r\n        },\r\n        {\r\n          \"indexed\": false,\r\n          \"internalType\": \"uint256[]\",\r\n          \"name\": \"amounts\",\r\n          \"type\": \"uint256[]\"\r\n        }\r\n      ],\r\n      \"name\": \"TransferBatch\",\r\n      \"type\": \"event\"\r\n    },\r\n    {\r\n      \"anonymous\": false,\r\n      \"inputs\": [\r\n        {\r\n          \"indexed\": true,\r\n          \"internalType\": \"address\",\r\n          \"name\": \"operator\",\r\n          \"type\": \"address\"\r\n        },\r\n        {\r\n          \"indexed\": true,\r\n          \"internalType\": \"address\",\r\n          \"name\": \"from\",\r\n          \"type\": \"address\"\r\n        },\r\n        {\r\n          \"indexed\": true,\r\n          \"internalType\": \"address\",\r\n          \"name\": \"to\",\r\n          \"type\": \"address\"\r\n        },\r\n        {\r\n          \"indexed\": false,\r\n          \"internalType\": \"uint256\",\r\n          \"name\": \"id\",\r\n          \"type\": \"uint256\"\r\n        },\r\n        {\r\n          \"indexed\": false,\r\n          \"internalType\": \"uint256\",\r\n          \"name\": \"amount\",\r\n          \"type\": \"uint256\"\r\n        }\r\n      ],\r\n      \"name\": \"TransferSingle\",\r\n      \"type\": \"event\"\r\n    },\r\n    {\r\n      \"anonymous\": false,\r\n      \"inputs\": [\r\n        {\r\n          \"indexed\": false,\r\n          \"internalType\": \"string\",\r\n          \"name\": \"value\",\r\n          \"type\": \"string\"\r\n        },\r\n        {\r\n          \"indexed\": true,\r\n          \"internalType\": \"uint256\",\r\n          \"name\": \"id\",\r\n          \"type\": \"uint256\"\r\n        }\r\n      ],\r\n      \"name\": \"URI\",\r\n      \"type\": \"event\"\r\n    },\r\n    {\r\n      \"inputs\": [\r\n        {\r\n          \"internalType\": \"address\",\r\n          \"name\": \"\",\r\n          \"type\": \"address\"\r\n        },\r\n        {\r\n          \"internalType\": \"uint256\",\r\n          \"name\": \"\",\r\n          \"type\": \"uint256\"\r\n        }\r\n      ],\r\n      \"name\": \"balanceOf\",\r\n      \"outputs\": [\r\n        {\r\n          \"internalType\": \"uint256\",\r\n          \"name\": \"\",\r\n          \"type\": \"uint256\"\r\n        }\r\n      ],\r\n      \"stateMutability\": \"view\",\r\n      \"type\": \"function\"\r\n    },\r\n    {\r\n      \"inputs\": [\r\n        {\r\n          \"internalType\": \"address[]\",\r\n          \"name\": \"owners\",\r\n          \"type\": \"address[]\"\r\n        },\r\n        {\r\n          \"internalType\": \"uint256[]\",\r\n          \"name\": \"ids\",\r\n          \"type\": \"uint256[]\"\r\n        }\r\n      ],\r\n      \"name\": \"balanceOfBatch\",\r\n      \"outputs\": [\r\n        {\r\n          \"internalType\": \"uint256[]\",\r\n          \"name\": \"balances\",\r\n          \"type\": \"uint256[]\"\r\n        }\r\n      ],\r\n      \"stateMutability\": \"view\",\r\n      \"type\": \"function\"\r\n    },\r\n    {\r\n      \"inputs\": [],\r\n      \"name\": \"baseUri\",\r\n      \"outputs\": [\r\n        {\r\n          \"internalType\": \"string\",\r\n          \"name\": \"\",\r\n          \"type\": \"string\"\r\n        }\r\n      ],\r\n      \"stateMutability\": \"view\",\r\n      \"type\": \"function\"\r\n    },\r\n    {\r\n      \"inputs\": [\r\n        {\r\n          \"internalType\": \"address\",\r\n          \"name\": \"\",\r\n          \"type\": \"address\"\r\n        },\r\n        {\r\n          \"internalType\": \"address\",\r\n          \"name\": \"\",\r\n          \"type\": \"address\"\r\n        }\r\n      ],\r\n      \"name\": \"isApprovedForAll\",\r\n      \"outputs\": [\r\n        {\r\n          \"internalType\": \"bool\",\r\n          \"name\": \"\",\r\n          \"type\": \"bool\"\r\n        }\r\n      ],\r\n      \"stateMutability\": \"view\",\r\n      \"type\": \"function\"\r\n    },\r\n    {\r\n      \"inputs\": [\r\n        {\r\n          \"internalType\": \"uint256\",\r\n          \"name\": \"amount\",\r\n          \"type\": \"uint256\"\r\n        }\r\n      ],\r\n      \"name\": \"mint\",\r\n      \"outputs\": [],\r\n      \"stateMutability\": \"nonpayable\",\r\n      \"type\": \"function\"\r\n    },\r\n    {\r\n      \"inputs\": [],\r\n      \"name\": \"owner\",\r\n      \"outputs\": [\r\n        {\r\n          \"internalType\": \"address\",\r\n          \"name\": \"\",\r\n          \"type\": \"address\"\r\n        }\r\n      ],\r\n      \"stateMutability\": \"view\",\r\n      \"type\": \"function\"\r\n    },\r\n    {\r\n      \"inputs\": [\r\n        {\r\n          \"internalType\": \"address\",\r\n          \"name\": \"from\",\r\n          \"type\": \"address\"\r\n        },\r\n        {\r\n          \"internalType\": \"address\",\r\n          \"name\": \"to\",\r\n          \"type\": \"address\"\r\n        },\r\n        {\r\n          \"internalType\": \"uint256[]\",\r\n          \"name\": \"ids\",\r\n          \"type\": \"uint256[]\"\r\n        },\r\n        {\r\n          \"internalType\": \"uint256[]\",\r\n          \"name\": \"amounts\",\r\n          \"type\": \"uint256[]\"\r\n        },\r\n        {\r\n          \"internalType\": \"bytes\",\r\n          \"name\": \"data\",\r\n          \"type\": \"bytes\"\r\n        }\r\n      ],\r\n      \"name\": \"safeBatchTransferFrom\",\r\n      \"outputs\": [],\r\n      \"stateMutability\": \"nonpayable\",\r\n      \"type\": \"function\"\r\n    },\r\n    {\r\n      \"inputs\": [\r\n        {\r\n          \"internalType\": \"address\",\r\n          \"name\": \"from\",\r\n          \"type\": \"address\"\r\n        },\r\n        {\r\n          \"internalType\": \"address\",\r\n          \"name\": \"to\",\r\n          \"type\": \"address\"\r\n        },\r\n        {\r\n          \"internalType\": \"uint256\",\r\n          \"name\": \"id\",\r\n          \"type\": \"uint256\"\r\n        },\r\n        {\r\n          \"internalType\": \"uint256\",\r\n          \"name\": \"amount\",\r\n          \"type\": \"uint256\"\r\n        },\r\n        {\r\n          \"internalType\": \"bytes\",\r\n          \"name\": \"data\",\r\n          \"type\": \"bytes\"\r\n        }\r\n      ],\r\n      \"name\": \"safeTransferFrom\",\r\n      \"outputs\": [],\r\n      \"stateMutability\": \"nonpayable\",\r\n      \"type\": \"function\"\r\n    },\r\n    {\r\n      \"inputs\": [\r\n        {\r\n          \"internalType\": \"address\",\r\n          \"name\": \"operator\",\r\n          \"type\": \"address\"\r\n        },\r\n        {\r\n          \"internalType\": \"bool\",\r\n          \"name\": \"approved\",\r\n          \"type\": \"bool\"\r\n        }\r\n      ],\r\n      \"name\": \"setApprovalForAll\",\r\n      \"outputs\": [],\r\n      \"stateMutability\": \"nonpayable\",\r\n      \"type\": \"function\"\r\n    },\r\n    {\r\n      \"inputs\": [\r\n        {\r\n          \"internalType\": \"bytes4\",\r\n          \"name\": \"interfaceId\",\r\n          \"type\": \"bytes4\"\r\n        }\r\n      ],\r\n      \"name\": \"supportsInterface\",\r\n      \"outputs\": [\r\n        {\r\n          \"internalType\": \"bool\",\r\n          \"name\": \"\",\r\n          \"type\": \"bool\"\r\n        }\r\n      ],\r\n      \"stateMutability\": \"view\",\r\n      \"type\": \"function\"\r\n    },\r\n    {\r\n      \"inputs\": [\r\n        {\r\n          \"internalType\": \"address\",\r\n          \"name\": \"newOwner\",\r\n          \"type\": \"address\"\r\n        }\r\n      ],\r\n      \"name\": \"transferOwnership\",\r\n      \"outputs\": [],\r\n      \"stateMutability\": \"nonpayable\",\r\n      \"type\": \"function\"\r\n    },\r\n    {\r\n      \"inputs\": [\r\n        {\r\n          \"internalType\": \"uint256\",\r\n          \"name\": \"id\",\r\n          \"type\": \"uint256\"\r\n        }\r\n      ],\r\n      \"name\": \"uri\",\r\n      \"outputs\": [\r\n        {\r\n          \"internalType\": \"string\",\r\n          \"name\": \"\",\r\n          \"type\": \"string\"\r\n        }\r\n      ],\r\n      \"stateMutability\": \"view\",\r\n      \"type\": \"function\"\r\n    },\r\n    {\r\n      \"inputs\": [],\r\n      \"name\": \"utilCount\",\r\n      \"outputs\": [\r\n        {\r\n          \"internalType\": \"uint256\",\r\n          \"name\": \"\",\r\n          \"type\": \"uint256\"\r\n        }\r\n      ],\r\n      \"stateMutability\": \"view\",\r\n      \"type\": \"function\"\r\n    }\r\n  ]";

    public static ContractManager Instance { get; private set; }
    public MapManager mapManager;
    public PlacementManager placementManager;
    private void Awake()
    {
        // Single persistent instance at all times.

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Debug.LogWarning("Two ContractManager instances were found, removing this one.");
            Destroy(this.gameObject);
            return;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        InitializeMap();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private async void InitializeMap()
    {
        var size = await getMapSize();
        placementManager.InitializeMap(size);
        mapManager.updateGridSize(size);
    }

    public void OnWalletConnect()
    {

    }

    public async Task<int> getMapSize()
    {
        Contract mapContract = ThirdwebManager.Instance.SDK.GetContract(mapContractAddress, mapContractABI);
        var size = await mapContract.Read<int>("size");
        Debug.Log("Size: " + size);
        return size;
    }

    public void OnWalletDisconnect()
    {

    }

    public void OnSwitchNetwork()
    {

    }
}
