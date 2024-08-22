//Maya ASCII 2018ff09 scene
//Name: dino.ma
//Last modified: Mon, Aug 19, 2024 03:10:55 AM
//Codeset: 1252
file -rdi 1 -ns "model" -rfn "modelRN" -op "VERS|2018ff09|UVER|undef|MADE|undef|CHNG|Sun, Aug 18, 2024 04:14:00 PM|ICON|undef|INFO|undef|OBJN|35|INCL|undef(|LUNI|cm|TUNI|film|AUNI|deg|TDUR|141120000|"
		 -typ "mayaBinary" "C:/Users/yonas/Desktop/trex/Trex_Model//scenes/rig/DinoRig01.mb";
file -r -ns "model" -dr 1 -rfn "modelRN" -op "VERS|2018ff09|UVER|undef|MADE|undef|CHNG|Sun, Aug 18, 2024 04:14:00 PM|ICON|undef|INFO|undef|OBJN|35|INCL|undef(|LUNI|cm|TUNI|film|AUNI|deg|TDUR|141120000|"
		 -typ "mayaBinary" "C:/Users/yonas/Desktop/trex/Trex_Model//scenes/rig/DinoRig01.mb";
requires maya "2018ff09";
requires "mtoa" "3.1.2.1";
requires "stereoCamera" "10.0";
currentUnit -l centimeter -a degree -t film;
fileInfo "application" "maya";
fileInfo "product" "Maya 2018";
fileInfo "version" "2018";
fileInfo "cutIdentifier" "201903222215-65bada0e52";
fileInfo "osv" "Microsoft Windows 8 Home Premium Edition, 64-bit  (Build 9200)\n";
createNode reference -n "modelRN";
	rename -uid "284DEBF2-44AD-E542-6FD1-69831CC15364";
	setAttr ".phl[1]" 0;
	setAttr ".ed" -type "dataReferenceEdits" 
		"modelRN"
		"modelRN" 0
		"modelRN" 13
		2 "model:trex" "displayType" " 1"
		2 "model:trex" "levelOfDetail" " 0"
		2 "model:trex" "shading" " 1"
		2 "model:trex" "texturing" " 1"
		2 "model:trex" "playback" " 1"
		2 "model:trex" "enabled" " 1"
		2 "model:trex" "visibility" " 1"
		2 "model:trex" "hideOnPlayback" " 0"
		2 "model:trex" "overrideRGBColors" " 0"
		2 "model:trex" "color" " 0"
		2 "model:trex" "overrideColorRGB" " -type \"float3\" 0 0 0"
		3 "model:trex.drawInfo" "|model:Dino.drawOverride" ""
		5 4 "modelRN" "|model:Dino.drawOverride" "modelRN.placeHolderList[1]" 
		"";
	setAttr ".ptag" -type "string" "";
lockNode -l 1 ;
createNode displayLayer -n "Hi";
	rename -uid "F7442381-4B65-E074-B429-DC83CBAE9E28";
	setAttr ".do" 1;
createNode displayLayerManager -n "layerManager";
	rename -uid "D25B9466-49FA-CDDB-ED7A-199F4078DEB3";
	setAttr -s 2 ".dli[1]"  1;
	setAttr -s 2 ".dli";
createNode lightLinker -s -n "lightLinker1";
	rename -uid "68526CD3-404A-66B0-644C-A7BB64E6E95E";
	setAttr -s 4 ".lnk";
	setAttr -s 4 ".slnk";
select -ne :time1;
	setAttr ".o" 1;
	setAttr ".unw" 1;
select -ne :hardwareRenderingGlobals;
	setAttr ".otfna" -type "stringArray" 22 "NURBS Curves" "NURBS Surfaces" "Polygons" "Subdiv Surface" "Particles" "Particle Instance" "Fluids" "Strokes" "Image Planes" "UI" "Lights" "Cameras" "Locators" "Joints" "IK Handles" "Deformers" "Motion Trails" "Components" "Hair Systems" "Follicles" "Misc. UI" "Ornaments"  ;
	setAttr ".otfva" -type "Int32Array" 22 0 1 1 1 1 1
		 1 1 1 0 0 0 0 0 0 0 0 0
		 0 0 0 0 ;
	setAttr ".fprt" yes;
select -ne :renderPartition;
	setAttr -s 4 ".st";
select -ne :renderGlobalsList1;
select -ne :defaultShaderList1;
	setAttr -s 6 ".s";
select -ne :postProcessList1;
	setAttr -s 2 ".p";
select -ne :defaultRenderUtilityList1;
select -ne :defaultRenderingList1;
	setAttr -s 2 ".r";
select -ne :defaultTextureList1;
select -ne :initialShadingGroup;
	setAttr ".ro" yes;
select -ne :initialParticleSE;
	setAttr ".ro" yes;
select -ne :defaultRenderGlobals;
	setAttr ".ren" -type "string" "arnold";
select -ne :defaultResolution;
	setAttr ".pa" 1;
select -ne :hardwareRenderGlobals;
	setAttr ".ctrs" 256;
	setAttr ".btrs" 512;
connectAttr "Hi.di" "modelRN.phl[1]";
connectAttr "layerManager.dli[1]" "Hi.id";
relationship "link" ":lightLinker1" ":initialShadingGroup.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" ":initialParticleSE.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" ":initialShadingGroup.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" ":initialParticleSE.message" ":defaultLightSet.message";
// End of dino.ma
