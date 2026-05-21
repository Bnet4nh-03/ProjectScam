import { update } from "lodash";
import { read } from "xlsx";

const varialbe = {
    resultCode: {
        success: 200,
        tokenExprire: 401
    },
    messageType: {
        error: 'error'
    },
    formatDate: {
        YYYY_DD_MM_HH_mm_ss: 'YYYY-DD-MM HH:mm:ss',
        YYYY_MMM_DD: 'YYYY-MMM-DD',
        YYYY_MM_DD: 'YYYY-MM-DD',
        YYYYMMDDHHmmss: 'YYYYMMDDHHmmss',
        YYYYMMDD: 'YYYYMMDD'
    },
    message: {
        error: 'Hệ thống truy cập quá tải, vui lòng thử lại sau ít phút'
    },

    permission: {
        assy2: {
            Create: 'F_D_ASSY2_C'
        },
        assy1: {
            Create: 'F_D_ASSY1_C'
        },
        hlmApproved: {
            TE: ['T_HLM_SRR_TE'],
            FA: ['T_HLM_SRR_FA'],
            QA: ['T_HLM_SRR_QA']
        },
        hcc :{
            hcc_io_request : ['T_HRC_RHI_R'],   
            hcc_io_hcc_action : ['T_HRC_RHI_H'],    
            hcc_hw_monitor_view : ['T_HRC_HM_V']   
        }
    },
    groupMail: {
        ccMailList: [
            "V1MTE@amkor.com",            
            'thang.vu@amkor.onmicrosoft.com',
            "Canh.Tranvan@amkor.com",
            "ATVTESTLINELD@amkor.com",
            "ATVTESTSHIFTLD@amkor.com",
            "Dai.Caovan@amkor.com",
            "Phuc.Nguyenthihong@amkor.com",
            "Quyet.Nguyenthanh@amkor.com"
        ],
        ccAutoHWMailList: [
            "ATVTESTPM@amkor.com",            
            'V1MTEKIOXIA@amkor.com'
        ],
        bccMailList: [
            "quyen.tranvan@amkor.com","chien.chuvan@amkor.com","Anh.Nguyencongviet@amkor.com"
        ],
        bccAutoHWMailList: [
            "chien.chuvan@amkor.com","Anh.Nguyencongviet@amkor.com","long.phamthanh@amkor.com"
        ]
    },
    sender: {
        autoHW: "ATV_Test_Kioxia_AutoHW@amkor.com"
    },
    backgroundColor: [
        'rgba(251, 65, 4, 0.2)',
        'rgba(15, 75, 143, 0.2)',
        'rgba(2, 130, 159, 0.2)',
        'rgba(127, 23, 75, 0.2)',
        'rgba(68, 155, 140, 0.2)',
        'rgba(74, 62, 110, 0.2)',
        'rgba(217, 141, 40, 0.2)',


        'rgba(75, 192, 192, 0.2)',
        'rgba(255, 99, 132, 0.2)',
        'rgba(54, 162, 235, 0.2)',
        'rgba(153, 102, 255, 0.2)',

        'rgba(0, 128, 128, 0.2)',
        'rgba(124, 252, 0, 0.2)',
        'rgba(255, 192, 203, 0.2)',
        'rgba(128, 128, 128, 0.2)',
        'rgba(128, 0, 0, 0.2)',
        'rgba(0, 0, 128, 0.2)',
        'rgba(255, 159, 64, 0.2)',
        'rgba(128, 128, 0, 0.2)',
        'rgba(255, 0, 255, 0.2)',
        'rgba(228,176,146,0.2)',
        'rgba(16, 157, 88,0.2)',
        'rgba(158,190,165,0.2)',
        'rgba(255, 205, 86, 0.2)',
        'rgba(251, 162, 208, 0.2)',
        'rgba(34, 126, 156,0.2)',
        'rgba(255,170,54,0.2)',
        'rgba(62, 241, 186,0.2)',
        'rgba(236, 31, 106, 0.2)',
        'rgba(255,180,174,0.2)',
        'rgb(255, 95, 1, 0.2)',
        'rgba(251,193,147,0.2)',
        'rgba(164,207,209,0.2)',
        'rgba(253, 138, 4,0.2)',
        'rgba(172,156,203,0.2)',
        'rgba(105, 102, 205, 0.2)',
        'rgba(249,163,254,0.2)',
        'rgba(249,214,122,0.2)',
        'rgba(163,198,198,0.2)',
        'rgba(197,151,165,0.2)',
        'rgba(222,177,169,0.2)',
        'rgba(254,154,154,0.2)',
        'rgba(192,212,225,0.2)',
        'rgba(219,210,105,0.2)',
        'rgba(208,202,177,0.2)',
        'rgba(205,124,124,0.2)',
        'rgba(124,164,182,0.2)',
        'rgba(255,184,208,0.2)',
        'rgba(228,206,202,0.2)',
        'rgba(255,191,179,0.2)',
        'rgba(196,154,104,0.2)',
        'rgba(255,214,109,0.2)',
        'rgba(203,163,164,0.2)',
        'rgba(228,223,212,0.2)',
        'rgba(144,181,178,0.2)',
        'rgba(167,177,193,0.2)',
        'rgba(228,127,195,0.2)',
        'rgba(249,193,62,0.2)',
        'rgba(248,191,172,0.2)',
        'rgba(255,182,88,0.2)',
        'rgba(215,171,114,0.2)',
        'rgba(224,206,183,0.2)',
        'rgba(241,142,144,0.2)',
        'rgba(229,190,164,0.2)',
        'rgba(253,252,160,0.2)',
        'rgba(174,195,66,0.2)',
        'rgba(144,155,181,0.2)',
        'rgba(216,158,196,0.2)',
        'rgba(252,196,183,0.2)',
        'rgba(228,219,218,0.2)',
        'rgba(3,169,244,0.2)',
        'rgba(254,230,132,0.2)',
        'rgba(201, 203, 207, 0.2)'
    ],

    borderColor: [
        'rgb(251, 65, 4)',
        'rgb(15, 75, 143)',
        'rgb(2, 130, 159)',
        'rgb(127, 23, 75)',
        'rgb(68, 155, 140)',
        'rgb(74, 62, 110)',
        'rgb(217, 141, 40)',

        'rgb(75, 192, 192)',
        'rgb(255, 99, 132)',
        'rgb(54, 162, 235)',
        'rgb(153, 102, 255)',
        'rgb(0, 128, 128)',
        'rgb(124, 252, 0)',
        'rgb(255, 192, 203)',
        'rgb(128, 128, 128)',
        'rgb(128, 0, 0)',
        'rgb(0, 0, 128)',
        'rgb(255, 159, 64)',
        'rgb(128, 128, 0)',
        'rgb(255, 0, 255)',
        'rgb(228,176,146)',
        'rgb(16, 157, 88)',
        'rgb(158,190,165)',
        'rgb(255, 205, 86)',
        'rgb(251, 162, 208)',
        'rgb(34, 126, 156)',
        'rgb(255,170,54)',
        'rgb(62, 241, 186)',
        'rgb(236, 31, 106)',
        'rgb(255,180,174)',
        'rgb(255, 95, 1)',
        'rgb(251,193,147)',
        'rgb(164,207,209)',
        'rgb(253, 138, 4)',
        'rgb(172,156,203)',
        'rgb(105, 102, 205)',
        'rgb(249,163,254)',
        'rgb(249,214,122)',
        'rgb(163,198,198)',
        'rgb(197,151,165)',
        'rgb(222,177,169)',
        'rgb(254,154,154)',
        'rgb(192,212,225)',
        'rgb(219,210,105)',
        'rgb(208,202,177)',
        'rgb(205,124,124)',
        'rgb(124,164,182)',
        'rgb(255,184,208)',
        'rgb(228,206,202)',
        'rgb(255,191,179)',
        'rgb(196,154,104)',
        'rgb(255,214,109)',
        'rgb(203,163,164)',
        'rgb(228,223,212)',
        'rgb(144,181,178)',
        'rgb(167,177,193)',
        'rgb(228,127,195)',
        'rgb(249,193,62)',
        'rgb(248,191,172)',
        'rgb(255,182,88)',
        'rgb(215,171,114)',
        'rgb(224,206,183)',
        'rgb(241,142,144)',
        'rgb(229,190,164)',
        'rgb(253,252,160)',
        'rgb(174,195,66)',
        'rgb(144,155,181)',
        'rgb(216,158,196)',
        'rgb(252,196,183)',
        'rgb(228,219,218)',
        'rgb(3,169,244)',
        'rgb(254,230,132)',
        'rgb(201, 203, 207)'
    ],

    backgroundColorAmkor: [
        'rgba(191, 218, 248, 1)',
        'rgba(128, 181, 242, 1)',
        'rgba(64, 144, 238, 1)',
        'rgba(11, 56, 107, 1)',
        'rgba(8, 38, 71, 1)',

        'rgba(186, 242, 254, 1)',
        'rgba(117, 228, 253, 1)',
        'rgba(48, 215, 252, 1)',
        'rgba(2, 98, 119, 1)',
        'rgba(1, 65, 80, 1)',

        'rgba(244, 194, 219, 1)',
        'rgba(233, 133, 183, 1)',
        'rgba(222, 72, 147, 1)',
        'rgba(95, 17, 56, 1)',
        'rgba(63, 12, 38, 1)',

        'rgba(215, 237, 234, 1)',
        'rgba(175, 220, 212, 1)',
        'rgba(138, 202, 191, 1)',
        'rgba(51, 116, 105, 1)',
        'rgba(34, 78, 70, 1)',

        'rgba(247, 232, 212, 1)',
        'rgba(240, 209, 169, 1)',
        'rgba(232, 187, 126, 1)',
        'rgba(164, 106, 29, 1)',
        'rgba(109, 71, 19, 1)',

        'rgba(216, 212, 231, 1)',
        'rgba(178, 169, 206, 1)',
        'rgba(139, 125, 182, 1)',
        'rgba(55, 46, 83, 1)',
        'rgba(37, 31, 55, 1)',

        'rgba(253, 247, 223, 1)',
        'rgba(250, 237, 192, 1)',
        'rgba(251, 228, 160, 1)',
        'rgba(243, 185, 62, 1)',
        'rgba(161, 123, 58, 1)',


    ],
};

export default varialbe;
