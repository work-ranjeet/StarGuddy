import { Component } from "@angular/core";
import { ProfileService } from "../profile.Service";
import IPhysicalAppearance = App.Client.Profile.IPhysicalAppearanceModal;

@Component({
    selector: "profile-physicalDetails",
    templateUrl: "./././physicalDetails.component.html"
})


export class PhysicalDetailsComponent {
    public showPhysicalAppearance: boolean = false;
    public PhysicalAppearanceResult: IPhysicalAppearance = {} as IPhysicalAppearance;

    constructor(private readonly profileService: ProfileService) { }

    ngOnInit() {
        this.loadData();
    }

    loadData() {
        this.profileService.GetUserPhysicalAppreance().subscribe(
            result => {
                if (result != null) {
                    this.bindResultToView(result);
                }
                else {
                    console.error("GetUserPhysicalAppreance: Error occurred.")
                }
            },
            error => {
                this.showPhysicalAppearance = false;
            });
    }

    bindResultToView(physicalAppearance: IPhysicalAppearance) {
        if (physicalAppearance != undefined) {
            var height = this.heightJson.find(x => x.key == physicalAppearance.height);
            this.PhysicalAppearanceResult.height = height != undefined ? height.value : "";

            var ethnicity = this.EthnicityJson.find(x => x.key == physicalAppearance.ethnicity);
            this.PhysicalAppearanceResult.ethnicity = ethnicity != undefined ? ethnicity.value : "";

            var eyeColor = this.eyeColorJson.find(x => x.key == physicalAppearance.eyeColor);
            this.PhysicalAppearanceResult.eyeColor = eyeColor != undefined ? eyeColor.value : "";

            var bodyType = this.bodyTypeJson.find(x => x.key == physicalAppearance.bodyType);
            this.PhysicalAppearanceResult.bodyType = bodyType != undefined ? bodyType.value : "";

            var hairType = this.hairTypeJson.find(x => x.key == physicalAppearance.hairType);
            this.PhysicalAppearanceResult.hairType = hairType != undefined ? hairType.value : "";

            var weight = this.weightJson.find(x => x.key == physicalAppearance.weight);
            this.PhysicalAppearanceResult.weight = weight != undefined ? weight.value : "";

            var skinColor = this.skinColorJson.find(x => x.key == physicalAppearance.skinColor);
            this.PhysicalAppearanceResult.skinColor = skinColor != undefined ? skinColor.value : "";

            var chest = this.chestJson.find(x => x.key == physicalAppearance.chest);
            this.PhysicalAppearanceResult.chest = chest != undefined ? chest.value : "";

            var hairLength = this.hairLengthJson.find(x => x.key == physicalAppearance.hairLength);
            this.PhysicalAppearanceResult.hairLength = hairLength != undefined ? hairLength.value : "";

            var hairColor = this.hairColorJson.find(x => x.key == physicalAppearance.hairColor);
            this.PhysicalAppearanceResult.hairColor = hairColor != undefined ? hairColor.value : "";

            this.showPhysicalAppearance = height != undefined || ethnicity != undefined || eyeColor != undefined || bodyType != undefined ||
                hairType != undefined || weight != undefined || skinColor != undefined || chest != undefined || hairLength != undefined || hairColor != undefined;
        }
        else {
            this.showPhysicalAppearance = false;
        }
    }

    public heightJson = [
        { key: "24", value: "Less than 132 cm / 4ft 4in" },
        { key: "25", value: "132 cm / 4ft 4in" },
        { key: "26", value: "134 cm / 4ft 5in" },
        { key: "27", value: "137 cm / 4ft 6in" },
        { key: "28", value: "139 cm / 4ft 7in" },
        { key: "29", value: "142 cm / 4ft 8in" },
        { key: "30", value: "144 cm / 4ft 9in" },
        { key: "31", value: "147 cm / 4ft 10in" },
        { key: "32", value: "149 cm / 4ft 11in" },
        { key: "33", value: "152 cm / 5ft 0in" },
        { key: "34", value: "154 cm / 5ft 1in" },
        { key: "35", value: "157 cm / 5ft 2in" },
        { key: "36", value: "160 cm / 5ft 3in" },
        { key: "37", value: "162 cm / 5ft 4in" },
        { key: "38", value: "165 cm / 5ft 5in" },
        { key: "39", value: "167 cm / 5ft 6in" },
        { key: "40", value: "170 cm / 5ft 7in" },
        { key: "41", value: "172 cm / 5ft 8in" },
        { key: "42", value: "175 cm / 5ft 9in" },
        { key: "43", value: "177 cm / 5ft 10in" },
        { key: "44", value: "180 cm / 5ft 11in" },
        { key: "45", value: "182 cm / 6ft 0in" },
        { key: "46", value: "185 cm / 6ft 1in" },
        { key: "47", value: "187 cm / 6ft 2in" },
        { key: "48", value: "190 cm / 6ft 3in" },
        { key: "49", value: "193 cm / 6ft 4in" },
        { key: "50", value: "195 cm / 6ft 5in" },
        { key: "51", value: "198 cm / 6ft 6in" },
        { key: "52", value: "200 cm / 6ft 7in" },
        { key: "53", value: "203 cm / 6ft 8in" },
        { key: "54", value: "205 cm / 6ft 9in" },
        { key: "55", value: "208 cm / 6ft 10in" },
        { key: "56", value: "over 208 cm / 6ft 10" }

    ]

    public EthnicityJson = [
        { key: "13", value: "Aboriginal / Torres Strait Islander" },
        { key: "14", value: "Asian" },
        { key: "15", value: "Black / African descent" },
        { key: "16", value: "East Indian" },
        { key: "17", value: "Latino / Hispanic" },
        { key: "18", value: "Maori" },
        { key: "19", value: "Middle Eastern" },
        { key: "20", value: "Native American" },
        { key: "21", value: "Pacific Islander" },
        { key: "22", value: "White / Caucasian" },
        { key: "23", value: "Other" }];

    public eyeColorJson = [
        { key: "289", value: "Black" },
        { key: "290", value: "Blue" },
        { key: "291", value: "Brown" },
        { key: "292", value: "Green" },
        { key: "293", value: "Grey" },
        { key: "294", value: "Hazel" }];

    public bodyTypeJson = [
        { key: "162", value: "Slim" },
        { key: "163", value: "Average" },
        { key: "164", value: "Faty" }
    ];

    public hairTypeJson = [
        { key: "247", value: "Straight" },
        { key: "248", value: "Wavy" },
        { key: "249", value: "Curly" },
        { key: "250", value: "Afro" },
        { key: "251", value: "Bald" }];

    public weightJson = [
        { key: "57", value: "Less than 40 kg / 88 lbs" },
        { key: "58", value: "40 kg / 88 lbs" },
        { key: "59", value: "41 kg / 90 lbs" },
        { key: "60", value: "42 kg / 92 lbs" },
        { key: "61", value: "43 kg / 94 lbs" },
        { key: "62", value: "44 kg / 96 lbs" },
        { key: "63", value: "45 kg / 99 lbs" },
        { key: "64", value: "46 kg / 101 lbs" },
        { key: "65", value: "47 kg / 103 lbs" },
        { key: "66", value: "48 kg / 105 lbs" },
        { key: "67", value: "49 kg / 107 lbs" },
        { key: "68", value: "50 kg / 110 lbs" },
        { key: "69", value: "51 kg / 112 lbs" },
        { key: "70", value: "52 kg / 114 lbs" },
        { key: "71", value: "53 kg / 116 lbs" },
        { key: "72", value: "54 kg / 118 lbs" },
        { key: "73", value: "55 kg / 121 lbs" },
        { key: "74", value: "56 kg / 123 lbs" },
        { key: "75", value: "57 kg / 125 lbs" },
        { key: "76", value: "58 kg / 127 lbs" },
        { key: "77", value: "59 kg / 129 lbs" },
        { key: "78", value: "60 kg / 132 lbs" },
        { key: "79", value: "61 kg / 134 lbs" },
        { key: "80", value: "62 kg / 136 lbs" },
        { key: "81", value: "63 kg / 138 lbs" },
        { key: "82", value: "64 kg / 140 lbs" },
        { key: "83", value: "65 kg / 143 lbs" },
        { key: "84", value: "66 kg / 145 lbs" },
        { key: "85", value: "67 kg / 147 lbs" },
        { key: "86", value: "68 kg / 149 lbs" },
        { key: "87", value: "69 kg / 151 lbs" },
        { key: "88", value: "70 kg / 154 lbs" },
        { key: "89", value: "71 kg / 156 lbs" },
        { key: "90", value: "72 kg / 158 lbs" },
        { key: "91", value: "73 kg / 160 lbs" },
        { key: "92", value: "74 kg / 162 lbs" },
        { key: "93", value: "75 kg / 165 lbs" },
        { key: "94", value: "76 kg / 167 lbs" },
        { key: "95", value: "77 kg / 169 lbs" },
        { key: "96", value: "78 kg / 171 lbs" },
        { key: "97", value: "79 kg / 173 lbs" },
        { key: "98", value: "80 kg / 176 lbs" },
        { key: "99", value: "81 kg / 178 lbs" },
        { key: "100", value: "82 kg / 180 lbs" },
        { key: "101", value: "83 kg / 182 lbs" },
        { key: "102", value: "84 kg / 184 lbs" },
        { key: "103", value: "85 kg / 187 lbs" },
        { key: "104", value: "86 kg / 189 lbs" },
        { key: "105", value: "87 kg / 191 lbs" },
        { key: "106", value: "88 kg / 193 lbs" },
        { key: "107", value: "89 kg / 195 lbs" },
        { key: "108", value: "90 kg / 198 lbs" },
        { key: "109", value: "91 kg / 200 lbs" },
        { key: "110", value: "92 kg / 202 lbs" },
        { key: "111", value: "93 kg / 204 lbs" },
        { key: "112", value: "94 kg / 206 lbs" },
        { key: "113", value: "95 kg / 209 lbs" },
        { key: "114", value: "96 kg / 211 lbs" },
        { key: "115", value: "97 kg / 213 lbs" },
        { key: "116", value: "98 kg / 215 lbs" },
        { key: "117", value: "99 kg / 217 lbs" },
        { key: "118", value: "100 kg / 220 lbs" },
        { key: "119", value: "101 kg / 222 lbs" },
        { key: "120", value: "102 kg / 224 lbs" },
        { key: "121", value: "103 kg / 226 lbs" },
        { key: "122", value: "104 kg / 228 lbs" },
        { key: "123", value: "105 kg / 231 lbs" },
        { key: "124", value: "106 kg / 233 lbs" },
        { key: "125", value: "107 kg / 235 lbs" },
        { key: "126", value: "108 kg / 237 lbs" },
        { key: "127", value: "109 kg / 239 lbs" },
        { key: "128", value: "110 kg / 242 lbs" },
        { key: "129", value: "111 kg / 244 lbs" },
        { key: "130", value: "112 kg / 246 lbs" },
        { key: "131", value: "113 kg / 248 lbs" },
        { key: "132", value: "114 kg / 250 lbs" },
        { key: "133", value: "115 kg / 253 lbs" },
        { key: "134", value: "116 kg / 255 lbs" },
        { key: "135", value: "117 kg / 257 lbs" },
        { key: "136", value: "118 kg / 259 lbs" },
        { key: "137", value: "119 kg / 261 lbs" },
        { key: "138", value: "120 kg / 264 lbs" },
        { key: "139", value: "over 120 kg / 264 lbs" }];

    public skinColorJson = [
        { key: "10", value: "Black" },
        { key: "11", value: "Brown" },
        { key: "12", value: "Olive" },
        { key: "13", value: "Tanned" },
        { key: "14", value: "White" },
        { key: "15", value: "Other" }];

    public chestJson = [
        { key: "140", value: "Less than 73 cm / 29 in " },
        { key: "141", value: "73 cm / 29 in " },
        { key: "142", value: "76 cm / 30 in " },
        { key: "143", value: "78 cm / 31 in " },
        { key: "144", value: "81 cm / 32 in " },
        { key: "145", value: "83 cm / 33 in " },
        { key: "146", value: "86 cm / 34 in " },
        { key: "147", value: "88 cm / 35 in " },
        { key: "148", value: "91 cm / 36 in " },
        { key: "149", value: "93 cm / 37 in " },
        { key: "150", value: "96 cm / 38 in " },
        { key: "151", value: "99 cm / 39 in " },
        { key: "152", value: "101 cm / 40 in " },
        { key: "153", value: "104 cm / 41 in " },
        { key: "154", value: "106 cm / 42 in " },
        { key: "155", value: "109 cm / 43 in " },
        { key: "156", value: "111 cm / 44 in " },
        { key: "157", value: "114 cm / 45 in " },
        { key: "158", value: "116 cm / 46 in " },
        { key: "159", value: "119 cm / 47 in " },
        { key: "160", value: "over 119 cm / 47 in " }];

    public hairLengthJson = [
        { key: "243", value: "None " },
        { key: "244", value: "Short " },
        { key: "245", value: "Medium " },
        { key: "246", value: "Long " }];

    public hairColorJson = [
        { key: "236", value: "Auburn " },
        { key: "237", value: "Black " },
        { key: "238", value: "Blonde " },
        { key: "239", value: "Brown " },
        { key: "240", value: "Grey " },
        { key: "241", value: "Red " },
        { key: "242", value: "Other " }];
}
