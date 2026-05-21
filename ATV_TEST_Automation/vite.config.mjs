import { fileURLToPath, URL } from 'node:url';

import { PrimeVueResolver } from '@primevue/auto-import-resolver';
import vue from '@vitejs/plugin-vue';
import Components from 'unplugin-vue-components/vite';
import { defineConfig, loadEnv } from 'vite';
// https://vitejs.dev/config/
export default defineConfig(({ mode }) => {
    const env = loadEnv(mode, process.cwd());
    const PORT = `${env.VITE_PORT ?? '3001'}`;
    const BUILD_DIRECTORY = `${env.VITE_BUILD_DIRECTORY || 'dist'}`;
    return {
        build: {
            outDir: BUILD_DIRECTORY,    // Đường dẫn đầu ra của bạn
            emptyOutDir: true           // Cho phép xóa thư mục đầu ra nằm ngoài thư mục gốc
        },
        server: {
            watch: {
                ignored: ["!**/node_modules/primevue/**"]
            },
            host: 'localhost',
            port: PORT,
            proxy: {
                '/udata': {
                    target: 'http://10.201.16.55/udata',
                    changeOrigin: true,
                    rewrite: (path) => path.replace(/^\/udata/, '')
            }
    }
        },
        optimizeDeps: {
            include: ["highcharts","quill"],
            //  include: ['quill']
        },
        // optimizeDeps: {
        //     noDiscovery: true,
        //     include: ["highcharts", "highcharts-vue"],
        //     exclude: ['primevue']
        // },
        // optimizeDeps: {
        //     include: ["highcharts", "highcharts-vue"], // Thêm highcharts và highcharts-vue vào danh sách tối ưu
        //     exclude: ['primevue', 'ag-grid-vue3', 'primeicons'],
        // },
        plugins: [
            vue(),
            Components({
                resolvers: [PrimeVueResolver()]
            })
        ],
        resolve: {
            alias: {
                '@': fileURLToPath(new URL('./src', import.meta.url))
            }
        },
    }
});
