cmake_minimum_required(VERSION 3.20)
project(NativeRopeProbe LANGUAGES CXX)

get_filename_component(SERVER_ROOT "${CMAKE_CURRENT_SOURCE_DIR}/../.." ABSOLUTE)
set(PHYSX_ROOT "${SERVER_ROOT}/.local/physx-sdk-3.4" CACHE PATH "Pinned PhysX 3.4 source checkout")

add_executable(NativeRopeProbe "${SERVER_ROOT}/tools/NativeRopeProbe.cpp")
add_library(WarRopePhysics SHARED "${SERVER_ROOT}/native/WarRopePhysics/RopePhysics.cpp")
foreach(ROPE_TARGET IN ITEMS NativeRopeProbe WarRopePhysics)
    target_compile_features(${ROPE_TARGET} PRIVATE cxx_std_14)
    target_include_directories(${ROPE_TARGET} PRIVATE
        "${PHYSX_ROOT}/PhysX_3.4/Include"
        "${PHYSX_ROOT}/PxShared/include")

    if(MSVC)
        set_property(TARGET ${ROPE_TARGET} PROPERTY MSVC_RUNTIME_LIBRARY "MultiThreaded$<$<CONFIG:Debug>:Debug>")
        target_link_libraries(${ROPE_TARGET} PRIVATE
            "${PHYSX_ROOT}/PhysX_3.4/Lib/vc15win64/PhysX3_x64.lib"
            "${PHYSX_ROOT}/PhysX_3.4/Lib/vc15win64/PhysX3Common_x64.lib"
            "${PHYSX_ROOT}/PhysX_3.4/Lib/vc15win64/PhysX3Extensions.lib"
            "${PHYSX_ROOT}/PxShared/lib/vc15win64/PxFoundation_x64.lib"
            "${PHYSX_ROOT}/PxShared/lib/vc15win64/PxPvdSDK_x64.lib")
    elseif(CMAKE_SYSTEM_NAME STREQUAL "Linux")
        target_compile_definitions(${ROPE_TARGET} PRIVATE NDEBUG)
        target_link_libraries(${ROPE_TARGET} PRIVATE
            "${PHYSX_ROOT}/PhysX_3.4/Lib/linux64/libPhysX3Extensions.a"
            "${PHYSX_ROOT}/PhysX_3.4/Bin/linux64/libPhysX3_x64.so"
            "${PHYSX_ROOT}/PhysX_3.4/Bin/linux64/libPhysX3Common_x64.so"
            "${PHYSX_ROOT}/PxShared/bin/linux64/libPxFoundation_x64.so"
            "${PHYSX_ROOT}/PxShared/bin/linux64/libPxPvdSDK_x64.so"
            pthread dl)
        set_property(TARGET ${ROPE_TARGET} PROPERTY BUILD_RPATH
            "${PHYSX_ROOT}/PhysX_3.4/Bin/linux64;${PHYSX_ROOT}/PxShared/bin/linux64")
    else()
        message(FATAL_ERROR "This research probe supports only Windows MSVC and Linux.")
    endif()
endforeach()
