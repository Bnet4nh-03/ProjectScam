import Highcharts from "highcharts";
import HighchartsVue from 'highcharts-vue';
import hcMoreInit from 'highcharts/highcharts-more';
import Highcharts3D from "highcharts/highcharts-3d";
import ExportingInit from "highcharts/modules/exporting";
import OfflineExporting from 'highcharts/modules/offline-exporting';
import ganttInit from 'highcharts/modules/gantt';
import NetworkGraphModule from "highcharts/modules/networkgraph";
import gaugeInit from 'highcharts/modules/solid-gauge';
import stockInit from "highcharts/modules/stock";
import TreeGraphModule from 'highcharts/modules/treegraph'; // Cho TreeGraph
import TreeModule from "highcharts/modules/treemap"; // Cho TreeMap


// Kích hoạt module Exporting
stockInit(Highcharts);
ganttInit(Highcharts);
Highcharts3D(Highcharts);
TreeModule(Highcharts);
TreeGraphModule(Highcharts);
ExportingInit(Highcharts);
OfflineExporting(Highcharts)
NetworkGraphModule(Highcharts);



// important require imoort hcMoreInit before import chart gauge
hcMoreInit(Highcharts);
gaugeInit(Highcharts);


export { Highcharts, HighchartsVue };
