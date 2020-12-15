### Overview ###
This library was designed to generate barcode images from a string of data.

|   Supported   | 
| Codabar       |

### Example ###
```
BarcodeGenerator.Barcode barcode = new BarcodeGenerator.Barcode("978020137962",
                                                BarcodeGenerator.SymbologyType.EAN13);
Image imgBarcode = barcode.DrawBarcode();
```

## Screenshot

![barcode_generator](https://user-images.githubusercontent.com/19513970/36727530-9b29d306-1be3-11e8-91bf-052a3e6383b7.png)

