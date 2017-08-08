var headers = [
"Machine",
"Models",
"Links",
"Models/Options",
"Vendor",
"Technology",
"Wavelength",
"Depth of Focus",
"Power",
"Film Resist Sides/hour",
"Soldermask Sides/hour",
"Speed Details",
"Edge Roughness",
"Positional Accuracy / Data Resolution / Alignment Accuracy",
"Registration Accuracy (Side by Side Alignment Accuracy)",
"Line/Space Width",
"Line/Space SEM Image",
"DF Thickness",
"Hole Diameter",
"Hole Diameter Image",
"SRO (solder resist opening)",
"SR Thickness",
"Address Pitch",
"Min. Image Size",
"Max. Image Size",
"Panel Thickness",
"Handling Options",
"Machine Dimensions",
"Double Machine Images",
"Expected Laser DMD Head Lifetime",
"Warranty Standard",
"Warranty Cost/year",
"Mechanical Clamping",
"Autofocus if needed",
"Panel Traceability(Serial Number Tracking)",
"Non-linear Distortion",
"Notes",
];

var products = [{ checked: ko.observable(false), data: ["SpeedLight 2D",
"speedlight.png",
"",
"Integrated (see notes) or Stand alone",
"Manz (formerly KLEO)",
"Laser diodes: 288 beams; 405 nm9 modules, 32 laser diodes per module",
"405nm",
"±300µ",
"",
"Image Size Unknown: 360",
"",
"",
"2 μm",
"2 μm",
"20µm",
"15 μm",
"",
"",
"",
"",
"",
"",
"",
"",
"660 mm width × 650 mm length (extendable)",
"0.05 mm to 8 mm",
"",
"",
"",
"",
"",
"",
"",
"",
"",
"",
"Their integrated solution includes Loading, Pre-cleaning, First buffer, Dry film laminator (third-party product), Second buffer, Laser direct imaging, Third buffer, Mylar peeler (third-party product), Developer, Unloading.",
]},
{ checked: ko.observable(false), data: ["Ledia 6F",
"",
"<a href=\"http://www.screen.co.jp/eng/pcb/products/ledia/index.html\"> website</a>",
"Automatic single-side/Automatic </br>double-sided/Manual</br>Standard/Fine</br>Especially for Soldermask</br>5 or 6 heads",
"Dainippon Screen",
"DMD with UV-LED 5-6 Heads",
"365nm, 385nm, 405nm",
"",
"",
"510X405mm: 187 (Standard)",
"510X405mm: 71 (Standard)",
"lediaspeed.png",
"",
"Fine: 7 micron",
"",
"Fine: 12/12 μm",
"ledia_line.png",
"Fine: 20µm",
"Fine: 40µm",
"",
"",
"Fine: 20 micron",
"1 micron",
"",
"512X661 mm(Optional: 610X661 mm)Large: 612X813mm",
"",
"Manual or Automatic",
"",
"",
"2-3 years",
"",
"",
"",
"",
"",
"Yes",
"",
]},
{ checked: ko.observable(false), data: ["INPREX",
"",
"<a href=\"http://www.adtec.com/pdf/di_lineup.pdf\"> Adtec DI Lineup</a></br><a href=\"http://www.adtec.com/pdf/ip-4000h.pdf\"> ip-4000h</a></br><a href=\"http://www.adtec.com/pdf/is-4000h.pdf\"> IS-4000h (for Soldermask)</a>",
"E Fine/PKG Standard/Stabi </br>Fine/Large Panel",
"Adtec",
"DMD with UV-LED leveraging Fugifilm's laser unit and lens design.",
"Standard: 405nm</br>Solder Resist: 365nm&405nm",
"",
"Standard: 30-40W</br>Large Panel: 34-45</br>WHDI Entry: 20W</br>Stabi Fast: 40-50W</br>Solder Resist: 80W (MAX)",
"",
"",
"",
"",
"Standard: 7.5µm</br>E Fine Prologue: 5µm</br>PKG Standard: 7µm</br>Large Panel: 10µm",
"",
"E Fine Prologue: 6/6µm</br>PKG Standard: 8/8µm</br>Stabi Fine: 12/12µm</br>Large Panel: 15/15µm</br>HDI Entry: 15/15µm</br>HDI Standard: 15/15µm</br>Stabi Fast: 15/15µm",
"inprex_line.png",
"",
"100µm",
"",
"50µm",
"",
"",
"Standard: 334X334mm</br>Large Panel: 483X381mm",
"E Fine Prologue: 546X622mm</br>PKG Standard: 546X622mm</br>Standard 551X640mm</br>Large Panel: 635X838mm",
"",
"Manual or Automatic, Single or Double Sided",
"",
"inprexdmi.png",
"2-3 years",
"",
"",
"Yes",
"Yes",
"",
"Yes",
"",
]},
{ checked: ko.observable(false), data: ["Schmoll",
"",
"",
"",
"",
"",
"",
"",
"",
"",
"",
"",
"",
"",
"",
"",
"",
"",
"",
"",
"",
"",
"",
"",
"",
"",
"",
"",
"",
"",
"",
"",
"",
"",
"",
"",
"Schmoll Maschinen, the well-known supplier of mechanical and laser drilling machines, is now also offering a DDI (digital direct imaging) system, ideal for prototyping innerlayer, out-erlayer, and soldermask images. It is based on semiconductor laser diodes and large (wide) op-tics. The imager is equipped with two to eight diode lasers and can handle a maximum panel size of 610 x 535 mm. Schmoll also offers MDI (micromirror digital imaging) systems. The sys-tems are available as a single-table unit or with a double stage for higher throughput. The units use high-power LEDs and DMD® with multiple waverlengths from 365 to 405 nm.",
]},
{ checked: ko.observable(false), data: ["First EIE SA",
"",
"",
"",
"",
"",
"",
"",
"",
"",
"",
"",
"",
"",
"",
"",
"",
"",
"",
"",
"",
"",
"",
"",
"610mm X 660mm",
"",
"",
"",
"",
"",
"",
"",
"",
"",
"",
"",
"",
]},
{ checked: ko.observable(false), data: ["Aladdin",
"",
"",
"Single Side, Double Side, PSR, Roll to Roll",
"Ajuhitek",
"UV Laser Diode",
"405nm",
"",
"2.5kWhUp to 100mj/㎠",
"Standard Single Side: 100-180 sides/hour</br>Fine Single Side: 55-100 sides/hour",
"",
"",
"Standard: 40μm-50μm</br>Fine: 20μm-25μm",
"20μm",
"20μm",
"Standard: 40μm - 50μm</br>PSR: 50µm</br>Fine: 20μm - 25μm",
"",
"",
"",
"",
"",
"",
"",
"",
"680mm x 620mm",
"",
"Manual or Automatic, </br>Single or Double Sided",
"Single Sided: 1,740mm(W) x 2,640mm(D) x 1,763mm(H)</br>Double Sided: 2,600mm(W) x 2,140mm(D) x 2,100mm(H)</br>PSR: 1,510mm(W) x 2,540mm(D) x 1,968mm(H)",
"aladdindmi.png",
"",
"",
"",
"",
"",
"",
"",
"",
]},
{ checked: ko.observable(false), data: ["Nuvogo 800/1000",
"nuvogo.png",
"<a href=\"http://www.orbotech.com/imgs/uploads/PCB_Brochures_PDF/nuvogo1000_for web.pdf\"> brochure1</a></br><a href=\"http://www.orbotech.com/imgs/uploads/PCB_Brochures_PDF/Nuvogo 800 brochure.pdf\"> brochure2</a>",
"Standard/Fine",
"Orbotech",
"Laser",
"",
"±300µ",
"",
"150",
"",
"",
"",
"",
"20µm",
"18µm",
"nuvogo_line.png",
"",
"",
"",
"75µm",
"",
"",
"",
"",
"",
"",
"",
"nuvogodmi.png",
"2-3 years",
"",
"",
"",
"",
"Yes",
"Yes",
"1000 is designed for solder mask",
]},
];

                    model = {headers: headers, products: products};
                
