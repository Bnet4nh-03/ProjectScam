#!/bin/sh
# the next line restarts using wish\
exec wish "$0" "$@" 

if {![info exists vTcl(sourcing)]} {

    # Provoke name search
    catch {package require bogus-package-name}
    set packageNames [package names]

    package require BWidget
    switch $tcl_platform(platform) {
	windows {
	}
	default {
	    option add *ScrolledWindow.size 14
	}
    }
    
    package require Tk
    switch $tcl_platform(platform) {
	windows {
            option add *Button.padY 0
	}
	default {
            option add *Scrollbar.width 10
            option add *Scrollbar.highlightThickness 0
            option add *Scrollbar.elementBorderWidth 2
            option add *Scrollbar.borderWidth 2
	}
    }
    
    # Tix is required
    package require Tix
    
}

#############################################################################
# Visual Tcl v1.60 Project
#


#############################################################################
# vTcl Code to Load Stock Fonts


if {![info exist vTcl(sourcing)]} {
set vTcl(fonts,counter) 0
#############################################################################
## Procedure:  vTcl:font:add_font

proc ::vTcl:font:add_font {font_descr font_type {newkey {}}} {
    ## This procedure may be used free of restrictions.
    ##    Exception added by Christian Gavin on 08/08/02.
    ## Other packages and widget toolkits have different licensing requirements.
    ##    Please read their license agreements for details.

    if {[info exists ::vTcl(fonts,$font_descr,object)]} {
        ## cool, it already exists
        return $::vTcl(fonts,$font_descr,object)
    }

     incr ::vTcl(fonts,counter)
     set newfont [eval font create $font_descr]
     lappend ::vTcl(fonts,objects) $newfont

     ## each font has its unique key so that when a project is
     ## reloaded, the key is used to find the font description
     if {$newkey == ""} {
          set newkey vTcl:font$::vTcl(fonts,counter)

          ## let's find an unused font key
          while {[vTcl:font:get_font $newkey] != ""} {
             incr ::vTcl(fonts,counter)
             set newkey vTcl:font$::vTcl(fonts,counter)
          }
     }

     set ::vTcl(fonts,$newfont,type)       $font_type
     set ::vTcl(fonts,$newfont,key)        $newkey
     set ::vTcl(fonts,$newfont,font_descr) $font_descr
     set ::vTcl(fonts,$font_descr,object)  $newfont
     set ::vTcl(fonts,$newkey,object)      $newfont

     lappend ::vTcl(fonts,$font_type) $newfont

     ## in case caller needs it
     return $newfont
}

#############################################################################
## Procedure:  vTcl:font:getFontFromDescr

proc ::vTcl:font:getFontFromDescr {font_descr} {
    ## This procedure may be used free of restrictions.
    ##    Exception added by Christian Gavin on 08/08/02.
    ## Other packages and widget toolkits have different licensing requirements.
    ##    Please read their license agreements for details.

    if {[info exists ::vTcl(fonts,$font_descr,object)]} {
        return $::vTcl(fonts,$font_descr,object)
    } else {
        return ""
    }
}

}
#############################################################################
# vTcl Code to Load User Fonts

vTcl:font:add_font \
    "-family Arial -size 9 -weight normal -slant roman -underline 0 -overstrike 0" \
    user \
    vTcl:font13
#################################
# VTCL LIBRARY PROCEDURES
#

if {![info exists vTcl(sourcing)]} {
#############################################################################
## Library Procedure:  Window

proc ::Window {args} {
    ## This procedure may be used free of restrictions.
    ##    Exception added by Christian Gavin on 08/08/02.
    ## Other packages and widget toolkits have different licensing requirements.
    ##    Please read their license agreements for details.

    global vTcl
    foreach {cmd name newname} [lrange $args 0 2] {}
    set rest    [lrange $args 3 end]
    if {$name == "" || $cmd == ""} { return }
    if {$newname == ""} { set newname $name }
    if {$name == "."} { wm withdraw $name; return }
    set exists [winfo exists $newname]
    switch $cmd {
        show {
            if {$exists} {
                wm deiconify $newname
            } elseif {[info procs vTclWindow$name] != ""} {
                eval "vTclWindow$name $newname $rest"
            }
            if {[winfo exists $newname] && [wm state $newname] == "normal"} {
                vTcl:FireEvent $newname <<Show>>
            }
        }
        hide    {
            if {$exists} {
                wm withdraw $newname
                vTcl:FireEvent $newname <<Hide>>
                return}
        }
        iconify { if $exists {wm iconify $newname; return} }
        destroy { if $exists {destroy $newname; return} }
    }
}
#############################################################################
## Library Procedure:  vTcl:DefineAlias

proc ::vTcl:DefineAlias {target alias widgetProc top_or_alias cmdalias} {
    ## This procedure may be used free of restrictions.
    ##    Exception added by Christian Gavin on 08/08/02.
    ## Other packages and widget toolkits have different licensing requirements.
    ##    Please read their license agreements for details.

    global widget
    set widget($alias) $target
    set widget(rev,$target) $alias
    if {$cmdalias} {
        interp alias {} $alias {} $widgetProc $target
    }
    if {$top_or_alias != ""} {
        set widget($top_or_alias,$alias) $target
        if {$cmdalias} {
            interp alias {} $top_or_alias.$alias {} $widgetProc $target
        }
    }
}
#############################################################################
## Library Procedure:  vTcl:DoCmdOption

proc ::vTcl:DoCmdOption {target cmd} {
    ## This procedure may be used free of restrictions.
    ##    Exception added by Christian Gavin on 08/08/02.
    ## Other packages and widget toolkits have different licensing requirements.
    ##    Please read their license agreements for details.

    ## menus are considered toplevel windows
    set parent $target
    while {[winfo class $parent] == "Menu"} {
        set parent [winfo parent $parent]
    }

    regsub -all {\%widget} $cmd $target cmd
    regsub -all {\%top} $cmd [winfo toplevel $parent] cmd

    uplevel #0 [list eval $cmd]
}
#############################################################################
## Library Procedure:  vTcl:FireEvent

proc ::vTcl:FireEvent {target event {params {}}} {
    ## This procedure may be used free of restrictions.
    ##    Exception added by Christian Gavin on 08/08/02.
    ## Other packages and widget toolkits have different licensing requirements.
    ##    Please read their license agreements for details.

    ## The window may have disappeared
    if {![winfo exists $target]} return
    ## Process each binding tag, looking for the event
    foreach bindtag [bindtags $target] {
        set tag_events [bind $bindtag]
        set stop_processing 0
        foreach tag_event $tag_events {
            if {$tag_event == $event} {
                set bind_code [bind $bindtag $tag_event]
                foreach rep "\{%W $target\} $params" {
                    regsub -all [lindex $rep 0] $bind_code [lindex $rep 1] bind_code
                }
                set result [catch {uplevel #0 $bind_code} errortext]
                if {$result == 3} {
                    ## break exception, stop processing
                    set stop_processing 1
                } elseif {$result != 0} {
                    bgerror $errortext
                }
                break
            }
        }
        if {$stop_processing} {break}
    }
}
#############################################################################
## Library Procedure:  vTcl:Toplevel:WidgetProc

proc ::vTcl:Toplevel:WidgetProc {w args} {
    ## This procedure may be used free of restrictions.
    ##    Exception added by Christian Gavin on 08/08/02.
    ## Other packages and widget toolkits have different licensing requirements.
    ##    Please read their license agreements for details.

    if {[llength $args] == 0} {
        ## If no arguments, returns the path the alias points to
        return $w
    }
    set command [lindex $args 0]
    set args [lrange $args 1 end]
    switch -- [string tolower $command] {
        "setvar" {
            foreach {varname value} $args {}
            if {$value == ""} {
                return [set ::${w}::${varname}]
            } else {
                return [set ::${w}::${varname} $value]
            }
        }
        "hide" - "show" {
            Window [string tolower $command] $w
        }
        "showmodal" {
            ## modal dialog ends when window is destroyed
            Window show $w; raise $w
            grab $w; tkwait window $w; grab release $w
        }
        "startmodal" {
            ## ends when endmodal called
            Window show $w; raise $w
            set ::${w}::_modal 1
            grab $w; tkwait variable ::${w}::_modal; grab release $w
        }
        "endmodal" {
            ## ends modal dialog started with startmodal, argument is var name
            set ::${w}::_modal 0
            Window hide $w
        }
        default {
            uplevel $w $command $args
        }
    }
}
#############################################################################
## Library Procedure:  vTcl:WidgetProc

proc ::vTcl:WidgetProc {w args} {
    ## This procedure may be used free of restrictions.
    ##    Exception added by Christian Gavin on 08/08/02.
    ## Other packages and widget toolkits have different licensing requirements.
    ##    Please read their license agreements for details.

    if {[llength $args] == 0} {
        ## If no arguments, returns the path the alias points to
        return $w
    }

    set command [lindex $args 0]
    set args [lrange $args 1 end]
    uplevel $w $command $args
}
#############################################################################
## Library Procedure:  vTcl:toplevel

proc ::vTcl:toplevel {args} {
    ## This procedure may be used free of restrictions.
    ##    Exception added by Christian Gavin on 08/08/02.
    ## Other packages and widget toolkits have different licensing requirements.
    ##    Please read their license agreements for details.

    uplevel #0 eval toplevel $args
    set target [lindex $args 0]
    namespace eval ::$target {set _modal 0}
}
}


if {[info exists vTcl(sourcing)]} {

proc vTcl:project:info {} {
    set base .top83
    namespace eval ::widgets::$base {
        set set,origin 1
        set set,size 1
        set runvisible 1
    }
    namespace eval ::widgets::$base.not84 {
        array set save {-activebackground 1 -activeforeground 1 -background 1 -font 1 -height 1 -width 1}
        namespace eval subOptions {
            array set save {-state 1 -text 1}
        }
    }
    set site_4_0 [$base.not84 getframe page1]
    namespace eval ::widgets::$site_4_0 {
        array set save {-background 1 -borderwidth 1}
    }
    set site_4_0 $site_4_0
    namespace eval ::widgets::$site_4_0.not85 {
        array set save {-activebackground 1 -background 1 -font 1 -height 1 -width 1}
        namespace eval subOptions {
            array set save {-text 1}
        }
    }
    set site_6_0 [$site_4_0.not85 getframe page1]
    namespace eval ::widgets::$site_6_0 {
        array set save {-background 1 -borderwidth 1}
    }
    set site_6_0 $site_6_0
    namespace eval ::widgets::$site_6_0.fra118 {
        array set save {-background 1 -borderwidth 1 -height 1 -relief 1 -width 1}
    }
    set site_7_0 $site_6_0.fra118
    namespace eval ::widgets::$site_7_0.ent121 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_7_0.tix83 {
        array set save {-borderwidth 1 -browsecmd 1 -height 1 -scrollbar 1 -width 1}
    }
    namespace eval ::widgets::$site_7_0.but123 {
        array set save {-background 1 -command 1 -font 1 -pady 1 -text 1}
    }
    namespace eval ::widgets::$site_7_0.but122 {
        array set save {-activebackground 1 -background 1 -command 1 -font 1 -pady 1 -text 1}
    }
    namespace eval ::widgets::$site_6_0.fra119 {
        array set save {-background 1 -borderwidth 1 -height 1 -relief 1 -width 1}
    }
    set site_7_0 $site_6_0.fra119
    namespace eval ::widgets::$site_7_0.ent128 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_7_0.tix83 {
        array set save {-borderwidth 1 -browsecmd 1 -height 1 -scrollbar 1 -takefocus 1 -width 1}
    }
    namespace eval ::widgets::$site_7_0.but127 {
        array set save {-background 1 -command 1 -font 1 -pady 1 -text 1}
    }
    namespace eval ::widgets::$site_6_0.fra120 {
        array set save {-background 1 -borderwidth 1 -height 1 -relief 1 -width 1}
    }
    set site_7_0 $site_6_0.fra120
    namespace eval ::widgets::$site_7_0.cpd129 {
        array set save {-background 1 -font 1 -text 1}
    }
    namespace eval ::widgets::$site_7_0.cpd130 {
        array set save {-background 1 -font 1 -text 1}
    }
    namespace eval ::widgets::$site_7_0.cpd131 {
        array set save {-background 1 -font 1 -text 1}
    }
    namespace eval ::widgets::$site_7_0.cpd132 {
        array set save {-background 1 -font 1 -text 1}
    }
    namespace eval ::widgets::$site_7_0.cpd133 {
        array set save {-background 1 -font 1 -text 1}
    }
    namespace eval ::widgets::$site_7_0.cpd137 {
        array set save {-background 1 -font 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_7_0.ent139 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_7_0.ent140 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_7_0.ent141 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_7_0.ent83 {
        array set save {-background 1 -takefocus 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_7_0.lab83 {
        array set save {-background 1 -font 1 -text 1}
    }
    namespace eval ::widgets::$site_7_0.ent84 {
        array set save {-background 1 -takefocus 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_6_0.fra135 {
        array set save {-background 1 -borderwidth 1 -height 1 -relief 1 -width 1}
    }
    set site_7_0 $site_6_0.fra135
    namespace eval ::widgets::$site_7_0.but136 {
        array set save {-background 1 -command 1 -font 1 -pady 1 -text 1}
    }
    set site_6_1 [$site_4_0.not85 getframe page2]
    namespace eval ::widgets::$site_6_1 {
        array set save {-background 1 -borderwidth 1}
    }
    set site_6_0 $site_6_1
    namespace eval ::widgets::$site_6_0.fra89 {
        array set save {-background 1 -borderwidth 1 -height 1 -relief 1 -width 1}
    }
    set site_7_0 $site_6_0.fra89
    namespace eval ::widgets::$site_7_0.cpd90 {
        array set save {-background 1 -font 1 -text 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_6_0.fra83 {
        array set save {-background 1 -borderwidth 1 -height 1 -relief 1 -width 1}
    }
    set site_7_0 $site_6_0.fra83
    namespace eval ::widgets::$site_7_0.cpd84 {
        array set save {-background 1 -command 1 -font 1 -pady 1 -text 1}
    }
    namespace eval ::widgets::$site_4_0.not83 {
        array set save {-background 1 -height 1 -width 1}
        namespace eval subOptions {
            array set save {-text 1}
        }
    }
    set site_6_0 [$site_4_0.not83 getframe page1]
    namespace eval ::widgets::$site_6_0 {
        array set save {-background 1 -borderwidth 1}
    }
    set site_6_0 $site_6_0
    namespace eval ::widgets::$site_6_0.cpd84 {
        array set save {-background 1 -borderwidth 1 -height 1 -relief 1 -width 1}
    }
    set site_7_0 $site_6_0.cpd84
    namespace eval ::widgets::$site_7_0.fra116 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_8_0 $site_7_0.fra116
    namespace eval ::widgets::$site_8_0.cpd137 {
        array set save {-background 1 -font 1 -text 1}
    }
    namespace eval ::widgets::$site_8_0.ent138 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_8_0.cpd139 {
        array set save {-background 1 -font 1 -text 1}
    }
    namespace eval ::widgets::$site_8_0.cpd140 {
        array set save {-background 1 -font 1 -text 1}
    }
    namespace eval ::widgets::$site_8_0.cpd142 {
        array set save {-background 1 -font 1 -text 1}
    }
    namespace eval ::widgets::$site_8_0.com143 {
        array set save {-entrybg 1 -modifycmd 1 -takefocus 1 -textvariable 1 -values 1}
    }
    namespace eval ::widgets::$site_8_0.cpd144 {
        array set save {-entrybg 1 -modifycmd 1 -takefocus 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_8_0.cpd145 {
        array set save {-entrybg 1 -takefocus 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_7_0.fra117 {
        array set save {-background 1 -borderwidth 1 -height 1 -relief 1 -width 1}
    }
    set site_8_0 $site_7_0.fra117
    namespace eval ::widgets::$site_8_0.tex89 {
        array set save {-background 1}
    }
    namespace eval ::widgets::$site_7_0.fra84 {
        array set save {-background 1 -borderwidth 1 -height 1 -relief 1 -width 1}
    }
    set site_8_0 $site_7_0.fra84
    namespace eval ::widgets::$site_8_0.but83 {
        array set save {-background 1 -command 1 -font 1 -pady 1 -takefocus 1 -text 1}
    }
    set site_6_1 [$site_4_0.not83 getframe page2]
    namespace eval ::widgets::$site_6_1 {
        array set save {-background 1 -borderwidth 1}
    }
    set site_6_0 $site_6_1
    namespace eval ::widgets::$site_6_0.fra88 {
        array set save {-background 1 -borderwidth 1 -height 1 -relief 1 -width 1}
    }
    set site_7_0 $site_6_0.fra88
    namespace eval ::widgets::$site_7_0.cpd91 {
        array set save {-background 1 -font 1 -text 1}
    }
    namespace eval ::widgets::$site_7_0.cpd117 {
        array set save {-background 1 -font 1 -text 1}
    }
    namespace eval ::widgets::$site_7_0.cpd118 {
        array set save {-background 1 -font 1 -text 1}
    }
    namespace eval ::widgets::$site_7_0.cpd119 {
        array set save {-background 1 -font 1 -text 1}
    }
    namespace eval ::widgets::$site_7_0.cpd127 {
        array set save {-background 1 -font 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_7_0.cpd128 {
        array set save {-background 1 -font 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_7_0.cpd129 {
        array set save {-background 1 -font 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_7_0.cpd130 {
        array set save {-background 1 -font 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_6_0.fra120 {
        array set save {-background 1 -borderwidth 1 -height 1 -relief 1 -width 1}
    }
    set site_7_0 $site_6_0.fra120
    namespace eval ::widgets::$site_7_0.cpd121 {
        array set save {-background 1 -font 1 -text 1}
    }
    namespace eval ::widgets::$site_7_0.cpd122 {
        array set save {-background 1 -font 1 -text 1}
    }
    namespace eval ::widgets::$site_7_0.ent123 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_7_0.ent124 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_7_0.fra83 {
        array set save {-background 1 -borderwidth 1 -height 1 -relief 1 -width 1}
    }
    set site_8_0 $site_7_0.fra83
    namespace eval ::widgets::$site_8_0.but84 {
        array set save {-background 1 -command 1 -font 1 -pady 1 -takefocus 1 -text 1}
    }
    namespace eval ::widgets::$site_4_0.not84 {
        array set save {-background 1 -height 1 -width 1}
        namespace eval subOptions {
            array set save {-text 1}
        }
    }
    set site_6_0 [$site_4_0.not84 getframe page1]
    namespace eval ::widgets::$site_6_0 {
        array set save {-background 1 -borderwidth 1}
    }
    set site_6_0 $site_6_0
    namespace eval ::widgets::$site_6_0.cpd85 {
        array set save {-background 1 -borderwidth 1 -height 1 -relief 1 -width 1}
    }
    set site_7_0 $site_6_0.cpd85
    namespace eval ::widgets::$site_7_0.lab87 {
        array set save {-anchor 1 -background 1 -font 1 -text 1}
    }
    namespace eval ::widgets::$site_7_0.cpd88 {
        array set save {-background 1 -font 1 -text 1}
    }
    namespace eval ::widgets::$site_7_0.cpd89 {
        array set save {-anchor 1 -background 1 -font 1 -text 1}
    }
    namespace eval ::widgets::$site_7_0.cpd90 {
        array set save {-anchor 1 -background 1 -font 1 -text 1}
    }
    namespace eval ::widgets::$site_7_0.cpd91 {
        array set save {-background 1 -font 1 -text 1}
    }
    namespace eval ::widgets::$site_7_0.cpd92 {
        array set save {-anchor 1 -background 1 -font 1 -text 1}
    }
    namespace eval ::widgets::$site_7_0.cpd93 {
        array set save {-background 1 -font 1 -text 1}
    }
    namespace eval ::widgets::$site_7_0.cpd94 {
        array set save {-anchor 1 -background 1 -font 1 -text 1}
    }
    namespace eval ::widgets::$site_7_0.cpd95 {
        array set save {-anchor 1 -background 1 -font 1 -text 1}
    }
    namespace eval ::widgets::$site_7_0.cpd96 {
        array set save {-background 1 -font 1 -text 1}
    }
    namespace eval ::widgets::$site_7_0.cpd97 {
        array set save {-anchor 1 -background 1 -font 1 -text 1}
    }
    namespace eval ::widgets::$site_7_0.cpd98 {
        array set save {-anchor 1 -background 1 -font 1 -text 1}
    }
    namespace eval ::widgets::$site_7_0.cpd102 {
        array set save {-anchor 1 -background 1 -font 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_7_0.cpd103 {
        array set save {-anchor 1 -background 1 -font 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_7_0.cpd104 {
        array set save {-background 1 -font 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_7_0.cpd105 {
        array set save {-activeforeground 1 -anchor 1 -background 1 -font 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_7_0.cpd106 {
        array set save {-background 1 -font 1 -textvariable 1 -width 1}
    }
    namespace eval ::widgets::$site_7_0.cpd108 {
        array set save {-background 1 -font 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_7_0.cpd109 {
        array set save {-anchor 1 -background 1 -font 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_7_0.cpd110 {
        array set save {-background 1 -font 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_7_0.cpd111 {
        array set save {-anchor 1 -background 1 -font 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_7_0.cpd112 {
        array set save {-anchor 1 -background 1 -font 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_7_0.cpd114 {
        array set save {-anchor 1 -background 1 -font 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_7_0.cpd100 {
        array set save {-anchor 1 -background 1 -font 1 -text 1}
    }
    namespace eval ::widgets::$site_7_0.cpd101 {
        array set save {-background 1 -font 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_7_0.cpd115 {
        array set save {-background 1 -font 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_7_0.cpd116 {
        array set save {-background 1 -font 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_7_0.cpd85 {
        array set save {-anchor 1 -background 1 -font 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_7_0.lab88 {
        array set save {-background 1 -font 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_7_0.cpd83 {
        array set save {-background 1 -font 1 -foreground 1 -textvariable 1}
    }
    set site_6_1 [$site_4_0.not84 getframe page2]
    namespace eval ::widgets::$site_6_1 {
        array set save {-background 1 -borderwidth 1}
    }
    set site_6_0 $site_6_1
    namespace eval ::widgets::$site_6_0.fra86 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_7_0 $site_6_0.fra86
    namespace eval ::widgets::$site_7_0.cpd87 {
        array set save {-background 1 -font 1 -text 1}
    }
    namespace eval ::widgets::$site_7_0.cpd88 {
        array set save {-background 1 -font 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_7_0.cpd89 {
        array set save {-background 1 -font 1 -text 1}
    }
    namespace eval ::widgets::$site_7_0.cpd90 {
        array set save {-background 1 -font 1 -textvariable 1}
    }
    set site_4_1 [$base.not84 getframe page2]
    namespace eval ::widgets::$site_4_1 {
        array set save {-background 1 -borderwidth 1}
    }
    set site_4_0 $site_4_1
    namespace eval ::widgets::$site_4_0.not85 {
        array set save {-activebackground 1 -background 1 -font 1 -height 1 -width 1}
        namespace eval subOptions {
            array set save {-text 1}
        }
    }
    set site_6_0 [$site_4_0.not85 getframe page1]
    namespace eval ::widgets::$site_6_0 {
        array set save {-background 1 -borderwidth 1}
    }
    set site_6_0 $site_6_0
    namespace eval ::widgets::$site_6_0.fra161 {
        array set save {-background 1 -borderwidth 1 -height 1 -relief 1 -width 1}
    }
    set site_7_0 $site_6_0.fra161
    namespace eval ::widgets::$site_7_0.cpd162 {
        array set save {-background 1 -font 1 -text 1}
    }
    namespace eval ::widgets::$site_7_0.cpd163 {
        array set save {-background 1 -font 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_7_0.cpd164 {
        array set save {-background 1 -font 1 -text 1}
    }
    namespace eval ::widgets::$site_7_0.cpd165 {
        array set save {-background 1 -font 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_7_0.cpd166 {
        array set save {-background 1 -font 1 -text 1}
    }
    namespace eval ::widgets::$site_7_0.cpd167 {
        array set save {-background 1 -font 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_7_0.cpd168 {
        array set save {-background 1 -font 1 -text 1}
    }
    namespace eval ::widgets::$site_7_0.cpd169 {
        array set save {-background 1 -font 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_7_0.cpd170 {
        array set save {-background 1 -font 1 -text 1}
    }
    namespace eval ::widgets::$site_7_0.cpd171 {
        array set save {-background 1 -font 1 -textvariable 1 -width 1}
    }
    namespace eval ::widgets::$site_6_0.not173 {
        array set save {-background 1 -font 1 -height 1 -width 1}
        namespace eval subOptions {
            array set save {-text 1}
        }
    }
    set site_8_0 [$site_6_0.not173 getframe page1]
    namespace eval ::widgets::$site_8_0 {
        array set save {-background 1 -borderwidth 1}
    }
    set site_8_0 $site_8_0
    namespace eval ::widgets::$site_8_0.fra197 {
        array set save {-background 1 -borderwidth 1 -height 1 -relief 1 -width 1}
    }
    set site_9_0 $site_8_0.fra197
    namespace eval ::widgets::$site_9_0.cpd198 {
        array set save {-background 1 -borderwidth 1 -height 1 -relief 1 -width 1}
    }
    set site_10_0 $site_9_0.cpd198
    namespace eval ::widgets::$site_10_0.fra176 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_11_0 $site_10_0.fra176
    namespace eval ::widgets::$site_11_0.che177 {
        array set save {-background 1 -takefocus 1 -variable 1}
    }
    namespace eval ::widgets::$site_11_0.ent178 {
        array set save {-background 1 -takefocus 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.lab179 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.cpd180 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.cpd181 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.lab101 {
        array set save {-font 1 -text 1}
    }
    namespace eval ::widgets::$site_10_0.cpd184 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_11_0 $site_10_0.cpd184
    namespace eval ::widgets::$site_11_0.che177 {
        array set save {-background 1 -takefocus 1 -variable 1}
    }
    namespace eval ::widgets::$site_11_0.ent178 {
        array set save {-background 1 -takefocus 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.lab179 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.cpd180 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.cpd181 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.lab102 {
        array set save {-font 1 -text 1}
    }
    namespace eval ::widgets::$site_10_0.cpd185 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_11_0 $site_10_0.cpd185
    namespace eval ::widgets::$site_11_0.che177 {
        array set save {-background 1 -takefocus 1 -variable 1}
    }
    namespace eval ::widgets::$site_11_0.ent178 {
        array set save {-background 1 -takefocus 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.lab179 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.cpd180 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.cpd181 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.lab103 {
        array set save {-font 1 -text 1}
    }
    namespace eval ::widgets::$site_10_0.cpd186 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_11_0 $site_10_0.cpd186
    namespace eval ::widgets::$site_11_0.che177 {
        array set save {-background 1 -takefocus 1 -variable 1}
    }
    namespace eval ::widgets::$site_11_0.ent178 {
        array set save {-background 1 -takefocus 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.lab179 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.cpd180 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.cpd181 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.lab104 {
        array set save {-font 1 -text 1}
    }
    namespace eval ::widgets::$site_10_0.cpd187 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_11_0 $site_10_0.cpd187
    namespace eval ::widgets::$site_11_0.che177 {
        array set save {-background 1 -takefocus 1 -variable 1}
    }
    namespace eval ::widgets::$site_11_0.ent178 {
        array set save {-background 1 -takefocus 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.lab179 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.cpd180 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.cpd181 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.lab105 {
        array set save {-font 1 -text 1}
    }
    namespace eval ::widgets::$site_10_0.cpd188 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_11_0 $site_10_0.cpd188
    namespace eval ::widgets::$site_11_0.che177 {
        array set save {-background 1 -takefocus 1 -variable 1}
    }
    namespace eval ::widgets::$site_11_0.ent178 {
        array set save {-background 1 -takefocus 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.lab179 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.cpd180 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.cpd181 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.lab107 {
        array set save {-font 1 -text 1}
    }
    namespace eval ::widgets::$site_10_0.cpd189 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_11_0 $site_10_0.cpd189
    namespace eval ::widgets::$site_11_0.che177 {
        array set save {-background 1 -takefocus 1 -variable 1}
    }
    namespace eval ::widgets::$site_11_0.ent178 {
        array set save {-background 1 -takefocus 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.lab179 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.cpd180 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.cpd181 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.lab108 {
        array set save {-font 1 -text 1}
    }
    namespace eval ::widgets::$site_10_0.cpd190 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_11_0 $site_10_0.cpd190
    namespace eval ::widgets::$site_11_0.che177 {
        array set save {-background 1 -takefocus 1 -variable 1}
    }
    namespace eval ::widgets::$site_11_0.ent178 {
        array set save {-background 1 -takefocus 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.lab179 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.cpd180 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.cpd181 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.lab109 {
        array set save {-font 1 -text 1}
    }
    namespace eval ::widgets::$site_10_0.fra191 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_11_0 $site_10_0.fra191
    namespace eval ::widgets::$site_11_0.lab192 {
        array set save {-background 1 -font 1 -text 1}
    }
    namespace eval ::widgets::$site_11_0.lab193 {
        array set save {-background 1 -font 1 -text 1}
    }
    namespace eval ::widgets::$site_11_0.lab194 {
        array set save {-background 1 -font 1 -text 1}
    }
    namespace eval ::widgets::$site_11_0.lab195 {
        array set save {-background 1 -font 1 -text 1}
    }
    namespace eval ::widgets::$site_11_0.cpd100 {
        array set save {-background 1 -font 1 -text 1}
    }
    namespace eval ::widgets::$site_9_0.cpd83 {
        array set save {-background 1 -borderwidth 1 -height 1 -relief 1 -width 1}
    }
    set site_10_0 $site_9_0.cpd83
    namespace eval ::widgets::$site_10_0.fra176 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_11_0 $site_10_0.fra176
    namespace eval ::widgets::$site_11_0.che177 {
        array set save {-background 1 -takefocus 1 -variable 1}
    }
    namespace eval ::widgets::$site_11_0.ent178 {
        array set save {-background 1 -takefocus 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.lab179 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.cpd180 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.cpd181 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.lab91 {
        array set save {-font 1 -text 1}
    }
    namespace eval ::widgets::$site_10_0.cpd184 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_11_0 $site_10_0.cpd184
    namespace eval ::widgets::$site_11_0.che177 {
        array set save {-background 1 -takefocus 1 -variable 1}
    }
    namespace eval ::widgets::$site_11_0.ent178 {
        array set save {-background 1 -takefocus 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.lab179 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.cpd180 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.cpd181 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.lab93 {
        array set save {-font 1 -text 1}
    }
    namespace eval ::widgets::$site_10_0.cpd185 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_11_0 $site_10_0.cpd185
    namespace eval ::widgets::$site_11_0.che177 {
        array set save {-background 1 -takefocus 1 -variable 1}
    }
    namespace eval ::widgets::$site_11_0.ent178 {
        array set save {-background 1 -takefocus 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.lab179 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.cpd180 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.cpd181 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.lab94 {
        array set save {-font 1 -text 1}
    }
    namespace eval ::widgets::$site_10_0.cpd186 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_11_0 $site_10_0.cpd186
    namespace eval ::widgets::$site_11_0.che177 {
        array set save {-background 1 -takefocus 1 -variable 1}
    }
    namespace eval ::widgets::$site_11_0.ent178 {
        array set save {-background 1 -takefocus 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.lab179 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.cpd180 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.cpd181 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.lab95 {
        array set save {-font 1 -text 1}
    }
    namespace eval ::widgets::$site_10_0.cpd187 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_11_0 $site_10_0.cpd187
    namespace eval ::widgets::$site_11_0.che177 {
        array set save {-background 1 -takefocus 1 -variable 1}
    }
    namespace eval ::widgets::$site_11_0.ent178 {
        array set save {-background 1 -takefocus 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.lab179 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.cpd180 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.cpd181 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.lab96 {
        array set save {-font 1 -text 1}
    }
    namespace eval ::widgets::$site_10_0.cpd188 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_11_0 $site_10_0.cpd188
    namespace eval ::widgets::$site_11_0.che177 {
        array set save {-background 1 -takefocus 1 -variable 1}
    }
    namespace eval ::widgets::$site_11_0.ent178 {
        array set save {-background 1 -takefocus 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.lab179 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.cpd180 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.cpd181 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.lab97 {
        array set save {-font 1 -text 1}
    }
    namespace eval ::widgets::$site_10_0.cpd189 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_11_0 $site_10_0.cpd189
    namespace eval ::widgets::$site_11_0.che177 {
        array set save {-background 1 -takefocus 1 -variable 1}
    }
    namespace eval ::widgets::$site_11_0.ent178 {
        array set save {-background 1 -takefocus 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.lab179 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.cpd180 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.cpd181 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.lab98 {
        array set save {-font 1 -text 1}
    }
    namespace eval ::widgets::$site_10_0.cpd190 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_11_0 $site_10_0.cpd190
    namespace eval ::widgets::$site_11_0.che177 {
        array set save {-background 1 -takefocus 1 -variable 1}
    }
    namespace eval ::widgets::$site_11_0.ent178 {
        array set save {-background 1 -takefocus 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.lab179 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.cpd180 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.cpd181 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.lab99 {
        array set save {-font 1 -text 1}
    }
    namespace eval ::widgets::$site_10_0.fra191 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_11_0 $site_10_0.fra191
    namespace eval ::widgets::$site_11_0.lab192 {
        array set save {-background 1 -font 1 -text 1}
    }
    namespace eval ::widgets::$site_11_0.lab193 {
        array set save {-background 1 -font 1 -text 1}
    }
    namespace eval ::widgets::$site_11_0.lab194 {
        array set save {-background 1 -font 1 -text 1}
    }
    namespace eval ::widgets::$site_11_0.lab195 {
        array set save {-background 1 -font 1 -text 1}
    }
    namespace eval ::widgets::$site_11_0.cpd83 {
        array set save {-background 1 -font 1 -text 1}
    }
    set site_8_1 [$site_6_0.not173 getframe page2]
    namespace eval ::widgets::$site_8_1 {
        array set save {-background 1 -borderwidth 1}
    }
    set site_8_0 $site_8_1
    namespace eval ::widgets::$site_8_0.fra83 {
        array set save {-background 1 -borderwidth 1 -height 1 -relief 1 -width 1}
    }
    set site_9_0 $site_8_0.fra83
    namespace eval ::widgets::$site_9_0.fra84 {
        array set save {-background 1 -borderwidth 1 -height 1 -relief 1 -width 1}
    }
    set site_10_0 $site_9_0.fra84
    namespace eval ::widgets::$site_10_0.cpd87 {
        array set save {-background 1 -font 1 -text 1}
    }
    namespace eval ::widgets::$site_10_0.cpd88 {
        array set save {-background 1 -font 1 -text 1}
    }
    namespace eval ::widgets::$site_10_0.cpd89 {
        array set save {-background 1 -font 1 -text 1}
    }
    namespace eval ::widgets::$site_10_0.cpd90 {
        array set save {-background 1 -font 1 -text 1}
    }
    namespace eval ::widgets::$site_10_0.cpd91 {
        array set save {-background 1 -font 1 -text 1}
    }
    namespace eval ::widgets::$site_10_0.cpd83 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_11_0 $site_10_0.cpd83
    namespace eval ::widgets::$site_11_0.che177 {
        array set save {-background 1 -takefocus 1 -variable 1}
    }
    namespace eval ::widgets::$site_11_0.ent178 {
        array set save {-background 1 -takefocus 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.lab179 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.cpd180 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.cpd181 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.lab101 {
        array set save {-font 1 -text 1}
    }
    namespace eval ::widgets::$site_10_0.cpd84 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_11_0 $site_10_0.cpd84
    namespace eval ::widgets::$site_11_0.che177 {
        array set save {-background 1 -takefocus 1 -variable 1}
    }
    namespace eval ::widgets::$site_11_0.ent178 {
        array set save {-background 1 -takefocus 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.lab179 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.cpd180 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.cpd181 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.lab101 {
        array set save {-font 1 -text 1}
    }
    namespace eval ::widgets::$site_10_0.cpd85 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_11_0 $site_10_0.cpd85
    namespace eval ::widgets::$site_11_0.che177 {
        array set save {-background 1 -takefocus 1 -variable 1}
    }
    namespace eval ::widgets::$site_11_0.ent178 {
        array set save {-background 1 -takefocus 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.lab179 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.cpd180 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.cpd181 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.lab101 {
        array set save {-font 1 -text 1}
    }
    namespace eval ::widgets::$site_10_0.cpd86 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_11_0 $site_10_0.cpd86
    namespace eval ::widgets::$site_11_0.che177 {
        array set save {-background 1 -takefocus 1 -variable 1}
    }
    namespace eval ::widgets::$site_11_0.ent178 {
        array set save {-background 1 -takefocus 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.lab179 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.cpd180 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.cpd181 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.lab101 {
        array set save {-font 1 -text 1}
    }
    namespace eval ::widgets::$site_10_0.cpd92 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_11_0 $site_10_0.cpd92
    namespace eval ::widgets::$site_11_0.che177 {
        array set save {-background 1 -takefocus 1 -variable 1}
    }
    namespace eval ::widgets::$site_11_0.ent178 {
        array set save {-background 1 -takefocus 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.lab179 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.cpd180 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.cpd181 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.lab101 {
        array set save {-font 1 -text 1}
    }
    namespace eval ::widgets::$site_10_0.cpd96 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_11_0 $site_10_0.cpd96
    namespace eval ::widgets::$site_11_0.che177 {
        array set save {-background 1 -takefocus 1 -variable 1}
    }
    namespace eval ::widgets::$site_11_0.ent178 {
        array set save {-background 1 -takefocus 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.lab179 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.cpd180 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.cpd181 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.lab101 {
        array set save {-font 1 -text 1}
    }
    namespace eval ::widgets::$site_10_0.cpd93 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_11_0 $site_10_0.cpd93
    namespace eval ::widgets::$site_11_0.che177 {
        array set save {-background 1 -takefocus 1 -variable 1}
    }
    namespace eval ::widgets::$site_11_0.ent178 {
        array set save {-background 1 -takefocus 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.lab179 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.cpd180 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.cpd181 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.lab101 {
        array set save {-font 1 -text 1}
    }
    namespace eval ::widgets::$site_10_0.cpd94 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_11_0 $site_10_0.cpd94
    namespace eval ::widgets::$site_11_0.che177 {
        array set save {-background 1 -takefocus 1 -variable 1}
    }
    namespace eval ::widgets::$site_11_0.ent178 {
        array set save {-background 1 -takefocus 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.lab179 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.cpd180 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.cpd181 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.lab101 {
        array set save {-font 1 -text 1}
    }
    namespace eval ::widgets::$site_9_0.fra85 {
        array set save {-background 1 -borderwidth 1 -height 1 -relief 1 -width 1}
    }
    set site_10_0 $site_9_0.fra85
    namespace eval ::widgets::$site_10_0.cpd83 {
        array set save {-background 1 -font 1 -text 1}
    }
    namespace eval ::widgets::$site_10_0.cpd84 {
        array set save {-background 1 -font 1 -text 1}
    }
    namespace eval ::widgets::$site_10_0.cpd85 {
        array set save {-background 1 -font 1 -text 1}
    }
    namespace eval ::widgets::$site_10_0.cpd86 {
        array set save {-background 1 -font 1 -text 1}
    }
    namespace eval ::widgets::$site_10_0.cpd87 {
        array set save {-background 1 -font 1 -text 1}
    }
    namespace eval ::widgets::$site_10_0.cpd88 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_11_0 $site_10_0.cpd88
    namespace eval ::widgets::$site_11_0.che177 {
        array set save {-background 1 -takefocus 1 -variable 1}
    }
    namespace eval ::widgets::$site_11_0.ent178 {
        array set save {-background 1 -takefocus 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.lab179 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.cpd180 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.cpd181 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.lab101 {
        array set save {-font 1 -text 1}
    }
    namespace eval ::widgets::$site_10_0.cpd89 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_11_0 $site_10_0.cpd89
    namespace eval ::widgets::$site_11_0.che177 {
        array set save {-background 1 -takefocus 1 -variable 1}
    }
    namespace eval ::widgets::$site_11_0.ent178 {
        array set save {-background 1 -takefocus 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.lab179 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.cpd180 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.cpd181 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.lab101 {
        array set save {-font 1 -text 1}
    }
    namespace eval ::widgets::$site_10_0.cpd90 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_11_0 $site_10_0.cpd90
    namespace eval ::widgets::$site_11_0.che177 {
        array set save {-background 1 -takefocus 1 -variable 1}
    }
    namespace eval ::widgets::$site_11_0.ent178 {
        array set save {-background 1 -takefocus 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.lab179 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.cpd180 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.cpd181 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.lab101 {
        array set save {-font 1 -text 1}
    }
    namespace eval ::widgets::$site_10_0.cpd91 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_11_0 $site_10_0.cpd91
    namespace eval ::widgets::$site_11_0.che177 {
        array set save {-background 1 -takefocus 1 -variable 1}
    }
    namespace eval ::widgets::$site_11_0.ent178 {
        array set save {-background 1 -takefocus 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.lab179 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.cpd180 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.cpd181 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.lab101 {
        array set save {-font 1 -text 1}
    }
    namespace eval ::widgets::$site_10_0.cpd92 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_11_0 $site_10_0.cpd92
    namespace eval ::widgets::$site_11_0.che177 {
        array set save {-background 1 -takefocus 1 -variable 1}
    }
    namespace eval ::widgets::$site_11_0.ent178 {
        array set save {-background 1 -takefocus 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.lab179 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.cpd180 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.cpd181 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.lab101 {
        array set save {-font 1 -text 1}
    }
    namespace eval ::widgets::$site_10_0.cpd93 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_11_0 $site_10_0.cpd93
    namespace eval ::widgets::$site_11_0.che177 {
        array set save {-background 1 -takefocus 1 -variable 1}
    }
    namespace eval ::widgets::$site_11_0.ent178 {
        array set save {-background 1 -takefocus 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.lab179 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.cpd180 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.cpd181 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.lab101 {
        array set save {-font 1 -text 1}
    }
    namespace eval ::widgets::$site_10_0.cpd94 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_11_0 $site_10_0.cpd94
    namespace eval ::widgets::$site_11_0.che177 {
        array set save {-background 1 -takefocus 1 -variable 1}
    }
    namespace eval ::widgets::$site_11_0.ent178 {
        array set save {-background 1 -takefocus 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.lab179 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.cpd180 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.cpd181 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.lab101 {
        array set save {-font 1 -text 1}
    }
    namespace eval ::widgets::$site_10_0.cpd95 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_11_0 $site_10_0.cpd95
    namespace eval ::widgets::$site_11_0.che177 {
        array set save {-background 1 -takefocus 1 -variable 1}
    }
    namespace eval ::widgets::$site_11_0.ent178 {
        array set save {-background 1 -takefocus 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.lab179 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.cpd180 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.cpd181 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_11_0.lab101 {
        array set save {-font 1 -text 1}
    }
    set site_8_2 [$site_6_0.not173 getframe page4]
    namespace eval ::widgets::$site_8_2 {
        array set save {-background 1 -borderwidth 1}
    }
    set site_8_3 [$site_6_0.not173 getframe page3]
    namespace eval ::widgets::$site_8_3 {
        array set save {-background 1 -borderwidth 1}
    }
    namespace eval ::widgets::$site_6_0.fra202 {
        array set save {-background 1 -borderwidth 1 -height 1 -relief 1 -width 1}
    }
    set site_7_0 $site_6_0.fra202
    namespace eval ::widgets::$site_7_0.but203 {
        array set save {-background 1 -command 1 -font 1 -pady 1 -takefocus 1 -text 1}
    }
    namespace eval ::widgets::$site_7_0.lab204 {
        array set save {-background 1 -font 1 -text 1}
    }
    namespace eval ::widgets::$site_7_0.ent205 {
        array set save {-background 1 -takefocus 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_7_0.but206 {
        array set save {-background 1 -command 1 -font 1 -pady 1 -takefocus 1 -text 1}
    }
    namespace eval ::widgets::$site_7_0.cpd207 {
        array set save {-background 1 -command 1 -font 1 -pady 1 -takefocus 1 -text 1}
    }
    set site_6_1 [$site_4_0.not85 getframe page2]
    namespace eval ::widgets::$site_6_1 {
        array set save {-background 1 -borderwidth 1}
    }
    set site_6_0 $site_6_1
    namespace eval ::widgets::$site_6_0.not83 {
        array set save {-background 1 -font 1 -height 1 -width 1}
        namespace eval subOptions {
            array set save {-text 1}
        }
    }
    set site_8_0 [$site_6_0.not83 getframe page1]
    namespace eval ::widgets::$site_8_0 {
        array set save {-background 1 -borderwidth 1}
    }
    set site_8_0 $site_8_0
    namespace eval ::widgets::$site_8_0.fra137 {
        array set save {-background 1 -borderwidth 1 -height 1 -relief 1 -width 1}
    }
    set site_9_0 $site_8_0.fra137
    namespace eval ::widgets::$site_9_0.lab138 {
        array set save {-background 1 -font 1 -text 1 -width 1}
    }
    namespace eval ::widgets::$site_9_0.cpd139 {
        array set save {-background 1 -font 1 -text 1 -width 1}
    }
    namespace eval ::widgets::$site_9_0.cpd140 {
        array set save {-background 1 -font 1 -text 1 -width 1}
    }
    namespace eval ::widgets::$site_9_0.cpd141 {
        array set save {-background 1 -font 1 -textvariable 1 -width 1}
    }
    namespace eval ::widgets::$site_9_0.cpd142 {
        array set save {-background 1 -font 1 -textvariable 1 -width 1}
    }
    namespace eval ::widgets::$site_9_0.cpd144 {
        array set save {-background 1 -font 1 -textvariable 1 -width 1}
    }
    namespace eval ::widgets::$site_8_0.fra145 {
        array set save {-background 1 -borderwidth 1 -height 1 -relief 1 -width 1}
    }
    set site_9_0 $site_8_0.fra145
    namespace eval ::widgets::$site_9_0.cpd146 {
        array set save {-background 1 -font 1 -text 1 -width 1}
    }
    namespace eval ::widgets::$site_9_0.cpd147 {
        array set save {-background 1 -textvariable 1 -width 1}
    }
    namespace eval ::widgets::$site_9_0.cpd148 {
        array set save {-background 1 -font 1 -text 1 -width 1}
    }
    namespace eval ::widgets::$site_9_0.cpd149 {
        array set save {-background 1 -textvariable 1 -width 1}
    }
    namespace eval ::widgets::$site_9_0.cpd150 {
        array set save {-background 1 -font 1 -text 1 -width 1}
    }
    namespace eval ::widgets::$site_9_0.cpd151 {
        array set save {-background 1 -textvariable 1 -width 1}
    }
    namespace eval ::widgets::$site_8_0.fra152 {
        array set save {-background 1 -borderwidth 1 -height 1 -relief 1 -width 1}
    }
    set site_9_0 $site_8_0.fra152
    namespace eval ::widgets::$site_9_0.but153 {
        array set save {-background 1 -command 1 -font 1 -pady 1 -takefocus 1 -text 1}
    }
    namespace eval ::widgets::$site_8_0.fra154 {
        array set save {-background 1 -borderwidth 1 -height 1 -relief 1 -width 1}
    }
    set site_9_0 $site_8_0.fra154
    namespace eval ::widgets::$site_9_0.cpd155 {
        array set save {-background 1 -font 1 -text 1 -width 1}
    }
    namespace eval ::widgets::$site_9_0.cpd156 {
        array set save {-background 1 -font 1 -text 1 -width 1}
    }
    namespace eval ::widgets::$site_9_0.ent157 {
        array set save {-background 1 -takefocus 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_9_0.ent158 {
        array set save {-background 1 -takefocus 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_9_0.but159 {
        array set save {-background 1 -command 1 -font 1 -pady 1 -takefocus 1 -text 1}
    }
    namespace eval ::widgets::$site_9_0.cpd160 {
        array set save {-background 1 -command 1 -font 1 -pady 1 -takefocus 1 -text 1}
    }
    set site_8_1 [$site_6_0.not83 getframe page2]
    namespace eval ::widgets::$site_8_1 {
        array set save {-background 1 -borderwidth 1}
    }
    set site_8_0 $site_8_1
    namespace eval ::widgets::$site_8_0.fra125 {
        array set save {-background 1 -borderwidth 1 -height 1 -relief 1 -width 1}
    }
    set site_9_0 $site_8_0.fra125
    namespace eval ::widgets::$site_9_0.lab126 {
        array set save {-background 1 -font 1 -foreground 1 -text 1}
    }
    namespace eval ::widgets::$site_9_0.fra127 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_10_0 $site_9_0.fra127
    namespace eval ::widgets::$site_10_0.lab129 {
        array set save {-background 1 -font 1 -text 1 -width 1}
    }
    namespace eval ::widgets::$site_10_0.cpd130 {
        array set save {-background 1 -font 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_10_0.cpd131 {
        array set save {-background 1 -font 1 -text 1 -width 1}
    }
    namespace eval ::widgets::$site_10_0.cpd132 {
        array set save {-background 1 -font 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_9_0.lab128 {
        array set save {-background 1 -font 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_9_0.fra133 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_10_0 $site_9_0.fra133
    namespace eval ::widgets::$site_10_0.cpd134 {
        array set save {-background 1 -font 1 -text 1}
    }
    namespace eval ::widgets::$site_10_0.ent135 {
        array set save {-background 1 -takefocus 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_10_0.but136 {
        array set save {-background 1 -command 1 -font 1 -pady 1 -takefocus 1 -text 1}
    }
    set site_8_2 [$site_6_0.not83 getframe page3]
    namespace eval ::widgets::$site_8_2 {
        array set save {-background 1 -borderwidth 1}
    }
    set site_8_0 $site_8_2
    namespace eval ::widgets::$site_8_0.cpd84 {
        array set save {-background 1 -borderwidth 1 -height 1 -relief 1 -width 1}
    }
    set site_9_0 $site_8_0.cpd84
    namespace eval ::widgets::$site_9_0.cpd162 {
        array set save {-background 1 -font 1 -text 1}
    }
    namespace eval ::widgets::$site_9_0.cpd163 {
        array set save {-background 1 -font 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_9_0.cpd164 {
        array set save {-background 1 -font 1 -text 1}
    }
    namespace eval ::widgets::$site_9_0.cpd165 {
        array set save {-background 1 -font 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_8_0.cpd85 {
        array set save {-background 1 -borderwidth 1 -height 1 -relief 1 -width 1}
    }
    set site_9_0 $site_8_0.cpd85
    namespace eval ::widgets::$site_9_0.fra176 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_10_0 $site_9_0.fra176
    namespace eval ::widgets::$site_10_0.che177 {
        array set save {-background 1 -takefocus 1 -variable 1}
    }
    namespace eval ::widgets::$site_10_0.ent178 {
        array set save {-background 1 -takefocus 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_10_0.lab179 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_10_0.cpd180 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_10_0.cpd181 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_10_0.lab101 {
        array set save {-font 1 -text 1}
    }
    namespace eval ::widgets::$site_9_0.cpd184 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_10_0 $site_9_0.cpd184
    namespace eval ::widgets::$site_10_0.che177 {
        array set save {-background 1 -takefocus 1 -variable 1}
    }
    namespace eval ::widgets::$site_10_0.ent178 {
        array set save {-background 1 -takefocus 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_10_0.lab179 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_10_0.cpd180 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_10_0.cpd181 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_10_0.lab102 {
        array set save {-font 1 -text 1}
    }
    namespace eval ::widgets::$site_9_0.cpd185 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_10_0 $site_9_0.cpd185
    namespace eval ::widgets::$site_10_0.che177 {
        array set save {-background 1 -takefocus 1 -variable 1}
    }
    namespace eval ::widgets::$site_10_0.ent178 {
        array set save {-background 1 -takefocus 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_10_0.lab179 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_10_0.cpd180 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_10_0.cpd181 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_10_0.lab103 {
        array set save {-font 1 -text 1}
    }
    namespace eval ::widgets::$site_9_0.cpd186 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_10_0 $site_9_0.cpd186
    namespace eval ::widgets::$site_10_0.che177 {
        array set save {-background 1 -takefocus 1 -variable 1}
    }
    namespace eval ::widgets::$site_10_0.ent178 {
        array set save {-background 1 -takefocus 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_10_0.lab179 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_10_0.cpd180 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_10_0.cpd181 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_10_0.lab104 {
        array set save {-font 1 -text 1}
    }
    namespace eval ::widgets::$site_9_0.cpd187 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_10_0 $site_9_0.cpd187
    namespace eval ::widgets::$site_10_0.che177 {
        array set save {-background 1 -takefocus 1 -variable 1}
    }
    namespace eval ::widgets::$site_10_0.ent178 {
        array set save {-background 1 -takefocus 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_10_0.lab179 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_10_0.cpd180 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_10_0.cpd181 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_10_0.lab105 {
        array set save {-font 1 -text 1}
    }
    namespace eval ::widgets::$site_9_0.cpd188 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_10_0 $site_9_0.cpd188
    namespace eval ::widgets::$site_10_0.che177 {
        array set save {-background 1 -takefocus 1 -variable 1}
    }
    namespace eval ::widgets::$site_10_0.ent178 {
        array set save {-background 1 -takefocus 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_10_0.lab179 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_10_0.cpd180 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_10_0.cpd181 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_10_0.lab107 {
        array set save {-font 1 -text 1}
    }
    namespace eval ::widgets::$site_9_0.cpd189 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_10_0 $site_9_0.cpd189
    namespace eval ::widgets::$site_10_0.che177 {
        array set save {-background 1 -takefocus 1 -variable 1}
    }
    namespace eval ::widgets::$site_10_0.ent178 {
        array set save {-background 1 -takefocus 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_10_0.lab179 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_10_0.cpd180 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_10_0.cpd181 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_10_0.lab108 {
        array set save {-font 1 -text 1}
    }
    namespace eval ::widgets::$site_9_0.cpd190 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_10_0 $site_9_0.cpd190
    namespace eval ::widgets::$site_10_0.che177 {
        array set save {-background 1 -takefocus 1 -variable 1}
    }
    namespace eval ::widgets::$site_10_0.ent178 {
        array set save {-background 1 -takefocus 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_10_0.lab179 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_10_0.cpd180 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_10_0.cpd181 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_10_0.lab109 {
        array set save {-font 1 -text 1}
    }
    namespace eval ::widgets::$site_9_0.fra191 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_10_0 $site_9_0.fra191
    namespace eval ::widgets::$site_10_0.lab192 {
        array set save {-background 1 -font 1 -text 1}
    }
    namespace eval ::widgets::$site_10_0.lab193 {
        array set save {-background 1 -font 1 -text 1}
    }
    namespace eval ::widgets::$site_10_0.lab194 {
        array set save {-background 1 -font 1 -text 1}
    }
    namespace eval ::widgets::$site_10_0.lab195 {
        array set save {-background 1 -font 1 -text 1}
    }
    namespace eval ::widgets::$site_10_0.cpd100 {
        array set save {-background 1 -font 1 -text 1}
    }
    namespace eval ::widgets::$site_8_0.cpd87 {
        array set save {-background 1 -borderwidth 1 -height 1 -relief 1 -width 1}
    }
    set site_9_0 $site_8_0.cpd87
    namespace eval ::widgets::$site_9_0.fra176 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_10_0 $site_9_0.fra176
    namespace eval ::widgets::$site_10_0.che177 {
        array set save {-background 1 -takefocus 1 -variable 1}
    }
    namespace eval ::widgets::$site_10_0.ent178 {
        array set save {-background 1 -takefocus 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_10_0.lab179 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_10_0.cpd180 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_10_0.cpd181 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_10_0.lab91 {
        array set save {-font 1 -text 1}
    }
    namespace eval ::widgets::$site_9_0.cpd184 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_10_0 $site_9_0.cpd184
    namespace eval ::widgets::$site_10_0.che177 {
        array set save {-background 1 -takefocus 1 -variable 1}
    }
    namespace eval ::widgets::$site_10_0.ent178 {
        array set save {-background 1 -takefocus 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_10_0.lab179 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_10_0.cpd180 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_10_0.cpd181 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_10_0.lab93 {
        array set save {-font 1 -text 1}
    }
    namespace eval ::widgets::$site_9_0.cpd185 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_10_0 $site_9_0.cpd185
    namespace eval ::widgets::$site_10_0.che177 {
        array set save {-background 1 -takefocus 1 -variable 1}
    }
    namespace eval ::widgets::$site_10_0.ent178 {
        array set save {-background 1 -takefocus 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_10_0.lab179 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_10_0.cpd180 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_10_0.cpd181 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_10_0.lab94 {
        array set save {-font 1 -text 1}
    }
    namespace eval ::widgets::$site_9_0.cpd186 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_10_0 $site_9_0.cpd186
    namespace eval ::widgets::$site_10_0.che177 {
        array set save {-background 1 -takefocus 1 -variable 1}
    }
    namespace eval ::widgets::$site_10_0.ent178 {
        array set save {-background 1 -takefocus 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_10_0.lab179 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_10_0.cpd180 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_10_0.cpd181 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_10_0.lab95 {
        array set save {-font 1 -text 1}
    }
    namespace eval ::widgets::$site_9_0.cpd187 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_10_0 $site_9_0.cpd187
    namespace eval ::widgets::$site_10_0.che177 {
        array set save {-background 1 -takefocus 1 -variable 1}
    }
    namespace eval ::widgets::$site_10_0.ent178 {
        array set save {-background 1 -takefocus 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_10_0.lab179 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_10_0.cpd180 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_10_0.cpd181 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_10_0.lab96 {
        array set save {-font 1 -text 1}
    }
    namespace eval ::widgets::$site_9_0.cpd188 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_10_0 $site_9_0.cpd188
    namespace eval ::widgets::$site_10_0.che177 {
        array set save {-background 1 -takefocus 1 -variable 1}
    }
    namespace eval ::widgets::$site_10_0.ent178 {
        array set save {-background 1 -takefocus 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_10_0.lab179 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_10_0.cpd180 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_10_0.cpd181 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_10_0.lab97 {
        array set save {-font 1 -text 1}
    }
    namespace eval ::widgets::$site_9_0.cpd189 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_10_0 $site_9_0.cpd189
    namespace eval ::widgets::$site_10_0.che177 {
        array set save {-background 1 -takefocus 1 -variable 1}
    }
    namespace eval ::widgets::$site_10_0.ent178 {
        array set save {-background 1 -takefocus 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_10_0.lab179 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_10_0.cpd180 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_10_0.cpd181 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_10_0.lab98 {
        array set save {-font 1 -text 1}
    }
    namespace eval ::widgets::$site_9_0.cpd190 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_10_0 $site_9_0.cpd190
    namespace eval ::widgets::$site_10_0.che177 {
        array set save {-background 1 -takefocus 1 -variable 1}
    }
    namespace eval ::widgets::$site_10_0.ent178 {
        array set save {-background 1 -takefocus 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_10_0.lab179 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_10_0.cpd180 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_10_0.cpd181 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_10_0.lab99 {
        array set save {-font 1 -text 1}
    }
    namespace eval ::widgets::$site_9_0.fra191 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_10_0 $site_9_0.fra191
    namespace eval ::widgets::$site_10_0.lab192 {
        array set save {-background 1 -font 1 -text 1}
    }
    namespace eval ::widgets::$site_10_0.lab193 {
        array set save {-background 1 -font 1 -text 1}
    }
    namespace eval ::widgets::$site_10_0.lab194 {
        array set save {-background 1 -font 1 -text 1}
    }
    namespace eval ::widgets::$site_10_0.lab195 {
        array set save {-background 1 -font 1 -text 1}
    }
    namespace eval ::widgets::$site_10_0.cpd83 {
        array set save {-background 1 -font 1 -text 1}
    }
    namespace eval ::widgets::$site_8_0.lab89 {
        array set save {-font 1 -text 1}
    }
    namespace eval ::widgets::$site_8_0.cpd83 {
        array set save {-background 1 -borderwidth 1 -height 1 -relief 1 -width 1}
    }
    set site_9_0 $site_8_0.cpd83
    namespace eval ::widgets::$site_9_0.but203 {
        array set save {-background 1 -command 1 -font 1 -pady 1 -takefocus 1 -text 1}
    }
    namespace eval ::widgets::$site_9_0.lab204 {
        array set save {-background 1 -font 1 -text 1}
    }
    namespace eval ::widgets::$site_9_0.ent205 {
        array set save {-background 1 -takefocus 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_9_0.but206 {
        array set save {-background 1 -command 1 -font 1 -pady 1 -takefocus 1 -text 1}
    }
    namespace eval ::widgets::$site_9_0.cpd207 {
        array set save {-background 1 -command 1 -font 1 -pady 1 -takefocus 1 -text 1}
    }
    set site_4_2 [$base.not84 getframe page5]
    namespace eval ::widgets::$site_4_2 {
        array set save {-background 1 -borderwidth 1}
    }
    set site_4_0 $site_4_2
    namespace eval ::widgets::$site_4_0.not83 {
        array set save {-activebackground 1 -background 1 -font 1 -height 1 -width 1}
        namespace eval subOptions {
            array set save {-text 1}
        }
    }
    set site_6_0 [$site_4_0.not83 getframe page2]
    namespace eval ::widgets::$site_6_0 {
        array set save {-background 1 -borderwidth 1}
    }
    set site_6_0 $site_6_0
    namespace eval ::widgets::$site_6_0.fra83 {
        array set save {-background 1 -borderwidth 1 -height 1 -relief 1 -width 1}
    }
    set site_7_0 $site_6_0.fra83
    namespace eval ::widgets::$site_7_0.but83 {
        array set save {-background 1 -command 1 -pady 1 -text 1}
    }
    namespace eval ::widgets::$site_7_0.fra83 {
        array set save {-background 1 -borderwidth 1 -height 1 -relief 1 -width 1}
    }
    set site_8_0 $site_7_0.fra83
    namespace eval ::widgets::$site_8_0.fra85 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_9_0 $site_8_0.fra85
    namespace eval ::widgets::$site_9_0.lab86 {
        array set save {-background 1 -text 1}
    }
    namespace eval ::widgets::$site_9_0.cpd88 {
        array set save {-background 1 -text 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_8_0.cpd89 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_9_0 $site_8_0.cpd89
    namespace eval ::widgets::$site_9_0.lab86 {
        array set save {-background 1 -text 1}
    }
    namespace eval ::widgets::$site_9_0.cpd88 {
        array set save {-background 1 -text 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_8_0.cpd90 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_9_0 $site_8_0.cpd90
    namespace eval ::widgets::$site_9_0.lab86 {
        array set save {-background 1 -text 1}
    }
    namespace eval ::widgets::$site_9_0.cpd88 {
        array set save {-background 1 -text 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_8_0.cpd91 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_9_0 $site_8_0.cpd91
    namespace eval ::widgets::$site_9_0.lab86 {
        array set save {-background 1 -text 1}
    }
    namespace eval ::widgets::$site_9_0.cpd88 {
        array set save {-background 1 -text 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_8_0.cpd92 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_9_0 $site_8_0.cpd92
    namespace eval ::widgets::$site_9_0.lab86 {
        array set save {-background 1 -text 1}
    }
    namespace eval ::widgets::$site_9_0.cpd88 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_8_0.cpd93 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_9_0 $site_8_0.cpd93
    namespace eval ::widgets::$site_9_0.lab86 {
        array set save {-background 1 -text 1}
    }
    namespace eval ::widgets::$site_9_0.cpd88 {
        array set save {-background 1 -text 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_8_0.cpd94 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_9_0 $site_8_0.cpd94
    namespace eval ::widgets::$site_9_0.lab86 {
        array set save {-background 1 -text 1}
    }
    namespace eval ::widgets::$site_9_0.cpd88 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_8_0.cpd95 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_9_0 $site_8_0.cpd95
    namespace eval ::widgets::$site_9_0.lab86 {
        array set save {-background 1 -text 1}
    }
    namespace eval ::widgets::$site_9_0.cpd88 {
        array set save {-background 1 -text 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_8_0.cpd96 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_9_0 $site_8_0.cpd96
    namespace eval ::widgets::$site_9_0.lab86 {
        array set save {-background 1 -text 1}
    }
    namespace eval ::widgets::$site_9_0.cpd88 {
        array set save {-background 1 -text 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_8_0.cpd97 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_9_0 $site_8_0.cpd97
    namespace eval ::widgets::$site_9_0.lab86 {
        array set save {-background 1 -text 1}
    }
    namespace eval ::widgets::$site_9_0.cpd88 {
        array set save {-background 1 -text 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_8_0.cpd98 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_9_0 $site_8_0.cpd98
    namespace eval ::widgets::$site_9_0.lab86 {
        array set save {-background 1 -text 1}
    }
    namespace eval ::widgets::$site_9_0.cpd88 {
        array set save {-background 1 -text 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_8_0.cpd99 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_9_0 $site_8_0.cpd99
    namespace eval ::widgets::$site_9_0.lab86 {
        array set save {-background 1 -text 1}
    }
    namespace eval ::widgets::$site_9_0.cpd88 {
        array set save {-background 1 -text 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_8_0.cpd100 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_9_0 $site_8_0.cpd100
    namespace eval ::widgets::$site_9_0.lab86 {
        array set save {-background 1 -text 1}
    }
    namespace eval ::widgets::$site_9_0.cpd88 {
        array set save {-background 1 -text 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_8_0.cpd101 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_9_0 $site_8_0.cpd101
    namespace eval ::widgets::$site_9_0.lab86 {
        array set save {-background 1 -text 1}
    }
    namespace eval ::widgets::$site_9_0.cpd88 {
        array set save {-background 1 -text 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_8_0.cpd102 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_9_0 $site_8_0.cpd102
    namespace eval ::widgets::$site_9_0.lab86 {
        array set save {-background 1 -text 1}
    }
    namespace eval ::widgets::$site_9_0.cpd88 {
        array set save {-background 1 -text 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_7_0.cpd103 {
        array set save {-background 1 -borderwidth 1 -height 1 -relief 1 -width 1}
    }
    set site_8_0 $site_7_0.cpd103
    namespace eval ::widgets::$site_8_0.fra85 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_9_0 $site_8_0.fra85
    namespace eval ::widgets::$site_9_0.lab86 {
        array set save {-background 1 -text 1}
    }
    namespace eval ::widgets::$site_9_0.cpd88 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_8_0.cpd89 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_9_0 $site_8_0.cpd89
    namespace eval ::widgets::$site_9_0.lab86 {
        array set save {-background 1 -text 1}
    }
    namespace eval ::widgets::$site_9_0.cpd88 {
        array set save {-background 1 -text 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_8_0.cpd90 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_9_0 $site_8_0.cpd90
    namespace eval ::widgets::$site_9_0.lab86 {
        array set save {-background 1 -text 1}
    }
    namespace eval ::widgets::$site_9_0.cpd88 {
        array set save {-background 1 -text 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_8_0.cpd91 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_9_0 $site_8_0.cpd91
    namespace eval ::widgets::$site_9_0.lab86 {
        array set save {-background 1 -text 1}
    }
    namespace eval ::widgets::$site_9_0.cpd88 {
        array set save {-background 1 -text 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_8_0.cpd92 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_9_0 $site_8_0.cpd92
    namespace eval ::widgets::$site_9_0.lab86 {
        array set save {-background 1 -text 1}
    }
    namespace eval ::widgets::$site_9_0.cpd88 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_8_0.cpd93 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_9_0 $site_8_0.cpd93
    namespace eval ::widgets::$site_9_0.lab86 {
        array set save {-background 1 -text 1}
    }
    namespace eval ::widgets::$site_9_0.cpd88 {
        array set save {-background 1 -text 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_8_0.cpd94 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_9_0 $site_8_0.cpd94
    namespace eval ::widgets::$site_9_0.lab86 {
        array set save {-background 1 -text 1}
    }
    namespace eval ::widgets::$site_9_0.cpd88 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_8_0.cpd95 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_9_0 $site_8_0.cpd95
    namespace eval ::widgets::$site_9_0.lab86 {
        array set save {-background 1 -text 1}
    }
    namespace eval ::widgets::$site_9_0.cpd88 {
        array set save {-background 1 -text 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_8_0.cpd96 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_9_0 $site_8_0.cpd96
    namespace eval ::widgets::$site_9_0.lab86 {
        array set save {-background 1 -text 1}
    }
    namespace eval ::widgets::$site_9_0.cpd88 {
        array set save {-background 1 -text 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_8_0.cpd97 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_9_0 $site_8_0.cpd97
    namespace eval ::widgets::$site_9_0.lab86 {
        array set save {-background 1 -text 1}
    }
    namespace eval ::widgets::$site_9_0.cpd88 {
        array set save {-background 1 -text 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_8_0.cpd98 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_9_0 $site_8_0.cpd98
    namespace eval ::widgets::$site_9_0.lab86 {
        array set save {-background 1 -text 1}
    }
    namespace eval ::widgets::$site_9_0.cpd88 {
        array set save {-background 1 -text 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_8_0.cpd99 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_9_0 $site_8_0.cpd99
    namespace eval ::widgets::$site_9_0.lab86 {
        array set save {-background 1 -text 1}
    }
    namespace eval ::widgets::$site_9_0.cpd88 {
        array set save {-background 1 -text 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_8_0.cpd100 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_9_0 $site_8_0.cpd100
    namespace eval ::widgets::$site_9_0.lab86 {
        array set save {-background 1 -text 1}
    }
    namespace eval ::widgets::$site_9_0.cpd88 {
        array set save {-background 1 -text 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_8_0.cpd101 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_9_0 $site_8_0.cpd101
    namespace eval ::widgets::$site_9_0.lab86 {
        array set save {-background 1 -text 1}
    }
    namespace eval ::widgets::$site_9_0.cpd88 {
        array set save {-background 1 -text 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_8_0.cpd102 {
        array set save {-background 1 -borderwidth 1 -height 1 -width 1}
    }
    set site_9_0 $site_8_0.cpd102
    namespace eval ::widgets::$site_9_0.lab86 {
        array set save {-background 1 -text 1}
    }
    namespace eval ::widgets::$site_9_0.cpd88 {
        array set save {-background 1 -text 1 -textvariable 1}
    }
    set site_6_1 [$site_4_0.not83 getframe page3]
    namespace eval ::widgets::$site_6_1 {
        array set save {-background 1 -borderwidth 1}
    }
    set site_6_0 $site_6_1
    namespace eval ::widgets::$site_6_0.fra83 {
        array set save {-background 1 -borderwidth 1 -height 1 -relief 1 -width 1}
    }
    set site_7_0 $site_6_0.fra83
    namespace eval ::widgets::$site_7_0.cpd84 {
        array set save {-background 1 -command 1 -font 1 -pady 1 -takefocus 1 -text 1}
    }
    namespace eval ::widgets::$site_7_0.cpd85 {
        array set save {-background 1 -command 1 -font 1 -pady 1 -takefocus 1 -text 1}
    }
    namespace eval ::widgets::$site_7_0.cpd86 {
        array set save {-background 1 -command 1 -font 1 -pady 1 -takefocus 1 -text 1}
    }
    namespace eval ::widgets::$site_7_0.cpd87 {
        array set save {-background 1 -font 1 -text 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_7_0.but85 {
        array set save {-background 1 -command 1 -font 1 -pady 1 -takefocus 1 -text 1}
    }
    namespace eval ::widgets::$site_7_0.but86 {
        array set save {-command 1 -font 1 -pady 1 -takefocus 1 -text 1}
    }
    namespace eval ::widgets::$site_6_0.fra84 {
        array set save {-background 1 -borderwidth 1 -height 1 -relief 1 -width 1}
    }
    set site_7_0 $site_6_0.fra84
    namespace eval ::widgets::$site_7_0.tix86 {
        array set save {-borderwidth 1 -browsecmd 1 -height 1 -scrollbar 1 -takefocus 1 -width 1}
    }
    namespace eval ::widgets::$site_6_0.fra87 {
        array set save {-background 1 -borderwidth 1 -height 1 -relief 1 -width 1}
    }
    set site_7_0 $site_6_0.fra87
    namespace eval ::widgets::$site_7_0.ent88 {
        array set save {-background 1 -takefocus 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_6_0.cpd83 {
        array set save {-background 1 -borderwidth 1 -height 1 -relief 1 -width 1}
    }
    set site_7_0 $site_6_0.cpd83
    namespace eval ::widgets::$site_7_0.ent90 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_7_0.ent91 {
        array set save {-background 1}
    }
    namespace eval ::widgets::$site_7_0.lab92 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_7_0.lab93 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_7_0.cpd94 {
        array set save {-background 1 -command 1 -pady 1 -text 1}
    }
    namespace eval ::widgets::$site_7_0.cpd95 {
        array set save {-background 1 -command 1 -pady 1 -text 1}
    }
    namespace eval ::widgets::$site_6_0.cpd84 {
        array set save {-background 1 -borderwidth 1 -height 1 -relief 1 -width 1}
    }
    set site_7_0 $site_6_0.cpd84
    namespace eval ::widgets::$site_7_0.ent90 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_7_0.ent91 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_7_0.cpd94 {
        array set save {-background 1 -command 1 -pady 1 -text 1}
    }
    namespace eval ::widgets::$site_7_0.cpd95 {
        array set save {-background 1 -command 1 -pady 1 -text 1}
    }
    namespace eval ::widgets::$site_7_0.cpd98 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_7_0.cpd99 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_6_0.cpd85 {
        array set save {-background 1 -borderwidth 1 -height 1 -relief 1 -width 1}
    }
    set site_7_0 $site_6_0.cpd85
    namespace eval ::widgets::$site_7_0.ent85 {
        array set save {-background 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_7_0.but88 {
        array set save {-background 1 -command 1 -pady 1 -text 1}
    }
    namespace eval ::widgets::$site_7_0.com84 {
        array set save {-entrybg 1 -takefocus 1 -text 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_7_0.but85 {
        array set save {-background 1 -command 1 -pady 1 -text 1}
    }
    namespace eval ::widgets::$site_7_0.but83 {
        array set save {-background 1 -command 1 -pady 1 -text 1}
    }
    namespace eval ::widgets::$site_7_0.cpd83 {
        array set save {-entrybg 1 -takefocus 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_7_0.cpd85 {
        array set save {-background 1 -command 1 -pady 1 -text 1}
    }
    set base .top85
    namespace eval ::widgets::$base {
        set set,origin 1
        set set,size 1
        set runvisible 1
    }
    namespace eval ::widgets::$base.fra86 {
        array set save {-background 1 -borderwidth 1 -height 1 -relief 1 -width 1}
    }
    set site_3_0 $base.fra86
    namespace eval ::widgets::$site_3_0.ent87 {
        array set save {-background 1 -font 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_3_0.but88 {
        array set save {-background 1 -command 1 -font 1 -pady 1 -text 1}
    }
    namespace eval ::widgets::$site_3_0.lab83 {
        array set save {-background 1 -font 1 -text 1}
    }
    namespace eval ::widgets::$site_3_0.can83 {
        array set save {-background 1 -borderwidth 1 -closeenough 1 -confine 1 -height 1 -relief 1 -width 1}
    }
    set base .top86
    namespace eval ::widgets::$base {
        set set,origin 1
        set set,size 1
        set runvisible 1
    }
    namespace eval ::widgets::$base.fra87 {
        array set save {-background 1 -borderwidth 1 -height 1 -relief 1 -width 1}
    }
    set site_3_0 $base.fra87
    namespace eval ::widgets::$site_3_0.tix83 {
        array set save {-borderwidth 1 -height 1 -scrollbar 1 -width 1}
    }
    namespace eval ::widgets::$base.fra83 {
        array set save {-background 1 -borderwidth 1 -height 1 -relief 1 -width 1}
    }
    set site_3_0 $base.fra83
    namespace eval ::widgets::$site_3_0.but91 {
        array set save {-background 1 -command 1 -font 1 -pady 1 -text 1}
    }
    namespace eval ::widgets::$base.fra84 {
        array set save {-background 1 -borderwidth 1 -height 1 -relief 1 -width 1}
    }
    set site_3_0 $base.fra84
    namespace eval ::widgets::$site_3_0.cpd85 {
        array set save {-background 1 -font 1 -foreground 1 -text 1}
    }
    namespace eval ::widgets::$site_3_0.cpd86 {
        array set save {-background 1 -font 1 -justify 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_3_0.but90 {
        array set save {-background 1 -command 1 -font 1 -pady 1 -text 1}
    }
    namespace eval ::widgets::$base.can93 {
        array set save {-background 1 -borderwidth 1 -closeenough 1 -height 1 -width 1}
    }
    namespace eval ::widgets::$base.m83 {
        array set save {-activeborderwidth 1 -borderwidth 1 -font 1 -tearoff 1}
    }
    set base .top95
    namespace eval ::widgets::$base {
        set set,origin 1
        set set,size 1
        set runvisible 1
    }
    namespace eval ::widgets::$base.fra96 {
        array set save {-borderwidth 1 -height 1 -relief 1 -width 1}
    }
    set site_3_0 $base.fra96
    namespace eval ::widgets::$site_3_0.lab97 {
        array set save {-font 1 -foreground 1 -text 1}
    }
    namespace eval ::widgets::$site_3_0.lab98 {
        array set save {-font 1 -text 1}
    }
    namespace eval ::widgets::$site_3_0.lab99 {
        array set save {-background 1 -font 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_3_0.cpd100 {
        array set save {-font 1 -foreground 1 -text 1}
    }
    namespace eval ::widgets::$site_3_0.cpd101 {
        array set save {-background 1 -font 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_3_0.cpd102 {
        array set save {-font 1 -foreground 1 -text 1}
    }
    namespace eval ::widgets::$site_3_0.cpd103 {
        array set save {-background 1 -font 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_3_0.cpd104 {
        array set save {-font 1 -text 1}
    }
    namespace eval ::widgets::$site_3_0.ent105 {
        array set save {-background 1 -takefocus 1 -textvariable 1}
    }
    namespace eval ::widgets::$site_3_0.but106 {
        array set save {-background 1 -command 1 -font 1 -pady 1 -text 1}
    }
    namespace eval ::widgets::$site_3_0.cpd83 {
        array set save {-font 1 -text 1}
    }
    namespace eval ::widgets::$site_3_0.cpd84 {
        array set save {-background 1 -takefocus 1 -textvariable 1}
    }
    namespace eval ::widgets::$base.m83 {
        array set save {-activeborderwidth 1 -borderwidth 1 -tearoff 1}
    }
    namespace eval ::widgets_bindings {
        set tagslist {_TopLevel _vTclBalloon}
    }
    namespace eval ::vTcl::modules::main {
        set procs {
            init
            main
            BTN_SEARCH_LOT
            FUNC_SELECT_LOT_LISTBOX
            FUNC_GET_DESCRIPTION
            FUNC_SELECT_JOB_LISTBOX
            FUNC_CLEAR_LOT
            FUNC_SELECT_SUBDSC_COMBOBOX
            FUNC_SELECT_MAINDSC_COMBOBOX
            FUNC_GET_HOSTSTATUS
            FUNC_SET_STATUS
            BTN_START_LOT
            BTN_SET_DOWN
            FUNC_EXECUTE_LOOP
            BTN_SEARCH_RFID
            FUNC_CHECK_COMMENT
            FUNC_CHECK_TPA
            FUNC_CHECK_T1T2
            BTN_ADD_RETEST
            FUNC_CHECK_SCOPSVERSION
            FUNC_CHECK_TPMS
            BTN_END_LOT
            FUNC_CHECK_OPERATORID
            TCL_LIB_FTP
            FUNC_SET_LANGUAGE
            FUNC_CHECK_VARIABLE
            BTN_INPUT_TESTRESULT
            FUNC_CHECK_SWR
            FUNC_EXECUTE_APL
            FUNC_DEBUG
            FUNC_GET_LOTINFORMATION
            test
            FUNC_LOAD_FUNCTIONS
            FUNC_CHECK_TPGM
            CONTACT_POINT
            TEMPLATE_MESSAGEBOX
            TEMPLATE_QUERY
            FD
            FUNC_SET_SKIN
            FUNC_CREATE_CONFIGFILE
            FUNC_INITIALIZE_VARIABLE
            FM
            FUNC_UPDATE_IP
            FUNC_UPDATE_SCOPSVERSION
            FUNC_EXECUTE_XTERM
            FUNC_CHECK_DOWNTIME
            FUNC_INITIALIZE_FLAG
            FUNC_SET_FLAG_END_LOT
            FUNC_PARSE_CONDITION
            FUNC_CHECK_BINAGENT
            FUNC_CHECK_HP93KDRIVER
            FUNC_DISPLAY_SWR
            test1
            test3
            FUNC_DOWNLOAD_FILE
            FUNC_UPDATE_OS
            FUNC_GET_TESTINFORMATION
            FUNC_SELECT_DEBUG_LISTBOX
            FUNC_DISPLAY_MESSAGE
            TEMPLATE_DISPLAY_MESSAGE
            FUNC_APL_T5585
            FUNC_SET_MESSAGE
            FUNC_SEND_UDPSTRING
            FUNC_SEND_TCPSTRING
            FUNC_SEND_TCPSTRINGRETURN
            TCL_LIB_MIME
            TCL_LIB_SMTP
            FUNC_LOAD_LIBRARY
            FUNC_SEND_EMAIL
            TEMPLATE_SEND_EMAIL
            TCL_LIB_BASE64
            TCL_LIB_MD5
            FUNC_SEND_DEBUG
            ATK_GROUP_START_LOT
            ATK_GROUP_HOSTSTATUS
            ATK_GROUP_SELECT_LOT_LISTBOX
            FUNC_VARTEST
            test4
            FUNC_SET_DELIMITER
            FUNC_CREATE_SOCKET
            FUNC_SEND_QRY_ORG
            FUNC_SEND_QRY_EXCEPTION
            FUNC_SEND_QRY
            FUNC_RFID_COMPARE_LOTS
            FUNC_RFID_INITIALIZE
            FUNC_RFID_REFRESH
            FUNC_BIND_WIDGET
            FUNC_CLEAR_FILE
            FUNC_KILL_PROCESS
            FUNC_PARSEANDSET_STRING
            FUNC_REMOTE_SCOPS
            FUNC_CHECK_MADEVICE
            FUNC_CHECK_BOARDKIT_NONQCT
            FUNC_CHECK_BOARDKIT_QCT
            TEMPLATE_TRYCATCH
            FUNC_RFID_CHECK_PROBETOUCHDOWN
            FUNC_RFID_CHECK_SOCKETTOUCHDOWN
            FUNC_APL_WINDOWS
            FUNC_APL_T2000
            FUNC_APL_XILINX
            FUNC_GET_CONFIG_ORG
            FUNC_GET_CONFIG
            ATK_GROUP_END_LOT
            FUNC_CHECK_DATASTREAM
            FUNC_CHECK_DRL
            ATK_GROUP_APL
            FUNC_CREATE_UDPSENDER
            FUNC_DOWNLOAD_UDPSENDER
            test5
            test2
            FUNC_CHECK_FILE
            FUNC_CONFIRM_VALIDATION
            FUNC_DEBUG_CLEAR
            FUNC_DEBUG_SAVE
            FUNC_DEBUG_DELETEFILE
            FUNC_DEBUG_SENDFILE
            FUNC_CHECK_OPERATORID_org
            FUNC_CONFIRM_VALIDATION_LOG
            FUNC_CHECK_FULLTEST
            FUNC_CHECK_RETEST
            FUNC_APL_MICROCHIP
            ATK_GROUP_ADDRETEST
            FUNC_APL_EVE_SLT
            FUNC_APL_EVE_UFLEX
            FUNC_RFID_CHECK
            FUNC_RFID_CLEAR_SOCKETTOUCHCOUNT
            FUNC_RFID_EXTEND_SOCKETLIMIT
            FUNC_RFID_CLEAR_PROBETOUCHDOWN
            FUNC_RFID_EXTEND_PROBELIMIT
            FUNC_CHECK_PROBE
            FUNC_CHECK_PROBESITEVARIANCE
            FUNC_APL_T2000_org
            FUNC_APL_ADVANTXXXX_20140331
            FUNC_APL_ADVANTXXXX
            FUNC_APL_D10_20140331
            FUNC_APL_D10
            FUNC_APL_MAVERICK_20140414
            FUNC_APL_MAVERICK
            FUNC_APL_MWEST_20140414
            FUNC_APL_MWEST
            FUNC_APL_ETS_20140414
            FUNC_APL_ETS
            FUNC_APL_J750_20140414
            FUNC_APL_J750
            FUNC_APL_MICROCHIP_20140414
            FUNC_APL_ARMAR_20140414
            FUNC_APL_ARMAR
            FUNC_APL_QSLT
            FUNC_APL_NXP
            FUNC_CHECK_TESTERASSIGNMENT
            FUNC_RFID_CHECK_SOCKETCLEAR
            FUNC_CHECK_JUNCTIONTEMPERATURE
            FUNC_CHECK_HSFANDSVR
            FUNC_CHECK_BOARDCORRELATION
            FUNC_APL_HP
            FUNC_APL_J750_NXP
            FUNC_APL_HP93K_NXP
            FUNC_CHECK_PREVIOUSSCOPS
            FUNC_CHECK_WIPFLOW
            FUNC_UPDATE_SCOPS
            FUNC_UPDATE_ID
            FUNC_APL_T2000_LSI_SUB
            FUNC_SPLIT_STRING
            FS
            FUNC_APL_AMD_HP93K
            FUNC_APL_EVE_HP93K
            FUNC_APL_QCT_T2000
            FUNC_APL_STS_QCT
            FUNC_APL_HP93K_NXP_MULTI_DEV
            FUNC_APL_MTK_UFLEX
            FUNC_APL_EXECUTE_SP
            FUNC_CHECK_QUALTESTER
            FUNC_APL_EXECUTE_SP_SUB
            FUNC_CHECK_RETEST_HISTORY
            FUNC_APL_HP_SMT8_COPY
            FUNC_APL_HP_SMT8_MAKE
            FUNC_RFID_LOTCHECK
            FUNC_CHECK_SOCKETCORRELATION
            FUNC_RFID_CHECK_CORETOUCHDOWN
            FUNC_CHECK_PROBECORRELATION
            FUNC_CHECK_RETEST_SKIP
            FUNC_PROBE_TD_OVER_CONFIRM
            FUNC_CHECK_HARDWARE_INOUT
            FUNC_RFID_CLEAR_CORETOUCHCOUNT
            FUNC_RFID_EXTEND_CORELIMIT
            FUNC_CHECK_PROBECARD
            FUNC_RFID_EXTEND_CLEANINGSHEETLIMIT
            FUNC_APL_NVIDIA_BUMP
            FUNC_CHECK_QUALTESTER_QCT
        }
        set compounds {
        }
        set projectType single
    }
}
}

#################################
# USER DEFINED PROCEDURES
#
#############################################################################
## Procedure:  main

proc ::main {argc argv} {
#Probe TD OVER ALTER
wm protocol .top95 WM_DELETE_WINDOW {
    if {[tk_messageBox -message "Quit?" -type yesno] eq "yes"} {
       Window hide .top95
    }
}

### ### set root directory
global g_rootdir
set g_rootdir [file dirname [info nameofexecutable]]

# Set Tester Status Ready diff flag 
global g_readydiff_flag
set g_readydiff_flag 0
global g_readydiff_time
set g_readydiff_time 0

### set delimiter
FUNC_SET_DELIMITER

### initialize valuse
FUNC_INITIALIZE_VARIABLE

###
FUNC_INITIALIZE_FLAG

### set host name
global g_hostname
set g_hostname [exec hostname]

if { $g_hostname == "KRK3OFLTP00062" } {
    set g_hostname  "test"
}

if { $g_hostname == "KRK3OFLTP00027" } {
    set g_hostname  "test"
}

if { $g_hostname == "VNV1OFLTP00087" } {
    set g_hostname  "test"
}
### set os
global tcl_platform
global g_os

if { [string match -nocase "*window*" $tcl_platform(platform)] == 0 } { 
    if [catch { 
        set g_os [exec uname]
    } err] {
        set g_os ""
    }
    
}

### get platform by TCL/TK
global tcl_platform

global g_tclplatform
set g_tclplatform $tcl_platform(platform)

### get user id by TCL/TK
global g_tcluserid
set g_tcluserid $tcl_platform(user)

### set scops server
global g_scopsserver

# ATV server 
set g_scopsserver "10.201.16.50"

### get tester config
FUNC_GET_CONFIG "FILE"
FUNC_GET_CONFIG "DB"
FUNC_GET_CONFIG "FILE"



### set scops version
global g_scopsversion
set g_scopsversion "1"
wm title .top83 "Scops3 ver.$g_scopsversion-$g_hostname"


### kill previous scops for sole operation
FUNC_CHECK_PREVIOUSSCOPS

### set languae
FUNC_SET_LANGUAGE

### load tcl libraries
FUNC_LOAD_LIBRARY

###
FUNC_GET_DESCRIPTION

FUNC_UPDATE_IP
FUNC_UPDATE_OS
FUNC_UPDATE_ID
FUNC_UPDATE_SCOPSVERSION

###
FUNC_EXECUTE_LOOP

### check tester's status
FUNC_GET_HOSTSTATUS

### lock admin tool
global g_note_root
#$g_note_root itemconfigure page5 -state disabled

### clear files that we don't need
FUNC_CLEAR_FILE

FUNC_LOAD_FUNCTIONS

### widget control
FUNC_BIND_WIDGET
}
#############################################################################
## Procedure:  BTN_SEARCH_LOT

proc ::BTN_SEARCH_LOT {flag} {
global widget

FUNC_BIND_WIDGET


global g_cd
global g_rd


global g_hostname
global g_lotname
global g_lotarray
global g_lst_lotname



## set operator id
global g_operatorid_sub
    
if { [FUNC_CHECK_VARIABLE g_operatorid_sub] == "NULL" } {
    set g_operatorid_sub ""
}


## rfid flag ###########
global g_rfid_flag
########################

### clear RFID information
if { $flag == "CLEAR" } {
 
    global g_operatorid
    set g_operatorid ""
 
    set g_rfid_flag "FALSE"
    FUNC_RFID_INITIALIZE 
    
    set g_operatorid_sub [string map {"_R" ""} $g_operatorid_sub] 
    global g_traylot_flag
    set g_traylot_flag 1
      
} else {
    set g_rfid_flag "TRUE"
    
    if { [string match -nocase "*_R*" $g_operatorid_sub] == 0 } {
        set g_operatorid_sub [format "%s%s" $g_operatorid_sub "_R"]
    }
}


if { [string length [string trim [ent_lotname get]]] < 3 } {
    set msg "Input more than 2 characters!"
    set choice [ tk_messageBox -title "Search Lot Error" -icon warning -message [FM "" $msg ""] ]
    return
}

set g_lotname [string toupper $g_lotname]

#set g_hostname "test"

set qry "SCOPS,SearchLot,$g_hostname,$g_lotname*"

set res [FUNC_SEND_QRY $qry]

if { $res == "" } {
    set choice [ tk_messageBox -title "Search Lot Error" -icon warning -message "NO RESULT FOR \"$g_lotname\"" ]
    FUNC_CLEAR_LOT
    return
}

if { [lindex [split $res $g_cd] 0] == "FAIL" } {
    set choice [ tk_messageBox -title "Search Lot Error" -icon warning -message [FM "" "" $res] ]
    FUNC_CLEAR_LOT
    return
}


### initialize ###########################
$g_lst_lotname subwidget listbox delete 0 end
array unset g_lotarray
FUNC_CLEAR_LOT
##########################################

if { [string length [string trim $res]] == 0 || $res == "" } {
    return
}

set res_ary [split $res $g_rd]

for { set i 0 } { $i < [llength $res_ary] } { incr i } {

    set lotname [lindex [split [lindex $res_ary $i] $g_cd] 0]
    set dcc [lindex [split [lindex $res_ary $i] $g_cd] 1]
    set operation [lindex [split [lindex $res_ary $i] $g_cd] 2]

    set g_lotarray($i.lotname) $lotname
    set g_lotarray($i.dcc) $dcc
    set g_lotarray($i.operation) $operation

    $g_lst_lotname subwidget listbox insert end "$lotname / DCC : $dcc / $operation"

}

### disable widget
global g_btn_start
$g_btn_start configure -state disable
global g_ent_operatorid
$g_ent_operatorid configure -state normal
}
#############################################################################
## Procedure:  FUNC_SELECT_LOT_LISTBOX

proc ::FUNC_SELECT_LOT_LISTBOX {} {
global widget


global g_lstlotname_flag
global g_lst_lotname
global g_lotarray

global g_lst_job
global g_jobarray

global g_hostname
global g_lotname
global g_dcc
global g_operation


if { [$g_lst_lotname subwidget listbox size] == 0 } {
    puts "no result!"
    return
}

if { $g_lstlotname_flag != "TRUE" } {
    #puts "not true"
    set g_lstlotname_flag "TRUE"
    return
} else {
    #puts "true"
    set g_lstlotname_flag "FALSE"
    
}

global g_lotlist_idx

set g_lotlist_idx [$g_lst_lotname subwidget listbox curselection]

set g_lotname [string trim $g_lotarray($g_lotlist_idx.lotname)]
set g_dcc [string trim $g_lotarray($g_lotlist_idx.dcc)]
set g_operation [string trim $g_lotarray($g_lotlist_idx.operation)]

### initialize job
global g_job
set g_job ""

#puts "$lotname / $dcc / $operation"

FUNC_GET_LOTINFORMATION

ATK_GROUP_SELECT_LOT_LISTBOX
}
#############################################################################
## Procedure:  FUNC_GET_DESCRIPTION

proc ::FUNC_GET_DESCRIPTION {} {
global widget
global g_maindescriptionarray

global g_cd
global g_rd

set qry "SCOPS,GETDESCRIPTION,MAIN,*"

set res [FUNC_SEND_QRY $qry]

puts "res : $res"


if { [string trim $res] == "" || [string match -nocase "*fail*" $res] == 1 } {
    set choice [ tk_messageBox -title "Lot Select Error" -icon warning -message "No result from DB!   "]
    return
}


array unset g_maindescriptionarray
set maindescription ""
set tmparray [split $res $g_rd]

for { set i 0 } { $i < [llength $tmparray] } { incr i } {

    set g_maindescriptionarray($i.statusid) [lindex [split [lindex $tmparray $i] "/"] 0]
    set g_maindescriptionarray($i.status) [lindex [split [lindex $tmparray $i] "/"] 1]
    
    puts "$tmparray"
    puts "[lindex [split [lindex $tmparray $i] "/"] 0] : [lindex [split [lindex $tmparray $i] "/"] 1]"
    
    set maindescription "$maindescription \"$g_maindescriptionarray($i.status)\""
}

ComboBox1 configure -text ""
ComboBox1 configure -values $maindescription
}
#############################################################################
## Procedure:  FUNC_SELECT_JOB_LISTBOX

proc ::FUNC_SELECT_JOB_LISTBOX {} {
global widget

global g_jobarray
global g_job
global g_lst_job

if { [$g_lst_job subwidget listbox size] == 0 } {
    puts "no result!"
    return
}

set idx [$g_lst_job subwidget listbox curselection]
set g_job [string trim $g_jobarray($idx.job)]

### activate operatorid entry and deactivate start button
global g_rfid_flag

if { $g_rfid_flag != "TRUE" } {
    global g_ent_operatorid
    $g_ent_operatorid configure -state normal
} else {
    global g_btn_start
    $g_btn_start configure -state normal
}
}
#############################################################################
## Procedure:  FUNC_CLEAR_LOT

proc ::FUNC_CLEAR_LOT {} {
global widget

## array
#global g_lotarray
#array unset g_lotarray

#global g_lst_lotname
#$g_lst_lotname subwidget listbox delete 0 end

#global g_jobarray
#array unset g_jobarray

#global g_lst_job
#$g_lst_job subwidget listbox delete 0 end


## lot information
global g_lotname
global g_dcc
global g_operation
global g_job
global g_devicename
global g_customer
global g_testprogram
global g_testprogramrev
global g_condition
global g_testtime
global g_yieldlimit
global g_incount
global g_qasample
global g_package
global g_dimension
global g_lead
global g_swrnumber
global g_swrmessage
global g_temperature
global g_handlertype

#set g_lotname ""
set g_dcc ""
set g_operation ""
set g_job ""
set g_devicename ""
set g_customer ""
set g_testprogram ""
set g_testprogramrev ""
set g_condition ""
set g_testtime ""
set g_yieldlimit ""
set g_incount ""
set g_qasample ""
set g_package "" 
set g_dimension ""
set g_lead ""
set g_swrnumber ""
set g_swrmessage ""
set g_temperature ""
set g_handlertype ""

### clear job list
global g_lst_job 
$g_lst_job subwidget listbox delete 0 end
}
#############################################################################
## Procedure:  FUNC_SELECT_SUBDSC_COMBOBOX

proc ::FUNC_SELECT_SUBDSC_COMBOBOX {} {
global widget

global g_cd
global g_rd

global g_maindescriptionid
global g_subdescriptionarray
global g_subdescriptionid
global g_subdescription
global g_actiondescription

#puts "size : [array size g_subdescriptionarray]"

### set sub description id
set g_subdescriptionid ""

for { set i 0 } { $i < [expr [array size g_subdescriptionarray]/2] } { incr i } {

    #puts "$g_subdescription == $g_subdescriptionarray($i.status)"

    if { $g_subdescription == $g_subdescriptionarray($i.status) } {
        set g_subdescriptionid $g_subdescriptionarray($i.statusid)
        #FD "sub dsc : $g_subdescription, id : $g_subdescriptionid"
    }
}

if { $g_subdescriptionid == "" || [string match -nocase "*NO_CAUSE*" $g_subdescription] == 1 } { return }

### get action list
set qry "SCOPS,GETDESCRIPTION,ACTION,$g_maindescriptionid,$g_subdescriptionid*"

set res [FUNC_SEND_QRY $qry]

if { [lindex [split $res $g_rd] 0] == "FAIL" } {
    set msg {"Fail to Get Action List!" "\xAC\xB9\x4C\xD1\xA4\xC2\xB8\xD2\x20\x00\xF5\xAC\x15\xC8\x20\x00\xDD\xC0\x31\xC1\xD0\xC5\x20\x00\xE4\xC2\x28\xD3\x58\xD5\x00\xC6\xB5\xC2\xC8\xB2\xE4\xB2\x21\x00"}
    set choice [ tk_messageBox -title "Add Retest Error" -icon warning -message [FM "" $msg $res] ]
    return
} 

#puts "action desc : $res"

if { $res == "" } {

    ComboBox3 configure -text "NO_ACTION"
    ComboBox3 configure -values \"NO_ACTION\"
    
} else {

    #puts "1"
    
    set actiondescription ""
    set tmparray [split $res $g_rd]

    for { set i 0 } { $i < [llength $tmparray] } { incr i } {
    
        set actiondescription "$actiondescription \"[lindex $tmparray $i]\""
    }
    
    ComboBox3 configure -text ""
    ComboBox3 configure -values $actiondescription
}
}
#############################################################################
## Procedure:  FUNC_SELECT_MAINDSC_COMBOBOX

proc ::FUNC_SELECT_MAINDSC_COMBOBOX {} {
global widget

global g_cd
global g_rd

global g_maindescriptionarray
global g_maindescription
global g_maindescriptionid

global g_subdescriptionarray
global g_subdescriptionid


#puts "size : [array size g_maindescriptionarray]"

set g_maindescriptionid ""

for { set i 0 } { $i < [expr [array size g_maindescriptionarray]/2] } { incr i } {
    if { $g_maindescription == $g_maindescriptionarray($i.status) } {
        set g_maindescriptionid $g_maindescriptionarray($i.statusid)
        FD "main dsc : $g_maindescription, id : $g_maindescriptionid"
    }
}

### initialize action combobox
ComboBox3 configure -text ""
ComboBox3 configure -values \"\"


set qry "SCOPS,GETDESCRIPTION,SUB,$g_maindescriptionid,*"

set res [FUNC_SEND_QRY $qry]

puts "sub desc : $res"

if { [lindex [split $res $g_rd] 0] == "FAIL" } {
    set choice [ tk_messageBox -title "Main DSC Select Error" -icon warning -message "No result from DB!! \n\n$res   "]
    return
}

array unset g_subdescriptionarray

if { $res == "" } {

    ComboBox2 configure -text "NO_CAUSE"
    ComboBox2 configure -values \"NO_CAUSE\"
    set g_subdescriptionarray(0.statusid) "0"
    set g_subdescriptionarray(0.status) "NO_CAUSE"
    
} else {

    set subdescription ""
    set tmparray [split $res $g_rd]

    for { set i 0 } { $i < [llength $tmparray] } { incr i } {

        set g_subdescriptionarray($i.statusid) [lindex [split [lindex $tmparray $i] "/"] 0]
        set g_subdescriptionarray($i.status) [lindex [split [lindex $tmparray $i] "/"] 1]
    
        #puts "$tmparray"
        #puts "[lindex [split [lindex $tmparray $i] "/"] 0] : [lindex [split [lindex $tmparray $i] "/"] 1]"
    
        set subdescription "$subdescription \"$g_subdescriptionarray($i.status)\""
    }

    ComboBox2 configure -values $subdescription
}

ComboBox2 configure -text $g_subdescriptionarray(0.status)
set g_subdescriptionid $g_subdescriptionarray(0.statusid)

puts "g_subdescriptionid : $g_subdescriptionid"
}
#############################################################################
## Procedure:  FUNC_GET_HOSTSTATUS

proc ::FUNC_GET_HOSTSTATUS {} {
global widget

global g_cd
global g_rd

global g_hostname
global g_previousoperatorid
global g_operatorid_sub


set qry "SCOPS,GetHostStatus,$g_hostname*"
set res ""
set res [FUNC_SEND_QRY $qry]

#FD "hoststatus : $res"

if { [string trim [lindex [split $res ","] 0] ] == "" } {
    #set choice [ tk_messageBox -title "FUNC_GET_HOSTSTATUS ERROR" -icon warning -message "No result from DB!   "]    
    return ""
}

set resultarray [split $res $g_cd]


## testing
if { [lindex $resultarray 0] == 101 || [lindex $resultarray 0] == 102 || [lindex $resultarray 0] == 103 || [lindex $resultarray 0] == 104 } {

    global g_hoststatus
    
    global g_lotname
    global g_dcc
    global g_operation
    global g_job
    global g_devicename
    global g_customer
    global g_testprogram
    global g_testprogramrev
    global g_condition
    global g_testtime
    global g_yieldlimit
    global g_incount
    global g_qasample
    global g_package
    global g_dimension
    global g_lead
    global g_swrnumber
    global g_swrmessage
    
    global g_totalcount
    global g_goodcount
    global g_yieldrate
    
    global g_jobstatus
    
    global g_handlertype
    global g_coincidence_flag
    
    set g_hoststatus [lindex $resultarray 0]
    set g_lotname [lindex $resultarray 1]
    set g_dcc [lindex $resultarray 2]
    set g_operation [lindex $resultarray 3]
    set g_job [lindex $resultarray 4]
    set g_devicename [lindex $resultarray 5]
    set g_customer [lindex $resultarray 6]
    set g_testprogram [lindex $resultarray 7]
    set g_testprogramrev [lindex $resultarray 8]
    set g_condition [lindex $resultarray 9]
    set g_testtime [lindex $resultarray 10]
    set g_yieldlimit [lindex $resultarray 11]
    set g_incount [lindex $resultarray 12]
    set g_qasample [lindex $resultarray 13]
    set g_package [lindex $resultarray 14]
    set g_dimension [lindex $resultarray 15]
    set g_lead [lindex $resultarray 16]
    set g_swrnumber [lindex $resultarray 17]
    set g_swrmessage [lindex $resultarray 18]
    set g_totalcount [lindex $resultarray 19]
    set g_goodcount [lindex $resultarray 20]
    set g_yieldrate [lindex $resultarray 21]    
    set g_jobstatus [lindex $resultarray 22]
    set g_handlertype [lindex $resultarray 23]
    set g_previousoperatorid [lindex $resultarray 24]
    set g_coincidence_flag [lindex $resultarray 25]

## handling
} elseif { [lindex $resultarray 0] == 11 } {

    global g_hoststatus
    global g_hoststatusname
    global g_hoststatusdifftime
    
    set g_hoststatus [lindex $resultarray 0]
    set g_hoststatusname [lindex $resultarray 1]
    set g_hoststatusdifftime [lindex $resultarray 2]
    
    
    set g_previousoperatorid ""    
    set g_operatorid_sub ""

## down
} else {
    
    global g_hoststatus
    global g_hoststatusname
    global g_hoststatusdifftime
    
    set g_hoststatus [lindex $resultarray 0]
    set g_hoststatusname [lindex $resultarray 2]    
    set g_hoststatusdifftime [lindex $resultarray 3]
}


FUNC_CHECK_SCOPSVERSION
FUNC_SET_STATUS
FUNC_SET_SKIN

ATK_GROUP_HOSTSTATUS
}
#############################################################################
## Procedure:  FUNC_SET_STATUS

proc ::FUNC_SET_STATUS {} {
global widget

global g_hoststatus
global g_tester_status


# testing
if { $g_hoststatus == 101 || $g_hoststatus == 102 || $g_hoststatus == 103 || $g_hoststatus == 104 } {

    #FD "status : testing"

    ## tester is running or not ######
    global g_testing_flag
    set g_testing_flag "TESTING"
    ##################################
    
    
    #set tester status label
    global g_operation
    global g_job
    #if { [string match -nocase "*re*" $g_job] == 0 } {
        #set g_tester_status "$g_operation"
    #} else {
        #set g_tester_status [format "%s %s" $g_operation [string range $g_job [string first "R" $g_job] end]]
    #}
    
    set g_tester_status [format "%s %s" $g_operation $g_job]
        
    global g_jobstatus
    global g_readydiff_flag
    global g_readydiff_time
    
    if { $g_jobstatus != 1 } { 
        if { $g_readydiff_flag == 0 } {
            set g_readydiff_flag 1
            set g_readydiff_time 0
        } else {
            set g_readydiff_time [expr $g_readydiff_time + 1]   
        }
        set readydiff_time_format [format " (%s Mins)" $g_readydiff_time]
        set g_tester_status [append g_tester_status " \nREADY" $readydiff_time_format]
    } else {
        set g_readydiff_flag 0
        set g_tester_status [append g_tester_status " \nTESTING"]
    }  
        
    global g_manual_flag
    if { $g_manual_flag == "ON" } {
        set  g_tester_status [format "%s %s" $g_tester_status "(MANUAL)"]
    }
    

# handling
} elseif { $g_hoststatus == 11 } {

    #FD "status : handling"

    ## tester is running or not ######
    global g_testing_flag
    set g_testing_flag "HANDLING"
    ##################################

    global g_tester_status
    global g_hoststatusname
    global g_hoststatusdifftime

    set g_tester_status [format "%s (%s)" $g_hoststatusname $g_hoststatusdifftime]

    #puts "handling"
    #puts "g_hoststatus : $g_hoststatus"
    #puts "g_hoststatusdifftime : $g_hoststatusdifftime"
    #puts "g_tester_status : $g_tester_status"
        
                  


# down
} else {

    #FD "status : down"

    ## tester is running or not ######
    global g_testing_flag
    set g_testing_flag "DOWN"
    ##################################

    global g_tester_status
    global g_hoststatusname
    global g_hoststatusdifftime
    
    if { [string match -nocase "*|*" $g_hoststatusname] == 1 } {
        ### with sub down category
        set main_down [lindex [split $g_hoststatusname "|"] 0]
        set sub_down [lindex [split $g_hoststatusname "|"] 1]
        set g_tester_status [format "%s (%s)\n%s" $main_down $g_hoststatusdifftime $sub_down]
    } else {
        set g_tester_status [format "%s (%s)" $g_hoststatusname $g_hoststatusdifftime]
    }

    #puts "g_tester_status : $g_tester_status"


}
}
#############################################################################
## Procedure:  BTN_START_LOT

proc ::BTN_START_LOT {} {
global widget

global g_hostname
global g_lotname
global g_dcc
global g_operation
global g_job
global g_operatorid
global g_operatorid_sub
global g_handler
global g_board
global g_boardno
global g_kit
global g_temperature
global g_scopsversion

if { [string trim $g_lotname] == "" } {
    set msg "Select Lot!"
    set choice [ tk_messageBox -title "Start Error" -icon warning -message [FM "" $msg ""]     ]
    return    
}

if { [string trim $g_operation] == "" } {
    set msg "Select Operation!"
    set choice [ tk_messageBox -title "Start Error" -icon warning -message [FM "" $msg ""]     ]
    return    
}

if { [string trim $g_job] == "" } {
    set msg "Select Full or Retest!"
    set choice [ tk_messageBox -title "Start Error" -icon warning -message [FM "" $msg ""]     ]
    return    
}

#BUTTON START DISABLE FOR WINDOWS10
global g_btn_start
$g_btn_start configure -state disable


if { [ATK_GROUP_START_LOT] != "TRUE" } {
    #BUTTON START ENABLE FOR WINDOWS10
    global g_btn_start
    $g_btn_start configure -state normal
    return 
}

if { [ATK_GROUP_APL] != "TRUE" } { 
    #BUTTON START ENABLE FOR WINDOWS10
    global g_btn_start
    $g_btn_start configure -state normal
    
    
    return 
}


set aplres "SUCCESS"

#####################################
### demo setting #####################
#set g_temperature ""
#####################################
#####################################

set comment ""



#g_operatorid_sub is for additional production information like "_R_H"
#check RFID


set tmp_operatorid ""
set tmp_operatorid [format "%s%s" $g_operatorid $g_operatorid_sub]

set qry "SCOPS,Start,$g_hostname,$g_lotname,$g_dcc,$g_operation,$g_job,$tmp_operatorid,$g_handler,$g_boardno,$g_kit,$g_temperature,$g_scopsversion,$comment,$aplres*"

set res [FUNC_SEND_QRY $qry]

if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
    #BUTTON START ENABLE FOR WINDOWS10
    global g_btn_start
    $g_btn_start configure -state normal
    
    
    set choice [ tk_messageBox -title "Start Error" -icon warning -message "Fail to Start!!!  "]
    
    return
}


FUNC_GET_HOSTSTATUS

FUNC_UPDATE_IP

#BUTTON END DISABLE FOR WINDOWS10
global g_btn_lotend
$g_btn_lotend configure -state disable

#BUTTON START ENABLE FOR WINDOWS10
global g_btn_start
$g_btn_start configure -state normal
}
#############################################################################
## Procedure:  BTN_SET_DOWN

proc ::BTN_SET_DOWN {} {
global widget

global g_cd
global g_rd

global g_hostname
global g_down_operator

global g_maindescriptionid
global g_subdescriptionid
global g_actiondescription
global g_maindescription

global g_testing_flag

global g_subdescription
###################################
### demo setting    ###############
#set g_actiondescription ""
###################################
###################################


if { [string trim $g_down_operator] == "" } {
    set choice [ tk_messageBox -title "Down Alert" -icon warning -message "Input Operator ID!  " ]
    return
}

#puts "11 : [FUNC_CHECK_VARIABLE g_maindescriptionid]"


if { [FUNC_CHECK_VARIABLE g_maindescriptionid] == "NULL" } {
    set msg "Select Down Category!"
    set choice [ tk_messageBox -title "Set Down Error" -icon warning -message [FM "" $msg ""] ]
    return
}


if { [FUNC_CHECK_COMMENT] != "TRUE" } {
    return
}

if { $g_testing_flag == "DOWN" } {

    set choice [ tk_messageBox -type yesno -title "Confirmation!" -icon warning -message "Do you want to change the down status?  " ]

    if { $choice == "no" } {
        return
    }
}

set comment [txt_comment get 1.0 end]




if { $g_actiondescription == "NO_ACTION" } {
    set g_actiondescription ""
}

# Close HSF Alert
if { $g_maindescription == "HANDLER" } {
    if { $g_subdescription == "Site Variance Clear" } {
        set win_title "handler_stop_s2s"
        FUNC_DISPLAY_MESSAGE "close" "$win_title" "" ""
    }
}

if { $g_testing_flag == "DOWN" } {
    set qry "SCOPS,DownChange,$g_hostname,$g_down_operator,$g_maindescriptionid,$g_subdescriptionid,$g_actiondescription,$comment*"
} else {
    set qry "SCOPS,Down,$g_hostname,$g_down_operator,$g_maindescriptionid,$g_subdescriptionid,$g_actiondescription,$comment*"
}

set res [FUNC_SEND_QRY $qry]

if { [lindex [split $res $g_cd] 0] == "FAIL" } {
    set msg "Fail to Set Down!"
    set choice [ tk_messageBox -title "Set Down Error" -icon warning -message [FM "" $msg $res] ]
    return
}

if { [string match -nocase "*change*" [lindex [split $qry $g_cd] 1] ] == 1 } {
    set msg "Success to Change Down!"
    set choice [ tk_messageBox -title "Success" -icon warning -message [FM "" $msg ""] ]

}

FUNC_GET_HOSTSTATUS

#BUTTON DOWN DISABLE FOR WINDOWS10
global g_btn_down
$g_btn_down configure -state disable
}
#############################################################################
## Procedure:  FUNC_EXECUTE_LOOP

proc ::FUNC_EXECUTE_LOOP {} {
global widget

global g_scops_time_watch_wait

global g_release_flag
global g_refreshperiod
global g_endlock

##############################
# demo setting ###############
#set g_release_flag "OFF"
#set g_refreshperoid 6000
#set g_endlock 1
##############################
##############################

global g_scops_time_watch_wait
set g_scops_time_watch_wait 1

if { $g_release_flag == "ON" } {

    set g_endlock 1
    
    while { $g_scops_time_watch_wait > 0 } {

        if { $g_endlock > 0 } {
            
            if [catch {
                FUNC_GET_HOSTSTATUS
                
                #BUTTON END ENABLE FOR WINDOWS10
                global g_btn_lotend
                $g_btn_lotend configure -state normal

                #BUTTON START ENABLE FOR WINDOWS10
                global g_btn_start
                $g_btn_start configure -state normal
        
                #BUTTON DOWN ENABLE FOR WINDOWS10
                global g_btn_down
                $g_btn_down configure -state normal
                
                #BUTTON ADD RETEST ENABLE FOR WINDOWS10
                global g_btn_addretest
                $g_btn_addretest configure -state normal
                
                
            } err] {
                exit
            }

            after $g_refreshperiod {set g_scops_time_watch_wait 1;}
            vwait g_scops_time_watch_wait
        } else {
            exit  
        }

    }
    
} else {
    set g_endlock 0
}
}
#############################################################################
## Procedure:  BTN_SEARCH_RFID

proc ::BTN_SEARCH_RFID {} {
global widget

FUNC_BIND_WIDGET

Window show .top85
set a [expr {int([winfo screenwidth .] * 0.5)}]
set b [expr {int([winfo screenheight .] * 0.5)}]
wm geometry .top85 [format "%sx%s+%s+%s" 393 160 [expr $a/2] [expr $b/2]]

global g_rootdir
global g_canvas_trbarcode
if [catch {
    $g_canvas_trbarcode delete all
} err] {
}

set canvas_width "356"
set canvas_height "43"
set filename "image/scops_trbarcodeLot.gif"
set titlename "Input Lot Name!"


### chech file
if { [FUNC_CHECK_FILE $filename] == "TRUE" } {

    if [catch {
        set img [image create photo -file [file join $g_rootdir $filename]]
        set height [image height $img]
        set width [image width $img]
    } err] {
        FD "Barcode image download error"
    }
    
    if [catch {
        $g_canvas_trbarcode create image [expr $canvas_width/2] [expr $canvas_height/2] -anchor center -image $img
    } err] {
        FD "Barcode image display error"
    }
} else {
    if [catch {
        $g_canvas_trbarcode create text [expr $canvas_width/2] [expr $canvas_height/2] -anchor center -text $titlename -font "helvetica 12 bold"
    } err] {
        FD "Barcode text display error"
    }
}
}
#############################################################################
## Procedure:  FUNC_CHECK_COMMENT

proc ::FUNC_CHECK_COMMENT {} {
global widget

set comment ""

#set special [, / * & @ $]
#set special [list "," "/" "\\*"]
set special {"," "/" "\\*"}
set comment [txt_comment get 1.0 end]

foreach tmp $special {
    if { [string match "*$tmp*" $comment] == 1 } {
        
        tk_messageBox -title "Comment Error!!"  -message "Do not use ,/*$%@ characters" -icon error
        return "FALSE"

    }
 }

return "TRUE"

~
&
^
}
#############################################################################
## Procedure:  FUNC_CHECK_TPA

proc ::FUNC_CHECK_TPA {} {
global widget

global g_tclplatform
global g_tcluserid
global g_hostname
global g_customer
global g_devicename
global g_lotname
global g_dcc
global g_testprogramrev
global g_testprogram
global g_operation
global g_package
global g_job
global g_temperature
global g_operatorid
global g_board
global g_handler


global g_tpa_flag

if { $g_tpa_flag != "ON" || $g_tpa_flag == 0 } { return "TRUE" }

set qry "SCOPS,CheckTPA,CHECK,$g_hostname,$g_lotname,$g_dcc,$g_operation,$g_operatorid,$g_testprogram,$g_tcluserid*"

set res ""
set res [FUNC_SEND_QRY $qry]

if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
    set choice [ tk_messageBox -title "FUNC_CHECK_TPA ERROR" -icon warning -message [FM "TESTIT" "FAIL TO GET TPA SERVER INFORMATION." $res] ]
    return "FALSE"
    
}

if { [lindex [split $res ","] 0] == "NO" } { return "TRUE" }

set tpa_ip ""
set tpa_port ""

set tpa_ip [lindex [split $res ","] 1]
set tpa_port [lindex [split $res ","] 2]

if { $tpa_ip == "" || $tpa_port == "" } {
    set choice [ tk_messageBox -title "FUNC_CHECK_TPA ERROR" -icon warning -message [FM "TPA SERVER INFORMATION IS NOT ENOUGH!" $res] ]
    return "FALSE"
}


set qry "pgmCompare,|$g_hostname|,|$g_customer|,|$g_devicename|,|$g_lotname|,|$g_dcc|,|$g_testprogramrev|,|$g_testprogram|,|$g_operation|,|$g_package|,|$g_job|,|$g_temperature|,|$g_operatorid|,|$g_board|,|$g_handler|,|$g_tcluserid|," 
FD "TPA qry : $qry"


set res ""
if [catch { set sock [socket $tpa_ip $tpa_port] } err] {
    close $sock
    return "FALSE"
    FD "FUNC_CHECK_TPA ERROR : $err"
} else {
    if [catch { 
        puts $sock $qry
        flush $sock
    } err] {
        FD "FUNC_CHECK_TPA ERROR : $err"
        return "FALSE"
    }
    
    while {[gets $sock line] >=0} {
        set res $line
    }    
    close $sock
}

set res [string trim $res]

#FD "TPA RESULT : $res" 


if { [string match -nocase "*success*" $res] == 0 } { 
    
    set win_title "warning_tpa"
    FUNC_DISPLAY_MESSAGE "close" "$win_title" "" ""
    #1.flag 2.title 3.height 4.width 5.top 6.left 7.bgcolor 8.fgcolor 9.thickness(line)
    set config "$win_title"
    set file_name "image,scops_warning_program.gif"
    
    FUNC_DISPLAY_MESSAGE "open" $config $file_name [FM "Engineer, Manager" "TPA FAIL!" "THIS PROGRAM IS WRONG!"]
    
    set choice [ tk_messageBox -title "FUNC_CHECK_TPA ERROR" -icon warning -message [FM "Engineer" "TPA FAIL! THIS PROGRAM IS WRONG!" $res] ]
    
    FUNC_DISPLAY_MESSAGE "close" "$win_title" "" ""
    
    return "FALSE" 
    

}

return "TRUE"
}
#############################################################################
## Procedure:  FUNC_CHECK_T1T2

proc ::FUNC_CHECK_T1T2 {} {
global widget

global g_hostname
global g_lotname
global g_dcc
global g_operation
global g_operatorid

global g_customer

if { [string match -nocase "*QUALCOM*" $g_customer] == 0 || [string match -nocase "*TEST2*" $g_operation] == 0  } {
    return "TRUE"
}


######################################
### demo setting #####################
#set tmplotname "J1N2T222.L1C1"
#set tmpdcc ""
#set tmpoperation "TEST1"
######################################
######################################

set qry "SCOPS,CheckT1T2,check,$g_hostname,$g_lotname,$g_dcc,$g_operation,,,,*"

set res ""
set res [FUNC_SEND_QRY $qry]


if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
    set msg {"Fail to Check TP1 and TP2" "\xAC\xB9\x4C\xD1\xA4\xC2\xB8\xD2\x20\x00\xF5\xAC\x15\xC8\x20\x00\xDD\xC0\x31\xC1\xD0\xC5\x20\x00\xE4\xC2\x28\xD3\x58\xD5\x00\xC6\xB5\xC2\xC8\xB2\xE4\xB2\x21\x00"}
    set choice [ tk_messageBox -title "TP1 and TP2 Check Error" -icon warning -message [FM "K3 engineer" $msg $res] ]
    return "TRUE"
}

if { [lindex [split $res ","] 0] == "NO" } {
    set msg {"TEST1 Program and TEST2 Program Are Different!(X)" "\xAC\xB9\x4C\xD1\xA4\xC2\xB8\xD2\x20\x00\xF5\xAC\x15\xC8\x20\x00\xDD\xC0\x31\xC1\xD0\xC5\x20\x00\xE4\xC2\x28\xD3\x58\xD5\x00\xC6\xB5\xC2\xC8\xB2\xE4\xB2\x21\x00"}
    set choice [ tk_messageBox -title "TP1 and TP2 Check Error" -icon error -message [FM "K3 engineer" $msg $res] ]
    return "FALSE"
}

return "TRUE"
}
#############################################################################
## Procedure:  BTN_ADD_RETEST

proc ::BTN_ADD_RETEST {} {
global widget


if { [ATK_GROUP_ADDRETEST] == "FALSE" } { return }


global g_hostname
global g_lotname
global g_dcc
global g_operation

if { [string trim $g_lotname] == "" || [string trim $g_operation] == "" } {
    set msg "Select Lot and Operation!"
    set choice [ tk_messageBox -title "Add Retest Error" -icon warning -message [FM "" $msg ""] ]
    return    
}

#BUTTON ADD RETEST DISABLE FOR WINDOWS10
global g_btn_addretest
$g_btn_addretest configure -state disable 
    
set msg "Do you really want to add Restest?"
set choice [ tk_messageBox -type yesno -title "Add Retest Confirmation" -icon warning -message [FM "" $msg ""] ]

if { $choice == "no" } { 
    #BUTTON ADD RETEST ENABLE FOR WINDOWS10
    global g_btn_addretest
    $g_btn_addretest configure -state normal
    return 
}


set qry "SCOPS,AddRetest,$g_hostname,$g_lotname,$g_dcc,$g_operation*"

#puts "AddRetest qry : $qry"

set res ""
set res [FUNC_SEND_QRY $qry]

#puts "AddRetest res : $res"

if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
    set "Fail to Add Retest!"
    set choice [ tk_messageBox -title "Add Retest Error" -icon warning -message [FM "" $msg $res] ]
    return
} 

FUNC_GET_LOTINFORMATION
}
#############################################################################
## Procedure:  FUNC_CHECK_SCOPSVERSION

proc ::FUNC_CHECK_SCOPSVERSION {} {
global widget

global g_update_flag

if { $g_update_flag != 1 && $g_update_flag != "ON" } {
    return "TRUE"
}

global g_scopsversion
global g_scopsnewversion
global g_hostname

set qry "SCOPS,GetSopsVersion,$g_hostname*"

set res ""
set res [FUNC_SEND_QRY $qry]


if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
    return "TRUE"
}

set g_scopsnewversion $res

if { $g_scopsversion != "" && $g_scopsnewversion != "" } {
    
    if { $g_scopsversion < $g_scopsnewversion } {
          
        FUNC_UPDATE_SCOPS
        
    }
    
}
}
#############################################################################
## Procedure:  FUNC_CHECK_TPMS

proc ::FUNC_CHECK_TPMS {} {
global widget

global g_hostname
global g_lotname
global g_dcc
global g_operation
global g_operatorid
global g_testprogram


global g_customer

if { [string match -nocase "*QUALCOM*" $g_customer] == 0 } {
    return "TRUE"
}


set qry "SCOPS,CheckTPMS,CHECK,$g_hostname,$g_lotname,$g_dcc,$g_operation,$g_operatorid,$g_testprogram,*"

set res ""
set res [FUNC_SEND_QRY $qry]

if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
    #set choice [ tk_messageBox -title "TestProgram & Fabsite Check Error" -icon warning -message [FM "TESTIT" "Fail to Check TPGM & Fabsite" $res] ]
    return "TRUE"
    
}

if { [lindex [split $res ","] 0] == "NO" } {
    set choice [ tk_messageBox -title "Test Program & Fabsite Check Error" -icon warning -message [FM "K3 engineer" "TestProgram & Fabsite are not suitable! " $res] ]
    return "FALSE"
}

return "TRUE"
}
#############################################################################
## Procedure:  BTN_END_LOT

proc ::BTN_END_LOT {} {
global widget


# Set Tester Status Ready diff flag 
global g_readydiff_flag
set g_readydiff_flag 0
global g_readydiff_time
set g_readydiff_time 0


#Close Probe Touch down limit over Alert
Window hide .top95

#Close VI Success Alert
set win_title_vi "v_inspection_success"
FUNC_DISPLAY_MESSAGE "close" "$win_title_vi" "" ""


global g_testing_flag

global g_comment

if { [FUNC_CHECK_VARIABLE g_comment] == "NULL" } {
    set g_comment ""
}


### end lot
if { $g_testing_flag == "TESTING" } {

    global g_hostname
    global g_lotname
    global g_dcc
    global g_operation
    global g_job
 
    set qry "SCOPS,Stop,$g_hostname,$g_lotname,$g_dcc,$g_operation,$g_job,$g_comment*"

    set res [FUNC_SEND_QRY $qry]

    if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
        set choice [ tk_messageBox -title "End Lot Error" -icon warning -message [FM "" "FAIL TO LOT END!" $res] ]
        return
    } else {
  
        FUNC_GET_HOSTSTATUS
        
        
        ### check HSF and SBL
        FUNC_CHECK_HSFANDSVR
    }
    
    
    

### down done
} else {

    global g_hostname
    
    set qry "SCOPS,DownDone,$g_hostname,$g_comment*"

    set res [FUNC_SEND_QRY $qry]

    if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
        set msg {"Fail to Donw Done!" "\xE4\xB2\xB4\xC6\xC1\xC0\xDC\xD0\x20\x00\x85\xC8\xCC\xB8\xD0\xC5\x20\x00\xE4\xC2\x28\xD3\x58\xD5\x00\xC6\xB5\xC2\xC8\xB2\xE4\xB2\x21\x00"}
        set choice [ tk_messageBox -title "Down Done Error" -icon warning -message [FM "" $msg $res] ]
        return
    } else {
    
        ### initialize down comment
        txt_comment del 1.0 end
        
        global g_down_operator
        set g_down_operator ""
        
        FUNC_GET_HOSTSTATUS
        
    }
    

}

FUNC_SET_FLAG_END_LOT
ATK_GROUP_END_LOT

#BUTTON START DISABLE FOR WINDOWS10
global g_btn_start
$g_btn_start configure -state disable
}
#############################################################################
## Procedure:  FUNC_CHECK_OPERATORID

proc ::FUNC_CHECK_OPERATORID {operatorid} {
global widget


set qry "SCOPS,CheckOperatorID,$operatorid*"

set res ""
set res [FUNC_SEND_QRY "$qry"]

return $res
}
#############################################################################
## Procedure:  TCL_LIB_FTP

proc ::TCL_LIB_FTP {} {
global widget

#
#   tcl FTP library package -- 
# 
#   required:   tcl8.0
#
#   created:	12/96 
#   changed:    04/99                            
#   version:    1.2
#
#   core ftp support: 	FTP::Open <server> <user> <passwd> <?options?>
#			FTP::Close
#		    	FTP::Cd <directory>
#			FTP::Pwd
#			FTP::Type <?ascii|binary?>	
#			FTP::List <?directory?>
#			FTP::NList <?directory?>
#			FTP::FileSize <file>
#			FTP::ModTime <from> <to>
#			FTP::Delete <file>
#			FTP::Rename <from> <to>
#			FTP::Put <local> <?remote?>
#			FTP::Append <local> <?remote?>
#			FTP::Get <remote> <?local?>
#			FTP::Reget <remote> <?local?>
#			FTP::Newer <remote> <?local?>
#			FTP::MkDir <directory>
#			FTP::RmDir <directory>
#			FTP::Quote <arg1> <arg2> ...
#
#   Copyright (C) 1996-1999 Steffen Traeger
#
#   This program is free software; you can redistribute it and/or modify
#   it under the terms of the GNU General Public License as published by
#   the Free Software Foundation; either version 2 of the License, or
#   (at your option) any later version.
#
#   This program is distributed in the hope that it will be useful,
#   but WITHOUT ANY WARRANTY; without even the implied warranty of
#   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
#   GNU General Public License for more details.
#
#   You should have received a copy of the GNU General Public License
#   along with this program; if not, write to the Free Software
#   Foundation, Inc., 675 Mass Ave, Cambridge, MA 02139, USA.
#
#   contact:
#	email:	Steffen.Traeger@t-online.de
#	url:	http://home.t-online.de/home/Steffen.Traeger
#
########################################################################

package provide FTP [lindex {$Revision: 1.2 $} 1]

namespace eval FTP {

namespace export DisplayMsg Open Close Cd Pwd Type List NList FileSize ModTime Delete Rename Put Append Get Reget Newer Quote MkDir RmDir 
	
set VERBOSE 1
set DEBUG 1

#############################################################################
#
# DisplayMsg --
#
# This is a simple procedure to display any messages on screen.
# It must be overwritten by users source code in the form:
# (exported)
#
#	namespace FTP {
#		proc DisplayMsg {msg} {
#			......
#		}
#	}
#
# Arguments:
# msg - 		message string
# state -		different states {normal, data, control, error}
#
proc DisplayMsg {msg {state ""}} {
variable VERBOSE 
    
	switch $state {
	  data		{if {$VERBOSE} {puts $msg}}
	  control	{if {$VERBOSE} {puts $msg}}
	  error		{puts stderr "ERROR: $msg"}
	  default 	{if {$VERBOSE} {puts $msg}}
	}
}

#############################################################################
#
# Timeout --
#
# Handle timeouts
# 
# Arguments:
#  -
#
proc Timeout {} {
variable ftp
upvar #0 finished state

	after cancel $ftp(Wait)
	set state(control) 1

	DisplayMsg "Timeout of control connection after $ftp(Timeout) sec.!" error

}

#############################################################################
#
# WaitOrTimeout --
#
# Blocks the running procedure and waits for a variable of the transaction 
# to complete. It continues processing procedure until a procedure or 
# StateHandler sets the value of variable "finished". 
# If a connection hangs the variable is setting instead of by this procedure after 
# specified seconds in $ftp(Timeout).
#  
# 
# Arguments:
#  -		
#

proc WaitOrTimeout {} {
variable ftp
upvar #0 finished state

	set retvar 1

	if {[info exists state(control)]} {

		set ftp(Wait) [after [expr $ftp(Timeout) * 1000] [namespace current]::Timeout]

		vwait finished(control)
		set retvar $state(control)
	}

	return $retvar
}

#############################################################################
#
# WaitComplete --
#
# Transaction completed.
# Cancel execution of the delayed command declared in procedure WaitOrTimeout.
# 
# Arguments:
# value -	result of the transaction
#			0 ... Error
#			1 ... OK
#

proc WaitComplete {value} {
variable ftp
upvar #0 finished state

	if {[info exists state(data)]} {
		vwait finished(data)
	}

	after cancel $ftp(Wait)
	set state(control) $value
}

#############################################################################
#
# PutsCtrlSocket --
#
# Puts then specified command to control socket,
# if DEBUG is set than it logs via DisplayMsg
# 
# Arguments:
# command - 		ftp command
#

proc PutsCtrlSock {{command ""}} {
variable ftp 
variable DEBUG
	
	if {$DEBUG} {
		DisplayMsg "---> $command"
	}

	puts $ftp(CtrlSock) $command
	flush $ftp(CtrlSock)


}

#############################################################################
#
# StateHandler --
#
# Implements a finite state handler and a fileevent handler
# for the control channel
# 
# Arguments:
# sock - 		socket name
#			If called from a procedure than this argument is empty.
# 			If called from a fileevent than this argument contains
#			the socket channel identifier.

proc StateHandler {{sock ""}} {
upvar #0 finished state
variable ftp
variable DEBUG 
variable VERBOSE

	# disable fileevent on control socket, enable it at the and of the state machine
        # fileevent $ftp(CtrlSock) readable {}
		
	# there is no socket (and no channel to get) if called from a procedure
	set rc "   "

	if { $sock != "" } {

		set number [gets $sock bufline]

		if { $number > 0 } {

			# get return code, check for multi-line text
			regexp "(^\[0-9\]+)( |-)?(.*)$" $bufline all rc multi_line msgtext

			set buffer $bufline
			
			# multi-line format detected ("-"), get all the lines
			# until the real return code
			while { $multi_line == "-"  } {
				set number [gets $sock bufline]	
				if { $number > 0 } {
					append buffer \n "$bufline"
					regexp "(^\[0-9\]+)( |-)?(.*)$" $bufline all rc multi_line
				}
			}
		} elseif [eof $ftp(CtrlSock)] {
			# remote server has closed control connection
			# kill control socket, unset State to disable all following command
			set rc 421
			if {$VERBOSE} {
				DisplayMsg "C: 421 Service not available, closing control connection." control
			}
			DisplayMsg "Service not available!" error
			CloseDataConn
			WaitComplete 0
			catch {unset ftp(State)}
			catch {close $ftp(CtrlSock); unset ftp(CtrlSock)}
			return
		}
		
	} 
	
	if {$DEBUG} {
		DisplayMsg "-> rc=\"$rc\"\n-> state=\"$ftp(State)\""
	}
	
	# system status replay
	if {$rc == "211"} {return}

	# use only the first digit 
	regexp "^\[0-9\]?" $rc rc
	
 	switch -- $ftp(State) {
	
		user	{ 
			  switch $rc {
			    2       {
			    	       PutsCtrlSock "USER $ftp(User)"
			               set ftp(State) passwd
			            }
			    default {
				       set errmsg "Error connecting! $msgtext"
				       set complete_with 0
			            }
			  }
			}

		passwd	{
			  switch $rc {
			    2       {
				       set complete_with 1
			            }
			    3       {
			  	       PutsCtrlSock "PASS $ftp(Passwd)"
		  	       	       set ftp(State) connect
			            }
			    default {
				       set errmsg "Error connecting! $msgtext"
				       set complete_with 0
			            }
			  }
			}

		connect	{
			  switch $rc {
			    2       {
				       set complete_with 1
			            }
			    default {
				       set errmsg "Error connecting! $msgtext"
				       set complete_with 0
			            }
			  }
			}

		quit	{
		    	   PutsCtrlSock "QUIT"
			   set ftp(State) quit_sent
			}

		quit_sent {
			  switch $rc {
			    2       {
			               set complete_with 1
			            }
			    default {
				       set errmsg "Error disconnecting! $msgtext"
				       set complete_with 0
			            }
			  }
			}
		
		quote	{
		    	   PutsCtrlSock $ftp(Cmd)
			   set ftp(State) quote_sent
			}

		quote_sent {
	                   set complete_with 1
                           set ftp(Quote) $buffer
			}
		
		type	{
		  	  if { $ftp(Type) == "ascii" } {
			  	PutsCtrlSock "TYPE A"
			  } else {
			  	PutsCtrlSock "TYPE I"
			  }
  		  	  set ftp(State) type_sent
			}
			
		type_sent {
			  switch $rc {
			    2       {
				       set complete_with 1
			            }
			    default {
				       set errmsg "Error setting type \"$ftp(Type)\"!"
				       set complete_with 0
			            }
			  }
			}
	
		nlist_active {
			  if {[OpenActiveConn]} {
			    	PutsCtrlSock "PORT $ftp(LocalAddr),$ftp(DataPort)"
			  	set ftp(State) nlist_open
			  } else {
				set errmsg "Error setting port!"
			  }
			  
		}
			
		nlist_passive {
		    PutsCtrlSock "PASV"
		    set ftp(State) nlist_open
		}
			
		nlist_open {
			  switch $rc {
			    2 {
			         if {$ftp(Mode) == "passive"} {
				     if ![OpenPassiveConn $buffer] {
				         set errmsg "Error setting PASSIVE mode!"
				       	 set complete_with 0
				     }
				 }   
			         PutsCtrlSock "NLST$ftp(Dir)"
			  	 set ftp(State) list_sent
			      }
			    default {
			              if {$ftp(Mode) == "passive"} {
				          set errmsg "Error setting PASSIVE mode!"
				      } else {
				          set errmsg "Error setting port!"
				      }  
			       	      set complete_with 0
			            }
			  }
		}
	
		list_active	{
			  if {[OpenActiveConn]} {
				PutsCtrlSock "PORT $ftp(LocalAddr),$ftp(DataPort)"
		  		set ftp(State) list_open
			  } else {
				set errmsg "Error setting port!"
			  }
			  
		}
			
		list_passive	{
		    PutsCtrlSock "PASV"
		    set ftp(State) list_open
		}
			
		list_open {
			  switch $rc {
			    2  {
			         if {$ftp(Mode) == "passive"} {
				     if {![OpenPassiveConn $buffer]} {
				         set errmsg "Error setting PASSIVE mode!"
				       	 set complete_with 0
				     }
				 }   
			         PutsCtrlSock "LIST$ftp(Dir)"
			  	 set ftp(State) list_sent
			       }
			    default {
			              if {$ftp(Mode) == "passive"} {
				          set errmsg "Error setting PASSIVE mode!"
				      } else {
				          set errmsg "Error setting port!"
				      }  
				      set complete_with 0
			            }
			  }
		}
			
		list_sent	{
			  switch $rc {
			    1       {
			               set ftp(State) list_close
			            }
			    default {  
			               if { $ftp(Mode) == "passive" } {
			    	           unset state(data)
				       }    
				       set errmsg "Error getting directory listing!"
				       set complete_with 0
			            }
			  }
		}

		list_close {
			  switch $rc {
			    2     {
			               set complete_with 1
			            }
			    default {
				       set errmsg "Error receiving list!"
				       set complete_with 0
			            }
			  }
			}
									
		size {
			  PutsCtrlSock "SIZE $ftp(File)"
  		  	  set ftp(State) size_sent
			}

		size_sent {
			  switch $rc {
			    2       {
            			       regexp "^\[0-9\]+ (.*)$" $buffer all ftp(FileSize)
			               set complete_with 1
			            }
			    default {
				       set errmsg "Error getting file size!"
				       set complete_with 0
			            }
			  }
			}

		modtime {
			  PutsCtrlSock "MDTM $ftp(File)"
  		  	  set ftp(State) modtime_sent
			}

		modtime_sent {
			  switch $rc {
			    2       {
            			       regexp "^\[0-9\]+ (.*)$" $buffer all ftp(DateTime)
			               set complete_with 1
			            }
			    default {
				       set errmsg "Error getting modification time!"
				       set complete_with 0
			            }
			  }
			}

		pwd	{
			   PutsCtrlSock "PWD"
  		  	   set ftp(State) pwd_sent
			}
			
		pwd_sent {
			  switch $rc {
			    2       {
            			       regexp "^.*\"(.*)\"" $buffer temp ftp(Dir)
			               set complete_with 1
			            }
			    default {
				       set errmsg "Error getting working dir!"
				       set complete_with 0
			            }
			  }
			}

		cd	{
			   PutsCtrlSock "CWD$ftp(Dir)"
  		  	   set ftp(State) cd_sent
			}
			
		cd_sent {
			  switch $rc {
			    2       {
			               set complete_with 1
			            }
			    default {
				       set errmsg "Error changing directory!"
				       set complete_with 0
				     }
			  }
			}
			
		mkdir	{
			  PutsCtrlSock "MKD $ftp(Dir)"
  		  	  set ftp(State) mkdir_sent
			}
			
		mkdir_sent {
			  switch $rc {
			    2       {
			               set complete_with 1
			            }
			    default {
				       set errmsg "Error making dir \"$ftp(Dir)\"!"
				       set complete_with 0
				     }
			  }
			}
			
		rmdir	{
			  PutsCtrlSock "RMD $ftp(Dir)"
  		  	  set ftp(State) rmdir_sent
			}
			
		rmdir_sent {
			  switch $rc {
			    2       {
			               set complete_with 1
			            }
			    default {
				       set errmsg "Error removing directory!"
				       set complete_with 0
				     }
			  }
			}
										
		delete	{
			  PutsCtrlSock "DELE $ftp(File)"
  		  	  set ftp(State) delete_sent
			}
			
		delete_sent {
			  switch $rc {
			    2       {
			               set complete_with 1
			            }
			    default {
				       set errmsg "Error deleting file \"$ftp(File)\"!"
				       set complete_with 0
				     }
			  }
			}
			
		rename	{
			  PutsCtrlSock "RNFR $ftp(RenameFrom)"
  		  	  set ftp(State) rename_to
			}
			
		rename_to {
			  switch $rc {
			    3       {
			  	       PutsCtrlSock "RNTO $ftp(RenameTo)"
  		  	  	       set ftp(State) rename_sent
			            }
			    default {
				       set errmsg "Error renaming file \"$ftp(RenameFrom)\"!"
				       set complete_with 0
				     }
			  }
			}

		rename_sent {
			  switch $rc {
			    2     {
			               set complete_with 1
			            }
			    default {
				       set errmsg "Error renaming file \"$ftp(RenameFrom)\"!"
				       set complete_with 0
				     }
			  }
			}
			
		put_active 	{
			  if {[OpenActiveConn]} {
			    	PutsCtrlSock "PORT $ftp(LocalAddr),$ftp(DataPort)"
			  	set ftp(State) put_open
			  } else {
				set errmsg "Error setting port!"
			  }
			}
			
			
		put_passive	{
			               PutsCtrlSock "PASV"
			  	       set ftp(State) put_open
			}
			
		put_open {
			  switch $rc {
			    2  {
			         if {$ftp(Mode) == "passive"} {
				     if {![OpenPassiveConn $buffer]} {
				         set errmsg "Error setting PASSIVE mode!"
				       	 set complete_with 0
				     }
				 }   
			         PutsCtrlSock "STOR $ftp(RemoteFilename)"
			         set ftp(State) put_sent
			       }
			    default {
			              if {$ftp(Mode) == "passive"} {
				          set errmsg "Error setting PASSIVE mode!"
				      } else {
				          set errmsg "Error setting port!"
				      }  
				      set complete_with 0
				    }
			  }
		}
			
		put_sent	{
			  switch $rc {
			    1       {
			               set ftp(State) put_close
			            }
			    default {
			              if {$ftp(Mode) == "passive"} {
			    	         # close already opened DataConnection
			    	         unset state(data)
				      }  
				       set errmsg "Error opening connection!"
				       set complete_with 0
				     }
			  }
		}
			
		put_close	{
			  switch $rc {
			    2       {
			  	       set complete_with 1
			            }
			    default {
				       set errmsg "Error storing file \"$ftp(RemoteFilename)\"!"
				       set complete_with 0
				     }
			  }
		}
			
		append_active 	{
			  if {[OpenActiveConn]} {
			    	PutsCtrlSock "PORT $ftp(LocalAddr),$ftp(DataPort)"
			  	set ftp(State) append_open
			  } else {
				set errmsg "Error setting port!"
			  }
			}
			
			
		append_passive	{
			               PutsCtrlSock "PASV"
			  	       set ftp(State) append_open
			}
			
		append_open {
			  switch $rc {
			    2  {
			         if {$ftp(Mode) == "passive"} {
				     if {![OpenPassiveConn $buffer]} {
				         set errmsg "Error setting PASSIVE mode!"
				       	 set complete_with 0
				     }
				 }   
			         PutsCtrlSock "APPE $ftp(RemoteFilename)"
			         set ftp(State) append_sent
			       }
			    default {
			              if {$ftp(Mode) == "passive"} {
				          set errmsg "Error setting PASSIVE mode!"
				      } else {
				          set errmsg "Error setting port!"
				      }  
				      set complete_with 0
				    }
			  }
		}
			
		append_sent	{
			  switch $rc {
			    1       {
			               set ftp(State) append_close
			            }
			    default {
			              if {$ftp(Mode) == "passive"} {
			    	         # close already opened DataConnection
			    	         unset state(data)
				      }  
				       set errmsg "Error opening connection!"
				       set complete_with 0
				     }
			  }
		}
			
		append_close	{
			  switch $rc {
			    2       {
			  	       set complete_with 1
			            }
			    default {
				       set errmsg "Error storing file \"$ftp(RemoteFilename)\"!"
				       set complete_with 0
				     }
			  }
		}
			
		reget_active 	{
			  if {[OpenActiveConn]} {
			    	PutsCtrlSock "PORT $ftp(LocalAddr),$ftp(DataPort)"
			  	set ftp(State) reget_restart
			  } else {
				set errmsg "Error setting port!"
			  }
		}
			
		reget_passive	{
			               PutsCtrlSock "PASV"
			  	       set ftp(State) reget_restart
		}
			
		reget_restart {
			  switch $rc {
			    2 { 
			         if {$ftp(Mode) == "passive"} {
				     if {![OpenPassiveConn $buffer]} {
				         set errmsg "Error setting PASSIVE mode!"
				       	 set complete_with 0
				     }
				 }   
			         if {$ftp(FileSize) != 0} {
				    PutsCtrlSock "REST $ftp(FileSize)"
	               		    set ftp(State) reget_open
				 } else {
			            PutsCtrlSock "RETR $ftp(RemoteFilename)"
			           set ftp(State) reget_sent
				 } 
			       }
			    default {
				       set errmsg "Error restarting filetransfer of \"$ftp(RemoteFilename)\"!"
				       set complete_with 0
				     }
			  }
			}
			
		reget_open {
			  switch $rc {
			    2  -
			    3  {
			         PutsCtrlSock "RETR $ftp(RemoteFilename)"
			         set ftp(State) reget_sent
			       }
			    default {
			              if {$ftp(Mode) == "passive"} {
				          set errmsg "Error setting PASSIVE mode!"
				      } else {
				          set errmsg "Error setting port!"
				      }  
				      set complete_with 0
				    }
			   }
			 }
			
			
		reget_sent	{
			  switch $rc {
			    1 {
			         set ftp(State) reget_close
			       }
			    default {
			              if {$ftp(Mode) == "passive"} {
			    	         # close already opened DataConnection
			    	         unset state(data)
				      }  
				      set errmsg "Error retrieving file \"$ftp(RemoteFilename)\"!"
				      set complete_with 0
				    }
			   }
		}
			
		reget_close	{
			  switch $rc {
			    2       {
			  	       set complete_with 1
			            }
			    default {
				       set errmsg "Error retrieving file \"$ftp(RemoteFilename)\"!"
				       set complete_with 0
				     }
			  }
		}
		get_active 	{
			  if {[OpenActiveConn]} {
			    	PutsCtrlSock "PORT $ftp(LocalAddr),$ftp(DataPort)"
			  	set ftp(State) get_open
			  } else {
				set errmsg "Error setting port!"
			  }
			}
			
		get_passive {
			        PutsCtrlSock "PASV"
			  	set ftp(State) get_open
			    }
			
		get_open {
			  switch $rc {
			    2  -
			    3  {
			         if {$ftp(Mode) == "passive"} {
				     if {![OpenPassiveConn $buffer]} {
				         set errmsg "Error setting PASSIVE mode!"
				       	 set complete_with 0
				     }
				 }   
			         PutsCtrlSock "RETR $ftp(RemoteFilename)"
			         set ftp(State) get_sent
			       }
			    default {
			              if {$ftp(Mode) == "passive"} {
				          set errmsg "Error setting PASSIVE mode!"
				      } else {
				          set errmsg "Error setting port!"
				      }  
				      set complete_with 0
				    }
			   }
			 }
			
		get_sent	{
			  switch $rc {
			    1 {
			         set ftp(State) get_close
			       }
			    default {
			              if {$ftp(Mode) == "passive"} {
			    	         # close already opened DataConnection
			    	         unset state(data)
				      }  
				      set errmsg "Error retrieving file \"$ftp(RemoteFilename)\"!"
				      set complete_with 0
				    }
			   }
		}
			
		get_close	{
			  switch $rc {
			    2       {
			  	       set complete_with 1
			            }
			    default {
				       set errmsg "Error retrieving file \"$ftp(RemoteFilename)\"!"
				       set complete_with 0
				     }
			  }
		}

			
	}

	# finish waiting 
	if {[info exists complete_with]} {
		WaitComplete $complete_with
	}

	# display control channel message
	if {[info exists buffer]} {
		if {$VERBOSE} {
			foreach line [split $buffer \n] {
				DisplayMsg "C: $line" control
			}
		}
	}
	
	# display error message
	if {[info exists errmsg]} {
		set ftp(Error) $errmsg
		DisplayMsg $errmsg error
	}

	# enable fileevent on control socket again
	#fileevent $ftp(CtrlSock) readable [list ::FTP::StateHandler $ftp(CtrlSock)]

}

#############################################################################
#
# Type --
#
# REPRESENTATION TYPE - Sets the file transfer type to ascii or binary.
# (exported)
#
# Arguments:
# type - 		specifies the representation type (ascii|binary)
# 
# Returns:
# type	-		returns the current type or {} if an error occurs

proc Type {{type ""}} {
variable ftp 

	if ![info exists ftp(State)] {
		DisplayMsg "Not connected!" error
		return {}
	}

	# return current type
	if { $type == "" } {
		return $ftp(Type)
	}

	# save current type
	set old_type $ftp(Type) 
	
	set ftp(Type) $type
	set ftp(State) type
	StateHandler
	
	# wait for synchronization
	set rc [WaitOrTimeout]
	if {$rc} {
		return $ftp(Type)
	} else {
		# restore old type
		set ftp(Type) $old_type
		return {}
	}
 
}

#############################################################################
#
# NList --
#
# NAME LIST - This command causes a directory listing to be sent from
# server to user site.
# (exported)
# 
# Arguments:
# dir - 		The $dir should specify a directory or other system 
#			specific file group descriptor; a null argument 
#			implies the current directory. 
#
# Arguments:
# dir - 		directory to list 
# 
# Returns:
# sorted list of files or {} if listing fails

proc NList {{dir ""}} {
variable ftp 

	if ![info exists ftp(State)] {
		DisplayMsg "Not connected!" error
		return {}
	}

	set ftp(List) {}
	if { $dir == "" } {
		set ftp(Dir) ""
	} else {
		set ftp(Dir) " $dir"
	}

	# save current type and force ascii mode
	set old_type $ftp(Type)
	if { $ftp(Type) != "ascii" } {
		Type ascii
	}

	set ftp(State) nlist_$ftp(Mode)
	StateHandler

	# wait for synchronization
	set rc [WaitOrTimeout]

	# restore old type
	if { [Type] != $old_type } {
		Type $old_type
	}

	unset ftp(Dir)
	if {$rc} { 
		return [lsort $ftp(List)]
	} else {
		CloseDataConn
		return {}
	}

}

#############################################################################
#
# List --
#
# LIST - This command causes a list to be sent from the server
# to user site.
# (exported)
# 
# Arguments:
# dir - 		If the $dir specifies a directory or other group of 
#			files, the server should transfer a list of files in 
#			the specified directory. If the $dir specifies a file
#			then the server should send current information on the
# 			file.  A null argument implies the user's current 
#			working or default directory.  
# 
# Returns:
# list of files or {} if listing fails

proc List {{dir ""}} {
variable ftp 

	if ![info exists ftp(State)] {
		DisplayMsg "Not connected!" error
		return {}
	}

	set ftp(List) {}
	if { $dir == "" } {
		set ftp(Dir) ""
	} else {
		set ftp(Dir) " $dir"
	}

	# save current type and force ascii mode
	set old_type $ftp(Type)
	if { $ftp(Type) != "ascii" } {
		Type ascii
	}

	set ftp(State) list_$ftp(Mode)
	StateHandler

	# wait for synchronization
	set rc [WaitOrTimeout]

	# restore old type
	if { [Type] != $old_type } {
		Type $old_type
	}

	unset ftp(Dir)
	if {$rc} { 
		
		# clear "total"-line
		set l [split $ftp(List) "\n"]
		set index [lsearch -regexp $l "^total"]
		if { $index != "-1" } { 
			set l [lreplace $l $index $index]
		}
		# clear blank line
		set index [lsearch -regexp $l "^$"]
		if { $index != "-1" } { 
			set l [lreplace $l $index $index]
		}
		
		return $l
	} else {
		CloseDataConn
		return {}
	}
}

#############################################################################
#
# FileSize --
#
# REMOTE FILE SIZE - This command gets the file size of the
# file on the remote machine. 
# ATTANTION! Doesn't work properly in ascci mode!
# (exported)
# 
# Arguments:
# filename - 		specifies the remote file name
# 
# Returns:
# size -		files size in bytes or {} in error cases

proc FileSize {{filename ""}} {
variable ftp 

	if ![info exists ftp(State)] {
		DisplayMsg "Not connected!" error
		return {}
	}
	
	if { $filename == "" } {
		return {}
	} 

	set ftp(File) $filename
	set ftp(FileSize) 0
	
	set ftp(State) size
	StateHandler

	# wait for synchronization
	set rc [WaitOrTimeout]
	
	unset ftp(File)
		
	if {$rc} {
		return $ftp(FileSize)
	} else {
		return {}
	}

}


#############################################################################
#
# ModTime --
#
# MODIFICATION TIME - This command gets the last modification time of the
# file on the remote machine.
# (exported)
# 
# Arguments:
# filename - 		specifies the remote file name
# 
# Returns:
# clock -		files date and time as a system-depentend integer
#			value in seconds (see tcls clock command) or {} in 
#			error cases

proc ModTime {{filename ""}} {
variable ftp 

	if ![info exists ftp(State)] {
		DisplayMsg "Not connected!" error
		return {}
	}
	
	if { $filename == "" } {
		return {}
	} 

	set ftp(File) $filename
	set ftp(DateTime) ""
	
	set ftp(State) modtime
	StateHandler

	# wait for synchronization
	set rc [WaitOrTimeout]
	
	unset ftp(File)
		
	if {$rc} {
		scan $ftp(DateTime) "%4s%2s%2s%2s%2s%2s" year month day hour min sec
		set clock [clock scan "$month/$day/$year $hour:$min:$sec" -gmt 1]
		unset year month day hour min sec
		return $clock
	} else {
		return {}
	}

}

#############################################################################
#
# Pwd --
#
# PRINT WORKING DIRECTORY - Causes the name of the current working directory.
# (exported)
# 
# Arguments:
# None.
# 
# Returns:
# current directory name

proc Pwd {} {
variable ftp 

	if ![info exists ftp(State)] {
		DisplayMsg "Not connected!" error
		return {}
	}

	set ftp(Dir) {}

	set ftp(State) pwd
	StateHandler

	# wait for synchronization
	set rc [WaitOrTimeout]
	
	if {$rc} {
		return $ftp(Dir)
	} else {
		return {}
	}
}

#############################################################################
#
# Cd --
#   
# CHANGE DIRECTORY - Sets the working directory on the server host.
# (exported)
# 
# Arguments:
# dir -			pathname specifying a directory
#
# Returns:
# 0 -			ERROR
# 1 - 			OK

proc Cd {{dir ""}} {
variable ftp 

	if ![info exists ftp(State)] {
		DisplayMsg "Not connected!" error
		return 0
	}

	if { $dir == "" } {
		set ftp(Dir) ""
	} else {
		set ftp(Dir) " $dir"
	}

	set ftp(State) cd
	StateHandler

	# wait for synchronization
	set rc [WaitOrTimeout] 

	unset ftp(Dir)
	
	if {$rc} {
		return 1
	} else {
		return 0
	}
}

#############################################################################
#
# MkDir --
#
# MAKE DIRECTORY - This command causes the directory specified in the $dir
# to be created as a directory (if the $dir is absolute) or as a subdirectory
# of the current working directory (if the $dir is relative).
# (exported)
# 
# Arguments:
# dir -			new directory name
#
# Returns:
# 0 -			ERROR
# 1 - 			OK

proc MkDir {dir} {
variable ftp 

	if ![info exists ftp(State)] {
		DisplayMsg "Not connected!" error
		return 0
	}

	set ftp(Dir) $dir

	set ftp(State) mkdir
	StateHandler

	# wait for synchronization
	set rc [WaitOrTimeout] 

	unset ftp(Dir)
	
	if {$rc} {
		return 1
	} else {
		return 0
	}
}

#############################################################################
#
# RmDir --
#
# REMOVE DIRECTORY - This command causes the directory specified in $dir to 
# be removed as a directory (if the $dir is absolute) or as a 
# subdirectory of the current working directory (if the $dir is relative).
# (exported)
#
# Arguments:
# dir -			directory name
#
# Returns:
# 0 -			ERROR
# 1 - 			OK

proc RmDir {dir} {
variable ftp 

	if ![info exists ftp(State)] {
		DisplayMsg "Not connected!" error
		return 0
	}

	set ftp(Dir) $dir

	set ftp(State) rmdir
	StateHandler

	# wait for synchronization
	set rc [WaitOrTimeout] 

	unset ftp(Dir)
	
	if {$rc} {
		return 1
	} else {
		return 0
	}
}

#############################################################################
#
# Delete --
#
# DELETE - This command causes the file specified in $file to be deleted at 
# the server site.
# (exported)
# 
# Arguments:
# file -			file name
#
# Returns:
# 0 -			ERROR
# 1 - 			OK

proc Delete {file} {
variable ftp 

	if ![info exists ftp(State)] {
		DisplayMsg "Not connected!" error
		return 0
	}

	set ftp(File) $file

	set ftp(State) delete
	StateHandler

	# wait for synchronization
	set rc [WaitOrTimeout] 

	unset ftp(File)
	
	if {$rc} {
		return 1
	} else {
		return 0
	}
}

#############################################################################
#
# Rename --
#
# RENAME FROM TO - This command causes the file specified in $from to be 
# renamed at the server site.
# (exported)
# 
# Arguments:
# from -			specifies the old file name of the file which 
#				is to be renamed
# to -				specifies the new file name of the file 
#				specified in the $from agument
# Returns:
# 0 -			ERROR
# 1 - 			OK

proc Rename {from to} {
variable ftp 

	if ![info exists ftp(State)] {
		DisplayMsg "Not connected!" error
		return 0
	}

	set ftp(RenameFrom) $from
	set ftp(RenameTo) $to

	set ftp(State) rename

	StateHandler

	# wait for synchronization
	set rc [WaitOrTimeout] 

	unset ftp(RenameFrom)
	unset ftp(RenameTo)
	
	if {$rc} {
		return 1
	} else {
		return 0
	}
}

#############################################################################
#
# ElapsedTime --
#
# Gets the elapsed time for file transfer
# 
# Arguments:
# stop_time - 		ending time

proc ElapsedTime {stop_time} {
variable ftp

	set elapsed [expr $stop_time - $ftp(Start_Time)]
	if { $elapsed == 0 } { set elapsed 1}
	set persec [expr $ftp(Total) / $elapsed]
	DisplayMsg "$ftp(Total) bytes sent in $elapsed seconds ($persec Bytes/s)"
}

#############################################################################
#
# PUT --
#
# STORE DATA - Causes the server to accept the data transferred via the data 
# connection and to store the data as a file at the server site.  If the file
# exists at the server site, then its contents shall be replaced by the data
# being transferred.  A new file is created at the server site if the file
# does not already exist.
# (exported)
#
# Arguments:
# source -			local file name
# dest -			remote file name, if unspecified, ftp assigns
#				the local file name.
# Returns:
# 0 -			file not stored
# 1 - 			OK

proc Put {source {dest ""}} {
variable ftp 

	if ![info exists ftp(State)] {
		DisplayMsg "Not connected!" error
		return 0
	}

	if ![file exists $source] {
		DisplayMsg "File \"$source\" not exist" error
		return 0
     	}
			
	if { $dest == "" } {
		set dest $source
	}

	set ftp(LocalFilename) $source
	set ftp(RemoteFilename) $dest

	set ftp(SourceCI) [open $ftp(LocalFilename) r]
	if { $ftp(Type) == "ascii" } {
		fconfigure $ftp(SourceCI) -buffering line -blocking 1
	} else {
		fconfigure $ftp(SourceCI) -buffering line -translation binary -blocking 1
	}

	set ftp(State) put_$ftp(Mode)
	StateHandler

	# wait for synchronization
	set rc [WaitOrTimeout]
	if {$rc} {
		ElapsedTime [clock seconds]
		return 1
	} else {
		CloseDataConn
		return 0
	}

}

#############################################################################
#
# APPEND --
#
# APPEND DATA - Causes the server to accept the data transferred via the data 
# connection and to store the data as a file at the server site.  If the file
# exists at the server site, then the data shall be appended to that file; 
# otherwise the file specified in the pathname shall be created at the
# server site.
# (exported)
#
# Arguments:
# source -			local file name
# dest -			remote file name, if unspecified, ftp assigns
#				the local file name.
# Returns:
# 0 -			file not stored
# 1 - 			OK

proc Append {source {dest ""}} {
variable ftp 

	if ![info exists ftp(State)] {
		DisplayMsg "Not connected!" error
		return 0
	}

	if ![file exists $source] {
		DisplayMsg "File \"$source\" not exist" error
		return 0
     	}
			
	if { $dest == "" } {
		set dest $source
	}

	set ftp(LocalFilename) $source
	set ftp(RemoteFilename) $dest

	set ftp(SourceCI) [open $ftp(LocalFilename) r]
	if { $ftp(Type) == "ascii" } {
		fconfigure $ftp(SourceCI) -buffering line -blocking 1
	} else {
		fconfigure $ftp(SourceCI) -buffering line -translation binary -blocking 1
	}

	set ftp(State) append_$ftp(Mode)
	StateHandler

	# wait for synchronization
	set rc [WaitOrTimeout]
	if {$rc} {
		ElapsedTime [clock seconds]
		return 1
	} else {
		CloseDataConn
		return 0
	}

}


#############################################################################
#
# Get --
#
# RETRIEVE DATA - Causes the server to transfer a copy of the specified file
# to the local site at the other end of the data connection.
# (exported)
#
# Arguments:
# source -			remote file name
# dest -			local file name, if unspecified, ftp assigns
#				the remote file name.
# Returns:
# 0 -			file not retrieved
# 1 - 			OK

proc Get {source {dest ""}} {
variable ftp 

	if ![info exists ftp(State)] {
		DisplayMsg "Not connected!" error
		return 0
	}

	if { $dest == "" } {
		set dest $source
	}

	set ftp(RemoteFilename) $source
	set ftp(LocalFilename) $dest

	set ftp(State) get_$ftp(Mode)
	StateHandler

	# wait for synchronization
	set rc [WaitOrTimeout]
	if {$rc} {
		ElapsedTime [clock seconds]
		return 1
	} else {
		CloseDataConn
		return 0
	}

}

#############################################################################
#
# Reget --
#
# RESTART RETRIEVING DATA - Causes the server to transfer a copy of the specified file
# to the local site at the other end of the data connection like get but skips over 
# the file to the specified data checkpoint. 
# (exported)
#
# Arguments:
# source -			remote file name
# dest -			local file name, if unspecified, ftp assigns
#				the remote file name.
# Returns:
# 0 -			file not retrieved
# 1 - 			OK

proc Reget {source {dest ""}} {
variable ftp 

	if ![info exists ftp(State)] {
		DisplayMsg "Not connected!" error
		return 0
	}

	if { $dest == "" } {
		set dest $source
	}

	set ftp(RemoteFilename) $source
	set ftp(LocalFilename) $dest

	if [file exists $ftp(LocalFilename)] {
		set ftp(FileSize) [file size $ftp(LocalFilename)]
	} else {
		set ftp(FileSize) 0
	}
	
	set ftp(State) reget_$ftp(Mode)
	StateHandler

	# wait for synchronization
	set rc [WaitOrTimeout]
	if {$rc} {
		ElapsedTime [clock seconds]
		return 1
	} else {
		CloseDataConn
		return 0
	}

}

#############################################################################
#
# Newer --
#
# GET NEWER DATA - Get the file only if the modification time of the remote 
# file is more recent that the file on the current system. If the file does
# not exist on the current system, the remote file is considered newer.
# Otherwise, this command is identical to get. 
# (exported)
#
# Arguments:
# source -			remote file name
# dest -			local file name, if unspecified, ftp assigns
#				the remote file name.
#
# Returns:
# 0 -			file not retrieved
# 1 - 			OK

proc Newer {source {dest ""}} {
variable ftp 

	if ![info exists ftp(State)] {
		DisplayMsg "Not connected!" error
		return 0
	}

	if { $dest == "" } {
		set dest $source
	}

	set ftp(RemoteFilename) $source
	set ftp(LocalFilename) $dest

	# get remote modification time
	set rmt [ModTime $ftp(RemoteFilename)]
	if { $rmt == "-1" } {
		return 0
	}

	# get local modification time
	if [file exists $ftp(LocalFilename)] {
		set lmt [file mtime $ftp(LocalFilename)]
	} else {
		set lmt 0
	}
	
	# remote file is older than local file
	if { $rmt < $lmt } {
		return 0
	}

	# remote file is newer than local file or local file doesn't exist
	# get it
	set rc [Get $ftp(RemoteFilename) $ftp(LocalFilename)]
	return $rc
		
}

#############################################################################
#
# Quote -- 
#
# The arguments specified are sent, verbatim, to the remote FTP server.     
#
# Arguments:
# 	arg1 arg2 ...
#
# Returns:
#  string sent back by the remote FTP server or null string if any error
#

proc Quote {args} {
variable ftp

	if ![info exists ftp(State)] {
		DisplayMsg "Not connected!" error
		return 0
	}

	set ftp(Cmd) $args

	set ftp(State) quote
	StateHandler

	# wait for synchronization
	set rc [WaitOrTimeout] 

	unset ftp(Cmd)

	if {$rc} {
		return $ftp(Quote)
	} else {
		return {}
	}
}


#############################################################################
#
# Abort -- 
#
# ABORT - Tells the server to abort the previous FTP service command and 
# any associated transfer of data. The control connection is not to be 
# closed by the server, but the data connection must be closed.
# 
# NOTE: This procedure doesn't work properly. Thus the FTP::Abort command
# is no longer available!
#
# Arguments:
# None.
#
# Returns:
# 0 -			ERROR
# 1 - 			OK
#
# proc Abort {} {
# variable ftp
#
# }

#############################################################################
#
# Close -- 
#
# Terminates a ftp session and if file transfer is not in progress, the server
# closes the control connection.  If file transfer is in progress, the 
# connection will remain open for result response and the server will then
# close it. 
# (exported)
# 
# Arguments:
# None.
#
# Returns:
# 0 -			ERROR
# 1 - 			OK

proc Close {} {
variable ftp

	if ![info exists ftp(State)] {
		DisplayMsg "Not connected!" error
		return 0
	}

	set ftp(State) quit
	StateHandler

	# wait for synchronization
	WaitOrTimeout

	catch {close $ftp(CtrlSock)}
	catch {unset ftp}
}

#############################################################################
#
# Open --
#
# Starts the ftp session and sets up a ftp control connection.
# (exported)
# 
# Arguments:
# server - 		The ftp server hostname.
# user -		A string identifying the user. The user identification 
#			is that which is required by the server for access to 
#			its file system.  
# passwd -		A string specifying the user's password.
# options -		-blocksize size		writes "size" bytes at once
#						(default 4096)
#			-timeout seconds	if non-zero, sets up timeout to
#						occur after specified number of
#						seconds (default 120)
#			-progress proc		procedure name that handles callbacks
#						(no default)  
#			-mode mode		switch active or passive file transfer
#						(default active)
#			-port number		alternative port (default 21)
# 
# Returns:
# 0 -			Not logged in
# 1 - 			User logged in

proc Open {server user passwd {args ""}} {
variable ftp
variable DEBUG 
variable VERBOSE
upvar #0 finished state

	if [info exists ftp(State)] {
       		DisplayMsg "Mmh, another attempt to open a new connection? There is already a hot wire!" error
		return 0
	}

	# default NO DEBUG
	if {![info exists DEBUG]} {
		set DEBUG 0
	}

	# default NO VERBOSE
	if {![info exists VERBOSE]} {
		set VERBOSE 0
	}
	
	if {$DEBUG} {
		DisplayMsg "Starting new connection with: "
	}
	
	set ftp(User) 		$user
	set ftp(Passwd) 	$passwd
	set ftp(RemoteHost) 	$server
	set ftp(LocalHost) 	[info hostname]
	set ftp(DataPort) 	0
	set ftp(Type) 		{}
	set ftp(Error) 		{}
	set ftp(Progress) 	{}
	set ftp(Blocksize) 	4096	
	set ftp(Timeout) 	600	
	set ftp(Mode) 		active	
	set ftp(Port) 		21	

	set ftp(State) 		user
	
	# set state var
	set state(control) ""
	
	# Get and set possible options
	set options {-blocksize -timeout -mode -port -progress}
	foreach {option value} $args {
		if { [lsearch -exact $options $option] != "-1" } {
				if {$DEBUG} {
					DisplayMsg "  $option = $value"
				}
				regexp {^-(.?)(.*)$} $option all first rest
				set option "[string toupper $first]$rest"
				set ftp($option) $value
		} 
	}
	if { $DEBUG && ($args == "") } {
		DisplayMsg "  no option"
	}

	# No call of StateHandler is required at this time.
	# StateHandler at first time is called automatically
	# by a fileevent for the control channel.

	# Try to open a control connection
	if ![OpenControlConn] { return 0 }

	# waits for synchronization
	#   0 ... Not logged in
	#   1 ... User logged in
	if {[WaitOrTimeout]} {
		# default type is binary
		Type binary
		return 1
	} else {
		# close connection if not logged in
		Close
		return 0
	}
}

#############################################################################
#
# CopyNext --
#
# recursive background copy procedure for ascii/binary file I/O
# 
# Arguments:
# bytes - 		indicates how many bytes were written on $ftp(DestCI)

proc CopyNext {bytes {error {}}} {
variable ftp
variable DEBUG
variable VERBOSE
upvar #0 finished state

	# summary bytes		
	incr ftp(Total) $bytes

	# callback for progress bar procedure
	if { ([info exists ftp(Progress)]) && ([info commands [lindex $ftp(Progress) 0]] != "") } { 
		eval $ftp(Progress) $ftp(Total)
	}

	# setup new timeout handler
	after cancel $ftp(Wait)
	set ftp(Wait) [after [expr $ftp(Timeout) * 1000] [namespace current]::Timeout]

	if {$DEBUG} {
		DisplayMsg "-> $ftp(Total) bytes $ftp(SourceCI) -> $ftp(DestCI)" 
	}

	if {$error != ""} {
		catch {close $ftp(DestCI)}
		catch {close $ftp(SourceCI)}
   		unset state(data)
		DisplayMsg $error error

	} elseif {[eof $ftp(SourceCI)]} {
		close $ftp(DestCI)
		close $ftp(SourceCI)
   		unset state(data)
		if {$VERBOSE} {
			DisplayMsg "D: Port closed" data
		}

	} else {
		fcopy $ftp(SourceCI) $ftp(DestCI) -command [namespace current]::CopyNext -size $ftp(Blocksize)

	}

}

#############################################################################
#
# HandleList --
#
# Handles ascii/binary data transfer for Put and Get 
# 
# Arguments:
# sock - 		socket name (data channel)

proc HandleData {sock} {
variable ftp 

	# Turn off any fileevent handlers
	fileevent $sock writable {}		
	fileevent $sock readable {}

	# create local file for FTP::Get 
	if [regexp "^get" $ftp(State)] {
		set rc [catch {set ftp(DestCI) [open $ftp(LocalFilename) w]} msg]
		if { $rc != 0 } {
			DisplayMsg "$msg" error
			return 0
		}
		if { $ftp(Type) == "ascii" } {
			fconfigure $ftp(DestCI) -buffering line -blocking 1
		} else {
			fconfigure $ftp(DestCI) -buffering line -translation binary -blocking 1
		}
	}	

	# append local file for FTP::Reget 
	if [regexp "^reget" $ftp(State)] {
		set rc [catch {set ftp(DestCI) [open $ftp(LocalFilename) a]} msg]
		if { $rc != 0 } {
			DisplayMsg "$msg" error
			return 0
		}
		if { $ftp(Type) == "ascii" } {
			fconfigure $ftp(DestCI) -buffering line -blocking 1
		} else {
			fconfigure $ftp(DestCI) -buffering line -translation binary -blocking 1
		}
	}	

	# perform fcopy	
	set ftp(Total) 0
	set ftp(Start_Time) [clock seconds]
	fcopy $ftp(SourceCI) $ftp(DestCI) -command [namespace current]::CopyNext -size $ftp(Blocksize)
}

#############################################################################
#
# HandleList --
#
# Handles ascii data transfer for list commands
# 
# Arguments:
# sock - 		socket name (data channel)

proc HandleList {sock} {
variable ftp 
variable VERBOSE
upvar #0 finished state

	if ![eof $sock] {
		set buffer [read $sock]
		if { $buffer != "" } {
			set ftp(List) [append ftp(List) $buffer]
		}	
	} else {
		close $sock
   		unset state(data)
		if {$VERBOSE} {
			DisplayMsg "D: Port closed" data
		}
	} 
}

############################################################################
#
# CloseDataConn -- 
#
# Closes all sockets and files used by the data conection
#
# Arguments:
# None.
#
# Returns:
# None.
#
proc CloseDataConn {} {
variable ftp

	catch {after cancel $ftp(Wait)}
	catch {fileevent $ftp(DataSock) readable {}}
	catch {close $ftp(DataSock); unset ftp(DataSock)}
	catch {close $ftp(DestCI); unset ftp(DestCI)} 
	catch {close $ftp(SourceCI); unset ftp(SourceCI)}
	catch {close $ftp(DummySock); unset ftp(DummySock)}
}

#############################################################################
#
# InitDataConn --
#
# Configures new data channel for connection to ftp server 
# ATTENTION! The new data channel "sock" is not the same as the 
# server channel, it's a dummy.
# 
# Arguments:
# sock -		the name of the new channel
# addr -		the address, in network address notation, 
#			of the client's host,
# port -		the client's port number

proc InitDataConn {sock addr port} {
variable ftp
variable VERBOSE
upvar #0 finished state

	# If the new channel is accepted, the dummy channel will be closed
	catch {close $ftp(DummySock); unset ftp(DummySock)}

	set state(data) 0

	# Configure translation mode
	if { $ftp(Type) == "ascii" } {
		fconfigure $sock -buffering line -blocking 1
	} else {
		fconfigure $sock -buffering line -translation binary -blocking 1
	}

	# assign fileevent handlers, source and destination CI (Channel Identifier)
	switch -regexp $ftp(State) {

		list {
			  fileevent $sock readable [list [namespace current]::HandleList $sock]
			  set ftp(SourceCI) $sock		  
			}

		get	{
			  fileevent $sock readable [list [namespace current]::HandleData $sock]
			  set ftp(SourceCI) $sock			  
			}

		append  -
		
		put {
			  fileevent $sock writable [list [namespace current]::HandleData $sock]
			  set ftp(DestCI) $sock			  
			}
	}

	if {$VERBOSE} {
		DisplayMsg "D: Connection from $addr:$port" data
	}
}

#############################################################################
#
# OpenActiveConn --
#
# Opens a ftp data connection
# 
# Arguments:
# None.
# 
# Returns:
# 0 -			no connection
# 1 - 			connection established

proc OpenActiveConn {} {
variable ftp
variable VERBOSE

	# Port address 0 is a dummy used to give the server the responsibility 
	# of getting free new port addresses for every data transfer.
	set rc [catch {set ftp(DummySock) [socket -server [namespace current]::InitDataConn 0]} msg]
	if { $rc != 0 } {
       		DisplayMsg "$msg" error
       		return 0
	}

	# get a new local port address for data transfer and convert it to a format
	# which is useable by the PORT command
	set p [lindex [fconfigure $ftp(DummySock) -sockname] 2]
	if {$VERBOSE} {
		DisplayMsg "D: Port is $p" data
	}
	set ftp(DataPort) "[expr "$p / 256"],[expr "$p % 256"]"

	return 1
}

#############################################################################
#
# OpenPassiveConn --
#
# Opens a ftp data connection
# 
# Arguments:
# buffer - returned line from server control connection 
# 
# Returns:
# 0 -			no connection
# 1 - 			connection established

proc OpenPassiveConn {buffer} {
variable ftp

	if {[regexp {([0-9]+),([0-9]+),([0-9]+),([0-9]+),([0-9]+),([0-9]+)} $buffer all a1 a2 a3 a4 p1 p2]} {
		set ftp(LocalAddr) "$a1.$a2.$a3.$a4"
		set ftp(DataPort) "[expr $p1 * 256 + $p2]"

		# establish data connection for passive mode
		set rc [catch {set ftp(DataSock) [socket $ftp(LocalAddr) $ftp(DataPort)]} msg]
		if { $rc != 0 } {
			DisplayMsg "$msg" error
			return 0
		}

		InitDataConn $ftp(DataSock) $ftp(LocalAddr) $ftp(DataPort)			
		return 1
	} else {
		return 0
	}
}
#############################################################################
#
# OpenControlConn --
#
# Opens a ftp control connection
# 
# Arguments:
# None.
# 
# Returns:
# 0 -			no connection
# 1 - 			connection established

proc OpenControlConn {} {
variable ftp
variable DEBUG
variable VERBOSE

	# open a control channel
        set rc [catch {set ftp(CtrlSock) [socket $ftp(RemoteHost) $ftp(Port)]} msg]
	if { $rc != 0 } {
		if {$VERBOSE} {
       			DisplayMsg "C: No connection to server!" error
		}
		if {$DEBUG} {
			DisplayMsg "[list $msg]" error
		}
       		unset ftp(State)
       		return 0
	}
	# configure control channel
	fconfigure $ftp(CtrlSock) -buffering line -blocking 1 -translation {auto crlf}
        fileevent $ftp(CtrlSock) readable [list [namespace current]::StateHandler $ftp(CtrlSock)]
	
	# prepare local ip address for PORT command (convert pointed format to comma format)
	set ftp(LocalAddr) [lindex [fconfigure $ftp(CtrlSock) -sockname] 0]
	regsub -all "\[.\]" $ftp(LocalAddr) "," ftp(LocalAddr) 

	# report ready message
	set peer [fconfigure $ftp(CtrlSock) -peername]
	if {$VERBOSE} {
		DisplayMsg "C: Connection from [lindex $peer 0]:[lindex $peer 2]" control
	}
	
	return 1
}

# added TkCon support
# TkCon is (c) 1995-1999 Jeffrey Hobbs, http://www.purl.org/net/hobbs/tcl/script/tkcon/
# started with: tkcon -load FTP
if { [uplevel "#0" {info commands tkcon}] == "tkcon" } {

	# new FTP::List proc makes the output more readable
	proc __ftp_ls {args} {
		foreach i [::FTP::List_org $args] {
			puts $i
		}
	}

	# rename the original FTP::List procedure
	rename ::FTP::List ::FTP::List_org

	alias ::FTP::List	::FTP::__ftp_ls
	alias bye		catch {::FTP::Close; exit}	

	set ::FTP::VERBOSE 1
	set ::FTP::DEBUG 0
}

# not forgotten close-brace (end of namespace)
}
}
#############################################################################
## Procedure:  FUNC_SET_LANGUAGE

proc ::FUNC_SET_LANGUAGE {} {
global widget

global tcl_platform
global g_language

set g_language "0"

if { [string match -nocase "*window*" $tcl_platform(platform)] == 1 } {
    
    set key {HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Keyboard Layouts\00000412}
    set value {Layout File}

    if { [catch { set tmp [registry get $key $value] } err] } {
        set g_language "0"
    } else {
        set g_language "1"
    }
    
} else {

    if { [catch {set tmp_language [exec locale -a]} error] } {
        set g_language "0"
        return
    }
    
    foreach tmp $tmp_language {
        #puts "tmp : $tmp"
        if { [string match -nocase "*kr*" $tmp] == 1 } {
            set g_language "1"
        }
    }
}

####################
####################
set g_language "0"
####################
####################

global g_hostname
set qry "SCOPS,UpdateLanguage,$g_hostname,$g_language*"
set res ""
set res [FUNC_SEND_QRY $qry]
}
#############################################################################
## Procedure:  FUNC_CHECK_VARIABLE

proc ::FUNC_CHECK_VARIABLE {var} {
global widget

global $var

#FD "var : $var"

if [catch { 
    subst $$var
} err] {
    #FD "ERROR : $err"
    return "NULL"
}

return [subst $$var]
}
#############################################################################
## Procedure:  BTN_INPUT_TESTRESULT

proc ::BTN_INPUT_TESTRESULT {} {
global widget

global g_manual_flag

#######################
### demo setting #######
#set g_manual_flag "ON"
#######################
#######################


if { $g_manual_flag == 0 || [string toupper $g_manual_flag] == "OFF" } {
    set msg "This is not a manual tester!"
    set choice [ tk_messageBox -title "Input Test result Error" -icon warning -message [FM "" $msg ""] ]
    return 
}


global g_hostname
global g_lotname
global g_dcc
global g_operation
global g_job
global g_passcount
global g_failcount
global g_incount


if { [string trim $g_lotname] == "" || [string trim $g_operation] == "" || [string trim $g_job] == "" } {
    set msg "Select Lot and Operation!"
    set choice [ tk_messageBox -title "Input Test result Error" -icon warning -message [FM "" $msg ""] ]
    return    
}

if { [string trim $g_passcount] == "" || [string trim $g_failcount] == "" } {
    set msg "Input Pass / Fail Quantity!"
    set choice [ tk_messageBox -title "Input Test Result Error" -icon warning -message [FM "" $msg ""] ]
    return    
}

set qry "SCOPS,InputTestResult,$g_hostname,$g_lotname,$g_dcc,$g_operation,$g_job,$g_passcount,$g_failcount,$g_incount*"

set res [FUNC_SEND_QRY $qry]

if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
    set msg "Fail to Input Test Result!"
    set choice [ tk_messageBox -title "Input Test Result Error" -icon warning -message [FM "" $msg $res] ]
    return
}

set g_passcount ""
set g_failcount ""

FUNC_GET_HOSTSTATUS
}
#############################################################################
## Procedure:  FUNC_CHECK_SWR

proc ::FUNC_CHECK_SWR {} {
global widget

global g_swrnumber
global g_testing_flag

puts "g_testing_flag : $g_testing_flag"

if { $g_testing_flag != "TESTING" } { return }

if { [string trim $g_swrnumber] == "" } { return }

global g_tester_status

if { [string match -nocase "*swr*" $g_tester_status] == 0 } {
    set g_tester_status [format "SWR %s" $g_tester_status]
}

global g_note_root
global g_note_search
global g_note_down

#color
set color #F03E75

# testing ready
if { [string match -nocase "*READY*" $g_tester_status] == 1 } {           
    set color #9034f9
}
    
lbl_status configure -background $color
#$g_note_root configure -background $color
.top83 configure -background $color
}
#############################################################################
## Procedure:  FUNC_EXECUTE_APL

proc ::FUNC_EXECUTE_APL {} {
global widget

global g_apl_flag
global g_apl_path

if { $g_apl_flag == "OFF" || $g_apl_flag == 0 } { return }

global g_devicename
global g_customer
global g_package
global g_operation

set qry "SCOPS,AplMultiProgramCheck,$g_devicename,$g_customer,$g_package,$g_operation*"

set res ""
set res [FUNC_SEND_QRY $qry]

if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
    set msg {"Fail to Check TP1 and TP2" "\xAC\xB9\x4C\xD1\xA4\xC2\xB8\xD2\x20\x00\xF5\xAC\x15\xC8\x20\x00\xDD\xC0\x31\xC1\xD0\xC5\x20\x00\xE4\xC2\x28\xD3\x58\xD5\x00\xC6\xB5\xC2\xC8\xB2\xE4\xB2\x21\x00"}
    set choice [ tk_messageBox -title "TP1 and TP2 Check Error" -icon warning -message [FM "K3 engineer" $msg $res] ]
    return "FALSE"
}

if { [file exists $g_apl_path] == 0 } { return "TRUE" }

global g_lotname
global g_dcc
global g_testprogramrev
global g_testprogram
global g_job
global g_temperature
global g_operatorid
global g_board
global g_handler

set program_list $res

if { $g_dcc != "" } {
    set tmp_lotname [format "%s\DCC%s" $g_lotname $g_dcc]
} else {
    set tmp_lotname $g_lotname
}

set apl_result [open "|$g_apl_path START {$g_customer} {$g_devicename} {$tmp_lotname} {$g_testprogramrev} {/usr/local1/APL} {$g_testprogram} {$g_operation} {$g_package} {$g_job} {$g_temperature} {$g_operatorid} {$g_board} {$g_handler} {$program_list}" ]

#FD "open |$g_apl_path START {$g_customer} {$g_devicename} {$tmp_lotname} {$g_testprogramrev} {/usr/local1/APL} {$g_testprogram} {$g_operation} {$g_package} {$g_job} {$g_temperature} {$g_operatorid} {$g_board} {$g_handler} {$program_list}"
#set apl_result "2/test2"

set apl_result_value [lindex [split $apl_result "/"] 0]
set apl_result_msg [lindex [split $apl_result "/"] 1]

if { $apl_result_value == 0 } {
    #puts "apl_result_value : $apl_result_value"
} elseif { $apl_result_value == 1 } {
  
    set msg {"$apl_result_msg" "\xAC\xB9\x4C\xD1\xA4\xC2\xB8\xD2\x20\x00\xF5\xAC\x15\xC8\x20\x00\xDD\xC0\x31\xC1\xD0\xC5\x20\x00\xE4\xC2\x28\xD3\x58\xD5\x00\xC6\xB5\xC2\xC8\xB2\xE4\xB2\x21\x00"}
    set choice [ tk_messageBox -title "APL Warning!" -icon warning -message [FM "K3 engineer" $msg ""] ]
  
} elseif { $apl_result_value == 2 } {

    global g_comment
    set g_comment $apl_result_msg
    BTN_END_LOT
    
    set msg {"$apl_result_msg" "\xAC\xB9\x4C\xD1\xA4\xC2\xB8\xD2\x20\x00\xF5\xAC\x15\xC8\x20\x00\xDD\xC0\x31\xC1\xD0\xC5\x20\x00\xE4\xC2\x28\xD3\x58\xD5\x00\xC6\xB5\xC2\xC8\xB2\xE4\xB2\x21\x00"}
    set choice [ tk_messageBox -title "APL Error!" -icon error -message [FM "K3 engineer" $msg ""] ]
       
    return "FALSE"
  
} elseif { $apl_result_value == 99 } {
    #puts "apl_result_value : $apl_result_value"
} else {
    #puts "apl_result_value : $apl_result_value"
}

return "TRUE"
}
#############################################################################
## Procedure:  FUNC_DEBUG

proc ::FUNC_DEBUG {str} {
global widget

global g_debug_flag
global g_lst_debug

set size [$g_lst_debug subwidget listbox size]

#puts "size : $size"

if { [$g_lst_debug subwidget listbox size] > 400 } {
    #set tmp [FUNC_CLEAR_DEBUG]
    set tmp [$g_lst_debug subwidget listbox del 1]
}

if { $g_debug_flag == "ON" } {

    set date ""
    set localtime [clock second]
    set date [clock format $localtime -format {%Y-%m-%d %H:%M:%S}]

    #$g_lst_debug subwidget listbox insert end "$str"
    $g_lst_debug subwidget listbox insert end "$date : $str"
}

puts "$str"
}
#############################################################################
## Procedure:  FUNC_GET_LOTINFORMATION

proc ::FUNC_GET_LOTINFORMATION {} {
global widget

global g_cd
global g_rd

global g_lstlotname_flag
global g_lst_lotname
global g_lotarray

global g_lst_job
global g_jobarray

global g_hostname
global g_lotname
global g_dcc
global g_operation       

set qry "SCOPS,SelectLot,$g_hostname,$g_lotname,$g_dcc,$g_operation*"
#puts "qry : $qry"

set res ""
set res [FUNC_SEND_QRY $qry]

if { $res == "" || [lindex [split $res ","] 0] == "FAIL" } {
    
    if { [string match -nocase "*DIFFERENT DEVICE*" $res] == 1 } {
        
        set win_title "warning_lot_information"
        FUNC_DISPLAY_MESSAGE "open" $win_title "image,scops_warning_device.gif" [FM "Engineer, PCS" $res ""]   
        set choice [ tk_messageBox -title "LOT SELECT ERROR" -icon error -message $res]        
        FUNC_DISPLAY_MESSAGE "close" "$win_title" "" ""
        
    } else {
        set choice [ tk_messageBox -title "LOT SELECT ERROR" -icon error -message $res]
    }
    
    FUNC_CLEAR_LOT
    return
}


#puts "$res"

set resultarray [split $res $g_cd]

global g_lotname
global g_dcc
global g_operation
global g_job
global g_devicename
global g_customer
global g_testprogram
global g_testprogramrev
global g_condition
global g_testtime
global g_yieldlimit
global g_incount
global g_qasample
global g_package
global g_dimension
global g_lead
global g_swrnumber
global g_swrmessage
global g_handlertype


set g_lotname [lindex $resultarray 0]
set g_dcc [lindex $resultarray 1]
set g_operation [lindex $resultarray 2]
set tmp_job [lindex $resultarray 3]
set g_devicename [lindex $resultarray 4]
set g_customer [lindex $resultarray 5]
set g_testprogram [lindex $resultarray 6]
set g_testprogramrev [lindex $resultarray 7]
set g_condition [lindex $resultarray 8]
set g_testtime [lindex $resultarray 9]
set g_yieldlimit [lindex $resultarray 10]
set g_incount [lindex $resultarray 11]
set g_qasample [lindex $resultarray 12]
set g_package [lindex $resultarray 13]
set g_dimension [lindex $resultarray 14]
set g_lead [lindex $resultarray 15]
set g_swrnumber [lindex $resultarray 16]
set g_swrmessage [lindex $resultarray 17]
set g_handlertype [lindex $resultarray 18]


### parse condtion to retrieve temperature and soaktime
FUNC_PARSE_CONDITION



### fill job listbox

### initialize ###########################
$g_lst_job subwidget listbox delete 0 end
array unset g_jobarray
##########################################

set tmp_jobarray [split $tmp_job ":"]

for { set i 0 } { $i < [llength $tmp_jobarray] } { incr i } {

    set g_jobarray($i.job) [lindex $tmp_jobarray $i]    
    $g_lst_job subwidget listbox insert end "[lindex $tmp_jobarray $i]"

}
}
#############################################################################
## Procedure:  test

proc ::test {} {
global widget

set ar "1 2 3 4 5 6 7 8 9 0"

FD "[FS $ar 11]"
}
#############################################################################
## Procedure:  FUNC_LOAD_FUNCTIONS

proc ::FUNC_LOAD_FUNCTIONS {} {
global widget

set func_list {
            BTN_SEARCH_LOT
            FUNC_SELECT_LOT_LISTBOX
            FUNC_GET_DESCRIPTION
            FUNC_SELECT_JOB_LISTBOX
            FUNC_CLEAR_LOT
            FUNC_SELECT_SUBDSC_COMBOBOX
            FUNC_SELECT_MAINDSC_COMBOBOX
            FUNC_GET_HOSTSTATUS
            FUNC_SET_STATUS
            BTN_START_LOT
            BTN_SET_DOWN
            FUNC_EXECUTE_LOOP
            BTN_SEARCH_RFID
            FUNC_CHECK_COMMENT
            FUNC_CHECK_TPA
            FUNC_CHECK_T1T2
            BTN_ADD_RETEST
            FUNC_CHECK_SCOPSVERSION
            FUNC_CHECK_TPMS
            FUNC_UPDATE_SCOPS
            BTN_END_LOT
            FUNC_CHECK_OPERATORID
            TCL_LIB_FTP
            FUNC_SET_LANGUAGE
            FUNC_CHECK_VARIABLE
            BTN_INPUT_TESTRESULT
            FUNC_CHECK_RFID
            FUNC_CHECK_SWR
            FUNC_EXECUTE_APL
            FUNC_DEBUG
            FUNC_GET_LOTINFORMATION
            test
            FUNC_LOAD_FUNCTIONS
            FUNC_CHECK_TPGM
            CONTACT_POINT
            TEMPLATE_MESSAGEBOX
            TEMPLATE_QUERY
            FD
            FUNC_SET_SKIN
            FUNC_CREATE_CONFIGFILE
            FUNC_INITIALIZE_VARIABLE
            FM
            FUNC_UPDATE_IP
            FUNC_UPDATE_SCOPSVERSION
            FUNC_EXECUTE_XTERM
            FUNC_CHECK_DOWNTIME
            FUNC_INITIALIZE_FLAG
            FUNC_SET_FLAG_END_LOT
  
            FUNC_PARSE_CONDITION
            FUNC_CHECK_BINAGENT
            FUNC_CHECK_HP93KDRIVER
            FUNC_DISPLAY_SWR
            test1
            test3
        
            FUNC_DOWNLOAD_FILE
            FUNC_UPDATE_OS
            FUNC_GET_TESTINFORMATION
            FUNC_SELECT_DEBUG_LISTBOX
            FUNC_DISPLAY_MESSAGE
            TEMPLATE_DISPLAY_MESSAGE
            FUNC_APL_T5585
          
            FUNC_SET_MESSAGE
            FUNC_SEND_UDPSTRING
            FUNC_SEND_TCPSTRING
            FUNC_SEND_TCPSTRINGRETURN
            TCL_LIB_MIME
            TCL_LIB_SMTP
            FUNC_LOAD_LIBRARY
            FUNC_SEND_EMAIL
            TEMPLATE_SEND_EMAIL
            TCL_LIB_BASE64
            TCL_LIB_MD5
            FUNC_SEND_DEBUG
            ATK_GROUP_START_LOT
            ATK_GROUP_HOSTSTATUS
            ATK_GROUP_SELECT_LOT_LISTBOX
            FUNC_VARTEST
            test4
            FUNC_SET_DELIMITER
            FUNC_CREATE_SOCKET
            FUNC_SEND_QRY_ORG
            FUNC_SEND_QRY_EXCEPTION
            FUNC_SEND_QRY
            FUNC_RFID_COMPARE_LOTS
            FUNC_RFID_INITIALIZE
            FUNC_RFID_REFRESH
            FUNC_BIND_WIDGET
            FUNC_CLEAR_FILE
         
            FUNC_KILL_PROCESS
            FUNC_PARSEANDSET_STRING
            FUNC_REMOTE_SCOPS
            FUNC_CHECK_MADEVICE
            FUNC_CHECK_BOARDKIT_NONQCT
            FUNC_CHECK_BOARDKIT_QCT
        
            TEMPLATE_TRYCATCH
            FUNC_RFID_CHECK_PROBETOUCHDOWN
            FUNC_RFID_CHECK_SOCKETTOUCHDOWN
            FUNC_APL_WINDOWS
            FUNC_APL_T2000
            FUNC_APL_XILINX
            FUNC_GET_CONFIG_ORG
            FUNC_GET_CONFIG
         
            ATK_GROUP_END_LOT
            FUNC_CHECK_DATASTREAM
        
            FUNC_CHECK_DRL
            ATK_GROUP_APL
       
            FUNC_CREATE_UDPSENDER
            FUNC_DOWNLOAD_UDPSENDER
            test5
         
            test2
          
            FUNC_CHECK_FILE
            FUNC_CONFIRM_VALIDATION
            FUNC_DEBUG_CLEAR
            FUNC_DEBUG_SAVE
            FUNC_DEBUG_DELETEFILE
            FUNC_DEBUG_SENDFILE
            FUNC_CHECK_OPERATORID_org
           
            FUNC_CONFIRM_VALIDATION_LOG
            FUNC_CHECK_FULLTEST
            FUNC_CHECK_RETEST
            FUNC_CHECK_OTDF
            FUNC_APL_MICROCHIP
            ATK_GROUP_ADDRETEST
           
            FUNC_APL_EVE_SLT
            FUNC_APL_EVE_UFLEX
          
            FUNC_RFID_CHECK
            FUNC_RFID_CLEAR_SOCKETTOUCHCOUNT
            FUNC_RFID_EXTEND_SOCKETLIMIT
            FUNC_RFID_CLEAR_PROBETOUCHDOWN
            FUNC_RFID_EXTEND_PROBELIMIT
            FUNC_CHECK_PROBE
            FUNC_CHECK_PROBESITEVARIANCE
        
            FUNC_APL_T2000_org
            FUNC_APL_ADVANTXXXX_20140331
            FUNC_APL_ADVANTXXXX
            FUNC_APL_D10_20140331
            FUNC_APL_D10
        
            FUNC_APL_MAVERICK_20140414
            FUNC_APL_MAVERICK
            FUNC_APL_MWEST_20140414
            FUNC_APL_MWEST
            FUNC_APL_ETS_20140414
            FUNC_APL_ETS
            FUNC_APL_J750_20140414
            FUNC_APL_J750
            FUNC_APL_MICROCHIP_20140414
            FUNC_APL_ARMAR_20140414
            FUNC_APL_ARMAR
            FUNC_APL_QSLT
            FUNC_APL_NXP
            FUNC_CHECK_TESTERASSIGNMENT
            FUNC_RFID_CHECK_SOCKETCLEAR
            FUNC_CHECK_JUNCTIONTEMPERATURE
       
            FUNC_CHECK_HSFANDSVR
      
            FUNC_CHECK_BOARDCORRELATION
            FUNC_APL_HP
          
            FUNC_APL_J750_NXP
            FUNC_APL_HP93K_NXP
          
            FUNC_CHECK_PREVIOUSSCOPS
          
            FUNC_CHECK_WIPFLOW
            FUNC_CHECK_TPA_NEW
           
            FUNC_CHECK_QUALTESTER
        
            FUNC_CHECK_RETEST_HISTORY
        
            FUNC_RFID_LOTCHECK
            FUNC_CHECK_SOCKETCORRELATION
         
            FUNC_RFID_CHECK_SOCKETTOUCHDOWN
            FUNC_RFID_CHECK_CORETOUCHDOWN
       
            FUNC_CHECK_PROBECORRELATION
          
            FUNC_CHECK_RETEST_SKIP
     
            FUNC_PROBE_TD_OVER_CONFIRM
         
            FUNC_CHECK_HARDWARE_INOUT
           
            FUNC_RFID_CLEAR_SOCKETTOUCHCOUNT
            FUNC_RFID_EXTEND_SOCKETLIMIT
            FUNC_CHECK_CALIBRATION
            FUNC_CHECK_PROBECARD
            
            FUNC_RFID_EXTEND_CLEANINGSHEETLIMIT
            
            FUNC_APL_NVIDIA_BUMP
            FUNC_CHECK_QUALTESTER_QCT
         
            
}        


if { [catch {
    cmb_debug1 configure -values "\"\""
    cmb_debug2 configure -values "\"\""

    cmb_debug1 configure -values [lsort $::vTcl::modules::main::procs]
    cmb_debug2 configure -values [lsort $::vTcl::modules::main::procs]
    cmb_debug2 configure -text "FUNC_GET_HOSTSTATUS"
    
} err] } {
    cmb_debug1 configure -values "\"\""
    cmb_debug2 configure -values "\"\""
    cmb_debug1 configure -values [lsort $func_list]
    cmb_debug2 configure -values [lsort $func_list]

}
}
#############################################################################
## Procedure:  FUNC_CHECK_TPGM

proc ::FUNC_CHECK_TPGM {} {
global widget


global g_hostname
global g_lotname
global g_dcc
global g_operation
global g_operatorid
global g_testprogram
global g_testprogramrev


set qry "SCOPS,CheckTestprogram,check,$g_hostname,$g_lotname,$g_dcc,$g_operation,$g_operatorid,$g_testprogram,$g_testprogramrev*"

set res ""
set res [FUNC_SEND_QRY $qry]

#set res [string map {"newline" "\n\n"} $res]

if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {

    #set choice [ tk_messageBox -title "TPGM Check Error" -icon warning -message [FM "TESTIT" "Fail to Get Test Program!" $res] ]
    return "TRUE"
    
}

if { [string match -nocase "*no*" [lindex [split $res ","] 0] ] == 1 } {

    set choice [ tk_messageBox -title "PGM Check Error" -icon error -message [FM "K3 Engineer" "SCOPS and eMES have different Test Program!" $res] ]
    return "FALSE"
}

return "TRUE"
}
#############################################################################
## Procedure:  CONTACT_POINT

proc ::CONTACT_POINT {str} {
global widget

return "============================================   \n\nContact to : $str\n\n============================================   \n\n"
}
#############################################################################
## Procedure:  TEMPLATE_MESSAGEBOX

proc ::TEMPLATE_MESSAGEBOX {} {
global widget

set res ""

set msg {"TPA Fail!" ""}
set choice [ tk_messageBox -title "TPA Error" -icon error -message [FM "" $msg $res] ]
}
#############################################################################
## Procedure:  TEMPLATE_QUERY

proc ::TEMPLATE_QUERY {} {
global widget

set qry "SCOPS,CheckT1T2,check,$g_hostname,$g_lotname,$g_dcc,$g_operation,,,,*"

set res ""
set res [FUNC_SEND_QRY $qry]

if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
    set msg {"Fail to Check TP1 and TP2" "\xAC\xB9\x4C\xD1\xA4\xC2\xB8\xD2\x20\x00\xF5\xAC\x15\xC8\x20\x00\xDD\xC0\x31\xC1\xD0\xC5\x20\x00\xE4\xC2\x28\xD3\x58\xD5\x00\xC6\xB5\xC2\xC8\xB2\xE4\xB2\x21\x00"}
    set choice [ tk_messageBox -title "TP1 and TP2 Check Error" -icon warning -message [FM "K3 engineer" $msg $res] ]
    return "FALSE"
}


if { [lindex [split $res ","] 0] == "NO" } {
    set msg {"TP1 and TP2 is different!" "\xAC\xB9\x4C\xD1\xA4\xC2\xB8\xD2\x20\x00\xF5\xAC\x15\xC8\x20\x00\xDD\xC0\x31\xC1\xD0\xC5\x20\x00\xE4\xC2\x28\xD3\x58\xD5\x00\xC6\xB5\xC2\xC8\xB2\xE4\xB2\x21\x00"}
    set choice [ tk_messageBox -title "TP1 and TP2 Check Error" -icon warning -message [FM "K3 engineer" $msg $res] ]
    return "FALSE"
}


set qry "SCOPS,CheckT1T2,check,$g_hostname,$g_lotname,$g_dcc,$g_operation,,,,*"

set res ""
set res [FUNC_SEND_QRY $qry]

if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
    set msg {"Fail to Check TP1 and TP2" ""}
    set choice [ tk_messageBox -title "TP1 and TP2 Check Error" -icon warning -message [FM "K3 engineer" $msg $res] ]
    return "FALSE"
}


if { [lindex [split $res ","] 0] == "NO" } {
    set msg {"TP1 and TP2 is different!" ""}
    set choice [ tk_messageBox -title "TP1 and TP2 Check Error" -icon warning -message [FM "K3 engineer" $msg $res] ]
    return "FALSE"
}
}
#############################################################################
## Procedure:  FD

proc ::FD {str} {
global widget

if [catch {
	FUNC_DEBUG $str
} err] {
}
}
#############################################################################
## Procedure:  FUNC_SET_SKIN

proc ::FUNC_SET_SKIN {} {
global widget

global g_testing_flag
global g_tester_status

# TESTING
# HANDLING
# DOWN

global g_note_root
global g_note_search
global g_note_down

global g_operation
global g_job


if { [string match -nocase "*testing*" $g_testing_flag] == 1 } {
    
    #selection
    $g_note_root raise page1  
    #search & status 
    $g_note_search itemconfigure page2 -state normal
    $g_note_search raise page2
    $g_note_search itemconfigure page1 -state disabled
    #down & yield   
    $g_note_down itemconfigure page2 -state normal
    $g_note_down raise page2
    $g_note_down itemconfigure page1 -state disabled
    
    #color
    set color #92F32A
    lbl_status configure -background $color
    #$g_note_root configure -background $color
    .top83 configure -background $color

    #test progress
    global g_incount
    global g_totalcount
    global g_goodcount
    global g_yieldrate
    
    if { $g_incount != 0 && $g_incount != "" && $g_totalcount != 0 && $g_totalcount != "" } {
        
        if [catch {     
            set progress [expr $g_totalcount*100/$g_incount]
        } err] {
            FD "$g_incount / $g_totalcount * 100"
            set progress 51
        }
    
        if { $progress >= 75  } {
            set color #74DF00
        } elseif { $progress < 75 && $progress >= 50  } {
            set color #80FF00
        } elseif { $progress < 50 && $progress >= 25  } {
            set color #9AFE2E
        } elseif { $progress < 25  } {
            set color #ACFA58
        }
        
        lbl_status configure -background $color
        #$g_note_root configure -background $color
        .top83 configure -background $color
     
    }
    
    #FD "g_operation : $g_operation, g_job : $g_job"
    
    # full & retest
    if { [string match -nocase "*qa*" $g_operation] == 0 && [string match -nocase "*re*" $g_job] == 1 } {
        set color #FFFC00
    } 
    
    # qa test
    if { [string match -nocase "*qa*" $g_operation] == 1 } {
        set color #FFA200
    } 
    
    # testing ready
    if { [string match -nocase "*READY*" $g_tester_status] == 1 } {           
	set color #9034f9
    }
       
    #FD "color : $color"
    
    lbl_status configure -background $color
    #$g_note_root configure -background $color
    .top83 configure -background $color
    
    
    #Coincidence
    global g_coincidence_flag
    if { $g_coincidence_flag == "ON" } {
        set color #FF0000
        lbl_status configure -background $color
        .top83 configure -background $color   
    }
    
}


if { [string match -nocase "*handling*" $g_testing_flag] == 1 } {

    #FD "CURRENT : HANDLING"

    #selection
    $g_note_root raise page1  
    #search & status 
    $g_note_search itemconfigure page1 -state normal
    $g_note_search raise page1
    $g_note_search itemconfigure page2 -state disabled
    #down & yield   
    $g_note_down itemconfigure page1 -state normal
    $g_note_down raise page1
    $g_note_down itemconfigure page2 -state disabled
   
    #color
    set color #EFEBEF
    lbl_status configure -background $color
    #$g_note_root configure -background $color
    .top83 configure -background $color
    
}


if { [string match -nocase "*down*" $g_testing_flag] == 1 } {

    #selection
    $g_note_root raise page1  
    #search & status 
    $g_note_search itemconfigure page2 -state normal
    $g_note_search raise page2
    $g_note_search itemconfigure page1 -state disabled
    #down & yield   
    $g_note_down itemconfigure page1 -state normal
    $g_note_down raise page1
    $g_note_down itemconfigure page2 -state disabled
    
    
    #color
    set color #93998E
    lbl_status configure -background $color
    #$g_note_root configure -background $color
    .top83 configure -background $color
}

#### set button text ##########################################
# lot end & down done
global g_btn_lotend
if { $g_testing_flag == "TESTING" } {
    
    $g_btn_lotend configure -text "LOT END"
} else {
    $g_btn_lotend configure -text "DOWN DONE"
}

global g_btn_down

# down & down change
if { $g_testing_flag == "DOWN" } {
    
    $g_btn_down configure -text "DOWN CHANGE"   
} else {

    $g_btn_down configure -text "DOWN"
}
}
#############################################################################
## Procedure:  FUNC_CREATE_CONFIGFILE

proc ::FUNC_CREATE_CONFIGFILE {} {
global widget

global g_rootdir
global g_hostname

set config_file [file join $g_rootdir [format "%s_scops.config" $g_hostname] ]

#FD "config_file : $config_file"

if { [file exist $config_file] == 1 } {
    set choice [ tk_messageBox -title "SCOPS Config File" -type yesno -icon warning -message "There is scops.config in $g_rootdir   \n\nDo you want to add sample format?" ]
    
    if { $choice == "no" } { return }

}

if [catch { 

        set fd [open $config_file a]
        
        puts $fd "##### Flag \"ON\" or \"OFF\", and it should be capitalized! #####"
        puts $fd "#g_scopsserver:"
        puts $fd "#g_release_flag:"
        puts $fd "#g_refreshperiod:"
        puts $fd "#g_scopsversion:"
        puts $fd "#g_scopsnewversion:"
        puts $fd "#g_manual_flag:"
        puts $fd "#g_apl_flag:"
        puts $fd "#g_apl_path:"
        puts $fd "#g_hsf_flag:"
        puts $fd "#g_sbl_flag:"
        puts $fd "#g_drl_flag:"
        puts $fd "#g_swr_flag:"
        puts $fd "#g_tpa_flag:"
        puts $fd "#g_update_flag:"
        puts $fd "#g_hostname:"
        puts $fd "#g_hostplatform:"
        puts $fd "#g_monitor:"
        puts $fd "#g_dualscops_flag:"
        
        close $fd
} error ] {
        FD "FUNC_CREATE_CONFIGFILE : $error"
        set choice [ tk_messageBox -title "SCOPS Config File" -icon warning -message "Fail to create $config_file   \n\nError : $error" ]
        return
}

set choice [ tk_messageBox -title "SCOPS Config File" -icon warning -message "Success to create $config_file  " ]
}
#############################################################################
## Procedure:  FUNC_INITIALIZE_VARIABLE

proc ::FUNC_INITIALIZE_VARIABLE {} {
global widget

global g_socketsitenumber
set g_socketsitenumber 64

global g_coresitenumber
set g_coresitenumber 16

##### list widget #################################################
global g_lst_lotname 
set g_lst_lotname  ".top83.not84.fpage1.not85.fpage1.fra118.tix83"

global g_lst_job 
set g_lst_job ".top83.not84.fpage1.not85.fpage1.fra119.tix83"

global g_lst_debug
set g_lst_debug ".top83.not84.fpage5.not83.fpage3.fra84.tix86"


##### button widget #################################################
global g_btn_lotend
set g_btn_lotend ".top83.not84.fpage1.not85.fpage2.fra83.cpd84"

global g_btn_down
set g_btn_down ".top83.not84.fpage1.not83.fpage1.cpd84.fra84.but83"

global g_btn_addretest
set g_btn_addretest ".top83.not84.fpage1.not85.fpage1.fra119.but127"

##### note widget ###############################################
global g_note_root
set g_note_root ".top83.not84"

global g_note_search
set g_note_search ".top83.not84.fpage1.not85"

global g_note_rfid
set g_note_rfid ".top83.not84.fpage2.not85"

global g_note_down
set g_note_down ".top83.not84.fpage1.not83"

global g_canvas_confirm
set g_canvas_confirm ".top86.can93"

global g_canvas_waferlot
set g_canvas_waferlot ".top90.can91"

global g_canvas_bumpcombine
set g_canvas_bumpcombine ".top91.cpd93"

global g_canvas_trbarcode
set  g_canvas_trbarcode ".top85.fra86.can83"

global g_canvas_confirm_spc
set  g_canvas_confirm_spc ".top100.can101"

global g_lst_confirm
set g_lst_confirm ".top86.fra87.tix83"

global g_note_probe
set g_note_probe ".top83.not84.fpage2.not85.fpage2.not83"

global g_note_cleaningsheet
set g_note_cleaningsheet ".top83.not84.fpage2.not85.fpage3.cpd83"

global g_ent_operatorid
set g_ent_operatorid ".top83.not84.fpage1.not85.fpage1.fra119.ent128"

global g_btn_start
set g_btn_start ".top83.not84.fpage1.not85.fpage1.fra135.but136"
}
#############################################################################
## Procedure:  FM

proc ::FM {contact msg result} {
global widget

FUNC_SET_MESSAGE $contact $msg $result
}
#############################################################################
## Procedure:  FUNC_UPDATE_IP

proc ::FUNC_UPDATE_IP {} {
global widget
global g_hostname

#GET FACTORY IP FOR K5 
set qry "SCOPS,CALLSP2,FactoryIP,$g_hostname*"  

set res ""
set res [FUNC_SEND_QRY $qry]

if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
    #set choice [ tk_messageBox -title "FACTORY IP ERROR" -icon warning -message [FM "TESTIT" "" $res] ]
    return
    
}  
if { [lindex [split $res ","] 0] == "YES" } {
   set factory_ip [lindex [split $res ","] 1]
}

set ip ""
set temp ""

if [catch {
    set temp [exec ipconfig]
} err] {
    set temp "" 
}

#FD "FUNC_UPDATE_IP : temp1 -> $temp"

if { $temp == "" } {
    if [catch {
        set temp [exec netstat -nei | grep $factory_ip]
    } err] {
        set temp ""
    }
}

if { $temp == "" } {
    if [catch {
        set temp [exec netstat -ni | grep $factory_ip]
    } err] {
        set temp ""
    }
}

#FD "FUNC_UPDATE_IP : temp2 -> $temp"

if [catch {

    set temp [string map {":" " "} $temp]
    
    if { $temp != "" } {
        foreach tmp $temp {
            if { [string match "*$factory_ip*" $tmp] == 1 && [string match "*.254*" $tmp] == 0 && [string match "*.255*" $tmp] == 0 && [string match "*.0*" $tmp] == 0 } {
                if { $ip == "" } {
                    set ip $tmp
                } else {
                    set ip "$ip/$tmp"
                }
            }
        } 
    }
    
} err] {
 
}

FD "FUNC_UPDATE_IP : $ip"

global g_testerip
set g_testerip $ip

global g_hostname

if { $ip != "" } {
    set qry "SCOPS,UpdateIP,$g_hostname,$ip*"
    set res ""
    set res [FUNC_SEND_QRY $qry]
}
}
#############################################################################
## Procedure:  FUNC_UPDATE_SCOPSVERSION

proc ::FUNC_UPDATE_SCOPSVERSION {} {
global widget

global g_hostname
global g_scopsversion
global g_language

set tmp [format "%s(%s)" $g_scopsversion $g_language]

set qry "SCOPS,UpdateVersion,$g_hostname,$g_scopsversion*"
set res ""
set res [FUNC_SEND_QRY $qry]
}
#############################################################################
## Procedure:  FUNC_EXECUTE_XTERM

proc ::FUNC_EXECUTE_XTERM {} {
global widget

global g_scopsmonitor


set xterm_w 80
set xterm_h 20

if { [string trim $g_scopsmonitor] == "" } {
    set g_scopsmonitor 1
}

set total_screen_w [winfo screenwidth .]
set total_screen_h [winfo screenheight .]

if { $total_screen_w < 2000 } {
    set screen_w $total_screen_w
} else {
    set screen_w [expr $total_screen_w/2]
}

if { $g_scopsmonitor == 1 } {
    set xterm_x [expr [expr $screen_w-$xterm_w]/2]
} elseif { $g_scopsmonitor == 2 } {
    set xterm_x [expr $screen_w + [expr [expr $screen_w-$xterm_w]/2]]
} else {
    puts "Wrong scopsMonitor value : $g_scopsmonitor!"
}

set xterm_y [expr [expr $total_screen_h/2] - $xterm_h]

set xterm_pos ""
append xterm_pos "$xterm_w"
append xterm_pos "x"
append xterm_pos "$xterm_h"
append xterm_pos "\+"
append xterm_pos "$xterm_x"
append xterm_pos "\+"
append xterm_pos "$xterm_y"

if [ catch {
    set tmp [exec /usr/openwin/bin/xterm -name scops_xterm -bg white -geom $xterm_pos &] 
} error ] {
    #puts "Func_Execute_Xterm error!\nerror : $error"
}
}
#############################################################################
## Procedure:  FUNC_CHECK_DOWNTIME

proc ::FUNC_CHECK_DOWNTIME {} {
global widget

global g_hostname
global g_downtime_val
   
if { $g_downtime_val == "TRUE" } {
    return "TRUE"
}
      
set qry "SCOPS,CheckDownTime,check,$g_hostname,*"


set res ""
set res [FUNC_SEND_QRY $qry]

puts "res : $res"


if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
    #set msg {"" ""}
    #set choice [ tk_messageBox -title "Add Retest Error" -icon warning -message [FM "" $msg ""]]
    return "TRUE"
}

if { [lindex [split $res ","] 0] == "NO" } {
   
    set g_downtime_val "FALSE"
      
    set msg {"Down Time is over 8hours!newlineIf you reset the tester, just confirm!newlinenewline- Validation : Down Time Check"}
    FUNC_CONFIRM_OPERATORID [FM "" $msg ""] g_downtime_val
   
   
    set res [string map {"NO," ""} $res]
   
    set msg {"==========================   newlinenewlineOVER '8 HOURS' SINCE THE LAST TESTING!   newlinenewline==========================   "}
   
    set choice [ tk_messageBox -title "DownTime Warning!" -icon warning -message [FM "" $msg $res]]
    
    return "FALSE"
}

return "TRUE"
}
#############################################################################
## Procedure:  FUNC_INITIALIZE_FLAG

proc ::FUNC_INITIALIZE_FLAG {} {
global widget

### to prevent select item two times on the lot list box
global g_lstlotname_flag
set g_lstlotname_flag "OFF"

### RFID flag
global g_rfid_flag
set g_rfid_flag "FALSE"

### Testing flag
global g_testing_flag
## TESTING
## HANDLING
## DOWN
set g_testing_flag "HANDLING"

global g_debug_flag
set g_debug_flag "ON"


### validation flag
global g_confirm_variable
set g_confirm_variable ""

global g_downtime_validation
set g_downtime_validation ""

global g_handlersitemap_validation
set g_handlersitemap_validation ""

global g_handlertemperature_validation
set g_handlertemperature_validation ""

global g_probecard_validation
set g_probecard_validation ""

global g_board_validation
set g_board_validation ""

global g_kit_validation
set g_kit_validation ""

global g_cleaningsheet_validation
set g_cleaningsheet_validation ""

global g_spc_validation
set g_spc_validation ""

### toplevel list
global g_toplevel_list
set g_toplevel_list ""

global g_dualscops_flag
set g_dualscops_flag "OFF"
}
#############################################################################
## Procedure:  FUNC_SET_FLAG_END_LOT

proc ::FUNC_SET_FLAG_END_LOT {} {
global widget

### validation flag



global g_confirm_variable
set g_confirm_variable ""

global g_downtime_validation
set g_downtime_validation ""

global g_handlersitemap_validation
set g_handlersitemap_validation ""

global g_handlertemperature_validation
set g_handlertemperature_validation ""


global g_probecard_validation
set g_probecard_validation ""

global g_board_validation
set g_board_validation ""

global g_kit_validation
set g_kit_validation ""

global g_cleaningsheet_validation
set g_cleaningsheet_validation ""

global g_spc_validation
set g_spc_validation ""
}
#############################################################################
## Procedure:  FUNC_PARSE_CONDITION

proc ::FUNC_PARSE_CONDITION {} {
global widget

global g_condition

global g_temperature
global g_temperature_positive
global g_temperature_negative
global g_soaktime


# no value in g_condition
if { [FUNC_CHECK_VARIABLE g_condition] == "NULL" || [string trim $g_condition] == "" } {

    set g_temperature ""
    set g_temperature_positive 0
    set g_temperature_negative 0
    set g_soaktime ""
    
    return
}

# wrong format of g_condition
if { [string match -nocase "*;*" $g_condition] == 0 } {
    if { [string match -nocase "*ROOM*" $g_condition] == 0 && [string match -nocase "*RM*" $g_condition] == 0 && [string match -nocase "*'C*" $g_condition] == 0 } {
        
        set g_temperature ""
        set g_temperature_positive 0
        set g_temperature_negative 0
        set g_soaktime ""
    
        return
    }
}


set condition [string toupper $g_condition]


############################
### demo setting ###########
#set condition "-$g_condition"
############################
############################

set temperature_condition [lindex [split $condition ";"] 0]
set temperature_condition [string map {"/" "" "|" "" " " ""} $temperature_condition]
set temperature_condition [string map -nocase {"'" "" "C" ""} $temperature_condition]


###################### temperature ############################################################################

if { [string match -nocase "*'C*" $temperature_condition] == 1 } {
    set tmp_temperature_condition [lindex [split $temperature_condition "'C"] 0]
} else {
    set tmp_temperature_condition $temperature_condition
}

set flag ""

if { [string range $tmp_temperature_condition 0 0] == "-" } {
    
    set flag "-"
    set tmp_temperature_condition [string range $tmp_temperature_condition 1 [string length $tmp_temperature_condition]]
}

#puts "flag : $flag"
#puts "temperature_condition : $tmp_temperature_condition"
#return


set g_temperature ""
set g_temperature_positive 0
set g_temperature_negative 0


# 100+-3
if { [string match -nocase "*+-*" $tmp_temperature_condition] == 1 } {

    
    set g_temperature [format "%s%s" $flag [lindex [split $tmp_temperature_condition "+-"] 0] ]
   
    set g_temperature_positive [lindex [split $tmp_temperature_condition "+-"] 2]
    set g_temperature_negative [lindex [split $tmp_temperature_condition "+-"] 2]

    # 100+3-2    
} elseif { [string match -nocase "*+-*" $tmp_temperature_condition] == 0 && [string match -nocase "*+*" $tmp_temperature_condition] == 1 && [string match -nocase "*-*" $tmp_temperature_condition] == 1 } {

    set g_temperature [format "%s%s" $flag [lindex [split $tmp_temperature_condition "+"] 0] ]
    
    set g_temperature_positive [lindex [split [lindex [split $tmp_temperature_condition "+"] 1] "-"] 0]
    set g_temperature_negative [lindex [split [lindex [split $tmp_temperature_condition "+"] 1] "-"] 1]

# 100+3
} elseif { [string match -nocase "*+-*" $tmp_temperature_condition] == 0 && [string match -nocase "*+*" $tmp_temperature_condition] == 1 && [string match -nocase "*-*" $tmp_temperature_condition] == 0 } {
    
    set g_temperature [format "%s%s" $flag [lindex [split $tmp_temperature_condition "+"] 0] ]
    
    set g_temperature_positive [lindex [split $tmp_temperature_condition "+"] 1]
    set g_temperature_negative 0
  
} elseif { [string match -nocase "*+-*" $tmp_temperature_condition] == 0 && [string match -nocase "*+*" $tmp_temperature_condition] == 0 && [string match -nocase "*-*" $tmp_temperature_condition] == 1 } {
    
    set g_temperature [format "%s%s" $flag [lindex [split $tmp_temperature_condition "-"] 0] ]
    
    set g_temperature_positive 0
    set g_temperature_negative [lindex [split $tmp_temperature_condition "-"] 1]
  
} else {
    set g_temperature [lindex [split $temperature_condition "'C"] 0]
}

if { [string match -nocase "*RM*" $g_condition] == 1 || [string match -nocase "*ROOM*" $g_condition] == 1 } {
    set g_temperature "25"
}


#puts "condition : $condition"
#puts "temperature_condition : $temperature_condition"
#puts "tmp_temperature_condition : $tmp_temperature_condition"

#puts "g_temperature : $g_temperature"
#puts "g_temperature_positive : $g_temperature_positive"
#puts "g_temperature_negative : $g_temperature_negative"


################################### soak time ###################################################

set soaktime_condition [lindex [split $condition ";"] 1]
set soaktime_condition [string map {" " ""} $soaktime_condition]

if { [string match -nocase "*S*" $soaktime_condition] == 1 } {
        
    if { [string match -nocase "*NO*" $soaktime_condition] == 0 } {
        set g_soaktime [lindex [split $soaktime_condition "S"] 0]
         
        if [catch { set tem [expr $g_soaktime - 1] } err] {     
            regexp (\\D*)(\[0-9]*)(\\D*) $g_soaktime aa bb cc
            set g_soaktime $bb
            
            if [catch { set tem [expr $g_soaktime - 1] } err] {     
                set g_soaktime "NO"
            }   
        }
    
    } else {
        set g_soaktime "NO"
    }       
}

#puts "g_soaktime : $g_soaktime"
}
#############################################################################
## Procedure:  FUNC_CHECK_BINAGENT

proc ::FUNC_CHECK_BINAGENT {flag} {
global widget

global g_hostname
global g_binagentstatus

if { [string match -nocase "*MAVERICK*" $g_hostname] == 1 } {
    set choice [ tk_messageBox -title "RESTRICTION!" -icon warning -message "Maverick seriese can't utilize this function! " ]
    return
}

if { [string match "*SAPPHIRE*" $g_hostname] == 1 } {
    set choice [ tk_messageBox -title "RESTRICTION!" -icon warning -message "D10 seriese can't utilize this function! " ]
    return
}

global tcl_platform

### Windows
if { [string match -nocase "*window*" $tcl_platform(platform)] == 1 } { 
    
    if [catch {
        package require twapi
        
        set win_agent ""
        set win_agent [twapi::get_process_ids -glob -name "*udptcpagent*"]
        
        FD "FUNC_CHECK_BINAGENT : win_agent -> $win_agent"
        
        if { $win_agent != "" } {
            set g_binagentstatus "ON"
        } else {
            set g_binagentstatus "OFF"
        }
          
    } err] {
        FD "FUNC_CHECK_BINAGENT : err -> $err"
    }
    
    if { $flag == "START" } {
        if { $g_binagentstatus == "OFF" } {
            if [catch {
                set temp [exec sc start udptcpagent]
            } err] {
                FD "FUNC_CHECK_BINAGENT START : err -> $err"
                set choice [ tk_messageBox -title "BIN AGENT ERROR" -icon warning -message "Start BIN AGENT Manually! \n\nProcedure to run BIN AGENT : \n\n1.My comuter -> Right button \n\n2.Management(G) \n\n3.Services and Applications -> Services \n\n4.udptcpagent -> start " ]
            }
        }  
    }
    
    return "TRUE"
}



### Unix & Linux
set ps_res 0
set catch_flag "OFF"

if [catch { 
    set temp [exec ps -ef | grep -v grep | grep scops_agent | wc -l]
    set ps_res $temp
    set catch_flag "OFF"
} err] {
    FD "FUNC_CHECK_BINAGENT ERROR : ef -> $err"
    set catch_flag "ON"
}

if { $catch_flag == "ON" } {
    if [catch { 
        set temp [exec ps -afe | grep -v grep | grep scops_agent | wc -l]
        set ps_res $temp
        set catch_flag "OFF"
    } err] {
        FD "FUNC_CHECK_BINAGENT ERROR : afe -> $err"
        set catch_flag "ON"
    }
}

if { $catch_flag == "ON" } {
    if [catch { 
        set temp [exec ps -ax | grep -v grep | grep scops_agent | wc -l]
        set ps_res $temp
        set catch_flag "OFF"
    } err] {
        FD "FUNC_CHECK_BINAGENT ERROR : ax -> $err"
        set catch_flag "ON"
    }
}

FD "FUNC_CHECK_BINAGENT : ps_res -> $ps_res"


if { $ps_res == 0 } {
    set g_binagentstatus "OFF"
} else {
    set g_binagentstatus "ON"
}

if { $flag == "START" } {
    if { $g_binagentstatus == "OFF" } {
        if [catch { 
            set temp [exec /usr/local1/bin/scops_agent &]
        } err] {
            set choice [ tk_messageBox -title "BIN AGENT ERROR" -icon warning -message "Start BIN AGENT Manually! \n\nProcedure to run BIN AGENT : \n/usr/local1/bin/scops_agent.sh&  " ]
        }
    }
}
}
#############################################################################
## Procedure:  FUNC_CHECK_HP93KDRIVER

proc ::FUNC_CHECK_HP93KDRIVER {} {
global widget

global g_hp93kdriverstatus

if { [catch { set TMP [exec ls -l /opt/hp93000/soc/PH_libs/GenericHandler/Delta/lib/libhfunc\.so ] } err] } {
    #set choice [ tk_messageBox -title "HP93K Driver Error" -icon warning -message "It can't find out the driver link of HP93K" ]
    set g_hp93kdriverstatus "It can't check"
} else {
    if { [string match -nocase "*->*" $TMP"] == 1 } {
        set g_hp93kdriverstatus "Changed (O)"
    } else {
        set g_hp93kdriverstatus "Changed (X)\n1. stop SMT program \n2. su \n3. /usr/local1/DRIVERS/driverchange"
    }
}
}
#############################################################################
## Procedure:  FUNC_DISPLAY_SWR

proc ::FUNC_DISPLAY_SWR {} {
global widget

global g_swrmessage

#set g_swrmessage "123"

set win_title "warning_swr"

FUNC_DISPLAY_MESSAGE "close" "$win_title" "" ""

if { $g_swrmessage == "" | $g_swrmessage == "NA" | $g_swrmessage == "1" } { return }

#           1.flag 2.title 3.height 4.width 5.top 6.left 7.bgcolor 8.fgcolor 9.thickness(line)
set config "$win_title"

#              1.directory 2.file name
set file_name [format "%s.gif" $g_swrmessage]
set file_name "image,$file_name"

#        alter message for image
#set msg {$g_swrmessage ""}

#if { $g_swrmessage == "" | $g_swrmessage == "N/A" } { return }

#FD "file_name : $file_name"

#FUNC_DISPLAY_MESSAGE $config "" [FM "K3 Engineer, Manager" $msg ""]
FUNC_DISPLAY_MESSAGE "open" $config $file_name [FM "Engineer, Manager" $g_swrmessage ""]
}
#############################################################################
## Procedure:  test1

proc ::test1 {str} {
global widget

FD "STR -> $str"
}
#############################################################################
## Procedure:  test3

proc ::test3 {} {
global widget
global tcl_platform

FD "$tcl_platform(wordSize) "
}
#############################################################################
## Procedure:  FUNC_DOWNLOAD_FILE

proc ::FUNC_DOWNLOAD_FILE {type source_file target_file} {
global widget

global g_hostname
global g_rootdir

if { $target_file == "" } {
    set target_file [file join $g_rootdir $source_file]
}


FD "FUNC_DOWNLOAD_FILE : Source -> $source_file, Target -> $target_file"


set target_file_path [file dir $target_file]
# check target directory
if { [file exist $target_file_path] != 1 } {
    if [catch {
        set tmp [file mkdir $target_file_path]
    } err] {
        FD "FUNC_DOWNLOAD_FILE : can't create target directory $target_file_path -> $err"
        return "FALSE"
    }     
}

set qry "SCOPS,GetFTP,$g_hostname*"

set res [FUNC_SEND_QRY $qry]
    
if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
    return "FALSE"
}

set port ""

set server [lindex [split $res ","] 1]
set port [lindex [split $res ","] 2]
set id [lindex [split $res ","] 3]
set pass [lindex [split $res ","] 4]

if { $port == "" } { set port 21 }

if { $server == "" || $id == "" || $pass == "" } {
    FD "FUNC_DOWNLOAD_FILE : No FTP Information -> $server, $id, $pass"
    return "FALSE"
}


if { [catch {

if {![FTP::Open $server $id $pass -port $port]} {
    FD "FUNC_DOWNLOAD_FILE : FTP Connection Fail!"
    FTP::Close
    return "FALSE"
}

if { [string match -nocase "*bin*" $type] == 1 } {
    FTP::Type binary
    FD "FUNC_DOWNLOAD_FILE : FTP Set Binary!"
}



set res [FTP::Get $source_file $target_file]
    
FTP::Close   
FD "FUNC_DOWNLOAD_FILE : FTP Close" 

} err] } {
    FTP::Close   
    FD "FUNC_DOWNLOAD_FILE : FTP Error Close" 
    return "FALSE"
}

#FD "FTP GET res : $res"

if { $res == 0 } {
    FD "FUNC_DOWNLOAD_FILE : FTP Download Fail!"
    return "FALSE"
} else {
    FD "FUNC_DOWNLOAD_FILE : FTP Download Success!"
}

return "TRUE"
}
#############################################################################
## Procedure:  FUNC_UPDATE_OS

proc ::FUNC_UPDATE_OS {} {
global widget

global tcl_platform
global g_testeros

if { [string match -nocase "*window*" $tcl_platform(platform)] == 1 } {
    set g_testeros $tcl_platform(platform)
} else {

    set g_testeros ""
}

global g_hostname
set qry "SCOPS,UpdateOS,$g_hostname,$g_testeros*"
set res ""
set res [FUNC_SEND_QRY $qry]
}
#############################################################################
## Procedure:  FUNC_GET_TESTINFORMATION

proc ::FUNC_GET_TESTINFORMATION {} {
global widget

global g_lotname
global g_dcc
global g_operation
global g_job

set qry "SCOPS,GetTestInformation,$g_lotname,$g_dcc,$g_operation,$g_job*"

set res ""
set res [FUNC_SEND_QRY $qry]
}
#############################################################################
## Procedure:  FUNC_SELECT_DEBUG_LISTBOX

proc ::FUNC_SELECT_DEBUG_LISTBOX {} {
global widget

global g_lst_debug
global g_lst_debug_msg

if { [$g_lst_debug subwidget listbox size] == 0 } {
    puts "no result!"
    return
}

set idx [$g_lst_debug subwidget listbox curselection]
set g_lst_debug_msg [$g_lst_debug subwidget listbox get $idx]
}
#############################################################################
## Procedure:  FUNC_DISPLAY_MESSAGE

proc ::FUNC_DISPLAY_MESSAGE {flag config filename msg} {
global widget

global g_toplevel_list
global g_rootdir

set title "EMPTY"
set height 250
set width 700
set bgcolor "#000000"
set fgcolor "red"
set fontsize 12
set thickness 1

#FD "msg : $msg"
#puts "msg : [llength [split $msg "\n"] ]"

set original_config_array "title height width top left bgcolor fgcolor fontsize thickness"

set config_array [split $config ","]

for { set i 0 } { $i < [llength $config_array] } { incr i } {
    if { [lindex $config_array $i] != "" } {
        set [lindex $original_config_array $i] [lindex $config_array $i]
        #puts "[lindex $original_config_array $i] : [lindex $config_array $i]"
    }
}


set window [format ".%s" $title]

# close
if { [string match -nocase "*close*" $flag] == 1 } { 
    
    #destroy $window
    
    set idx [lsearch $g_toplevel_list $title] 
    set g_toplevel_list [lreplace $g_toplevel_list $idx $idx]
    
    destroy $window
    
    return ""
}


# close the previous window to refresh
destroy $window
set idx [lsearch $g_toplevel_list $title] 
set g_toplevel_list [lreplace $g_toplevel_list $idx $idx]


#if { [winfo exists $window] == 1 } { 
#    #wm focusmodel $window active
#    FD "FUNC_DISPLAY_MESSAGE : toplevel $title already exists!" 
#    return "toplevel $title already exists!" 
#}

   
# set or download image
set filename_array [split $filename ","]


if { [llength $filename_array] > 0 } {

    set img_dir ""
    set img_name ""
    
    #check dir
    
    set tmp_dir $g_rootdir
    
    for { set i 0 } { $i < [llength $filename_array] } { incr i } {
        
        if { $i != [expr [llength $filename_array]-1] } {
        
            set img_dir [file join $img_dir [lindex $filename_array $i] ]
            set tmp_dir [file join $tmp_dir [lindex $filename_array $i] ]
        
            #puts "tmp_dir : $tmp_dir, i : $i"
        
            if { [file exists $tmp_dir] == 0 } {
        
                if { [catch {
                    set tmp [file mkdir $tmp_dir]
                } err] } {
                    FD "It can't create $tmp_dir"
                    set filename_array ""
                    break
                }
            
            }
        
        } else {
            set img_name [lindex $filename_array $i]
        }
        
    }
    
    #puts "img_dir : $img_dir"
    #puts "tmp_dir : $tmp_dir"
    #puts "img_name : $img_name"    
    
    if { $filename_array != "" } {
    
        set img_file [file join $tmp_dir $img_name]

        if { [file exists $img_file] != 1 } {
        
            set source_file [file join $img_dir $img_name]
        
            if { [FUNC_DOWNLOAD_FILE "bin" $source_file ""] != "TRUE" } {
                FD "FUNC_DISPLAY_MESSAGE : fail to download, $source_file"
                set filename_array ""
            }
        }
    }
    
    if { $filename_array != "" } {
        set img [image create photo -file $img_file]
        set height [image height $img]
        set width [image width $img]
    }  
      
}


# create new toplevel
toplevel $window -height [expr $height + 100] -width $width

set a [expr {int([winfo screenwidth .] * 0.5)}]
set b [expr {int([winfo screenheight .] * 0.5)}]
wm geometry $window [format "%sx%s+%s+%s" $width $height [expr $a - $width/2] [expr $b - $height/2]]


# create canvas
set cvs [format ".%s.%scanvas" $title $title]
canvas $cvs -height $height -width $width -background $bgcolor
pack $cvs -fill both


# set title
wm title $window $title


# put toplevel to toplevel list
if { [lsearch -exact $g_toplevel_list $title] == -1 } {
    lappend g_toplevel_list $title
}

if { [llength $filename_array] > 0 } {

    $cvs create image [expr $width/2] [expr $height/2] -anchor center -image $img
    
} else {
    
    $cvs create text [expr $width/2] [expr $height/2] -anchor center -text $msg -font "helvetica $fontsize bold" -fill $fgcolor
}
}
#############################################################################
## Procedure:  TEMPLATE_DISPLAY_MESSAGE

proc ::TEMPLATE_DISPLAY_MESSAGE {} {
global widget

set win_title "swr_warning"

FUNC_DISPLAY_MESSAGE "close" "" "" ""

#           1.flag 2.title 3.height 4.width 5.top 6.left 7.bgcolor 8.fgcolor 9.fontsize 10.thickness(line)
set config "$win_title,,,,,#EFEBEF,#ffffff,12,"

#              1.directory 2.file name
set file_name "image,[format "%s.gif" [string map {"/" ""} $g_swrmessage] ]"

#        alter message for image
set msg {"If this is 'EL/TEST', Use specific Tester/Handler!" ""}

FUNC_DISPLAY_MESSAGE "open" $config $file_name [FM "K3 Engineer, Manager" $msg ""]
}
#############################################################################
## Procedure:  FUNC_APL_T5585

proc ::FUNC_APL_T5585 {} {
global widget

global g_hostname
global tcl_platform

global g_scopsmonitor
global g_testprogram
global g_devicename
global g_incount
global g_operatorid
global g_job
global g_lotname

################################
### Format #####################
#Path : lotinfo.asc
#1.Test Program
#2.Device Name
#3.Lot
#4.In qty
#5.Operator ID
#6.Prod(0) or ENGR(1) mode
#7.Full(0) or Retest(1...N)
#8.Station Number
################################
################################


if { [string match -nocase "*adv*" $g_hostname] == 0 } { return }

if { [string match -nocase "*window*" $tcl_platform(platform)] == 1 } { return }

set apl_file "/lotinfo/lotinfo.asc"

if { [file exist $apl_file] == 1 } {
    if [catch {
        set tmp [file delete $apl_file]
    } err] {
        FD "FUNC_APL_T5585 : $err"
        
        set msg {"Fail to delete the previous APL file!newlineCheck the authority of the file or directory." ""}
        set choice [ tk_messageBox -title "ADVAN APL Error" -icon error -message [FM "K3 Engineer" $msg ""] ]
        
        return "FALSE"
    }
}

### set station number ########
set station_number ""

if { [string match -nocase "*-1*" $g_hostname] == 1 } {
    if { [string match -nocase "*Shelby*" $g_devicename] == 1 } {
        set station_number 0
    } elseif { [string match -nocase "tp*" $g_devicename] == 1 } {
        set station_number 1
    } 
}

if { [string match -nocase "*-2*" $g_hostname] == 1 } { 
    set station_number 2
}

### set fulltest or retest ####
set full_retest ""

if { [string match -nocase "*full*" $g_job] == 1 } {
    set full_retest "0"
}

if { [string match -nocase "*re*" $g_job] == 1 } {
    set full_retest [lindex [split $g_job "#"] 1]
}

### start writing APL parameters ###
if [catch {
    
    set advant5585_apl [open $apl_file w]
    
    #1.Test Program
    puts $advant5585_apl $g_testprogram
    #2.Device Name
    puts $advant5585_apl $g_devicename
    #3.Lot
    puts $advant5585_apl $g_lotname
    #4.In qty
    puts $advant5585_apl $g_incount
    #5.Operator ID
    puts $advant5585_apl $g_operatorid
    #6.Prod(0) or ENGR(1) mode
    puts $advant5585_apl 0
    #7.Full(0) or Retest(1...N)
    puts $advant5585_apl $full_retest
    #8.Station Number
    puts $advant5585_apl $station_number
    
    close $advant5585_apl
    
    set tmp [exec chmod 777 $apl_file]
    
    FD "Success to create ADVAN APL!"
    
} error ] {
    
    FD "FUNC_APL_T5585 : $err"
        
    set msg {"Fail to create APL file!" ""}
    set choice [ tk_messageBox -title "ADVAN APL Error" -icon error -message [FM "K3 Engineer" $msg ""] ]
    
    set tmp [file delete $apl_file]
    
    return "FALSE"
}

return "TRUE"
}
#############################################################################
## Procedure:  FUNC_SET_MESSAGE

proc ::FUNC_SET_MESSAGE {contact msg result} {
global widget

global g_language

set str1 ""
set str2 ""
set str3 ""

### set str1 (contact point)
if { $contact != "" } {
    set str1 "=================================   \nContact to : $contact   \n=================================   \n"
}

set str2 [string map {"newline" "\n"} $msg]

set str3 $result

return [format "%s\n%s\n\n%s" $str1 $str2 $str3]
}
#############################################################################
## Procedure:  FUNC_SEND_UDPSTRING

proc ::FUNC_SEND_UDPSTRING {} {
global widget

global tcl_platform

if { [string match -nocase "*window*" $tcl_platform(platform)] == 0 } { return }

package require udp

set server ""
set port ""
set msg ""

set server [g_ent_udp_binserver get]
set port [g_ent_udp_binport get]
set msg [g_ent_udp_binmessage get]

if { [string trim $server] == "" } { 
    set server "127.0.0.1" 
}

if { [string trim $port] == "" } { 
    set port "4000" 
}

if { [string match -nocase "*\\**" $msg] == 0 } {
    set msg [format "%s*" $msg]
}

if { [catch {

    set s [udp_open]
    fconfigure $s -remote [list $server $port]
    puts $s $msg
    FD "UDP SEND : $msg"
    close $s

} error] } { 
    close $s
    FD "FUNC_SEND_UDPSTRING : $error"
}
}
#############################################################################
## Procedure:  FUNC_SEND_TCPSTRING

proc ::FUNC_SEND_TCPSTRING {} {
global widget

global g_scopsserver

set server ""
set port ""
set msg ""

set server [g_ent_tcp_binserver get]
set port [g_ent_tcp_binport get]
set msg [g_ent_tcp_binmessage get]

if { [string trim $server] == "" } { 
    
    set server $g_scopsserver
}

if { [string trim $port] == "" } { 
    set port "10333" 
}

if { [string match -nocase "*\\**" $msg] == 0 } {
    set msg [format "%s*" $msg]
}

set res ""
if [catch { set sock [socket $server $port] } err] {

    FD "FUNC_SEND_TCPSTRING ERROR : $err"
    close $sock
    return "FALSE"
    
} else {

    puts $sock $msg
    flush $sock
    FD "TCP SEND : $msg"   

    close $sock
    
}
return "TRUE"
}
#############################################################################
## Procedure:  FUNC_SEND_TCPSTRINGRETURN

proc ::FUNC_SEND_TCPSTRINGRETURN {} {
global widget

global g_scopsserver

set server ""
set port ""
set msg ""

set server [g_ent_tcp_binserver get]
set port [g_ent_tcp_binport get]
set msg [g_ent_tcp_binmessage get]

if { [string trim $server] == "" } { 
    
    set server $g_scopsserver
}

if { [string trim $port] == "" } { 
    set port "10333" 
}

if { [string match -nocase "*\\**" $msg] == 0 } {
    set msg [format "%s*" $msg]
}

set res ""
if [catch { set sock [socket $server $port] } err] {

    FD "FUNC_SEND_TCPSTRING ERROR : $err"
    close $sock
    return "FALSE"
    
} else {

    puts $sock $msg
    flush $sock
    FD "TCP SEND : $msg"   

    while {[gets $sock line] >=0} {
        set res $line
    }

    close $sock
        
    FD "TCP RECV : $res"
    
    return "$res"
    
}
return "TRUE"
}
#############################################################################
## Procedure:  TCL_LIB_MIME

proc ::TCL_LIB_MIME {} {
global widget

# mime.tcl - MIME body parts
#
# (c) 1999-2000 Marshall T. Rose
# (c) 2000      Brent Welch
# (c) 2000      Sandeep Tamhankar
# (c) 2000      Dan Kuchler
# (c) 2000-2001 Eric Melski
# (c) 2001      Jeff Hobbs
# (c) 2001-2008 Andreas Kupries
# (c) 2002-2003 David Welton
# (c) 2003-2008 Pat Thoyts
# (c) 2005      Benjamin Riefenstahl
#
#
# See the file "license.terms" for information on usage and redistribution
# of this file, and for a DISCLAIMER OF ALL WARRANTIES.
#
# Influenced by Borenstein's/Rose's safe-tcl (circa 1993) and Darren New's
# unpublished package of 1999.
#

# new string features and inline scan are used, requiring 8.3.
package require Tcl 8.3

package provide mime 1.5.4

if {[catch {package require Trf 2.0}]} {

    # Fall-back to tcl-based procedures of base64 and quoted-printable encoders
    # Warning!
    # These are a fragile emulations of the more general calling sequence
    # that appears to work with this code here.

    package require base64 2.0
    set ::major [lindex [split [package require md5] .] 0]

    # Create these commands in the mime namespace so that they
    # won't collide with things at the global namespace level

    namespace eval ::mime {
        proc base64 {-mode what -- chunk} {
   	    return [base64::$what $chunk]
        }
        proc quoted-printable {-mode what -- chunk} {
  	    return [mime::qp_$what $chunk]
        }

	if {$::major < 2} {
	    # md5 v1, result is hex string ready for use.
	    proc md5 {-- string} {
		return [md5::md5 $string]
	    }
	} else {
	    # md5 v2, need option to get hex string
	    proc md5 {-- string} {
		return [md5::md5 -hex $string]
	    }
	}
    }

    unset ::major
}        

#
# state variables:
#
#     canonicalP: input is in its canonical form
#     content: type/subtype
#     params: seralized array of key/value pairs (keys are lower-case)
#     encoding: transfer encoding
#     version: MIME-version
#     header: serialized array of key/value pairs (keys are lower-case)
#     lowerL: list of header keys, lower-case
#     mixedL: list of header keys, mixed-case
#     value: either "file", "parts", or "string"
#
#     file: input file
#     fd: cached file-descriptor, typically for root
#     root: token for top-level part, for (distant) subordinates
#     offset: number of octets from beginning of file/string
#     count: length in octets of (encoded) content
#
#     parts: list of bodies (tokens)
#
#     string: input string
#
#     cid: last child-id assigned
#


namespace eval ::mime {
    variable mime
    array set mime { uid 0 cid 0 }

# 822 lexemes
    variable addrtokenL  [list ";"          ","          "<"          ">"          ":"          "."          "("          ")"          "@"          "\""         "\["         "\]"         "\\"]
    variable addrlexemeL [list LX_SEMICOLON LX_COMMA     LX_LBRACKET  LX_RBRACKET  LX_COLON     LX_DOT       LX_LPAREN    LX_RPAREN    LX_ATSIGN    LX_QUOTE     LX_LSQUARE   LX_RSQUARE    LX_QUOTE]

# 2045 lexemes
    variable typetokenL  [list ";"          ","          "<"          ">"          ":"          "?"          "("          ")"          "@"          "\""         "\["         "\]"         "="          "/"          "\\"]
    variable typelexemeL [list LX_SEMICOLON LX_COMMA     LX_LBRACKET  LX_RBRACKET  LX_COLON     LX_QUESTION  LX_LPAREN    LX_RPAREN    LX_ATSIGN    LX_QUOTE     LX_LSQUARE   LX_RSQUARE   LX_EQUALS    LX_SOLIDUS   LX_QUOTE]

    set encList [list  ascii US-ASCII  big5 Big5  cp1250 Windows-1250  cp1251 Windows-1251  cp1252 Windows-1252  cp1253 Windows-1253  cp1254 Windows-1254  cp1255 Windows-1255  cp1256 Windows-1256  cp1257 Windows-1257  cp1258 Windows-1258  cp437 IBM437  cp737 ""  cp775 IBM775  cp850 IBM850  cp852 IBM852  cp855 IBM855  cp857 IBM857  cp860 IBM860  cp861 IBM861  cp862 IBM862  cp863 IBM863  cp864 IBM864  cp865 IBM865  cp866 IBM866  cp869 IBM869  cp874 ""  cp932 ""  cp936 GBK  cp949 ""  cp950 ""  dingbats ""  ebcdic ""  euc-cn EUC-CN  euc-jp EUC-JP  euc-kr EUC-KR  gb12345 GB12345  gb1988 GB1988  gb2312 GB2312  iso2022 ISO-2022  iso2022-jp ISO-2022-JP  iso2022-kr ISO-2022-KR  iso8859-1 ISO-8859-1  iso8859-2 ISO-8859-2  iso8859-3 ISO-8859-3  iso8859-4 ISO-8859-4  iso8859-5 ISO-8859-5  iso8859-6 ISO-8859-6  iso8859-7 ISO-8859-7  iso8859-8 ISO-8859-8  iso8859-9 ISO-8859-9  iso8859-10 ISO-8859-10  iso8859-13 ISO-8859-13  iso8859-14 ISO-8859-14  iso8859-15 ISO-8859-15  iso8859-16 ISO-8859-16  jis0201 JIS_X0201  jis0208 JIS_C6226-1983  jis0212 JIS_X0212-1990  koi8-r KOI8-R  koi8-u KOI8-U  ksc5601 KS_C_5601-1987  macCentEuro ""  macCroatian ""  macCyrillic ""  macDingbats ""  macGreek ""  macIceland ""  macJapan ""  macRoman ""  macRomania ""  macThai ""  macTurkish ""  macUkraine ""  shiftjis Shift_JIS  symbol ""  tis-620 TIS-620  unicode ""  utf-8 UTF-8]

    variable encodings
    array set encodings $encList
    variable reversemap
    foreach {enc mimeType} $encList {
        if {$mimeType != ""} {
            set reversemap([string tolower $mimeType]) $enc
        }
    } 

    set encAliasList [list  ascii ANSI_X3.4-1968  ascii iso-ir-6  ascii ANSI_X3.4-1986  ascii ISO_646.irv:1991  ascii ASCII  ascii ISO646-US  ascii us  ascii IBM367  ascii cp367  cp437 cp437  cp437 437  cp775 cp775  cp850 cp850  cp850 850  cp852 cp852  cp852 852  cp855 cp855  cp855 855  cp857 cp857  cp857 857  cp860 cp860  cp860 860  cp861 cp861  cp861 861  cp861 cp-is  cp862 cp862  cp862 862  cp863 cp863  cp863 863  cp864 cp864  cp865 cp865  cp865 865  cp866 cp866  cp866 866  cp869 cp869  cp869 869  cp869 cp-gr  cp936 CP936  cp936 MS936  cp936 Windows-936  iso8859-1 ISO_8859-1:1987  iso8859-1 iso-ir-100  iso8859-1 ISO_8859-1  iso8859-1 latin1  iso8859-1 l1  iso8859-1 IBM819  iso8859-1 CP819  iso8859-2 ISO_8859-2:1987  iso8859-2 iso-ir-101  iso8859-2 ISO_8859-2  iso8859-2 latin2  iso8859-2 l2  iso8859-3 ISO_8859-3:1988  iso8859-3 iso-ir-109  iso8859-3 ISO_8859-3  iso8859-3 latin3  iso8859-3 l3  iso8859-4 ISO_8859-4:1988  iso8859-4 iso-ir-110  iso8859-4 ISO_8859-4  iso8859-4 latin4  iso8859-4 l4  iso8859-5 ISO_8859-5:1988  iso8859-5 iso-ir-144  iso8859-5 ISO_8859-5  iso8859-5 cyrillic  iso8859-6 ISO_8859-6:1987  iso8859-6 iso-ir-127  iso8859-6 ISO_8859-6  iso8859-6 ECMA-114  iso8859-6 ASMO-708  iso8859-6 arabic  iso8859-7 ISO_8859-7:1987  iso8859-7 iso-ir-126  iso8859-7 ISO_8859-7  iso8859-7 ELOT_928  iso8859-7 ECMA-118  iso8859-7 greek  iso8859-7 greek8  iso8859-8 ISO_8859-8:1988  iso8859-8 iso-ir-138  iso8859-8 ISO_8859-8  iso8859-8 hebrew  iso8859-9 ISO_8859-9:1989  iso8859-9 iso-ir-148  iso8859-9 ISO_8859-9  iso8859-9 latin5  iso8859-9 l5  iso8859-10 iso-ir-157  iso8859-10 l6  iso8859-10 ISO_8859-10:1992  iso8859-10 latin6  iso8859-14 iso-ir-199  iso8859-14 ISO_8859-14:1998  iso8859-14 ISO_8859-14  iso8859-14 latin8  iso8859-14 iso-celtic  iso8859-14 l8  iso8859-15 ISO_8859-15  iso8859-15 Latin-9  iso8859-16 iso-ir-226  iso8859-16 ISO_8859-16:2001  iso8859-16 ISO_8859-16  iso8859-16 latin10  iso8859-16 l10  jis0201 X0201  jis0208 iso-ir-87  jis0208 x0208  jis0208 JIS_X0208-1983  jis0212 x0212  jis0212 iso-ir-159  ksc5601 iso-ir-149  ksc5601 KS_C_5601-1989  ksc5601 KSC5601  ksc5601 korean  shiftjis MS_Kanji  utf-8 UTF8]

    foreach {enc mimeType} $encAliasList {
        set reversemap([string tolower $mimeType]) $enc
    }

    namespace export initialize finalize getproperty  getheader setheader  getbody  copymessage  mapencoding  reversemapencoding  parseaddress  parsedatetime  uniqueID
}

# ::mime::initialize --
#
#	Creates a MIME part, and returnes the MIME token for that part.
#
# Arguments:
#	args   Args can be any one of the following:
#                  ?-canonical type/subtype
#                  ?-param    {key value}?...
#                  ?-encoding value?
#                  ?-header   {key value}?... ?
#                  (-file name | -string value | -parts {token1 ... tokenN})
#
#       If the -canonical option is present, then the body is in
#       canonical (raw) form and is found by consulting either the -file,
#       -string, or -part option. 
#
#       In addition, both the -param and -header options may occur zero
#       or more times to specify "Content-Type" parameters (e.g.,
#       "charset") and header keyword/values (e.g.,
#       "Content-Disposition"), respectively. 
#
#       Also, -encoding, if present, specifies the
#       "Content-Transfer-Encoding" when copying the body.
#
#       If the -canonical option is not present, then the MIME part
#       contained in either the -file or the -string option is parsed,
#       dynamically generating subordinates as appropriate.
#
# Results:
#	An initialized mime token.

proc ::mime::initialize {args} {
    global errorCode errorInfo

    variable mime

    set token [namespace current]::[incr mime(uid)]
    # FRINK: nocheck
    variable $token
    upvar 0 $token state

    if {[set code [catch { eval [linsert $args 0 mime::initializeaux $token] }  result]]} {
        set ecode $errorCode
        set einfo $errorInfo

        catch { mime::finalize $token -subordinates dynamic }

        return -code $code -errorinfo $einfo -errorcode $ecode $result
    }

    return $token
}

# ::mime::initializeaux --
#
#	Configures the MIME token created in mime::initialize based on
#       the arguments that mime::initialize supports.
#
# Arguments:
#       token  The MIME token to configure.
#	args   Args can be any one of the following:
#                  ?-canonical type/subtype
#                  ?-param    {key value}?...
#                  ?-encoding value?
#                  ?-header   {key value}?... ?
#                  (-file name | -string value | -parts {token1 ... tokenN})
#
# Results:
#       Either configures the mime token, or throws an error.

proc ::mime::initializeaux {token args} {
    global errorCode errorInfo
    # FRINK: nocheck
    variable $token
    upvar 0 $token state

    array set params [set state(params) ""]
    set state(encoding) ""
    set state(version) "1.0"

    set state(header) ""
    set state(lowerL) ""
    set state(mixedL) ""

    set state(cid) 0

    set argc [llength $args]
    for {set argx 0} {$argx < $argc} {incr argx} {
        set option [lindex $args $argx]
        if {[incr argx] >= $argc} {
            error "missing argument to $option"
        }
	set value [lindex $args $argx]

        switch -- $option {
            -canonical {
                set state(content) [string tolower $value]
            }

            -param {
                if {[llength $value] != 2} {
                    error "-param expects a key and a value, not $value"
                }
                set lower [string tolower [set mixed [lindex $value 0]]]
                if {[info exists params($lower)]} {
                    error "the $mixed parameter may be specified at most once"
                }

                set params($lower) [lindex $value 1]
                set state(params) [array get params]
            }

            -encoding {
                switch -- [set state(encoding) [string tolower $value]] {
                    7bit - 8bit - binary - quoted-printable - base64 {
                    }

                    default {
                        error "unknown value for -encoding $state(encoding)"
                    }
                }
            }

            -header {
                if {[llength $value] != 2} {
                    error "-header expects a key and a value, not $value"
                }
                set lower [string tolower [set mixed [lindex $value 0]]]
                if {![string compare $lower content-type]} {
                    error "use -canonical instead of -header $value"
                }
                if {![string compare $lower content-transfer-encoding]} {
                    error "use -encoding instead of -header $value"
                }
                if {(![string compare $lower content-md5])  || (![string compare $lower mime-version])} {
                    error "don't go there..."
                }
                if {[lsearch -exact $state(lowerL) $lower] < 0} {
                    lappend state(lowerL) $lower
                    lappend state(mixedL) $mixed
                }               

                array set header $state(header)
                lappend header($lower) [lindex $value 1]
                set state(header) [array get header]
            }

            -file {
                set state(file) $value
            }

            -parts {
                set state(parts) $value
            }

            -string {
                set state(string) $value

		set state(lines) [split $value "\n"]
		set state(lines.count) [llength $state(lines)]
		set state(lines.current) 0
            }

            -root {
                # the following are internal options

                set state(root) $value
            }

            -offset {
                set state(offset) $value
            }

            -count {
                set state(count) $value
            }

	    -lineslist { 
		set state(lines) $value 
		set state(lines.count) [llength $state(lines)]
		set state(lines.current) 0
		#state(string) is needed, but will be built when required
		set state(string) ""
	    }

            default {
                error "unknown option $option"
            }
        }
    }

    #We only want one of -file, -parts or -string:
    set valueN 0
    foreach value [list file parts string] {
        if {[info exists state($value)]} {
            set state(value) $value
            incr valueN
        }
    }
    if {$valueN != 1 && ![info exists state(lines)]} {
        error "specify exactly one of -file, -parts, or -string"
    }

    if {[set state(canonicalP) [info exists state(content)]]} {
        switch -- $state(value) {
            file {
                set state(offset) 0
            }

            parts {
                switch -glob -- $state(content) {
                    text/*
                        -
                    image/*
                        -
                    audio/*
                        -
                    video/* {
                        error "-canonical $state(content) and -parts do not mix"
                    }
    
                    default {
                        if {[string compare $state(encoding) ""]} {
                            error "-encoding and -parts do not mix"
                        }
                    }
                }
            }
	    default {# Go ahead}
        }

        if {[lsearch -exact $state(lowerL) content-id] < 0} {
            lappend state(lowerL) content-id
            lappend state(mixedL) Content-ID

            array set header $state(header)
            lappend header(content-id) [uniqueID]
            set state(header) [array get header]
        }

        set state(version) 1.0

        return
    }

    if {[string compare $state(params) ""]} {
        error "-param requires -canonical"
    }
    if {[string compare $state(encoding) ""]} {
        error "-encoding requires -canonical"
    }
    if {[string compare $state(header) ""]} {
        error "-header requires -canonical"
    }
    if {[info exists state(parts)]} {
        error "-parts requires -canonical"
    }

    if {[set fileP [info exists state(file)]]} {
        if {[set openP [info exists state(root)]]} {
	    # FRINK: nocheck
            variable $state(root)
            upvar 0 $state(root) root

            set state(fd) $root(fd)
        } else {
            set state(root) $token
            set state(fd) [open $state(file) { RDONLY }]
            set state(offset) 0
            seek $state(fd) 0 end
            set state(count) [tell $state(fd)]

            fconfigure $state(fd) -translation binary
        }
    }

    set code [catch { mime::parsepart $token } result]
    set ecode $errorCode
    set einfo $errorInfo

    if {$fileP} {
        if {!$openP} {
            unset state(root)
            catch { close $state(fd) }
        }
        unset state(fd)
    }

    return -code $code -errorinfo $einfo -errorcode $ecode $result
}

# ::mime::parsepart --
#
#       Parses the MIME headers and attempts to break up the message
#       into its various parts, creating a MIME token for each part.
#
# Arguments:
#       token  The MIME token to parse.
#
# Results:
#       Throws an error if it has problems parsing the MIME token,
#       otherwise it just sets up the appropriate variables.

proc ::mime::parsepart {token} {
    # FRINK: nocheck
    variable $token
    upvar 0 $token state

    if {[set fileP [info exists state(file)]]} {
        seek $state(fd) [set pos $state(offset)] start
        set last [expr {$state(offset)+$state(count)-1}]
    } else {
        set string $state(string)
    }

    set vline ""
    while {1} {
        set blankP 0
        if {$fileP} {
            if {($pos > $last) || ([set x [gets $state(fd) line]] <= 0)} {
                set blankP 1
            } else {
                incr pos [expr {$x+1}]
            }
        } else {

	    if { $state(lines.current) >= $state(lines.count) } {
		set blankP 1
		set line ""
	    } else {
		set line [lindex $state(lines) $state(lines.current)]
		incr state(lines.current)
		set x [string length $line]
		if { $x == 0 } { set blankP 1 }
	    }

        }

         if {(!$blankP) && ([string last "\r" $line] == [expr {$x-1}])} {
	    
             set line [string range $line 0 [expr {$x-2}]]
             if {$x == 1} {
                 set blankP 1
             }
         }

        if {(!$blankP)  && (([string first " " $line] == 0)  || ([string first "\t" $line] == 0))} {
            append vline "\n" $line
            continue
        }      

        if {![string compare $vline ""]} {
            if {$blankP} {
                break
            }

            set vline $line
            continue
        }

        if {([set x [string first ":" $vline]] <= 0)  || (![string compare  [set mixed  [string trimright  [string range  $vline 0 [expr {$x-1}]]]]  ""])} {
            error "improper line in header: $vline"
        }
        set value [string trim [string range $vline [expr {$x+1}] end]]
        switch -- [set lower [string tolower $mixed]] {
            content-type {
                if {[info exists state(content)]} {
                    error "multiple Content-Type fields starting with $vline"
                }

                if {![catch { set x [parsetype $token $value] }]} {
                    set state(content) [lindex $x 0]
                    set state(params) [lindex $x 1]
                }
            }

            content-md5 {
            }

            content-transfer-encoding {
                if {([string compare $state(encoding) ""])  && ([string compare $state(encoding)  [string tolower $value]])} {
                    error "multiple Content-Transfer-Encoding fields starting with $vline"
                }

                set state(encoding) [string tolower $value]
            }

            mime-version {
                set state(version) $value
            }

            default {
                if {[lsearch -exact $state(lowerL) $lower] < 0} {
                    lappend state(lowerL) $lower
                    lappend state(mixedL) $mixed
                }

                array set header $state(header)
                lappend header($lower) $value
                set state(header) [array get header]
            }
        }

        if {$blankP} {
            break
        }
        set vline $line
    }

    if {![info exists state(content)]} {
        set state(content) text/plain
        set state(params) [list charset us-ascii]
    }

    if {![string match multipart/* $state(content)]} {
        if {$fileP} {
            set x [tell $state(fd)]
            incr state(count) [expr {$state(offset)-$x}]
            set state(offset) $x
        } else {
	    # rebuild string, this is cheap and needed by other functions    
	    set state(string) [join [lrange $state(lines)  $state(lines.current) end] "\n"]
        }

        if {[string match message/* $state(content)]} {
	    # FRINK: nocheck
            variable [set child $token-[incr state(cid)]]

            set state(value) parts
            set state(parts) $child
            if {$fileP} {
                mime::initializeaux $child  -file $state(file) -root $state(root)  -offset $state(offset) -count $state(count)
            } else {
		mime::initializeaux $child  -lineslist [lrange $state(lines)  $state(lines.current) end] 
            }
        }

        return
    } 

    set state(value) parts

    set boundary ""
    foreach {k v} $state(params) {
        if {![string compare $k boundary]} {
            set boundary $v
            break
        }
    }
    if {![string compare $boundary ""]} {
        error "boundary parameter is missing in $state(content)"
    }
    if {![string compare [string trim $boundary] ""]} {
        error "boundary parameter is empty in $state(content)"
    }

    if {$fileP} {
        set pos [tell $state(fd)]
	# This variable is like 'start', for the reasons laid out
	# below, in the other branch of this conditional.
	set initialpos $pos
    } else {
	# This variable is like 'start', a list of lines in the
	# part. This record is made even before we find a starting
	# boundary and used if we run into the terminating boundary
	# before a starting boundary was found. In that case the lines
	# before the terminator as recorded by tracelines are seen as
	# the part, or at least we attempt to parse them as a
	# part. See the forceoctet and nochild flags later. We cannot
	# use 'start' as that records lines only after the starting
	# boundary was found.
	set tracelines [list]
    }

    set inP 0
    set moreP 1
    set forceoctet 0
    while {$moreP} {
        if {$fileP} {
            if {$pos > $last} {
		# We have run over the end of the part per the outer
		# information without finding a terminating boundary.
		# We now fake the boundary and force the parser to
		# give any new part coming of this a mime-type of
		# application/octet-stream regardless of header
		# information.
		set line "--$boundary--"
		set x [string length $line]
		set forceoctet 1
            } else {
		if {[set x [gets $state(fd) line]] < 0} {
		    error "end-of-file encountered while parsing $state(content)"
		}
	    }
            incr pos [expr {$x+1}]
        } else {

	    if { $state(lines.current) >= $state(lines.count) } {
		error "end-of-string encountered while parsing $state(content)"
	    } else {
		set line [lindex $state(lines) $state(lines.current)]
		incr state(lines.current)
		set x [string length $line]
	    }

            set x [string length $line]
        }
        if {[string last "\r" $line] == [expr {$x-1}]} {
            set line [string range $line 0 [expr {$x-2}]]
	    set crlf 2
	} else {
	    set crlf 1
        }

        if {[string first "--$boundary" $line] != 0} {
             if {$inP && !$fileP} {
 		lappend start $line
             }

             continue
        } else {
	    lappend tracelines $line
	}

        if {!$inP} {
	    # Haven't seen the starting boundary yet. Check if the
	    # current line contains this starting boundary.

            if {[string equal $line "--$boundary"]} {
		# Yes. Switch parser state to now search for the
		# terminating boundary of the part and record where
		# the part begins (or initialize the recorder for the
		# lines in the part).
                set inP 1
                if {$fileP} {
                    set start $pos
                } else {
		    set start [list]
                }
		continue
            } elseif {[string equal $line "--$boundary--"]} {
		# We just saw a terminating boundary before we ever
		# saw the starting boundary of a part. This forces us
		# to stop parsing, we do this by forcing the parser
		# into an accepting state. We will try to create a
		# child part based on faked start position or recorded
		# lines, or, if that fails, let the current part have
		# no children.

		# As an example note the test case mime-3.7 and the
		# referenced file "badmail1.txt".

                set inP 1
                if {$fileP} {
                    set start $initialpos
                } else {
		    set start $tracelines
                }
		set forceoctet 1
		# Fall through. This brings to the creation of the new
		# part instead of searching further and possible
		# running over the end.
	    } else {
		continue
	    }
	}

	# Looking for the end of the current part. We accept both a
	# terminating boundary and the starting boundary of the next
	# part as the end of the current part.

        if {([set moreP [string compare $line "--$boundary--"]])  && ([string compare $line "--$boundary"])} {
	    # The current part has not ended, so we record the line
	    # if we are inside a part and doing string parsing.
            if {$inP && !$fileP} {
		lappend start $line
            }
            continue
        }

	# The current part has ended. We now determine the exact
	# boundaries, create a mime part object for it and recursively
	# parse it deeper as part of that action.

	# FRINK: nocheck
        variable [set child $token-[incr state(cid)]]

        lappend state(parts) $child

	set nochild 0
        if {$fileP} {
            if {[set count [expr {$pos-($start+$x+$crlf+1)}]] < 0} {
                set count 0
            }
	    if {$forceoctet} {
		set ::errorInfo {}
		if {[catch {
		    mime::initializeaux $child  -file $state(file) -root $state(root)  -offset $start -count $count
		}]} {
		    set nochild 1
		    set state(parts) [lrange $state(parts) 0 end-1]
		}
	    } else {
		mime::initializeaux $child  -file $state(file) -root $state(root)  -offset $start -count $count
	    }
	    seek $state(fd) [set start $pos] start
        } else {
	    if {$forceoctet} {
		if {[catch {
		    mime::initializeaux $child -lineslist $start
		}]} {
		    set nochild 1
		    set state(parts) [lrange $state(parts) 0 end-1]
		}
	    } else {
		mime::initializeaux $child -lineslist $start
	    }
            set start ""
        }
	if {$forceoctet && !$nochild} {
	    variable $child
	    upvar 0  $child childstate
	    set childstate(content) application/octet-stream
	}
	set forceoctet 0
    }
}

# ::mime::parsetype --
#
#       Parses the string passed in and identifies the content-type and
#       params strings.
#
# Arguments:
#       token  The MIME token to parse.
#       string The content-type string that should be parsed.
#
# Results:
#       Returns the content and params for the string as a two element
#       tcl list.

proc ::mime::parsetype {token string} {
    global errorCode errorInfo
    # FRINK: nocheck
    variable $token
    upvar 0 $token state

    variable typetokenL
    variable typelexemeL

    set state(input)   $string
    set state(buffer)  ""
    set state(lastC)   LX_END
    set state(comment) ""
    set state(tokenL)  $typetokenL
    set state(lexemeL) $typelexemeL

    set code [catch { mime::parsetypeaux $token $string } result]    
    set ecode $errorCode
    set einfo $errorInfo

    unset state(input)    state(buffer)   state(lastC)    state(comment)  state(tokenL)   state(lexemeL)

    return -code $code -errorinfo $einfo -errorcode $ecode $result
}

# ::mime::parsetypeaux --
#
#       A helper function for mime::parsetype.  Parses the specified
#       string looking for the content type and params.
#
# Arguments:
#       token  The MIME token to parse.
#       string The content-type string that should be parsed.
#
# Results:
#       Returns the content and params for the string as a two element
#       tcl list.

proc ::mime::parsetypeaux {token string} {
    # FRINK: nocheck
    variable $token
    upvar 0 $token state

    if {[string compare [parselexeme $token] LX_ATOM]} {
        error [format "expecting type (found %s)" $state(buffer)]
    }
    set type [string tolower $state(buffer)]

    switch -- [parselexeme $token] {
        LX_SOLIDUS {
        }

        LX_END {
            if {[string compare $type message]} {
                error "expecting type/subtype (found $type)"
            }

            return [list message/rfc822 ""]
        }

        default {
            error [format "expecting \"/\" (found %s)" $state(buffer)]
        }
    }

    if {[string compare [parselexeme $token] LX_ATOM]} {
        error [format "expecting subtype (found %s)" $state(buffer)]
    }
    append type [string tolower /$state(buffer)]

    array set params ""
    while {1} {
        switch -- [parselexeme $token] {
            LX_END {
                return [list $type [array get params]]
            }

            LX_SEMICOLON {
            }

            default {
                error [format "expecting \";\" (found %s)" $state(buffer)]
            }
        }

        switch -- [parselexeme $token] {
            LX_END {
                return [list $type [array get params]]
            }

            LX_ATOM {
            }

            default {
                error [format "expecting attribute (found %s)" $state(buffer)]
            }
        }

        set attribute [string tolower $state(buffer)]

        if {[string compare [parselexeme $token] LX_EQUALS]} {
            error [format "expecting \"=\" (found %s)" $state(buffer)]
        }

        switch -- [parselexeme $token] {
            LX_ATOM {
            }

            LX_QSTRING {
                set state(buffer)  [string range $state(buffer) 1  [expr {[string length $state(buffer)]-2}]]
            }

            default {
                error [format "expecting value (found %s)" $state(buffer)]
            }
        }
        set params($attribute) $state(buffer)
    }
}

# ::mime::finalize --
#
#   mime::finalize destroys a MIME part.
#
#   If the -subordinates option is present, it specifies which
#   subordinates should also be destroyed. The default value is
#   "dynamic".
#
# Arguments:
#       token  The MIME token to parse.
#       args   Args can be optionally be of the following form:
#              ?-subordinates "all" | "dynamic" | "none"?
#
# Results:
#       Returns an empty string.

proc ::mime::finalize {token args} {
    # FRINK: nocheck
    variable $token
    upvar 0 $token state

    array set options [list -subordinates dynamic]
    array set options $args

    switch -- $options(-subordinates) {
        all {
            if {![string compare $state(value) parts]} {
                foreach part $state(parts) {
                    eval [linsert $args 0 mime::finalize $part]
                }
            }
        }

        dynamic {
            for {set cid $state(cid)} {$cid > 0} {incr cid -1} {
                eval [linsert $args 0 mime::finalize $token-$cid]
            }
        }

        none {
        }

        default {
            error "unknown value for -subordinates $options(-subordinates)"
        }
    }

    foreach name [array names state] {
        unset state($name)
    }
    # FRINK: nocheck
    unset $token
}

# ::mime::getproperty --
#
#   mime::getproperty returns the properties of a MIME part.
#
#   The properties are:
#
#       property    value
#       ========    =====
#       content     the type/subtype describing the content
#       encoding    the "Content-Transfer-Encoding"
#       params      a list of "Content-Type" parameters
#       parts       a list of tokens for the part's subordinates
#       size        the approximate size of the content (unencoded)
#
#   The "parts" property is present only if the MIME part has
#   subordinates.
#
#   If mime::getproperty is invoked with the name of a specific
#   property, then the corresponding value is returned; instead, if
#   -names is specified, a list of all properties is returned;
#   otherwise, a serialized array of properties and values is returned.
#
# Arguments:
#       token      The MIME token to parse.
#       property   One of 'content', 'encoding', 'params', 'parts', and
#                  'size'. Defaults to returning a serialized array of
#                  properties and values.
#
# Results:
#       Returns the properties of a MIME part

proc ::mime::getproperty {token {property ""}} {
    # FRINK: nocheck
    variable $token
    upvar 0 $token state

    switch -- $property {
        "" {
            array set properties [list content  $state(content)  encoding $state(encoding)  params   $state(params)  size     [getsize $token]]
            if {[info exists state(parts)]} {
                set properties(parts) $state(parts)
            }

            return [array get properties]
        }

        -names {
            set names [list content encoding params]
            if {[info exists state(parts)]} {
                lappend names parts
            }

            return $names
        }

        content
            -
        encoding
            -
        params {
            return $state($property)
        }

        parts {
            if {![info exists state(parts)]} {
                error "MIME part is a leaf"
            }

            return $state(parts)
        }

        size {
            return [getsize $token]
        }

        default {
            error "unknown property $property"
        }
    }
}

# ::mime::getsize --
#
#    Determine the size (in bytes) of a MIME part/token
#
# Arguments:
#       token      The MIME token to parse.
#
# Results:
#       Returns the size in bytes of the MIME token.

proc ::mime::getsize {token} {
    # FRINK: nocheck
    variable $token
    upvar 0 $token state

    switch -- $state(value)/$state(canonicalP) {
        file/0 {
            set size $state(count)
        }

        file/1 {
            return [file size $state(file)]
        }

        parts/0
            -
        parts/1 {
            set size 0
            foreach part $state(parts) {
                incr size [getsize $part]
            }

            return $size
        }

        string/0 {
            set size [string length $state(string)]
        }

        string/1 {
            return [string length $state(string)]
        }
	default {
	    error "Unknown combination \"$state(value)/$state(canonicalP)\""
	}
    }

    if {![string compare $state(encoding) base64]} {
        set size [expr {($size*3+2)/4}]
    }

    return $size
}

# ::mime::getheader --
#
#    mime::getheader returns the header of a MIME part.
#
#    A header consists of zero or more key/value pairs. Each value is a
#    list containing one or more strings.
#
#    If mime::getheader is invoked with the name of a specific key, then
#    a list containing the corresponding value(s) is returned; instead,
#    if -names is specified, a list of all keys is returned; otherwise, a
#    serialized array of keys and values is returned. Note that when a
#    key is specified (e.g., "Subject"), the list returned usually
#    contains exactly one string; however, some keys (e.g., "Received")
#    often occur more than once in the header, accordingly the list
#    returned usually contains more than one string.
#
# Arguments:
#       token      The MIME token to parse.
#       key        Either a key or '-names'.  If it is '-names' a list
#                  of all keys is returned.
#
# Results:
#       Returns the header of a MIME part.

proc ::mime::getheader {token {key ""}} {
    # FRINK: nocheck
    variable $token
    upvar 0 $token state

    array set header $state(header)
    switch -- $key {
        "" {
            set result ""
            foreach lower $state(lowerL) mixed $state(mixedL) {
                lappend result $mixed $header($lower)
            }
            return $result
        }

        -names {
            return $state(mixedL)
        }

        default {
            set lower [string tolower [set mixed $key]]

            if {![info exists header($lower)]} {
                error "key $mixed not in header"
            }
            return $header($lower)
        }
    }
}

# ::mime::setheader --
#
#    mime::setheader writes, appends to, or deletes the value associated
#    with a key in the header.
#
#    The value for -mode is one of: 
#
#       write: the key/value is either created or overwritten (the
#       default);
#
#       append: a new value is appended for the key (creating it as
#       necessary); or,
#
#       delete: all values associated with the key are removed (the
#       "value" parameter is ignored).
#
#    Regardless, mime::setheader returns the previous value associated
#    with the key.
#
# Arguments:
#       token      The MIME token to parse.
#       key        The name of the key whose value should be set.
#       value      The value for the header key to be set to.
#       args       An optional argument of the form:
#                  ?-mode "write" | "append" | "delete"?
#
# Results:
#       Returns previous value associated with the specified key.

proc ::mime::setheader {token key value args} {
    # FRINK: nocheck
    variable $token
    upvar 0 $token state

    array set options [list -mode write]
    array set options $args

    switch -- [set lower [string tolower $key]] {
        content-md5
            -
        content-type
            -
        content-transfer-encoding
            -
        mime-version {
            error "key $key may not be set"
        }
	default {# Skip key}
    }

    array set header $state(header)
    if {[set x [lsearch -exact $state(lowerL) $lower]] < 0} {
        if {![string compare $options(-mode) delete]} {
            error "key $key not in header"
        }

        lappend state(lowerL) $lower
        lappend state(mixedL) $key

        set result ""
    } else {
        set result $header($lower)
    }
    switch -- $options(-mode) {
        append {
            lappend header($lower) $value
        }

        delete {
            unset header($lower)
            set state(lowerL) [lreplace $state(lowerL) $x $x]
            set state(mixedL) [lreplace $state(mixedL) $x $x]
        }

        write {
            set header($lower) [list $value]
        }

        default {
            error "unknown value for -mode $options(-mode)"
        }
    }

    set state(header) [array get header]

    return $result
}

# ::mime::getbody --
#
#    mime::getbody returns the body of a leaf MIME part in canonical form.
#
#    If the -command option is present, then it is repeatedly invoked
#    with a fragment of the body as this:
#
#        uplevel #0 $callback [list "data" $fragment]
#
#    (The -blocksize option, if present, specifies the maximum size of
#    each fragment passed to the callback.)
#    When the end of the body is reached, the callback is invoked as:
#
#        uplevel #0 $callback "end"
#
#    Alternatively, if an error occurs, the callback is invoked as:
#
#        uplevel #0 $callback [list "error" reason]
#
#    Regardless, the return value of the final invocation of the callback
#    is propagated upwards by mime::getbody.
#
#    If the -command option is absent, then the return value of
#    mime::getbody is a string containing the MIME part's entire body.
#
# Arguments:
#       token      The MIME token to parse.
#       args       Optional arguments of the form:
#                  ?-decode? ?-command callback ?-blocksize octets? ?
#
# Results:
#       Returns a string containing the MIME part's entire body, or
#       if '-command' is specified, the return value of the command
#       is returned.

proc ::mime::getbody {token args} {
    global errorCode errorInfo
    # FRINK: nocheck
    variable $token
    upvar 0 $token state

    set decode 0
    if {[set pos [lsearch -exact $args -decode]] >= 0} {
        set decode 1
        set args [lreplace $args $pos $pos]
    }

    array set options [list -command [list mime::getbodyaux $token]  -blocksize 4096]
    array set options $args
    if {$options(-blocksize) < 1} {
        error "-blocksize expects a positive integer, not $options(-blocksize)"
    }

    set code 0
    set ecode ""
    set einfo ""

    switch -- $state(value)/$state(canonicalP) {
        file/0 {
            set fd [open $state(file) { RDONLY }]

            set code [catch {
                fconfigure $fd -translation binary
                seek $fd [set pos $state(offset)] start
                set last [expr {$state(offset)+$state(count)-1}]

                set fragment ""
                while {$pos <= $last} {
                    if {[set cc [expr {($last-$pos)+1}]]  > $options(-blocksize)} {
                        set cc $options(-blocksize)
                    }
                    incr pos [set len  [string length [set chunk [read $fd $cc]]]]
                    switch -exact -- $state(encoding) {
                        base64
                            -
                        quoted-printable {
                            if {([set x [string last "\n" $chunk]] > 0)  && ($x+1 != $len)} {
                                set chunk [string range $chunk 0 $x]
                                seek $fd [incr pos [expr {($x+1)-$len}]] start
                            }
                            set chunk [$state(encoding) -mode decode  -- $chunk]
                        }
			7bit - 8bit - binary - "" {
			    # Bugfix for [#477088]
			    # Go ahead, leave chunk alone
			}
			default {
			    error "Can't handle content encoding \"$state(encoding)\""
			}
                    }
                    append fragment $chunk

                    set cc [expr {$options(-blocksize)-1}]
                    while {[string length $fragment] > $options(-blocksize)} {
                        uplevel #0 $options(-command)  [list data  [string range $fragment 0 $cc]]

                        set fragment [string range  $fragment $options(-blocksize)  end]
                    }
                }
                if {[string length $fragment] > 0} {
                    uplevel #0 $options(-command) [list data $fragment]
                }
            } result]
            set ecode $errorCode
            set einfo $errorInfo

            catch { close $fd }
        }

        file/1 {
            set fd [open $state(file) { RDONLY }]

            set code [catch {
                fconfigure $fd -translation binary

                while {[string length  [set fragment  [read $fd $options(-blocksize)]]] > 0} {
                    uplevel #0 $options(-command) [list data $fragment]
                }
            } result]
            set ecode $errorCode
            set einfo $errorInfo

            catch { close $fd }
        }

        parts/0
            -
        parts/1 {
            error "MIME part isn't a leaf"
        }

        string/0
            -
        string/1 {
            switch -- $state(encoding)/$state(canonicalP) {
                base64/0
                    -
                quoted-printable/0 {
                    set fragment [$state(encoding) -mode decode  -- $state(string)]
                }

                default {
		    # Not a bugfix for [#477088], but clarification
		    # This handles no-encoding, 7bit, 8bit, and binary.
                    set fragment $state(string)
                }
            }

            set code [catch {
                set cc [expr {$options(-blocksize)-1}]
                while {[string length $fragment] > $options(-blocksize)} {
                    uplevel #0 $options(-command)  [list data [string range $fragment 0 $cc]]

                    set fragment [string range $fragment  $options(-blocksize) end]
                }
                if {[string length $fragment] > 0} {
                    uplevel #0 $options(-command) [list data $fragment]
                }
            } result]
            set ecode $errorCode
            set einfo $errorInfo
	}
	default {
	    error "Unknown combination \"$state(value)/$state(canonicalP)\""
	}
    }

    set code [catch {
        if {$code} {
            uplevel #0 $options(-command) [list error $result]
        } else {
            uplevel #0 $options(-command) [list end]
        }
    } result]
    set ecode $errorCode
    set einfo $errorInfo    

    if {$code} {
        return -code $code -errorinfo $einfo -errorcode $ecode $result
    }

    if {$decode} {
        array set params [mime::getproperty $token params]

        if {[info exists params(charset)]} {
            set charset $params(charset)
        } else {
            set charset US-ASCII
        }

        set enc [reversemapencoding $charset]
        if {$enc != ""} {
            set result [::encoding convertfrom $enc $result]
        } else {
            return -code error "-decode failed: can't reversemap charset $charset"
        }
    }

    return $result
}

# ::mime::getbodyaux --
#
#    Builds up the body of the message, fragment by fragment.  When
#    the entire message has been retrieved, it is returned.
#
# Arguments:
#       token      The MIME token to parse.
#       reason     One of 'data', 'end', or 'error'.
#       fragment   The section of data data fragment to extract a
#                  string from.
#
# Results:
#       Returns nothing, except when called with the 'end' argument
#       in which case it returns a string that contains all of the
#       data that 'getbodyaux' has been called with.  Will throw an
#       error if it is called with the reason of 'error'.

proc ::mime::getbodyaux {token reason {fragment ""}} {
    # FRINK: nocheck
    variable $token
    upvar 0 $token state

    switch -- $reason {
        data {
            append state(getbody) $fragment
	    return ""
        }

        end {
            if {[info exists state(getbody)]} {
                set result $state(getbody)
                unset state(getbody)
            } else {
                set result ""
            }

            return $result
        }

        error {
            catch { unset state(getbody) }
            error $reason
        }

	default {
	    error "Unknown reason \"$reason\""
	}
    }
}

# ::mime::copymessage --
#
#    mime::copymessage copies the MIME part to the specified channel.
#
#    mime::copymessage operates synchronously, and uses fileevent to
#    allow asynchronous operations to proceed independently.
#
# Arguments:
#       token      The MIME token to parse.
#       channel    The channel to copy the message to.
#
# Results:
#       Returns nothing unless an error is thrown while the message
#       is being written to the channel.

proc ::mime::copymessage {token channel} {
    global errorCode errorInfo
    # FRINK: nocheck
    variable $token
    upvar 0 $token state

    set openP [info exists state(fd)]

    set code [catch { mime::copymessageaux $token $channel } result]
    set ecode $errorCode
    set einfo $errorInfo

    if {(!$openP) && ([info exists state(fd)])} {
        if {![info exists state(root)]} {
            catch { close $state(fd) }
        }
        unset state(fd)
    }

    return -code $code -errorinfo $einfo -errorcode $ecode $result
}

# ::mime::copymessageaux --
#
#    mime::copymessageaux copies the MIME part to the specified channel.
#
# Arguments:
#       token      The MIME token to parse.
#       channel    The channel to copy the message to.
#
# Results:
#       Returns nothing unless an error is thrown while the message
#       is being written to the channel.

proc ::mime::copymessageaux {token channel} {
    # FRINK: nocheck
    variable $token
    upvar 0 $token state

    array set header $state(header)

    if {[string compare $state(version) ""]} {
        puts $channel "MIME-Version: $state(version)"
    }
    foreach lower $state(lowerL) mixed $state(mixedL) {
        foreach value $header($lower) {
            puts $channel "$mixed: $value"
        }
    }
    if {(!$state(canonicalP))  && ([string compare [set encoding $state(encoding)] ""])} {
        puts $channel "Content-Transfer-Encoding: $encoding"
    }

    puts -nonewline $channel "Content-Type: $state(content)"
    set boundary ""
    foreach {k v} $state(params) {
        if {![string compare $k boundary]} {
            set boundary $v
        }

        puts -nonewline $channel ";\n              $k=\"$v\""
    }

    set converter ""
    set encoding ""
    if {[string compare $state(value) parts]} {
        puts $channel ""

        if {$state(canonicalP)} {
            if {![string compare [set encoding $state(encoding)] ""]} {
                set encoding [encoding $token]
            }
            if {[string compare $encoding ""]} {
                puts $channel "Content-Transfer-Encoding: $encoding"
            }
            switch -- $encoding {
                base64
                    -
                quoted-printable {
                    set converter $encoding
                }
		7bit - 8bit - binary - "" {
		    # Bugfix for [#477088], also [#539952]
		    # Go ahead
		}
		default {
		    error "Can't handle content encoding \"$encoding\""
		}
            }
        }
    } elseif {([string match multipart/* $state(content)])  && (![string compare $boundary ""])} {
	# we're doing everything in one pass...
        set key [clock seconds]$token[info hostname][array get state]
        set seqno 8
        while {[incr seqno -1] >= 0} {
            set key [md5 -- $key]
        }
        set boundary "----- =_[string trim [base64 -mode encode -- $key]]"

        puts $channel ";\n              boundary=\"$boundary\""
    } else {
        puts $channel ""
    }

    if {[info exists state(error)]} {
        unset state(error)
    }

    switch -- $state(value) {
        file {
            set closeP 1
            if {[info exists state(root)]} {
		# FRINK: nocheck
                variable $state(root)
                upvar 0 $state(root) root 

                if {[info exists root(fd)]} {
                    set fd $root(fd)
                    set closeP 0
                } else {
                    set fd [set state(fd)  [open $state(file) { RDONLY }]]
                }
                set size $state(count)
            } else {
                set fd [set state(fd) [open $state(file) { RDONLY }]]
		# read until eof
                set size -1
            }
            seek $fd $state(offset) start
            if {$closeP} {
                fconfigure $fd -translation binary
            }

            puts $channel ""

	    while {($size != 0) && (![eof $fd])} {
		if {$size < 0 || $size > 32766} {
		    set X [read $fd 32766]
		} else {
		    set X [read $fd $size]
		}
		if {$size > 0} {
		    set size [expr {$size - [string length $X]}]
		}
		if {[string compare $converter ""]} {
		    puts -nonewline $channel [$converter -mode encode -- $X]
		} else {
		    puts -nonewline $channel $X
		}
	    }

            if {$closeP} {
                catch { close $state(fd) }
                unset state(fd)
            }
        }

        parts {
            if {(![info exists state(root)])  && ([info exists state(file)])} {
                set state(fd) [open $state(file) { RDONLY }]
                fconfigure $state(fd) -translation binary
            }

            switch -glob -- $state(content) {
                message/* {
                    puts $channel ""
                    foreach part $state(parts) {
                        mime::copymessage $part $channel
                        break
                    }
                }

                default {
		    # Note RFC 2046: See buildmessageaux for details.

                    foreach part $state(parts) {
                        puts $channel "\n--$boundary"
                        mime::copymessage $part $channel
                    }
                    puts $channel "\n--$boundary--"
                }
            }

            if {[info exists state(fd)]} {
                catch { close $state(fd) }
                unset state(fd)
            }
        }

        string {
            if {[catch { fconfigure $channel -buffersize } blocksize]} {
                set blocksize 4096
            } elseif {$blocksize < 512} {
                set blocksize 512
            }
            set blocksize [expr {($blocksize/4)*3}]

	    # [893516]
	    fconfigure $channel -buffersize $blocksize

            puts $channel ""

            if {[string compare $converter ""]} {
                puts -nonewline $channel [$converter -mode encode -- $state(string)]
            } else {
		puts -nonewline $channel $state(string)
	    }
        }
	default {
	    error "Unknown value \"$state(value)\""
	}
    }

    flush $channel

    if {[info exists state(error)]} {
        error $state(error)
    }
}

# ::mime::buildmessage --
#
#     The following is a clone of the copymessage code to build up the
#     result in memory, and, unfortunately, without using a memory channel.
#     I considered parameterizing the "puts" calls in copy message, but
#     the need for this procedure may go away, so I'm living with it for
#     the moment.
#
# Arguments:
#       token      The MIME token to parse.
#
# Results:
#       Returns the message that has been built up in memory.

proc ::mime::buildmessage {token} {
    global errorCode errorInfo
    # FRINK: nocheck
    variable $token
    upvar 0 $token state

    set openP [info exists state(fd)]

    set code [catch { mime::buildmessageaux $token } result]
    set ecode $errorCode
    set einfo $errorInfo

    if {(!$openP) && ([info exists state(fd)])} {
        if {![info exists state(root)]} {
            catch { close $state(fd) }
        }
        unset state(fd)
    }

    return -code $code -errorinfo $einfo -errorcode $ecode $result
}

# ::mime::buildmessageaux --
#
#     The following is a clone of the copymessageaux code to build up the
#     result in memory, and, unfortunately, without using a memory channel.
#     I considered parameterizing the "puts" calls in copy message, but
#     the need for this procedure may go away, so I'm living with it for
#     the moment.
#
# Arguments:
#       token      The MIME token to parse.
#
# Results:
#       Returns the message that has been built up in memory.

proc ::mime::buildmessageaux {token} {
    # FRINK: nocheck
    variable $token
    upvar 0 $token state

    array set header $state(header)

    set result ""
    if {[string compare $state(version) ""]} {
        append result "MIME-Version: $state(version)\r\n"
    }
    foreach lower $state(lowerL) mixed $state(mixedL) {
        foreach value $header($lower) {
            append result "$mixed: $value\r\n"
        }
    }
    if {(!$state(canonicalP))  && ([string compare [set encoding $state(encoding)] ""])} {
        append result "Content-Transfer-Encoding: $encoding\r\n"
    }

    append result "Content-Type: $state(content)"
    set boundary ""
    foreach {k v} $state(params) {
        if {![string compare $k boundary]} {
            set boundary $v
        }

        append result ";\r\n              $k=\"$v\""
    }

    set converter ""
    set encoding ""
    if {[string compare $state(value) parts]} {
        append result \r\n

        if {$state(canonicalP)} {
            if {![string compare [set encoding $state(encoding)] ""]} {
                set encoding [encoding $token]
            }
            if {[string compare $encoding ""]} {
                append result "Content-Transfer-Encoding: $encoding\r\n"
            }
            switch -- $encoding {
                base64
                    -
                quoted-printable {
                    set converter $encoding
                }
		7bit - 8bit - binary - "" {
		    # Bugfix for [#477088]
		    # Go ahead
		}
		default {
		    error "Can't handle content encoding \"$encoding\""
		}
            }
        }
    } elseif {([string match multipart/* $state(content)])  && (![string compare $boundary ""])} {
# we're doing everything in one pass...
        set key [clock seconds]$token[info hostname][array get state]
        set seqno 8
        while {[incr seqno -1] >= 0} {
            set key [md5 -- $key]
        }
        set boundary "----- =_[string trim [base64 -mode encode -- $key]]"

        append result ";\r\n              boundary=\"$boundary\"\r\n"
    } else {
        append result "\r\n"
    }

    if {[info exists state(error)]} {
        unset state(error)
    }
                
    switch -- $state(value) {
        file {
            set closeP 1
            if {[info exists state(root)]} {
		# FRINK: nocheck
                variable $state(root)
                upvar 0 $state(root) root 

                if {[info exists root(fd)]} {
                    set fd $root(fd)
                    set closeP 0
                } else {
                    set fd [set state(fd)  [open $state(file) { RDONLY }]]
                }
                set size $state(count)
            } else {
                set fd [set state(fd) [open $state(file) { RDONLY }]]
                set size -1	;# Read until EOF
            }
            seek $fd $state(offset) start
            if {$closeP} {
                fconfigure $fd -translation binary
            }

            append result "\r\n"

	    while {($size != 0) && (![eof $fd])} {
		if {$size < 0 || $size > 32766} {
		    set X [read $fd 32766]
		} else {
		    set X [read $fd $size]
		}
		if {$size > 0} {
		    set size [expr {$size - [string length $X]}]
		}
		if {[string compare $converter ""]} {
		    append result [$converter -mode encode -- $X]
		} else {
		    append result $X
		}
	    }

            if {$closeP} {
                catch { close $state(fd) }
                unset state(fd)
            }
        }

        parts {
            if {(![info exists state(root)])  && ([info exists state(file)])} {
                set state(fd) [open $state(file) { RDONLY }]
                fconfigure $state(fd) -translation binary
            }

            switch -glob -- $state(content) {
                message/* {
                    append result "\r\n"
                    foreach part $state(parts) {
                        append result [buildmessage $part]
                        break
                    }
                }

                default {
		    # Note RFC 2046:
		    #
		    # The boundary delimiter MUST occur at the
		    # beginning of a line, i.e., following a CRLF, and
		    # the initial CRLF is considered to be attached to
		    # the boundary delimiter line rather than part of
		    # the preceding part.
		    #
		    # - The above means that the CRLF before $boundary
		    #   is needed per the RFC, and the parts must not
		    #   have a closing CRLF of their own. See Tcllib bug
		    #   1213527, and patch 1254934 for the problems when
		    #   both file/string brnaches added CRLF after the
		    #   body parts.

                    foreach part $state(parts) {
                        append result "\r\n--$boundary\r\n"
                        append result [buildmessage $part]
                    }
                    append result "\r\n--$boundary--\r\n"
                }
            }

            if {[info exists state(fd)]} {
                catch { close $state(fd) }
                unset state(fd)
            }
        }

        string {
            append result "\r\n"

	    if {[string compare $converter ""]} {
		append result [$converter -mode encode -- $state(string)]
	    } else {
		append result $state(string)
	    }
        }
	default {
	    error "Unknown value \"$state(value)\""
	}
    }

    if {[info exists state(error)]} {
        error $state(error)
    }
    return $result
}

# ::mime::encoding --
#
#     Determines how a token is encoded.
#
# Arguments:
#       token      The MIME token to parse.
#
# Results:
#       Returns the encoding of the message (the null string, base64,
#       or quoted-printable).

proc ::mime::encoding {token} {
    # FRINK: nocheck
    variable $token
    upvar 0 $token state

    switch -glob -- $state(content) {
        audio/*
            -
        image/*
            -
        video/* {
            return base64
        }

        message/*
            -
        multipart/* {
            return ""
        }
	default {# Skip}
    }

    set asciiP 1
    set lineP 1
    switch -- $state(value) {
        file {
            set fd [open $state(file) { RDONLY }]
            fconfigure $fd -translation binary

            while {[gets $fd line] >= 0} {
                if {$asciiP} {
                    set asciiP [encodingasciiP $line]
                }
                if {$lineP} {
                    set lineP [encodinglineP $line]
                }
                if {(!$asciiP) && (!$lineP)} {
                    break
                }
            }

            catch { close $fd }
        }

        parts {
            return ""
        }

        string {
            foreach line [split $state(string) "\n"] {
                if {$asciiP} {
                    set asciiP [encodingasciiP $line]
                }
                if {$lineP} {
                    set lineP [encodinglineP $line]
                }
                if {(!$asciiP) && (!$lineP)} {
                    break
                }
            }
        }
	default {
	    error "Unknown value \"$state(value)\""
	}
    }

    switch -glob -- $state(content) {
        text/* {
            if {!$asciiP} {
                foreach {k v} $state(params) {
                    if {![string compare $k charset]} {
                        set v [string tolower $v]
                        if {([string compare $v us-ascii])  && (![string match {iso-8859-[1-8]} $v])} {
                            return base64
                        }

                        break
                    }
                }
            }

            if {!$lineP} {
                return quoted-printable
            }
        }

        
        default {
            if {(!$asciiP) || (!$lineP)} {
                return base64
            }
        }
    }

    return ""
}

# ::mime::encodingasciiP --
#
#     Checks if a string is a pure ascii string, or if it has a non-standard
#     form.
#
# Arguments:
#       line    The line to check.
#
# Results:
#       Returns 1 if \r only occurs at the end of lines, and if all
#       characters in the line are between the ASCII codes of 32 and 126.

proc ::mime::encodingasciiP {line} {
    foreach c [split $line ""] {
        switch -- $c {
            " " - "\t" - "\r" - "\n" {
            }

            default {
                binary scan $c c c
                if {($c < 32) || ($c > 126)} {
                    return 0
                }
            }
        }
    }
    if {([set r [string first "\r" $line]] < 0)  || ($r == [expr {[string length $line]-1}])} {
        return 1
    }

    return 0
}

# ::mime::encodinglineP --
#
#     Checks if a string is a line is valid to be processed.
#
# Arguments:
#       line    The line to check.
#
# Results:
#       Returns 1 the line is less than 76 characters long, the line
#       contains more characters than just whitespace, the line does
#       not start with a '.', and the line does not start with 'From '.

proc ::mime::encodinglineP {line} {
    if {([string length $line] > 76)  || ([string compare $line [string trimright $line]])  || ([string first . $line] == 0)  || ([string first "From " $line] == 0)} {
        return 0
    }

    return 1
}

# ::mime::fcopy --
#
#	Appears to be unused.
#
# Arguments:
#
# Results:
# 

proc ::mime::fcopy {token count {error ""}} {
    # FRINK: nocheck
    variable $token
    upvar 0 $token state

    if {[string compare $error ""]} {
        set state(error) $error
    }
    set state(doneP) 1
}

# ::mime::scopy --
#
#	Copy a portion of the contents of a mime token to a channel.
#
# Arguments:
#	token     The token containing the data to copy.
#       channel   The channel to write the data to.
#       offset    The location in the string to start copying
#                 from.
#       len       The amount of data to write.
#       blocksize The block size for the write operation.
#
# Results:
#	The specified portion of the string in the mime token is
#       copied to the specified channel.

proc ::mime::scopy {token channel offset len blocksize} {
    # FRINK: nocheck
    variable $token
    upvar 0 $token state

    if {$len <= 0} {
        set state(doneP) 1
        fileevent $channel writable ""
        return
    }

    if {[set cc $len] > $blocksize} {
        set cc $blocksize
    }

    if {[catch { puts -nonewline $channel  [string range $state(string) $offset  [expr {$offset+$cc-1}]]
                 fileevent $channel writable  [list mime::scopy $token $channel  [incr offset $cc]  [incr len -$cc]  $blocksize]
               } result]} {
        set state(error) $result
        set state(doneP) 1
        fileevent $channel writable ""
    }
    return
}

# ::mime::qp_encode --
#
#	Tcl version of quote-printable encode
#
# Arguments:
#	string        The string to quote.
#       encoded_word  Boolean value to determine whether or not encoded words
#                     (RFC 2047) should be handled or not. (optional)
#
# Results:
#	The properly quoted string is returned.

proc ::mime::qp_encode {string {encoded_word 0} {no_softbreak 0}} {
    # 8.1+ improved string manipulation routines used.
    # Replace outlying characters, characters that would normally
    # be munged by EBCDIC gateways, and special Tcl characters "[\]{}
    # with =xx sequence

    regsub -all --  {[\x00-\x08\x0B-\x1E\x21-\x24\x3D\x40\x5B-\x5E\x60\x7B-\xFF]}  $string {[format =%02X [scan "\\&" %c]]} string

    # Replace the format commands with their result

    set string [subst -novariable $string]

    # soft/hard newlines and other
    # Funky cases for SMTP compatibility
    set mapChars [list " \n" "=20\n" "\t\n" "=09\n"  "\n\.\n" "\n=2E\n" "\nFrom " "\n=46rom "]
    if {$encoded_word} {
	# Special processing for encoded words (RFC 2047)
	lappend mapChars " " "_"
    }
    set string [string map $mapChars $string]

    # Break long lines - ugh

    # Implementation of FR #503336
    if {$no_softbreak} {
	set result $string
    } else {
	set result ""
	foreach line [split $string \n] {
	    while {[string length $line] > 72} {
		set chunk [string range $line 0 72]
		if {[regexp -- (=|=.)$ $chunk dummy end]} {
		    
		    # Don't break in the middle of a code

		    set len [expr {72 - [string length $end]}]
		    set chunk [string range $line 0 $len]
		    incr len
		    set line [string range $line $len end]
		} else {
		    set line [string range $line 73 end]
		}
		append result $chunk=\n
	    }
	    append result $line\n
	}
    
	# Trim off last \n, since the above code has the side-effect
	# of adding an extra \n to the encoded string and return the
	# result.
	set result [string range $result 0 end-1]
    }

    # If the string ends in space or tab, replace with =xx

    set lastChar [string index $result end]
    if {$lastChar==" "} {
	set result [string replace $result end end "=20"]
    } elseif {$lastChar=="\t"} {
	set result [string replace $result end end "=09"]
    }

    return $result
}

# ::mime::qp_decode --
#
#	Tcl version of quote-printable decode
#
# Arguments:
#	string        The quoted-prinatble string to decode.
#       encoded_word  Boolean value to determine whether or not encoded words
#                     (RFC 2047) should be handled or not. (optional)
#
# Results:
#	The decoded string is returned.

proc ::mime::qp_decode {string {encoded_word 0}} {
    # 8.1+ improved string manipulation routines used.
    # Special processing for encoded words (RFC 2047)

    if {$encoded_word} {
	# _ == \x20, even if SPACE occupies a different code position
	set string [string map [list _ \u0020] $string]
    }

    # smash the white-space at the ends of lines since that must've been
    # generated by an MUA.

    regsub -all -- {[ \t]+\n} $string "\n" string
    set string [string trimright $string " \t"]

    # Protect the backslash for later subst and
    # smash soft newlines, has to occur after white-space smash
    # and any encoded word modification.

    set string [string map [list "\\" "\\\\" "=\n" ""] $string]

    # Decode specials

    regsub -all -nocase {=([a-f0-9][a-f0-9])} $string {\\u00\1} string

    # process \u unicode mapped chars

    return [subst -novar -nocommand $string]
}

# ::mime::parseaddress --
#
#       This was originally written circa 1982 in C. we're still using it
#       because it recognizes virtually every buggy address syntax ever
#       generated!
#
#       mime::parseaddress takes a string containing one or more 822-style
#       address specifications and returns a list of serialized arrays, one
#       element for each address specified in the argument.
#
#    Each serialized array contains these properties:
#
#       property    value
#       ========    =====
#       address     local@domain
#       comment     822-style comment
#       domain      the domain part (rhs)
#       error       non-empty on a parse error
#       group       this address begins a group
#       friendly    user-friendly rendering
#       local       the local part (lhs)
#       memberP     this address belongs to a group
#       phrase      the phrase part
#       proper      822-style address specification
#       route       822-style route specification (obsolete)
#
#    Note that one or more of these properties may be empty.
#
# Arguments:
#	string        The address string to parse
#
# Results:
#	Returns a list of serialized arrays, one element for each address
#       specified in the argument.

proc ::mime::parseaddress {string} {
    global errorCode errorInfo

    variable mime

    set token [namespace current]::[incr mime(uid)]
    # FRINK: nocheck
    variable $token
    upvar 0 $token state

    set code [catch { mime::parseaddressaux $token $string } result]
    set ecode $errorCode
    set einfo $errorInfo

    foreach name [array names state] {
        unset state($name)
    }
    # FRINK: nocheck
    catch { unset $token }

    return -code $code -errorinfo $einfo -errorcode $ecode $result
}

# ::mime::parseaddressaux --
#
#       This was originally written circa 1982 in C. we're still using it
#       because it recognizes virtually every buggy address syntax ever
#       generated!
#
#       mime::parseaddressaux does the actually parsing for mime::parseaddress
#
#    Each serialized array contains these properties:
#
#       property    value
#       ========    =====
#       address     local@domain
#       comment     822-style comment
#       domain      the domain part (rhs)
#       error       non-empty on a parse error
#       group       this address begins a group
#       friendly    user-friendly rendering
#       local       the local part (lhs)
#       memberP     this address belongs to a group
#       phrase      the phrase part
#       proper      822-style address specification
#       route       822-style route specification (obsolete)
#
#    Note that one or more of these properties may be empty.
#
# Arguments:
#       token         The MIME token to work from.
#	string        The address string to parse
#
# Results:
#	Returns a list of serialized arrays, one element for each address
#       specified in the argument.

proc ::mime::parseaddressaux {token string} {
    # FRINK: nocheck
    variable $token
    upvar 0 $token state

    variable addrtokenL
    variable addrlexemeL

    set state(input)   $string
    set state(glevel)  0
    set state(buffer)  ""
    set state(lastC)   LX_END
    set state(tokenL)  $addrtokenL
    set state(lexemeL) $addrlexemeL

    set result ""
    while {[addr_next $token]} {
        if {[string compare [set tail $state(domain)] ""]} {
            set tail @$state(domain)
        } else {
            set tail @[info hostname]
        }
        if {[string compare [set address $state(local)] ""]} {
            append address $tail
        }

        if {[string compare $state(phrase) ""]} {
            set state(phrase) [string trim $state(phrase) "\""]
            foreach t $state(tokenL) {
                if {[string first $t $state(phrase)] >= 0} {
                    set state(phrase) \"$state(phrase)\"
                    break
                }
            }

            set proper "$state(phrase) <$address>"
        } else {
            set proper $address
        }

        if {![string compare [set friendly $state(phrase)] ""]} {
            if {[string compare [set note $state(comment)] ""]} {
                if {[string first "(" $note] == 0} {
                    set note [string trimleft [string range $note 1 end]]
                }
                if {[string last ")" $note]  == [set len [expr {[string length $note]-1}]]} {
                    set note [string range $note 0 [expr {$len-1}]]
                }
                set friendly $note
            }

            if {(![string compare $friendly ""])  && ([string compare [set mbox $state(local)] ""])} {
                set mbox [string trim $mbox "\""]

                if {[string first "/" $mbox] != 0} {
                    set friendly $mbox
                } elseif {[string compare  [set friendly [addr_x400 $mbox PN]]  ""]} {
                } elseif {([string compare  [set friendly [addr_x400 $mbox S]]  ""])  && ([string compare  [set g [addr_x400 $mbox G]]  ""])} {
                    set friendly "$g $friendly"
                }

                if {![string compare $friendly ""]} {
                    set friendly $mbox
                }
            }
        }
        set friendly [string trim $friendly "\""]

        lappend result [list address  $address         comment  $state(comment)  domain   $state(domain)   error    $state(error)    friendly $friendly        group    $state(group)    local    $state(local)    memberP  $state(memberP)  phrase   $state(phrase)   proper   $proper          route    $state(route)]

    }

    unset state(input)    state(glevel)   state(buffer)   state(lastC)    state(tokenL)   state(lexemeL)

    return $result
}

# ::mime::addr_next --
#
#       Locate the next address in a mime token.
#
# Arguments:
#       token         The MIME token to work from.
#
# Results:
#	Returns 1 if there is another address, and 0 if there is not.

proc ::mime::addr_next {token} {
    global errorCode errorInfo
    # FRINK: nocheck
    variable $token
    upvar 0 $token state
    set nocomplain [package vsatisfies [package provide Tcl] 8.4]
    foreach prop {comment domain error group local memberP phrase route} {
        if {$nocomplain} {
            unset -nocomplain state($prop)
        } else {
            if {[catch { unset state($prop) }]} { set ::errorInfo {} }
        }
    }

    switch -- [set code [catch { mime::addr_specification $token } result]] {
        0 {
            if {!$result} {
                return 0
            }

            switch -- $state(lastC) {
                LX_COMMA
                    -
                LX_END {
                }
                default {
                    # catch trailing comments...
                    set lookahead $state(input)
                    mime::parselexeme $token
                    set state(input) $lookahead
                }
            }
        }

        7 {
            set state(error) $result

            while {1} {
                switch -- $state(lastC) {
                    LX_COMMA
                        -
                    LX_END {
                        break
                    }

                    default {
                        mime::parselexeme $token
                    }
                }
            }
        }

        default {
            set ecode $errorCode
            set einfo $errorInfo

            return -code $code -errorinfo $einfo -errorcode $ecode $result
        }
    }

    foreach prop {comment domain error group local memberP phrase route} {
        if {![info exists state($prop)]} {
            set state($prop) ""
        }
    }

    return 1
}

# ::mime::addr_specification --
#
#   Uses lookahead parsing to determine whether there is another
#   valid e-mail address or not.  Throws errors if unrecognized
#   or invalid e-mail address syntax is used.
#
# Arguments:
#       token         The MIME token to work from.
#
# Results:
#	Returns 1 if there is another address, and 0 if there is not.

proc ::mime::addr_specification {token} {
    # FRINK: nocheck
    variable $token
    upvar 0 $token state

    set lookahead $state(input)
    switch -- [parselexeme $token] {
        LX_ATOM
            -
        LX_QSTRING {
            set state(phrase) $state(buffer)
        }

        LX_SEMICOLON {
            if {[incr state(glevel) -1] < 0} {
                return -code 7 "extraneous semi-colon"
            }

            catch { unset state(comment) }
            return [addr_specification $token]
        }

        LX_COMMA {
            catch { unset state(comment) }
            return [addr_specification $token]
        }

        LX_END {
            return 0
        }

        LX_LBRACKET {
            return [addr_routeaddr $token]
        }

        LX_ATSIGN {
            set state(input) $lookahead
            return [addr_routeaddr $token 0]
        }

        default {
            return -code 7  [format "unexpected character at beginning (found %s)"  $state(buffer)]
        }
    }

    switch -- [parselexeme $token] {
        LX_ATOM
            -
        LX_QSTRING {
            append state(phrase) " " $state(buffer)

            return [addr_phrase $token]
        }

        LX_LBRACKET {
            return [addr_routeaddr $token]
        }

        LX_COLON {
            return [addr_group $token]
        }

        LX_DOT {
            set state(local) "$state(phrase)$state(buffer)"
            unset state(phrase)
            mime::addr_routeaddr $token 0
            mime::addr_end $token
        }

        LX_ATSIGN {
            set state(memberP) $state(glevel)
            set state(local) $state(phrase)
            unset state(phrase)
            mime::addr_domain $token
            mime::addr_end $token
        }

        LX_SEMICOLON
            -
        LX_COMMA
            -
        LX_END {
            set state(memberP) $state(glevel)
            if {(![string compare $state(lastC) LX_SEMICOLON])  && ([incr state(glevel) -1] < 0)} {
                return -code 7 "extraneous semi-colon"
            }

            set state(local) $state(phrase)
            unset state(phrase)
        }

        default {
            return -code 7 [format "expecting mailbox (found %s)"  $state(buffer)]
        }
    }

    return 1
}

# ::mime::addr_routeaddr --
#
#       Parses the domain portion of an e-mail address.  Finds the '@'
#       sign and then calls mime::addr_route to verify the domain.
#
# Arguments:
#       token         The MIME token to work from.
#
# Results:
#	Returns 1 if there is another address, and 0 if there is not.

proc ::mime::addr_routeaddr {token {checkP 1}} {
    # FRINK: nocheck
    variable $token
    upvar 0 $token state

    set lookahead $state(input)
    if {![string compare [parselexeme $token] LX_ATSIGN]} {
        mime::addr_route $token
    } else {
        set state(input) $lookahead
    }

    mime::addr_local $token

    switch -- $state(lastC) {
        LX_ATSIGN {
            mime::addr_domain $token
        }

        LX_SEMICOLON
            -
        LX_RBRACKET
            -
        LX_COMMA
            -
        LX_END {
        }

        default {
            return -code 7  [format "expecting at-sign after local-part (found %s)"  $state(buffer)]
        }
    }

    if {($checkP) && ([string compare $state(lastC) LX_RBRACKET])} {
        return -code 7 [format "expecting right-bracket (found %s)"  $state(buffer)]
    }

    return 1
}

# ::mime::addr_route --
#
#    Attempts to parse the portion of the e-mail address after the @.
#    Tries to verify that the domain definition has a valid form.
#
# Arguments:
#       token         The MIME token to work from.
#
# Results:
#	Returns nothing if successful, and throws an error if invalid
#       syntax is found.

proc ::mime::addr_route {token} {
    # FRINK: nocheck
    variable $token
    upvar 0 $token state

    set state(route) @

    while {1} {
        switch -- [parselexeme $token] {
            LX_ATOM
                -
            LX_DLITERAL {
                append state(route) $state(buffer)
            }

            default {
                return -code 7  [format "expecting sub-route in route-part (found %s)"  $state(buffer)]
            }
        }

        switch -- [parselexeme $token] {
            LX_COMMA {
                append state(route) $state(buffer)
                while {1} {
                    switch -- [parselexeme $token] {
                        LX_COMMA {
                        }

                        LX_ATSIGN {
                            append state(route) $state(buffer)
                            break
                        }

                        default {
                            return -code 7  [format "expecting at-sign in route (found %s)"  $state(buffer)]
                        }
                    }
                }
            }

            LX_ATSIGN
                -
            LX_DOT {
                append state(route) $state(buffer)
            }

            LX_COLON {
                append state(route) $state(buffer)
                return
            }

            default {
                return -code 7  [format "expecting colon to terminate route (found %s)"  $state(buffer)]
            }
        }
    }
}

# ::mime::addr_domain --
#
#    Attempts to parse the portion of the e-mail address after the @.
#    Tries to verify that the domain definition has a valid form.
#
# Arguments:
#       token         The MIME token to work from.
#
# Results:
#	Returns nothing if successful, and throws an error if invalid
#       syntax is found.

proc ::mime::addr_domain {token} {
    # FRINK: nocheck
    variable $token
    upvar 0 $token state

    while {1} {
        switch -- [parselexeme $token] {
            LX_ATOM
                -
            LX_DLITERAL {
                append state(domain) $state(buffer)
            }

            default {
                return -code 7  [format "expecting sub-domain in domain-part (found %s)"  $state(buffer)]
            }
        }

        switch -- [parselexeme $token] {
            LX_DOT {
                append state(domain) $state(buffer)
            }

            LX_ATSIGN {
                append state(local) % $state(domain)
                unset state(domain)
            }

            default {
                return
            }
        }
    }
}

# ::mime::addr_local --
#
#
# Arguments:
#       token         The MIME token to work from.
#
# Results:
#	Returns nothing if successful, and throws an error if invalid
#       syntax is found.

proc ::mime::addr_local {token} {
    # FRINK: nocheck
    variable $token
    upvar 0 $token state

    set state(memberP) $state(glevel)

    while {1} {
        switch -- [parselexeme $token] {
            LX_ATOM
                -
            LX_QSTRING {
                append state(local) $state(buffer)
            }

            default {
                return -code 7  [format "expecting mailbox in local-part (found %s)"  $state(buffer)]
            }
        }

        switch -- [parselexeme $token] {
            LX_DOT {
                append state(local) $state(buffer)
            }

            default {
                return
            }
        }
    }
}

# ::mime::addr_phrase --
#
#
# Arguments:
#       token         The MIME token to work from.
#
# Results:
#	Returns nothing if successful, and throws an error if invalid
#       syntax is found.


proc ::mime::addr_phrase {token} {
    # FRINK: nocheck
    variable $token
    upvar 0 $token state

    while {1} {
        switch -- [parselexeme $token] {
            LX_ATOM
                -
            LX_QSTRING {
                append state(phrase) " " $state(buffer)
            }

            default {
                break
            }
        }
    }

    switch -- $state(lastC) {
        LX_LBRACKET {
            return [addr_routeaddr $token]
        }

        LX_COLON {
            return [addr_group $token]
        }

        LX_DOT {
            append state(phrase) $state(buffer)
            return [addr_phrase $token]   
        }

        default {
            return -code 7  [format "found phrase instead of mailbox (%s%s)"  $state(phrase) $state(buffer)]
        }
    }
}

# ::mime::addr_group --
#
#
# Arguments:
#       token         The MIME token to work from.
#
# Results:
#	Returns nothing if successful, and throws an error if invalid
#       syntax is found.

proc ::mime::addr_group {token} {
    # FRINK: nocheck
    variable $token
    upvar 0 $token state

    if {[incr state(glevel)] > 1} {
        return -code 7 [format "nested groups not allowed (found %s)"  $state(phrase)]
    }

    set state(group) $state(phrase)
    unset state(phrase)

    set lookahead $state(input)
    while {1} {
        switch -- [parselexeme $token] {
            LX_SEMICOLON
                -
            LX_END {
                set state(glevel) 0
                return 1
            }

            LX_COMMA {
            }

            default {
                set state(input) $lookahead
                return [addr_specification $token]
            }
        }
    }
}

# ::mime::addr_end --
#
#
# Arguments:
#       token         The MIME token to work from.
#
# Results:
#	Returns nothing if successful, and throws an error if invalid
#       syntax is found.

proc ::mime::addr_end {token} {
    # FRINK: nocheck
    variable $token
    upvar 0 $token state

    switch -- $state(lastC) {
        LX_SEMICOLON {
            if {[incr state(glevel) -1] < 0} {
                return -code 7 "extraneous semi-colon"
            }
        }

        LX_COMMA
            -
        LX_END {
        }

        default {
            return -code 7 [format "junk after local@domain (found %s)"  $state(buffer)]
        }
    }    
}

# ::mime::addr_x400 --
#
#
# Arguments:
#       token         The MIME token to work from.
#
# Results:
#	Returns nothing if successful, and throws an error if invalid
#       syntax is found.

proc ::mime::addr_x400 {mbox key} {
    if {[set x [string first "/$key=" [string toupper $mbox]]] < 0} {
        return ""
    }
    set mbox [string range $mbox [expr {$x+[string length $key]+2}] end]

    if {[set x [string first "/" $mbox]] > 0} {
        set mbox [string range $mbox 0 [expr {$x-1}]]
    }

    return [string trim $mbox "\""]
}

# ::mime::parsedatetime --
#
#    Fortunately the clock command in the Tcl 8.x core does all the heavy 
#    lifting for us (except for timezone calculations).
#
#    mime::parsedatetime takes a string containing an 822-style date-time
#    specification and returns the specified property.
#
#    The list of properties and their ranges are:
#
#       property     range
#       ========     =====
#       clock        raw result of "clock scan"
#       hour         0 .. 23
#       lmonth       January, February, ..., December
#       lweekday     Sunday, Monday, ... Saturday
#       mday         1 .. 31
#       min          0 .. 59
#       mon          1 .. 12
#       month        Jan, Feb, ..., Dec
#       proper       822-style date-time specification
#       rclock       elapsed seconds between then and now
#       sec          0 .. 59
#       wday         0 .. 6 (Sun .. Mon)
#       weekday      Sun, Mon, ..., Sat
#       yday         1 .. 366
#       year         1900 ...
#       zone         -720 .. 720 (minutes east of GMT)
#
# Arguments:
#       value       Either a 822-style date-time specification or '-now'
#                   if the current date/time should be used.
#       property    The property (from the list above) to return
#
# Results:
#	Returns the string value of the 'property' for the date/time that was
#       specified in 'value'.

namespace eval ::mime {
        variable WDAYS_SHORT  [list Sun Mon Tue Wed Thu Fri Sat]
        variable WDAYS_LONG   [list Sunday Monday Tuesday Wednesday Thursday  Friday Saturday]

        # Counting months starts at 1, so just insert a dummy element
        # at index 0.
        variable MONTHS_SHORT [list ""  Jan Feb Mar Apr May Jun  Jul Aug Sep Oct Nov Dec]
        variable MONTHS_LONG  [list ""  January February March April May June July  August Sepember October November December]
}
proc ::mime::parsedatetime {value property} {
    if {![string compare $value -now]} {
        set clock [clock seconds]
    } elseif {[regexp {^(.*) ([+-])([0-9][0-9])([0-9][0-9])$} $value  -> value zone_sign zone_hour zone_min]} {
        set clock [clock scan $value -gmt 1]
        if {[info exists zone_min]} {
            set zone_min [scan $zone_min %d]
            set zone_hour [scan $zone_hour %d]
            set zone [expr {60*($zone_min+60*$zone_hour)}]
            if {[string equal $zone_sign "+"]} {
                set zone -$zone
            }
            incr clock $zone
        }
    } else {
        set clock [clock scan $value]
    }

    switch -- $property {
        clock {
            return $clock
        }

        hour {
            set value [clock format $clock -format %H]
        }

        lmonth {
            variable MONTHS_LONG
            return [lindex $MONTHS_LONG  [scan [clock format $clock -format %m] %d]]
        }

        lweekday {
            variable WDAYS_LONG
            return [lindex $WDAYS_LONG [clock format $clock -format %w]]
        }

        mday {
            set value [clock format $clock -format %d]
        }

        min {
            set value [clock format $clock -format %M]
        }

        mon {
            set value [clock format $clock -format %m]
        }

        month {
            variable MONTHS_SHORT
            return [lindex $MONTHS_SHORT  [scan [clock format $clock -format %m] %d]]
        }

        proper {
            set gmt [clock format $clock -format "%Y-%m-%d %H:%M:%S"  -gmt true]
            if {[set diff [expr {($clock-[clock scan $gmt])/60}]] < 0} {
                set s -
                set diff [expr {-($diff)}]
            } else {
                set s +
            }
            set zone [format %s%02d%02d $s [expr {$diff/60}] [expr {$diff%60}]]

            variable WDAYS_SHORT
            set wday [lindex $WDAYS_SHORT [clock format $clock -format %w]]
            variable MONTHS_SHORT
            set mon [lindex $MONTHS_SHORT  [scan [clock format $clock -format %m] %d]]

            return [clock format $clock  -format "$wday, %d $mon %Y %H:%M:%S $zone"]
        }

        rclock {
            if {![string compare $value -now]} {
                return 0
            } else {
                return [expr {[clock seconds]-$clock}]
            }
        }

        sec {
            set value [clock format $clock -format %S]
        }

        wday {
            return [clock format $clock -format %w]
        }

        weekday {
            variable WDAYS_SHORT
            return [lindex $WDAYS_SHORT [clock format $clock -format %w]]
        }

        yday {
            set value [clock format $clock -format %j]
        }

        year {
            set value [clock format $clock -format %Y]
        }

        zone {
	    set value [string trim [string map [list "\t" " "] $value]]
            if {[set x [string last " " $value]] < 0} {
                return 0
            }
            set value [string range $value [expr {$x+1}] end]
            switch -- [set s [string index $value 0]] {
                + - - {
                    if {![string compare $s +]} {
                        set s ""
                    }
                    set value [string trim [string range $value 1 end]]
                    if {([string length $value] != 4)  || ([scan $value %2d%2d h m] != 2)  || ($h > 12)  || ($m > 59)  || (($h == 12) && ($m > 0))} {
                        error "malformed timezone-specification: $value"
                    }
                    set value $s[expr {$h*60+$m}]
                }

                default {
                    set value [string toupper $value]
                    set z1 [list  UT GMT EST EDT CST CDT MST MDT PST PDT]
                    set z2 [list   0   0  -5  -4  -6  -5  -7  -6  -8  -7]
                    if {[set x [lsearch -exact $z1 $value]] < 0} {
                        error "unrecognized timezone-mnemonic: $value"
                    }
                    set value [expr {[lindex $z2 $x]*60}]
                }
            }
        }

        date2gmt
            -
        date2local
            -
        dst
            -
        sday
            -
        szone
            -
        tzone
            -
        default {
            error "unknown property $property"
        }
    }

    if {![string compare [set value [string trimleft $value 0]] ""]} {
        set value 0
    }
    return $value
}

# ::mime::uniqueID --
#
#    Used to generate a 'globally unique identifier' for the content-id.
#    The id is built from the pid, the current time, the hostname, and
#    a counter that is incremented each time a message is sent.
#
# Arguments:
#
# Results:
#	Returns the a string that contains the globally unique identifier
#       that should be used for the Content-ID of an e-mail message.

proc ::mime::uniqueID {} {
    variable mime

    return "<[pid].[clock seconds].[incr mime(cid)]@[info hostname]>"
}

# ::mime::parselexeme --
#
#    Used to implement a lookahead parser.
#
# Arguments:
#       token    The MIME token to operate on.
#
# Results:
#	Returns the next token found by the parser.

proc ::mime::parselexeme {token} {
    # FRINK: nocheck
    variable $token
    upvar 0 $token state

    set state(input) [string trimleft $state(input)]

    set state(buffer) ""
    if {![string compare $state(input) ""]} {
        set state(buffer) end-of-input
        return [set state(lastC) LX_END]
    }

    set c [string index $state(input) 0]
    set state(input) [string range $state(input) 1 end]

    if {![string compare $c "("]} {
        set noteP 0
        set quoteP 0

        while {1} {
            append state(buffer) $c

            switch -- $c/$quoteP {
                "(/0" {
                    incr noteP
                }

                "\\/0" {
                    set quoteP 1
                }

                ")/0" {
                    if {[incr noteP -1] < 1} {
                        if {[info exists state(comment)]} {
                            append state(comment) " "
                        }
                        append state(comment) $state(buffer)

                        return [parselexeme $token]
                    }
                }

                default {
                    set quoteP 0
                }
            }

            if {![string compare [set c [string index $state(input) 0]] ""]} {
                set state(buffer) "end-of-input during comment"
                return [set state(lastC) LX_ERR]
            }
            set state(input) [string range $state(input) 1 end]
        }
    }

    if {![string compare $c "\""]} {
        set firstP 1
        set quoteP 0

        while {1} {
            append state(buffer) $c

            switch -- $c/$quoteP {
                "\\/0" {
                    set quoteP 1
                }

                "\"/0" {
                    if {!$firstP} {
                        return [set state(lastC) LX_QSTRING]
                    }
                    set firstP 0
                }

                default {
                    set quoteP 0
                }
            }

            if {![string compare [set c [string index $state(input) 0]] ""]} {
                set state(buffer) "end-of-input during quoted-string"
                return [set state(lastC) LX_ERR]
            }
            set state(input) [string range $state(input) 1 end]
        }
    }

    if {![string compare $c "\["]} {
        set quoteP 0

        while {1} {
            append state(buffer) $c

            switch -- $c/$quoteP {
                "\\/0" {
                    set quoteP 1
                }

                "\]/0" {
                    return [set state(lastC) LX_DLITERAL]
                }

                default {
                    set quoteP 0
                }
            }

            if {![string compare [set c [string index $state(input) 0]] ""]} {
                set state(buffer) "end-of-input during domain-literal"
                return [set state(lastC) LX_ERR]
            }
            set state(input) [string range $state(input) 1 end]
        }
    }

    if {[set x [lsearch -exact $state(tokenL) $c]] >= 0} {
        append state(buffer) $c

        return [set state(lastC) [lindex $state(lexemeL) $x]]
    }

    while {1} {
        append state(buffer) $c

        switch -- [set c [string index $state(input) 0]] {
            "" - " " - "\t" - "\n" {
                break
            }

            default {
                if {[lsearch -exact $state(tokenL) $c] >= 0} {
                    break
                }
            }
        }

        set state(input) [string range $state(input) 1 end]
    }

    return [set state(lastC) LX_ATOM]
}

# ::mime::mapencoding --
#
#    mime::mapencodings maps tcl encodings onto the proper names for their
#    MIME charset type.  This is only done for encodings whose charset types
#    were known.  The remaining encodings return "" for now.
#
# Arguments:
#       enc      The tcl encoding to map.
#
# Results:
#	Returns the MIME charset type for the specified tcl encoding, or ""
#       if none is known.

proc ::mime::mapencoding {enc} {

    variable encodings

    if {[info exists encodings($enc)]} {
        return $encodings($enc)
    }
    return ""
}

# ::mime::reversemapencoding --
#
#    mime::reversemapencodings maps MIME charset types onto tcl encoding names.
#    Those that are unknown return "".
#
# Arguments:
#       mimeType  The MIME charset to convert into a tcl encoding type.
#
# Results:
#	Returns the tcl encoding name for the specified mime charset, or ""
#       if none is known.

proc ::mime::reversemapencoding {mimeType} {

    variable reversemap
    
    set lmimeType [string tolower $mimeType]
    if {[info exists reversemap($lmimeType)]} {
        return $reversemap($lmimeType)
    }
    return ""
}

# ::mime::word_encode --
#
#    Word encodes strings as per RFC 2047.
#
# Arguments:
#       charset   The character set to encode the message to.
#       method    The encoding method (base64 or quoted-printable).
#       string    The string to encode.
#       ?-charset_encoded   0 or 1      Whether the data is already encoded
#                                       in the specified charset (default 1)
#       ?-maxlength         maxlength   The maximum length of each encoded
#                                       word to return (default 66)
#
# Results:
#	Returns a word encoded string.

proc ::mime::word_encode {charset method string {args}} {

    variable encodings

    if {![info exists encodings($charset)]} {
	error "unknown charset '$charset'"
    }

    if {$encodings($charset) == ""} {
	error "invalid charset '$charset'"
    }

    if {$method != "base64" && $method != "quoted-printable"} {
	error "unknown method '$method', must be base64 or quoted-printable"
    }

    # default to encoded and a length that won't make the Subject header to long
    array set options [list -charset_encoded 1 -maxlength 66]
    array set options $args

    if { $options(-charset_encoded) } {
    	set unencoded_string [::encoding convertfrom $charset $string]
    } else {
        set unencoded_string $string
    }

    set string_length [string length $unencoded_string]

    if {!$string_length} {
	return ""
    }

    set string_bytelength [string bytelength $unencoded_string]

    # the 7 is for =?, ?Q?, ?= delimiters of the encoded word
    set maxlength [expr {$options(-maxlength) - [string length $encodings($charset)] - 7}]
    switch -exact -- $method {
	base64 {
            if { $maxlength < 4 } {
                error "maxlength $options(-maxlength) too short for chosen charset and encoding"
            }
            set count 0
            set maxlength [expr {($maxlength / 4) * 3}]
            while { $count < $string_length } {
                set length 0
                set enc_string ""
                while { ($length < $maxlength) && ($count < $string_length) } {
                    set char [string range $unencoded_string $count $count]
                    set enc_char [::encoding convertto $charset $char]
                    if { ($length + [string length $enc_char]) > $maxlength } {
                        set length $maxlength
                    } else {
                        append enc_string $enc_char
                        incr count
                        incr length [string length $enc_char]
                    }
                }
                set encoded_word [string map [list \n {}]  [base64 -mode encode -- $enc_string]]
                append result "=?$encodings($charset)?B?$encoded_word?=\n "
            }
            # Trim off last "\n ", since the above code has the side-effect
            # of adding an extra "\n " to the encoded string.

            set result [string range $result 0 end-2]
	}
	quoted-printable {
            if { $maxlength < 1 } {
                error "maxlength $options(-maxlength) too short for chosen charset and encoding"
            }
            set count 0
            while { $count < $string_length } {
            set length 0
            set encoded_word ""
            while { ($length < $maxlength) && ($count < $string_length) } {
                set char [string range $unencoded_string $count $count]
                set enc_char [::encoding convertto $charset $char]
                set qp_enc_char [qp_encode $enc_char 1]
                set qp_enc_char_length [string length $qp_enc_char]
                if { $qp_enc_char_length > $maxlength } {
                    error "maxlength $options(-maxlength) too short for chosen charset and encoding"
                }
		if { ($length + [string length $qp_enc_char]) > $maxlength } {
                    set length $maxlength
                } else {
                    append encoded_word $qp_enc_char
                    incr count
                    incr length [string length $qp_enc_char]
                }
            }
	    append result "=?$encodings($charset)?Q?$encoded_word?=\n "
            }
            # Trim off last "\n ", since the above code has the side-effect
            # of adding an extra "\n " to the encoded string.

            set result [string range $result 0 end-2]
	}
	"" {
	    # Go ahead
	}
	default {
	    error "Can't handle content encoding \"$method\""
	}
    }

    return $result
}

# ::mime::word_decode --
#
#    Word decodes strings that have been word encoded as per RFC 2047.
#
# Arguments:
#       encoded   The word encoded string to decode.
#
# Results:
#	Returns the string that has been decoded from the encoded message.

proc ::mime::word_decode {encoded} {

    variable reversemap

    if {[regexp -- {=\?([^?]+)\?(.)\?([^?]*)\?=} $encoded  - charset method string] != 1} {
	error "malformed word-encoded expression '$encoded'"
    }

    set enc [reversemapencoding $charset]
    if {[string equal "" $enc]} {
	error "unknown charset '$charset'"
    }

    switch -exact -- $method {
	b -
	B {
            set method base64
        }
	q -
	Q {
            set method quoted-printable
        }
	default {
	    error "unknown method '$method', must be B or Q"
        }
    }

    switch -exact -- $method {
	base64 {
	    set result [base64 -mode decode -- $string]
	}
	quoted-printable {
	    set result [qp_decode $string 1]
	}
	"" {
	    # Go ahead
	}
	default {
	    error "Can't handle content encoding \"$method\""
	}
    }

    return [list $enc $method $result]
}

# ::mime::field_decode --
#
#    Word decodes strings that have been word encoded as per RFC 2047
#    and converts the string from the original encoding/charset to UTF.
#
# Arguments:
#       field     The string to decode
#
# Results:
#	Returns the decoded string in UTF.

proc ::mime::field_decode {field} {
    # ::mime::field_decode is broken.  Here's a new version.
    # This code is in the public domain.  Don Libes <don@libes.com>

    # Step through a field for mime-encoded words, building a new
    # version with unencoded equivalents.

    # Sorry about the grotesque regexp.  Most of it is sensible.  One
    # notable fudge: the final $ is needed because of an apparent bug
    # in the regexp engine where the preceding .* otherwise becomes
    # non-greedy - perhaps because of the earlier ".*?", sigh.

    while {[regexp {(.*?)(=\?(?:[^?]+)\?(?:.)\?(?:[^?]*)\?=)(.*)$} $field ignore prefix encoded field]} {
	# don't allow whitespace between encoded words per RFC 2047
	if {"" != $prefix} {
	    if {![string is space $prefix]} {
		append result $prefix
	    }
	}

	set decoded [word_decode $encoded]
        foreach {charset - string} $decoded break

	append result [::encoding convertfrom $charset $string]
    }

    append result $field
    return $result
}
}
#############################################################################
## Procedure:  TCL_LIB_SMTP

proc ::TCL_LIB_SMTP {} {
global widget

# smtp.tcl - SMTP client
#
# Copyright (c) 1999-2000 Marshall T. Rose
# Copyright (c) 2003-2006 Pat Thoyts
#
# See the file "license.terms" for information on usage and redistribution
# of this file, and for a DISCLAIMER OF ALL WARRANTIES.
#

package require Tcl 8.3
package require mime 1.4.1

catch {
    package require SASL 1.0;           # tcllib 1.8
    package require SASL::NTLM 1.0;     # tcllib 1.8
}

#
# state variables:
#
#    sd: socket to server
#    afterID: afterID associated with ::smtp::timer
#    options: array of user-supplied options
#    readable: semaphore for vwait
#    addrs: number of recipients negotiated
#    error: error during read
#    line: response read from server
#    crP: just put a \r in the data
#    nlP: just put a \n in the data
#    size: number of octets sent in DATA
#


namespace eval ::smtp {
    variable version 1.4.5
    variable trf 1
    variable smtp
    array set smtp { uid 0 }

    namespace export sendmessage
}

if {[catch {package require Trf  2.0}]} {
    # Trf is not available, but we can live without it as long as the
    # transform and unstack procs are defined.

    # Warning!
    # This is a fragile emulation of the more general calling sequence
    # that appears to work with this code here.

    proc transform {args} {
	upvar state mystate
	set mystate(size) 1
    }
    proc unstack {channel} {
        # do nothing
        return
    }
    set ::smtp::trf 0
}


# ::smtp::sendmessage --
#
#	Sends a mime object (containing a message) to some recipients
#
# Arguments:
#	part  The MIME object containing the message to send
#       args  A list of arguments specifying various options for sending the
#             message:
#             -atleastone  A boolean specifying whether or not to send the
#                          message at all if any of the recipients are 
#                          invalid.  A value of false (as defined by 
#                          ::smtp::boolean) means that ALL recipients must be
#                          valid in order to send the message.  A value of
#                          true means that as long as at least one recipient
#                          is valid, the message will be sent.
#             -debug       A boolean specifying whether or not debugging is
#                          on.  If debugging is enabled, status messages are 
#                          printed to stderr while trying to send mail.
#             -queue       A boolean specifying whether or not the message
#                          being sent should be queued for later delivery.
#             -header      A single RFC 822 header key and value (as a list),
#                          used to specify to whom to send the message 
#                          (To, Cc, Bcc), the "From", etc.
#             -originator  The originator of the message (equivalent to
#                          specifying a From header).
#             -recipients  A string containing recipient e-mail addresses.
#                          NOTE: This option overrides any recipient addresses
#                          specified with -header.
#             -servers     A list of mail servers that could process the
#                          request.
#             -ports       A list of SMTP ports to use for each SMTP server
#                          specified
#             -client      The string to use as our host name for EHLO or HELO
#                          This defaults to 'localhost' or [info hostname]
#             -maxsecs     Maximum number of seconds to allow the SMTP server
#                          to accept the message. If not specified, the default
#                          is 120 seconds.
#             -usetls      A boolean flag. If the server supports it and we
#                          have the package, use TLS to secure the connection.
#             -tlspolicy   A command to call if the TLS negotiation fails for
#                          some reason. Return 'insecure' to continue with
#                          normal SMTP or 'secure' to close the connection and
#                          try another server.
#             -username    These are needed if your SMTP server requires
#             -password    authentication.
#
# Results:
#	Message is sent.  On success, return "".  On failure, throw an
#       exception with an error code and error message.

proc ::smtp::sendmessage {part args} {
    global errorCode errorInfo

    # Here are the meanings of the following boolean variables:
    # aloP -- value of -atleastone option above.
    # debugP -- value of -debug option above.
    # origP -- 1 if -originator option was specified, 0 otherwise.
    # queueP -- value of -queue option above.

    set aloP 0
    set debugP 0
    set origP 0
    set queueP 0
    set maxsecs 120
    set originator ""
    set recipients ""
    set servers [list localhost]
    set client "" ;# default is set after options processing
    set ports [list 25]
    set tlsP 1
    set tlspolicy {}
    set username {}
    set password {}

    array set header ""

    # lowerL will contain the list of header keys (converted to lower case) 
    # specified with various -header options.  mixedL is the mixed-case version
    # of the list.
    set lowerL ""
    set mixedL ""

    # Parse options (args).

    if {[expr {[llength $args]%2}]} {
        # Some option didn't get a value.
        error "Each option must have a value!  Invalid option list: $args"
    }
    
    foreach {option value} $args {
        switch -- $option {
            -atleastone {set aloP   [boolean $value]}
            -debug      {set debugP [boolean $value]}
            -queue      {set queueP [boolean $value]}
            -usetls     {set tlsP   [boolean $value]}
            -tlspolicy  {set tlspolicy $value}
	    -maxsecs    {set maxsecs [expr {$value < 0 ? 0 : $value}]}
            -header {
                if {[llength $value] != 2} {
                    error "-header expects a key and a value, not $value"
                }
                set mixed [lindex $value 0]
                set lower [string tolower $mixed]
                set disallowedHdrList  [list content-type  content-transfer-encoding  content-md5  mime-version]
                if {[lsearch -exact $disallowedHdrList $lower] > -1} {
                    error "Content-Type, Content-Transfer-Encoding, Content-MD5, and MIME-Version cannot be user-specified."
                }
                if {[lsearch -exact $lowerL $lower] < 0} {
                    lappend lowerL $lower
                    lappend mixedL $mixed
                }               

                lappend header($lower) [lindex $value 1]
            }

            -originator {
                set originator $value
                if {$originator == ""} {
                    set origP 1
                }
            }

            -recipients {
                set recipients $value
            }

            -servers {
                set servers $value
            }

            -client {
                set client $value
            }

            -ports {
                set ports $value
            }

            -username { set username $value }
            -password { set password $value }

            default {
                error "unknown option $option"
            }
        }
    }

    if {[lsearch -glob $lowerL resent-*] >= 0} {
        set prefixL resent-
        set prefixM Resent-
    } else {
        set prefixL ""
        set prefixM ""
    }

    # Set a bunch of variables whose value will be the real header to be used
    # in the outbound message (with proper case and prefix).

    foreach mixed {From Sender To cc Dcc Bcc Date Message-ID} {
        set lower [string tolower $mixed]
	# FRINK: nocheck
        set ${lower}L $prefixL$lower
	# FRINK: nocheck
        set ${lower}M $prefixM$mixed
    }

    if {$origP} {
        # -originator was specified with "", so SMTP sender should be marked "".
        set sender ""
    } else {
        # -originator was specified with a value, OR -originator wasn't
        # specified at all.
        
        # If no -originator was provided, get the originator from the "From"
        # header.  If there was no "From" header get it from the username
        # executing the script.

        set who "-originator"
        if {$originator == ""} {
            if {![info exists header($fromL)]} {
                set originator $::tcl_platform(user)
            } else {
                set originator [join $header($fromL) ,]

                # Indicate that we're using the From header for the originator.

                set who $fromM
            }
        }
        
	# If there's no "From" header, create a From header with the value
	# of -originator as the value.

        if {[lsearch -exact $lowerL $fromL] < 0} {
            lappend lowerL $fromL
            lappend mixedL $fromM
            lappend header($fromL) $originator
        }

	# ::mime::parseaddress returns a list whose elements are huge key-value
	# lists with info about the addresses.  In this case, we only want one
	# originator, so we want the length of the main list to be 1.

        set addrs [::mime::parseaddress $originator]
        if {[llength $addrs] > 1} {
            error "too many mailboxes in $who: $originator"
        }
        array set aprops {error "invalid address \"$from\""}
        array set aprops [lindex $addrs 0]
        if {$aprops(error) != ""} {
            error "error in $who: $aprops(error)"
        }

	# sender = validated originator or the value of the From header.

        set sender $aprops(address)

	# If no Sender header has been specified and From is different from
	# originator, then set the sender header to the From.  Otherwise, don't
	# specify a Sender header.
        set from [join $header($fromL) ,]
        if {[lsearch -exact $lowerL $senderL] < 0 &&  [string compare $originator $from]} {
            if {[info exists aprops]} {
                unset aprops
            }
            array set aprops {error "invalid address \"$from\""}
            array set aprops [lindex [::mime::parseaddress $from] 0]
            if {$aprops(error) != ""} {
                error "error in $fromM: $aprops(error)"
            }
            if {[string compare $aprops(address) $sender]} {
                lappend lowerL $senderL
                lappend mixedL $senderM
                lappend header($senderL) $aprops(address)
            }
        }
    }

    # We're done parsing the arguments.

    if {$recipients != ""} {
        set who -recipients
    } elseif {![info exists header($toL)]} {
        error "need -header \"$toM ...\""
    } else {
        set recipients [join $header($toL) ,]
	# Add Cc values to recipients list
	set who $toM
        if {[info exists header($ccL)]} {
            append recipients ,[join $header($ccL) ,]
            append who /$ccM
        }

        set dccInd [lsearch -exact $lowerL $dccL]
        if {$dccInd >= 0} {
	    # Add Dcc values to recipients list, and get rid of Dcc header
	    # since we don't want to output that.
            append recipients ,[join $header($dccL) ,]
            append who /$dccM

            unset header($dccL)
            set lowerL [lreplace $lowerL $dccInd $dccInd]
            set mixedL [lreplace $mixedL $dccInd $dccInd]
        }
    }

    set brecipients ""
    set bccInd [lsearch -exact $lowerL $bccL]
    if {$bccInd >= 0} {
        set bccP 1

	# Build valid bcc list and remove bcc element of header array (so that
	# bcc info won't be sent with mail).
        foreach addr [::mime::parseaddress [join $header($bccL) ,]] {
            if {[info exists aprops]} {
                unset aprops
            }
            array set aprops {error "invalid address \"$from\""}
            array set aprops $addr
            if {$aprops(error) != ""} {
                error "error in $bccM: $aprops(error)"
            }
            lappend brecipients $aprops(address)
        }

        unset header($bccL)
        set lowerL [lreplace $lowerL $bccInd $bccInd]
        set mixedL [lreplace $mixedL $bccInd $bccInd]
    } else {
        set bccP 0
    }

    # If there are no To headers, add "" to bcc list.  WHY??
    if {[lsearch -exact $lowerL $toL] < 0} {
        lappend lowerL $bccL
        lappend mixedL $bccM
        lappend header($bccL) ""
    }

    # Construct valid recipients list from recipients list.

    set vrecipients ""
    foreach addr [::mime::parseaddress $recipients] {
        if {[info exists aprops]} {
            unset aprops
        }
        array set aprops {error "invalid address \"$from\""}
        array set aprops $addr
        if {$aprops(error) != ""} {
            error "error in $who: $aprops(error)"
        }
        lappend vrecipients $aprops(address)
    }

    # If there's no date header, get the date from the mime message.  Same for
    # the message-id.

    if {([lsearch -exact $lowerL $dateL] < 0)  && ([catch { ::mime::getheader $part $dateL }])} {
        lappend lowerL $dateL
        lappend mixedL $dateM
        lappend header($dateL) [::mime::parsedatetime -now proper]
    }

    if {([lsearch -exact $lowerL ${message-idL}] < 0)  && ([catch { ::mime::getheader $part ${message-idL} }])} {
        lappend lowerL ${message-idL}
        lappend mixedL ${message-idM}
        lappend header(${message-idL}) [::mime::uniqueID]

    }

    # Get all the headers from the MIME object and save them so that they can
    # later be restored.
    set savedH [::mime::getheader $part]

    # Take all the headers defined earlier and add them to the MIME message.
    foreach lower $lowerL mixed $mixedL {
        foreach value $header($lower) {
            ::mime::setheader $part $mixed $value -mode append
        }
    }

    if {[string length $client] < 1} {
        if {![string compare $servers localhost]} {
            set client localhost
        } else {
            set client [info hostname]
        }
    }

    # Create smtp token, which essentially means begin talking to the SMTP
    # server.
    set token [initialize -debug $debugP -client $client  -maxsecs $maxsecs -usetls $tlsP  -multiple $bccP -queue $queueP  -servers $servers -ports $ports  -tlspolicy $tlspolicy  -username $username -password $password]

    if {![string match "::smtp::*" $token]} {
	# An error occurred and $token contains the error info
	array set respArr $token
	return -code error $respArr(diagnostic)
    }

    set code [catch { sendmessageaux $token $part  $sender $vrecipients $aloP }  result]
    set ecode $errorCode
    set einfo $errorInfo

    # Send the message to bcc recipients as a MIME attachment.

    if {($code == 0) && ($bccP)} {
        set inner [::mime::initialize -canonical message/rfc822  -header [list Content-Description  "Original Message"]  -parts [list $part]]

        set subject "\[$bccM\]"
        if {[info exists header(subject)]} {
            append subject " " [lindex $header(subject) 0] 
        }

        set outer [::mime::initialize  -canonical multipart/digest  -header [list From $originator]  -header [list Bcc ""]  -header [list Date  [::mime::parsedatetime -now proper]]  -header [list Subject $subject]  -header [list Message-ID [::mime::uniqueID]]  -header [list Content-Description  "Blind Carbon Copy"]  -parts [list $inner]]


        set code [catch { sendmessageaux $token $outer  $sender $brecipients  $aloP } result2]
        set ecode $errorCode
        set einfo $errorInfo

        if {$code == 0} {
            set result [concat $result $result2]
        } else {
            set result $result2
        }

        catch { ::mime::finalize $inner -subordinates none }
        catch { ::mime::finalize $outer -subordinates none }
    }

    # Determine if there was any error in prior operations and set errorcodes
    # and error messages appropriately.
    
    switch -- $code {
        0 {
            set status orderly
        }

        7 {
            set code 1
            array set response $result
            set result "$response(code): $response(diagnostic)"
            set status abort
        }

        default {
            set status abort
        }
    }

    # Destroy SMTP token 'cause we're done with it.
    
    catch { finalize $token -close $status }

    # Restore provided MIME object to original state (without the SMTP headers).
    
    foreach key [::mime::getheader $part -names] {
        mime::setheader $part $key "" -mode delete
    }
    foreach {key values} $savedH {
        foreach value $values {
            ::mime::setheader $part $key $value -mode append
        }
    }

    return -code $code -errorinfo $einfo -errorcode $ecode $result
}

# ::smtp::sendmessageaux --
#
#	Sends a mime object (containing a message) to some recipients using an
#       existing SMTP token.
#
# Arguments:
#       token       SMTP token that has an open connection to the SMTP server.
#	part        The MIME object containing the message to send.
#       originator  The e-mail address of the entity sending the message,
#                   usually the From clause.
#       recipients  List of e-mail addresses to whom message will be sent.
#       aloP        Boolean "atleastone" setting; see the -atleastone option
#                   in ::smtp::sendmessage for details.
#
# Results:
#	Message is sent.  On success, return "".  On failure, throw an
#       exception with an error code and error message.

proc ::smtp::sendmessageaux {token part originator recipients aloP} {
    global errorCode errorInfo

    winit $token $part $originator

    set goodP 0
    set badP 0
    set oops ""
    foreach recipient $recipients {
        set code [catch { waddr $token $recipient } result]
        set ecode $errorCode
        set einfo $errorInfo

        switch -- $code {
            0 {
                incr goodP
            }

            7 {
                incr badP

                array set response $result
                lappend oops [list $recipient $response(code)  $response(diagnostic)]
            }

            default {
                return -code $code -errorinfo $einfo -errorcode $ecode $result
            }
        }
    }

    if {($goodP) && ((!$badP) || ($aloP))} {
        wtext $token $part
    } else {
        catch { talk $token 300 RSET }
    }

    return $oops
}

# ::smtp::initialize --
#
#	Create an SMTP token and open a connection to the SMTP server.
#
# Arguments:
#       args  A list of arguments specifying various options for sending the
#             message:
#             -debug       A boolean specifying whether or not debugging is
#                          on.  If debugging is enabled, status messages are 
#                          printed to stderr while trying to send mail.
#             -client      Either localhost or the name of the local host.
#             -multiple    Multiple messages will be sent using this token.
#             -queue       A boolean specifying whether or not the message
#                          being sent should be queued for later delivery.
#             -servers     A list of mail servers that could process the
#                          request.
#             -ports       A list of ports on mail servers that could process
#                          the request (one port per server-- defaults to 25).
#             -usetls      A boolean to indicate we will use TLS if possible.
#             -tlspolicy   Command called if TLS setup fails.
#             -username    These provide the authentication information 
#             -password    to be used if needed by the SMTP server.
#
# Results:
#	On success, return an smtp token.  On failure, throw
#       an exception with an error code and error message.

proc ::smtp::initialize {args} {
    global errorCode errorInfo

    variable smtp

    set token [namespace current]::[incr smtp(uid)]
    # FRINK: nocheck
    variable $token
    upvar 0 $token state

    array set state [list afterID "" options "" readable 0]
    array set options [list -debug 0 -client localhost -multiple 1  -maxsecs 120 -queue 0 -servers localhost  -ports 25 -usetls 1 -tlspolicy {}  -username {} -password {}]
    array set options $args
    set state(options) [array get options]

    # Iterate through servers until one accepts a connection (and responds
    # nicely).
   
    set index 0 
    foreach server $options(-servers) {
	set state(readable) 0
        if {[llength $options(-ports)] >= $index} {
            set port [lindex $options(-ports) $index]
        } else {
            set port 25
        }
        if {$options(-debug)} {
            puts stderr "Trying $server..."
            flush stderr
        }

        if {[info exists state(sd)]} {
            unset state(sd)
        }

        if {[set code [catch {
            set state(sd) [socket -async $server $port]
            fconfigure $state(sd) -blocking off -translation binary
            fileevent $state(sd) readable [list ::smtp::readable $token]
        } result]]} {
            set ecode $errorCode
            set einfo $errorInfo

            catch { close $state(sd) }
            continue
        }

        if {[set code [catch { hear $token 600 } result]]} {
            array set response [list code 400 diagnostic $result]
        } else {
            array set response $result
        }
        set ecode $errorCode
        set einfo $errorInfo
        switch -- $response(code) {
            220 {
            }

            421 - default {
                # 421 - Temporary problem on server
                catch {close $state(sd)}
                continue
            }
        }

        set r [initialize_ehlo $token]
        if {$r != {}} {
            return $r
        }
        incr index
    }

    # None of the servers accepted our connection, so close everything up and
    # return an error.
    finalize $token -close drop

    return -code $code -errorinfo $einfo -errorcode $ecode $result
}

# If we cannot load the tls package, ignore the error
proc ::smtp::load_tls {} {
    set r [catch {package require tls}]
    if {$r} {set ::errorInfo ""}
    return $r
}

proc ::smtp::initialize_ehlo {token} {
    global errorCode errorInfo
    upvar einfo einfo
    upvar ecode ecode
    upvar code  code
    
    # FRINK: nocheck
    variable $token
    upvar 0 $token state
    array set options $state(options)

    # Try enhanced SMTP first.

    if {[set code [catch {smtp::talk $token 300 "EHLO $options(-client)"}  result]]} {
        array set response [list code 400 diagnostic $result args ""]
    } else {
        array set response $result
    }
    set ecode $errorCode
    set einfo $errorInfo
    if {(500 <= $response(code)) && ($response(code) <= 599)} {
        if {[set code [catch { talk $token 300  "HELO $options(-client)" }  result]]} {
            array set response [list code 400 diagnostic $result args ""]
        } else {
            array set response $result
        }
        set ecode $errorCode
        set einfo $errorInfo
    }
    
    if {$response(code) == 250} {
        # Successful response to HELO or EHLO command, so set up queuing
        # and whatnot and return the token.
        
        set state(esmtp) $response(args)

        if {(!$options(-multiple))  && ([lsearch $response(args) ONEX] >= 0)} {
            catch {smtp::talk $token 300 ONEX}
        }
        if {($options(-queue))  && ([lsearch $response(args) XQUE] >= 0)} {
            catch {smtp::talk $token 300 QUED}
        }
        
        # Support STARTTLS extension.
        # The state(tls) item is used to see if we have already tried this.
        if {($options(-usetls)) && ![info exists state(tls)]  && (([lsearch $response(args) STARTTLS] >= 0)
                    || ([lsearch $response(args) TLS] >= 0))} {
            if {![load_tls]} {
                set state(tls) 0
                if {![catch {smtp::talk $token 300 STARTTLS} resp]} {
                    array set starttls $resp
                    if {$starttls(code) == 220} {
                        fileevent $state(sd) readable {}
                        catch {
                            ::tls::import $state(sd)
                            catch {::tls::handshake $state(sd)} msg
                            set state(tls) 1
                        } 
                        fileevent $state(sd) readable  [list ::smtp::readable $token]
                        return [initialize_ehlo $token]
                    } else {
                        # Call a TLS client policy proc here
                        #  returns secure close and try another server.
                        #  returns insecure continue on current socket
                        set policy insecure
                        if {$options(-tlspolicy) != {}} {
                            catch {
                                eval $options(-tlspolicy)  [list $starttls(code)]  [list $starttls(diagnostic)]
                            } policy
                        }
                        if {$policy != "insecure"} {
                            set code error
                            set ecode $starttls(code)
                            set einfo $starttls(diagnostic)
                            catch {close $state(sd)}
                            return {}
                        }
                    }
                }
            }
        }

        # If we have not already tried and the server supports it and we 
        # have a username -- lets try to authenticate.
        #
        if {![info exists state(auth)]
            && [llength [package provide SASL]] != 0
            && [set andx [lsearch -glob $response(args) "AUTH*"]] >= 0 
            && [string length $options(-username)] > 0 } {
            
            # May be AUTH mech or AUTH=mech
            # We want to use the strongest mechanism that has been offered
            # and that we support. If we cannot find a mechanism that 
            # succeeds, we will go ahead and try to carry on unauthenticated.
            # This may still work else we'll get an unauthorised error later.

            set mechs [string range [lindex $response(args) $andx] 5 end]
            foreach mech [SASL::mechanisms] {
                if {[lsearch -exact $mechs $mech] == -1} { continue }
                if {[catch {
                    Authenticate $token $mech
                } msg]} {
                    if {$options(-debug)} {
                        puts stderr "AUTH $mech failed: $msg "
                        flush stderr
                    }
                }
                if {[info exists state(auth)] && $state(auth)} {
                    if {$state(auth) == 1} {
                        break
                    } else {
                        # After successful AUTH we are supposed to redo
                        # our connection for mechanisms that setup a new
                        # security layer -- these should set state(auth) 
                        # greater than 1
                        fileevent $state(sd) readable  [list ::smtp::readable $token]
                        return [initialize_ehlo $token]
                    }
                }
            }
        }
        
        return $token
    } else {
        # Bad response; close the connection and hope the next server
        # is happier.
        catch {close $state(sd)}
    }
    return {}
}

proc ::smtp::SASLCallback {token context command args} {
    upvar #0 $token state
    upvar #0 $context ctx
    array set options $state(options)
    switch -exact -- $command {
        login    { return "" }
        username { return $options(-username) }
        password { return $options(-password) }
        hostname { return [info host] }
        realm    { 
            if {[string equal $ctx(mech) "NTLM"]  && [info exists ::env(USERDOMAIN)]} {
                return $::env(USERDOMAIN)
            } else {
                return ""
            }
        }
        default  { 
            return -code error "error: unsupported SASL information requested"
        }
    }
}

proc ::smtp::Authenticate {token mechanism} {
    upvar 0 $token state
    package require base64
    set ctx [SASL::new -mechanism $mechanism  -callback [list [namespace origin SASLCallback] $token]]

    set state(auth) 0
    set result [smtp::talk $token 300 "AUTH $mechanism"]
    array set response $result

    while {$response(code) == 334} {
        # The NTLM initial response is not base64 encoded so handle it.
        if {[catch {base64::decode $response(diagnostic)} challenge]} {
            set challenge $response(diagnostic)
        }
        SASL::step $ctx $challenge
        set result [smtp::talk $token 300  [base64::encode -maxlen 0 [SASL::response $ctx]]]
        array set response $result
    }
    
    if {$response(code) == 235} {
        set state(auth) 1
        return $result
    } else {
        return -code 7 $result
    }
}

# ::smtp::finalize --
#
#	Deletes an SMTP token by closing the connection to the SMTP server,
#       cleanup up various state.
#
# Arguments:
#       token   SMTP token that has an open connection to the SMTP server.
#       args    Optional arguments, where the only useful option is -close,
#               whose valid values are the following:
#               orderly     Normal successful completion.  Close connection and
#                           clear state variables.
#               abort       A connection exists to the SMTP server, but it's in
#                           a weird state and needs to be reset before being
#                           closed.  Then clear state variables.
#               drop        No connection exists, so we just need to clean up
#                           state variables.
#
# Results:
#	SMTP connection is closed and state variables are cleared.  If there's
#       an error while attempting to close the connection to the SMTP server,
#       throw an exception with the error code and error message.

proc ::smtp::finalize {token args} {
    global errorCode errorInfo
    # FRINK: nocheck
    variable $token
    upvar 0 $token state

    array set options [list -close orderly]
    array set options $args

    switch -- $options(-close) {
        orderly {
            set code [catch { talk $token 120 QUIT } result]
        }

        abort {
            set code [catch {
                talk $token 0 RSET
                talk $token 0 QUIT
            } result]
        }

        drop {
            set code 0
            set result ""
        }

        default {
            error "unknown value for -close $options(-close)"
        }
    }
    set ecode $errorCode
    set einfo $errorInfo

    catch { close $state(sd) }

    if {$state(afterID) != ""} {
        catch { after cancel $state(afterID) }
    }

    foreach name [array names state] {
        unset state($name)
    }
    # FRINK: nocheck
    unset $token

    return -code $code -errorinfo $einfo -errorcode $ecode $result
}

# ::smtp::winit --
#
#	Send originator info to SMTP server.  This occurs after HELO/EHLO
#       command has completed successfully (in ::smtp::initialize).  This function
#       is called by ::smtp::sendmessageaux.
#
# Arguments:
#       token       SMTP token that has an open connection to the SMTP server.
#       part        MIME token for the message to be sent. May be used for
#                   handling some SMTP extensions.
#       originator  The e-mail address of the entity sending the message,
#                   usually the From clause.
#       mode        SMTP command specifying the mode of communication.  Default
#                   value is MAIL.
#
# Results:
#	Originator info is sent and SMTP server's response is returned.  If an
#       error occurs, throw an exception.

proc ::smtp::winit {token part originator {mode MAIL}} {
    # FRINK: nocheck
    variable $token
    upvar 0 $token state

    if {[lsearch -exact [list MAIL SEND SOML SAML] $mode] < 0} {
        error "unknown origination mode $mode"
    }

    set from "$mode FROM:<$originator>"

    # RFC 1870 -  SMTP Service Extension for Message Size Declaration
    if {[info exists state(esmtp)] 
        && [lsearch -glob $state(esmtp) "SIZE*"] != -1} {
        catch {
            set size [string length [mime::buildmessage $part]]
            append from " SIZE=$size"
        }
    }

    array set response [set result [talk $token 600 $from]]

    if {$response(code) == 250} {
        set state(addrs) 0
        return $result
    } else {
        return -code 7 $result
    }
}

# ::smtp::waddr --
#
#	Send recipient info to SMTP server.  This occurs after originator info
#       is sent (in ::smtp::winit).  This function is called by
#       ::smtp::sendmessageaux. 
#
# Arguments:
#       token       SMTP token that has an open connection to the SMTP server.
#       recipient   One of the recipients to whom the message should be
#                   delivered.  
#
# Results:
#	Recipient info is sent and SMTP server's response is returned.  If an
#       error occurs, throw an exception.

proc ::smtp::waddr {token recipient} {
    # FRINK: nocheck
    variable $token
    upvar 0 $token state

    set result [talk $token 3600 "RCPT TO:<$recipient>"]
    array set response $result

    switch -- $response(code) {
        250 - 251 {
            incr state(addrs)
            return $result
        }

        default {
            return -code 7 $result
        }
    }
}

# ::smtp::wtext --
#
#	Send message to SMTP server.  This occurs after recipient info
#       is sent (in ::smtp::winit).  This function is called by
#       ::smtp::sendmessageaux. 
#
# Arguments:
#       token       SMTP token that has an open connection to the SMTP server.
#	part        The MIME object containing the message to send.
#
# Results:
#	MIME message is sent and SMTP server's response is returned.  If an
#       error occurs, throw an exception.

proc ::smtp::wtext {token part} {
    # FRINK: nocheck
    variable $token
    upvar 0 $token state
    array set options $state(options)

    set result [talk $token 300 DATA]
    array set response $result
    if {$response(code) != 354} {
        return -code 7 $result
    }

    if {[catch { wtextaux $token $part } result]} {
        catch { puts -nonewline $state(sd) "\r\n.\r\n" ; flush $state(sd) }
        return -code 7 [list code 400 diagnostic $result]
    }

    set secs $options(-maxsecs)

    set result [talk $token $secs .]
    array set response $result
    switch -- $response(code) {
        250 - 251 {
            return $result
        }

        default {
            return -code 7 $result
        }
    }
}

# ::smtp::wtextaux --
#
#	Helper function that coordinates writing the MIME message to the socket.
#       In particular, it stacks the channel leading to the SMTP server, sets up
#       some file events, sends the message, unstacks the channel, resets the
#       file events to their original state, and returns.
#
# Arguments:
#       token       SMTP token that has an open connection to the SMTP server.
#	part        The MIME object containing the message to send.
#
# Results:
#	Message is sent.  If anything goes wrong, throw an exception.

proc ::smtp::wtextaux {token part} {
    global errorCode errorInfo

    # FRINK: nocheck
    variable $token
    upvar 0 $token state

    # Workaround a bug with stacking channels on top of TLS.
    # FRINK: nocheck
    set trf [set [namespace current]::trf]
    if {[info exists state(tls)] && $state(tls)} {
        set trf 0
    }

    flush $state(sd)
    fileevent $state(sd) readable ""
    if {$trf} {
        transform -attach $state(sd) -command [list ::smtp::wdata $token]
    } else {
        set state(size) 1
    }
    fileevent $state(sd) readable [list ::smtp::readable $token]

    # If trf is not available, get the contents of the message,
    # replace all '.'s that start their own line with '..'s, and
    # then write the mime body out to the filehandle. Do not forget to
    # deal with bare LF's here too (SF bug #499242).

    if {$trf} {
        set code [catch { ::mime::copymessage $part $state(sd) } result]
    } else {
        set code [catch { ::mime::buildmessage $part } result]
        if {$code == 0} {
	    # Detect and transform bare LF's into proper CR/LF
	    # sequences.

	    while {[regsub -all -- {([^\r])\n} $result "\\1\r\n" result]} {}
            regsub -all -- {\n\.}      $result "\n.."   result

            # Fix for bug #827436 - mail data must end with CRLF.CRLF
            if {[string compare [string index $result end] "\n"] != 0} {
                append result "\r\n"
            }
            set state(size) [string length $result]
            puts -nonewline $state(sd) $result
            set result ""
	}
    }
    set ecode $errorCode
    set einfo $errorInfo

    flush $state(sd)
    fileevent $state(sd) readable ""
    if {$trf} {
        unstack $state(sd)
    }
    fileevent $state(sd) readable [list ::smtp::readable $token]

    return -code $code -errorinfo $einfo -errorcode $ecode $result
}

# ::smtp::wdata --
#
#	This is the custom transform using Trf to do CR/LF translation.  If Trf
#       is not installed on the system, then this function never gets called and
#       no translation occurs.
#
# Arguments:
#       token       SMTP token that has an open connection to the SMTP server.
#       command     Trf provided command for manipulating socket data.
#	buffer      Data to be converted.
#
# Results:
#	buffer is translated, and state(size) is set.  If Trf is not installed
#       on the system, the transform proc defined at the top of this file sets
#       state(size) to 1.  state(size) is used later to determine a timeout
#       value.

proc ::smtp::wdata {token command buffer} {
    # FRINK: nocheck
    variable $token
    upvar 0 $token state

    switch -- $command {
        create/write -
        clear/write  -
        delete/write {
            set state(crP) 0
            set state(nlP) 1
            set state(size) 0
        }

        write {
            set result ""

            foreach c [split $buffer ""] {
                switch -- $c {
                    "." {
                        if {$state(nlP)} {
                            append result .
                        }
                        set state(crP) 0
                        set state(nlP) 0
                    }

                    "\r" {
                        set state(crP) 1
                        set state(nlP) 0
                    }

                    "\n" {
                        if {!$state(crP)} {
                            append result "\r"
                        }
                        set state(crP) 0
                        set state(nlP) 1
                    }

                    default {
                        set state(crP) 0
                        set state(nlP) 0
                    }
                }

                append result $c
            }

            incr state(size) [string length $result]
            return $result
        }

        flush/write {
            set result ""

            if {!$state(nlP)} {
                if {!$state(crP)} {
                    append result "\r"
                }
                append result "\n"
            }

            incr state(size) [string length $result]
            return $result
        }

	create/read -
        delete/read {
	    # Bugfix for [#539952]
        }

	query/ratio {
	    # Indicator for unseekable channel,
	    # for versions of Trf which ask for
	    # this.
	    return {0 0}
	}
	query/maxRead {
	    # No limits on reading bytes from the channel below, for
	    # versions of Trf which ask for this information
	    return -1
	}

	default {
	    # Silently pass all unknown commands.
	    #error "Unknown command \"$command\""
	}
    }

    return ""
}

# ::smtp::talk --
#
#	Sends an SMTP command to a server
#
# Arguments:
#       token       SMTP token that has an open connection to the SMTP server.
#	secs        Timeout after which command should be aborted.
#       command     Command to send to SMTP server.
#
# Results:
#	command is sent and response is returned.  If anything goes wrong, throw
#       an exception.

proc ::smtp::talk {token secs command} {
    # FRINK: nocheck
    variable $token
    upvar 0 $token state

    array set options $state(options)

    if {$options(-debug)} {
        puts stderr "--> $command (wait upto $secs seconds)"
        flush stderr
    }

    if {[catch { puts -nonewline $state(sd) "$command\r\n"
                 flush $state(sd) } result]} {
        return [list code 400 diagnostic $result]
    }

    if {$secs == 0} {
        return ""
    }

    return [hear $token $secs]
}

# ::smtp::hear --
#
#	Listens for SMTP server's response to some prior command.
#
# Arguments:
#       token       SMTP token that has an open connection to the SMTP server.
#	secs        Timeout after which we should stop waiting for a response.
#
# Results:
#	Response is returned.

proc ::smtp::hear {token secs} {
    # FRINK: nocheck
    variable $token
    upvar 0 $token state

    array set options $state(options)

    array set response [list args ""]

    set firstP 1
    while {1} {
        if {$secs >= 0} {
	    ## SF [ 836442 ] timeout with large data
	    ## correction, aotto 031105 -
	    if {$secs > 600} {set secs 600}
            set state(afterID) [after [expr {$secs*1000}]  [list ::smtp::timer $token]]
        }

        if {!$state(readable)} {
            vwait ${token}(readable)
        }

        # Wait until socket is readable.
        if {$state(readable) !=  -1} {
            catch { after cancel $state(afterID) }
            set state(afterID) ""
        }

        if {$state(readable) < 0} {
            array set response [list code 400 diagnostic $state(error)]
            break
        }
        set state(readable) 0

        if {$options(-debug)} {
            puts stderr "<-- $state(line)"
            flush stderr
        }

        if {[string length $state(line)] < 3} {
            array set response  [list code 500  diagnostic "response too short: $state(line)"]
            break
        }

        if {$firstP} {
            set firstP 0

            if {[scan [string range $state(line) 0 2] %d response(code)]  != 1} {
                array set response  [list code 500  diagnostic "unrecognizable code: $state(line)"]
                break
            }

            set response(diagnostic)  [string trim [string range $state(line) 4 end]]
        } else {
            lappend response(args)  [string trim [string range $state(line) 4 end]]
        }

        # When status message line ends in -, it means the message is complete.
        
        if {[string compare [string index $state(line) 3] -]} {
            break
        }
    }

    return [array get response]
}

# ::smtp::readable --
#
#	Reads a line of data from SMTP server when the socket is readable.  This
#       is the callback of "fileevent readable".
#
# Arguments:
#       token       SMTP token that has an open connection to the SMTP server.
#
# Results:
#	state(line) contains the line of data and state(readable) is reset.
#       state(readable) gets the following values:
#       -3  if there's a premature eof,
#       -2  if reading from socket fails.
#       1   if reading from socket was successful

proc ::smtp::readable {token} {
    # FRINK: nocheck
    variable $token
    upvar 0 $token state

    if {[catch { array set options $state(options) }]} {
        return
    }

    set state(line) ""
    if {[catch { gets $state(sd) state(line) } result]} {
        set state(readable) -2
        set state(error) $result
    } elseif {$result == -1} {
        if {[eof $state(sd)]} {
            set state(readable) -3
            set state(error) "premature end-of-file from server"
        }
    } else {
        # If the line ends in \r, remove the \r.
        if {![string compare [string index $state(line) end] "\r"]} {
            set state(line) [string range $state(line) 0 end-1]
        }
        set state(readable) 1
    }

    if {$state(readable) < 0} {
        if {$options(-debug)} {
            puts stderr "    ... $state(error) ..."
            flush stderr
        }

        catch { fileevent $state(sd) readable "" }
    }
}

# ::smtp::timer --
#
#	Handles timeout condition on any communication with the SMTP server.
#
# Arguments:
#       token       SMTP token that has an open connection to the SMTP server.
#
# Results:
#	Sets state(readable) to -1 and state(error) to an error message.

proc ::smtp::timer {token} {
    # FRINK: nocheck
    variable $token
    upvar 0 $token state

    array set options $state(options)

    set state(afterID) ""
    set state(readable) -1
    set state(error) "read from server timed out"

    if {$options(-debug)} {
        puts stderr "    ... $state(error) ..."
        flush stderr
    }
}

# ::smtp::boolean --
#
#	Helper function for unifying boolean values to 1 and 0.
#
# Arguments:
#       value   Some kind of value that represents true or false (i.e. 0, 1,
#               false, true, no, yes, off, on).
#
# Results:
#	Return 1 if the value is true, 0 if false.  If the input value is not
#       one of the above, throw an exception.

proc ::smtp::boolean {value} {
    switch -- [string tolower $value] {
        0 - false - no - off {
            return 0
        }

        1 - true - yes - on {
            return 1
        }

        default {
            error "unknown boolean value: $value"
        }
    }
}

# -------------------------------------------------------------------------

package provide smtp $::smtp::version

# -------------------------------------------------------------------------
# Local variables:
# indent-tabs-mode: nil
# End:
}
#############################################################################
## Procedure:  FUNC_LOAD_LIBRARY

proc ::FUNC_LOAD_LIBRARY {} {
global widget

TCL_LIB_FTP
#TCL_LIB_HTTP

# mail service
TCL_LIB_MD5
TCL_LIB_BASE64
TCL_LIB_MIME
TCL_LIB_SMTP
}
#############################################################################
## Procedure:  FUNC_SEND_EMAIL

proc ::FUNC_SEND_EMAIL {sender recipient cc subject body filepath} {
global widget

package require mime 
package require smtp
 
#k1mh02.amkor.co.kr 10.101.10.6
set qry "SCOPS,GetSMTPConfig,*"

set res ""
set res [FUNC_SEND_QRY $qry]

if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
    #set msg {"Fail to Check TP1 and TP2" "\xAC\xB9\x4C\xD1\xA4\xC2\xB8\xD2\x20\x00\xF5\xAC\x15\xC8\x20\x00\xDD\xC0\x31\xC1\xD0\xC5\x20\x00\xE4\xC2\x28\xD3\x58\xD5\x00\xC6\xB5\xC2\xC8\xB2\xE4\xB2\x21\x00"}
    #set choice [ tk_messageBox -title "TP1 and TP2 Check Error" -icon warning -message [FM "K3 engineer" $msg $res] ]
    return "FALSE"
}

set server [lindex [split $res ","] 0]
set port [lindex [split $res ","] 1]

set tmp_body ""

#puts "length : [llength $body]"

if { [llength $body] > 1 } {

    foreach tmp $body {
        set tmp_body [format "%s\r\n%s" $tmp_body $tmp]   
    }

} else {
    set tmp_body $body
}

set tmp_body [format "%s\r\n\r\n" $tmp_body] 

if { [file exist $filepath] == 0 } {
    set msg "Sender wanted to attach $filepath, but there's no file!"
    set tmp_body [format "%s\r\n\r\n%s" $tmp_body $msg]
    set filepath ""
}


set msg [mime::initialize -canonical text/plain -string $tmp_body]
mime::setheader $msg Subject $subject

if { $filepath == "" } {

    if { $cc != "" } {

        smtp::sendmessage $msg -recipients $recipient -servers $server -ports $port  -header [list From $sender]  -header [list To $recipient]  -header [list cc $cc]
    
    } else { 
    
        smtp::sendmessage $msg -recipients $recipient -servers $server -ports $port  -header [list From $sender]  -header [list To $recipient]
    
    }
    
    mime::finalize $msg -subordinates all
    
} else {
 
    set attachment [mime::initialize -canonical text/plain -file $filepath ]

    set total [mime::initialize -canonical multipart/mixed -parts [list $msg $attachment]]
    mime::setheader $total Subject $subject

    if { $cc != "" } {

        smtp::sendmessage $total -recipients $recipient -servers $server -ports $port  -header [list From $sender]  -header [list To $recipient]  -header [list cc $cc]
    
    } else {
    
        smtp::sendmessage $total -recipients $recipient -servers $server -ports $port  -header [list From $sender]  -header [list To $recipient]  
    
    }

    mime::finalize $total -subordinates all
    
}
    
}
#############################################################################
## Procedure:  TEMPLATE_SEND_EMAIL

proc ::TEMPLATE_SEND_EMAIL {} {
global widget

set sender "ngukim"
set recipient "namgu.kim@amkor.co.kr"
set cc ""
set subject "test"

set body "123"
lappend body "456"

set filepath "c:/scops/scops.config"


FUNC_SEND_EMAIL $sender $recipient $cc $subject $body $filepath
}
#############################################################################
## Procedure:  TCL_LIB_BASE64

proc ::TCL_LIB_BASE64 {} {
global widget

# base64.tcl --
#
# Encode/Decode base64 for a string
# Stephen Uhler / Brent Welch (c) 1997 Sun Microsystems
# The decoder was done for exmh by Chris Garrigues
#
# Copyright (c) 1998-2000 by Ajuba Solutions.
# See the file "license.terms" for information on usage and redistribution
# of this file, and for a DISCLAIMER OF ALL WARRANTIES.
# 
# RCS: @(#) $Id: base64.tcl,v 1.29 2008/05/28 17:34:31 andreas_kupries Exp $

# Version 1.0   implemented Base64_Encode, Base64_Decode
# Version 2.0   uses the base64 namespace
# Version 2.1   fixes various decode bugs and adds options to encode
# Version 2.2   is much faster, Tcl8.0 compatible
# Version 2.2.1 bugfixes
# Version 2.2.2 bugfixes
# Version 2.3   bugfixes and extended to support Trf

# @mdgen EXCLUDE: base64c.tcl

package require Tcl 8.2
namespace eval ::base64 {
    namespace export encode decode
}

if {![catch {package require Trf 2.0}]} {
    # Trf is available, so implement the functionality provided here
    # in terms of calls to Trf for speed.

    # ::base64::encode --
    #
    #	Base64 encode a given string.
    #
    # Arguments:
    #	args	?-maxlen maxlen? ?-wrapchar wrapchar? string
    #	
    #		If maxlen is 0, the output is not wrapped.
    #
    # Results:
    #	A Base64 encoded version of $string, wrapped at $maxlen characters
    #	by $wrapchar.
    
    proc ::base64::encode {args} {
	# Set the default wrapchar and maximum line length to match
	# the settings for MIME encoding (RFC 3548, RFC 2045). These
	# are the settings used by Trf as well. Various RFCs allow for
	# different wrapping characters and wraplengths, so these may
	# be overridden by command line options.
	set wrapchar "\n"
	set maxlen 76

	if { [llength $args] == 0 } {
	    error "wrong # args: should be \"[lindex [info level 0] 0] ?-maxlen maxlen? ?-wrapchar wrapchar? string\""
	}

	set optionStrings [list "-maxlen" "-wrapchar"]
	for {set i 0} {$i < [llength $args] - 1} {incr i} {
	    set arg [lindex $args $i]
	    set index [lsearch -glob $optionStrings "${arg}*"]
	    if { $index == -1 } {
		error "unknown option \"$arg\": must be -maxlen or -wrapchar"
	    }
	    incr i
	    if { $i >= [llength $args] - 1 } {
		error "value for \"$arg\" missing"
	    }
	    set val [lindex $args $i]

	    # The name of the variable to assign the value to is extracted
	    # from the list of known options, all of which have an
	    # associated variable of the same name as the option without
	    # a leading "-". The [string range] command is used to strip
	    # of the leading "-" from the name of the option.
	    #
	    # FRINK: nocheck
	    set [string range [lindex $optionStrings $index] 1 end] $val
	}
    
	# [string is] requires Tcl8.2; this works with 8.0 too
	if {[catch {expr {$maxlen % 2}}]} {
	    return -code error "expected integer but got \"$maxlen\""
	} elseif {$maxlen < 0} {
	    return -code error "expected positive integer but got \"$maxlen\""
	}

	set string [lindex $args end]
	set result [::base64 -mode encode -- $string]

	# Trf's encoder implicitly uses the settings -maxlen 76,
	# -wrapchar \n for its output. We may have to reflow this for
	# the settings chosen by the user. A second difference is that
	# Trf closes the output with the wrap char sequence,
	# always. The code here doesn't. Therefore 'trimright' is
	# needed in the fast cases.

	if {($maxlen == 76) && [string equal $wrapchar \n]} {
	    # Both maxlen and wrapchar are identical to Trf's
	    # settings. This is the super-fast case, because nearly
	    # nothing has to be done. Only thing to do is strip a
	    # terminating wrapchar.
	    set result [string trimright $result]
	} elseif {$maxlen == 76} {
	    # wrapchar has to be different here, length is the
	    # same. We can use 'string map' to transform the wrap
	    # information.
	    set result [string map [list \n $wrapchar]  [string trimright $result]]
	} elseif {$maxlen == 0} {
	    # Have to reflow the output to no wrapping. Another fast
	    # case using only 'string map'. 'trimright' is not needed
	    # here.

	    set result [string map [list \n ""] $result]
	} else {
	    # Have to reflow the output from 76 to the chosen maxlen,
	    # and possibly change the wrap sequence as well.

	    # Note: After getting rid of the old wrap sequence we
	    # extract the relevant segments from the string without
	    # modifying the string. Modification, i.e. removal of the
	    # processed part, means 'shifting down characters in
	    # memory', making the algorithm O(n^2). By avoiding the
	    # modification we stay in O(n).
	    
	    set result [string map [list \n ""] $result]
	    set l [expr {[string length $result]-$maxlen}]
	    for {set off 0} {$off < $l} {incr off $maxlen} {
		append res [string range $result $off [expr {$off+$maxlen-1}]] $wrapchar
	    }
	    append res [string range $result $off end]
	    set result $res
	}

	return $result
    }

    # ::base64::decode --
    #
    #	Base64 decode a given string.
    #
    # Arguments:
    #	string	The string to decode.  Characters not in the base64
    #		alphabet are ignored (e.g., newlines)
    #
    # Results:
    #	The decoded value.

    proc ::base64::decode {string} {
	regsub -all {\s} $string {} string
	::base64 -mode decode -- $string
    }

} else {
    # Without Trf use a pure tcl implementation

    namespace eval base64 {
	variable base64 {}
	variable base64_en {}

	# We create the auxiliary array base64_tmp, it will be unset later.

	set i 0
	foreach char {A B C D E F G H I J K L M N O P Q R S T U V W X Y Z  a b c d e f g h i j k l m n o p q r s t u v w x y z  0 1 2 3 4 5 6 7 8 9 + /} {
	    set base64_tmp($char) $i
	    lappend base64_en $char
	    incr i
	}

	#
	# Create base64 as list: to code for instance C<->3, specify
	# that [lindex $base64 67] be 3 (C is 67 in ascii); non-coded
	# ascii chars get a {}. we later use the fact that lindex on a
	# non-existing index returns {}, and that [expr {} < 0] is true
	#

	# the last ascii char is 'z'
	scan z %c len
	for {set i 0} {$i <= $len} {incr i} {
	    set char [format %c $i]
	    set val {}
	    if {[info exists base64_tmp($char)]} {
		set val $base64_tmp($char)
	    } else {
		set val {}
	    }
	    lappend base64 $val
	}

	# code the character "=" as -1; used to signal end of message
	scan = %c i
	set base64 [lreplace $base64 $i $i -1]

	# remove unneeded variables
	unset base64_tmp i char len val

	namespace export encode decode
    }

    # ::base64::encode --
    #
    #	Base64 encode a given string.
    #
    # Arguments:
    #	args	?-maxlen maxlen? ?-wrapchar wrapchar? string
    #	
    #		If maxlen is 0, the output is not wrapped.
    #
    # Results:
    #	A Base64 encoded version of $string, wrapped at $maxlen characters
    #	by $wrapchar.
    
    proc ::base64::encode {args} {
	set base64_en $::base64::base64_en
	
	# Set the default wrapchar and maximum line length to match
	# the settings for MIME encoding (RFC 3548, RFC 2045). These
	# are the settings used by Trf as well. Various RFCs allow for
	# different wrapping characters and wraplengths, so these may
	# be overridden by command line options.
	set wrapchar "\n"
	set maxlen 76

	if { [llength $args] == 0 } {
	    error "wrong # args: should be \"[lindex [info level 0] 0] ?-maxlen maxlen? ?-wrapchar wrapchar? string\""
	}

	set optionStrings [list "-maxlen" "-wrapchar"]
	for {set i 0} {$i < [llength $args] - 1} {incr i} {
	    set arg [lindex $args $i]
	    set index [lsearch -glob $optionStrings "${arg}*"]
	    if { $index == -1 } {
		error "unknown option \"$arg\": must be -maxlen or -wrapchar"
	    }
	    incr i
	    if { $i >= [llength $args] - 1 } {
		error "value for \"$arg\" missing"
	    }
	    set val [lindex $args $i]

	    # The name of the variable to assign the value to is extracted
	    # from the list of known options, all of which have an
	    # associated variable of the same name as the option without
	    # a leading "-". The [string range] command is used to strip
	    # of the leading "-" from the name of the option.
	    #
	    # FRINK: nocheck
	    set [string range [lindex $optionStrings $index] 1 end] $val
	}
    
	# [string is] requires Tcl8.2; this works with 8.0 too
	if {[catch {expr {$maxlen % 2}}]} {
	    return -code error "expected integer but got \"$maxlen\""
	} elseif {$maxlen < 0} {
	    return -code error "expected positive integer but got \"$maxlen\""
	}

	set string [lindex $args end]

	set result {}
	set state 0
	set length 0


	# Process the input bytes 3-by-3

	binary scan $string c* X

	foreach {x y z} $X {
	    ADD [lindex $base64_en [expr {($x >>2) & 0x3F}]]
	    if {$y != {}} {
		ADD [lindex $base64_en [expr {(($x << 4) & 0x30) | (($y >> 4) & 0xF)}]]
		if {$z != {}} {
		    ADD [lindex $base64_en [expr {(($y << 2) & 0x3C) | (($z >> 6) & 0x3)}]]
		    ADD [lindex $base64_en [expr {($z & 0x3F)}]]
		} else {
		    set state 2
		    break
		}
	    } else {
		set state 1
		break
	    }
	}
	if {$state == 1} {
	    ADD [lindex $base64_en [expr {(($x << 4) & 0x30)}]]
	    ADD =
	    ADD =
	} elseif {$state == 2} {
	    ADD [lindex $base64_en [expr {(($y << 2) & 0x3C)}]]
	    ADD =
	}
	return $result
    }

    proc ::base64::ADD {x} {
	# The line length check is always done before appending so
	# that we don't get an extra newline if the output is a
	# multiple of $maxlen chars long.

	upvar 1 maxlen maxlen length length result result wrapchar wrapchar
	if {$maxlen && $length >= $maxlen} {
	    append result $wrapchar
	    set length 0
	}
	append result $x
	incr length
	return
    }

    # ::base64::decode --
    #
    #	Base64 decode a given string.
    #
    # Arguments:
    #	string	The string to decode.  Characters not in the base64
    #		alphabet are ignored (e.g., newlines)
    #
    # Results:
    #	The decoded value.

    proc ::base64::decode {string} {
	if {[string length $string] == 0} {return ""}

	set base64 $::base64::base64
	set output "" ; # Fix for [Bug 821126]

	binary scan $string c* X
	foreach x $X {
	    set bits [lindex $base64 $x]
	    if {$bits >= 0} {
		if {[llength [lappend nums $bits]] == 4} {
		    foreach {v w z y} $nums break
		    set a [expr {($v << 2) | ($w >> 4)}]
		    set b [expr {(($w & 0xF) << 4) | ($z >> 2)}]
		    set c [expr {(($z & 0x3) << 6) | $y}]
		    append output [binary format ccc $a $b $c]
		    set nums {}
		}		
	    } elseif {$bits == -1} {
		# = indicates end of data.  Output whatever chars are left.
		# The encoding algorithm dictates that we can only have 1 or 2
		# padding characters.  If x=={}, we have 12 bits of input 
		# (enough for 1 8-bit output).  If x!={}, we have 18 bits of
		# input (enough for 2 8-bit outputs).
		
		foreach {v w z} $nums break
		set a [expr {($v << 2) | (($w & 0x30) >> 4)}]
		if {$z == {}} {
		    append output [binary format c $a ]
		} else {
		    set b [expr {(($w & 0xF) << 4) | (($z & 0x3C) >> 2)}]
		    append output [binary format cc $a $b]
		}		
		break
	    } else {
		# RFC 2045 says that line breaks and other characters not part
		# of the Base64 alphabet must be ignored, and that the decoder
		# can optionally emit a warning or reject the message.  We opt
		# not to do so, but to just ignore the character. 
		continue
	    }
	}
	return $output
    }
}

package provide base64 2.4
}
#############################################################################
## Procedure:  TCL_LIB_MD5

proc ::TCL_LIB_MD5 {} {
global widget

##################################################
#
# md5.tcl - MD5 in Tcl
# Author: Don Libes <libes@nist.gov>, July 1999
# Version 1.2.0
#
# MD5  defined by RFC 1321, "The MD5 Message-Digest Algorithm"
# HMAC defined by RFC 2104, "Keyed-Hashing for Message Authentication"
#
# Most of the comments below come right out of RFC 1321; That's why
# they have such peculiar numbers.  In addition, I have retained
# original syntax, bugs in documentation (yes, really), etc. from the
# RFC.  All remaining bugs are mine.
#
# HMAC implementation by D. J. Hagberg <dhagberg@millibits.com> and
# is based on C code in RFC 2104.
#
# For more info, see: http://expect.nist.gov/md5pure
#
# - Don
#
# Modified by Miguel Sofer to use inlines and simple variables
##################################################

# @mdgen EXCLUDE: md5c.tcl

package require Tcl 8.2
namespace eval ::md5 {
}

if {![catch {package require Trf 2.0}] && ![catch {::md5 -- test}]} {
    # Trf is available, so implement the functionality provided here
    # in terms of calls to Trf for speed.

    proc ::md5::md5 {msg} {
	string tolower [::hex -mode encode -- [::md5 -- $msg]]
    }

    # hmac: hash for message authentication

    # MD5 of Trf and MD5 as defined by this package have slightly
    # different results. Trf returns the digest in binary, here we get
    # it as hex-string. In the computation of the HMAC the latter
    # requires back conversion into binary in some places. With Trf we
    # can use omit these.

    proc ::md5::hmac {key text} {
	# if key is longer than 64 bytes, reset it to MD5(key).  If shorter, 
	# pad it out with null (\x00) chars.
	set keyLen [string length $key]
	if {$keyLen > 64} {
	    #old: set key [binary format H32 [md5 $key]]
	    set key [::md5 -- $key]
	    set keyLen [string length $key]
	}
    
	# ensure the key is padded out to 64 chars with nulls.
	set padLen [expr {64 - $keyLen}]
	append key [binary format "a$padLen" {}]

	# Split apart the key into a list of 16 little-endian words
	binary scan $key i16 blocks

	# XOR key with ipad and opad values
	set k_ipad {}
	set k_opad {}
	foreach i $blocks {
	    append k_ipad [binary format i [expr {$i ^ 0x36363636}]]
	    append k_opad [binary format i [expr {$i ^ 0x5c5c5c5c}]]
	}
    
	# Perform inner md5, appending its results to the outer key
	append k_ipad $text
	#old: append k_opad [binary format H* [md5 $k_ipad]]
	append k_opad [::md5 -- $k_ipad]

	# Perform outer md5
	#old: md5 $k_opad
	string tolower [::hex -mode encode -- [::md5 -- $k_opad]]
    }

} else {
    # Without Trf use the all-tcl implementation by Don Libes.

    # T will be inlined after the definition of md5body

    # test md5
    #
    # This proc is not necessary during runtime and may be omitted if you
    # are simply inserting this file into a production program.
    #
    proc ::md5::test {} {
	foreach {msg expected} {
	    ""
	    "d41d8cd98f00b204e9800998ecf8427e"
	    "a"
	    "0cc175b9c0f1b6a831c399e269772661"
	    "abc"
	    "900150983cd24fb0d6963f7d28e17f72"
	    "message digest"
	    "f96b697d7cb7938d525a2f31aaf161d0"
	    "abcdefghijklmnopqrstuvwxyz"
	    "c3fcd3d76192e4007dfb496cca67e13b"
	    "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"
	    "d174ab98d277d9f5a5611c2c9f419d9f"
	    "12345678901234567890123456789012345678901234567890123456789012345678901234567890"
	    "57edf4a22be3c955ac49da2e2107b67a"
	} {
	    puts "testing: md5 \"$msg\""
	    set computed [md5 $msg]
	    puts "expected: $expected"
	    puts "computed: $computed"
	    if {0 != [string compare $computed $expected]} {
		puts "FAILED"
	    } else {
		puts "SUCCEEDED"
	    }
	}
    }

    # time md5
    #
    # This proc is not necessary during runtime and may be omitted if you
    # are simply inserting this file into a production program.
    #
    proc ::md5::time {} {
	foreach len {10 50 100 500 1000 5000 10000} {
	    set time [::time {md5 [format %$len.0s ""]} 100]
	    set msec [lindex $time 0]
	    puts "input length $len: [expr {$msec/1000}] milliseconds per interation"
	}
    }

    #
    # We just define the body of md5pure::md5 here; later we
    # regsub to inline a few function calls for speed
    #

    set ::md5::md5body {

	#
	# 3.1 Step 1. Append Padding Bits
	#

	set msgLen [string length $msg]

	set padLen [expr {56 - $msgLen%64}]
	if {$msgLen % 64 > 56} {
	    incr padLen 64
	}

	# pad even if no padding required
	if {$padLen == 0} {
	    incr padLen 64
	}

	# append single 1b followed by 0b's
	append msg [binary format "a$padLen" \200]

	#
	# 3.2 Step 2. Append Length
	#

	# RFC doesn't say whether to use little- or big-endian
	# code demonstrates little-endian
	# This step limits our input to size 2^32b or 2^24B
	append msg [binary format "i1i1" [expr {8*$msgLen}] 0]
	
	#
	# 3.3 Step 3. Initialize MD Buffer
	#

	set A [expr 0x67452301]
	set B [expr 0xefcdab89]
	set C [expr 0x98badcfe]
	set D [expr 0x10325476]

	#
	# 3.4 Step 4. Process Message in 16-Word Blocks
	#

	# process each 16-word block
	# RFC doesn't say whether to use little- or big-endian
	# code says little-endian
	binary scan $msg i* blocks

	# loop over the message taking 16 blocks at a time

	foreach {X0 X1 X2 X3 X4 X5 X6 X7 X8 X9 X10 X11 X12 X13 X14 X15} $blocks {

	    # Save A as AA, B as BB, C as CC, and D as DD.
	    set AA $A
	    set BB $B
	    set CC $C
	    set DD $D

	    # Round 1.
	    # Let [abcd k s i] denote the operation
	    #      a = b + ((a + F(b,c,d) + X[k] + T[i]) <<< s).
	    # [ABCD  0  7  1]  [DABC  1 12  2]  [CDAB  2 17  3]  [BCDA  3 22  4]
	    set A [expr {$B + [<<< [expr {$A + [F $B $C $D] + $X0  + $T01}]  7]}]
	    set D [expr {$A + [<<< [expr {$D + [F $A $B $C] + $X1  + $T02}] 12]}]
	    set C [expr {$D + [<<< [expr {$C + [F $D $A $B] + $X2  + $T03}] 17]}]
	    set B [expr {$C + [<<< [expr {$B + [F $C $D $A] + $X3  + $T04}] 22]}]
	    # [ABCD  4  7  5]  [DABC  5 12  6]  [CDAB  6 17  7]  [BCDA  7 22  8]
	    set A [expr {$B + [<<< [expr {$A + [F $B $C $D] + $X4  + $T05}]  7]}]
	    set D [expr {$A + [<<< [expr {$D + [F $A $B $C] + $X5  + $T06}] 12]}]
	    set C [expr {$D + [<<< [expr {$C + [F $D $A $B] + $X6  + $T07}] 17]}]
	    set B [expr {$C + [<<< [expr {$B + [F $C $D $A] + $X7  + $T08}] 22]}]
	    # [ABCD  8  7  9]  [DABC  9 12 10]  [CDAB 10 17 11]  [BCDA 11 22 12]
	    set A [expr {$B + [<<< [expr {$A + [F $B $C $D] + $X8  + $T09}]  7]}]
	    set D [expr {$A + [<<< [expr {$D + [F $A $B $C] + $X9  + $T10}] 12]}]
	    set C [expr {$D + [<<< [expr {$C + [F $D $A $B] + $X10 + $T11}] 17]}]
	    set B [expr {$C + [<<< [expr {$B + [F $C $D $A] + $X11 + $T12}] 22]}]
	    # [ABCD 12  7 13]  [DABC 13 12 14]  [CDAB 14 17 15]  [BCDA 15 22 16]
	    set A [expr {$B + [<<< [expr {$A + [F $B $C $D] + $X12 + $T13}]  7]}]
	    set D [expr {$A + [<<< [expr {$D + [F $A $B $C] + $X13 + $T14}] 12]}]
	    set C [expr {$D + [<<< [expr {$C + [F $D $A $B] + $X14 + $T15}] 17]}]
	    set B [expr {$C + [<<< [expr {$B + [F $C $D $A] + $X15 + $T16}] 22]}]

	    # Round 2.
	    # Let [abcd k s i] denote the operation
	    #      a = b + ((a + G(b,c,d) + X[k] + T[i]) <<< s).
	    # Do the following 16 operations.
	    # [ABCD  1  5 17]  [DABC  6  9 18]  [CDAB 11 14 19]  [BCDA  0 20 20]
	    set A [expr {$B + [<<< [expr {$A + [G $B $C $D] + $X1  + $T17}]  5]}]
	    set D [expr {$A + [<<< [expr {$D + [G $A $B $C] + $X6  + $T18}]  9]}]
	    set C [expr {$D + [<<< [expr {$C + [G $D $A $B] + $X11 + $T19}] 14]}]
	    set B [expr {$C + [<<< [expr {$B + [G $C $D $A] + $X0  + $T20}] 20]}]
	    # [ABCD  5  5 21]  [DABC 10  9 22]  [CDAB 15 14 23]  [BCDA  4 20 24]
	    set A [expr {$B + [<<< [expr {$A + [G $B $C $D] + $X5  + $T21}]  5]}]
	    set D [expr {$A + [<<< [expr {$D + [G $A $B $C] + $X10 + $T22}]  9]}]
	    set C [expr {$D + [<<< [expr {$C + [G $D $A $B] + $X15 + $T23}] 14]}]
	    set B [expr {$C + [<<< [expr {$B + [G $C $D $A] + $X4  + $T24}] 20]}]
	    # [ABCD  9  5 25]  [DABC 14  9 26]  [CDAB  3 14 27]  [BCDA  8 20 28]
	    set A [expr {$B + [<<< [expr {$A + [G $B $C $D] + $X9  + $T25}]  5]}]
	    set D [expr {$A + [<<< [expr {$D + [G $A $B $C] + $X14 + $T26}]  9]}]
	    set C [expr {$D + [<<< [expr {$C + [G $D $A $B] + $X3  + $T27}] 14]}]
	    set B [expr {$C + [<<< [expr {$B + [G $C $D $A] + $X8  + $T28}] 20]}]
	    # [ABCD 13  5 29]  [DABC  2  9 30]  [CDAB  7 14 31]  [BCDA 12 20 32]
	    set A [expr {$B + [<<< [expr {$A + [G $B $C $D] + $X13 + $T29}]  5]}]
	    set D [expr {$A + [<<< [expr {$D + [G $A $B $C] + $X2  + $T30}]  9]}]
	    set C [expr {$D + [<<< [expr {$C + [G $D $A $B] + $X7  + $T31}] 14]}]
	    set B [expr {$C + [<<< [expr {$B + [G $C $D $A] + $X12 + $T32}] 20]}]

	    # Round 3.
	    # Let [abcd k s t] [sic] denote the operation
	    #     a = b + ((a + H(b,c,d) + X[k] + T[i]) <<< s).
	    # Do the following 16 operations.
	    # [ABCD  5  4 33]  [DABC  8 11 34]  [CDAB 11 16 35]  [BCDA 14 23 36]
	    set A [expr {$B + [<<< [expr {$A + [H $B $C $D] + $X5  + $T33}]  4]}]
	    set D [expr {$A + [<<< [expr {$D + [H $A $B $C] + $X8  + $T34}] 11]}]
	    set C [expr {$D + [<<< [expr {$C + [H $D $A $B] + $X11 + $T35}] 16]}]
	    set B [expr {$C + [<<< [expr {$B + [H $C $D $A] + $X14 + $T36}] 23]}]
	    # [ABCD  1  4 37]  [DABC  4 11 38]  [CDAB  7 16 39]  [BCDA 10 23 40]
	    set A [expr {$B + [<<< [expr {$A + [H $B $C $D] + $X1  + $T37}]  4]}]
	    set D [expr {$A + [<<< [expr {$D + [H $A $B $C] + $X4  + $T38}] 11]}]
	    set C [expr {$D + [<<< [expr {$C + [H $D $A $B] + $X7  + $T39}] 16]}]
	    set B [expr {$C + [<<< [expr {$B + [H $C $D $A] + $X10 + $T40}] 23]}]
	    # [ABCD 13  4 41]  [DABC  0 11 42]  [CDAB  3 16 43]  [BCDA  6 23 44]
	    set A [expr {$B + [<<< [expr {$A + [H $B $C $D] + $X13 + $T41}]  4]}]
	    set D [expr {$A + [<<< [expr {$D + [H $A $B $C] + $X0  + $T42}] 11]}]
	    set C [expr {$D + [<<< [expr {$C + [H $D $A $B] + $X3  + $T43}] 16]}]
	    set B [expr {$C + [<<< [expr {$B + [H $C $D $A] + $X6  + $T44}] 23]}]
	    # [ABCD  9  4 45]  [DABC 12 11 46]  [CDAB 15 16 47]  [BCDA  2 23 48]
	    set A [expr {$B + [<<< [expr {$A + [H $B $C $D] + $X9  + $T45}]  4]}]
	    set D [expr {$A + [<<< [expr {$D + [H $A $B $C] + $X12 + $T46}] 11]}]
	    set C [expr {$D + [<<< [expr {$C + [H $D $A $B] + $X15 + $T47}] 16]}]
	    set B [expr {$C + [<<< [expr {$B + [H $C $D $A] + $X2  + $T48}] 23]}]

	    # Round 4.
	    # Let [abcd k s t] [sic] denote the operation
	    #     a = b + ((a + I(b,c,d) + X[k] + T[i]) <<< s).
	    # Do the following 16 operations.
	    # [ABCD  0  6 49]  [DABC  7 10 50]  [CDAB 14 15 51]  [BCDA  5 21 52]
	    set A [expr {$B + [<<< [expr {$A + [I $B $C $D] + $X0  + $T49}]  6]}]
	    set D [expr {$A + [<<< [expr {$D + [I $A $B $C] + $X7  + $T50}] 10]}]
	    set C [expr {$D + [<<< [expr {$C + [I $D $A $B] + $X14 + $T51}] 15]}]
	    set B [expr {$C + [<<< [expr {$B + [I $C $D $A] + $X5  + $T52}] 21]}]
	    # [ABCD 12  6 53]  [DABC  3 10 54]  [CDAB 10 15 55]  [BCDA  1 21 56]
	    set A [expr {$B + [<<< [expr {$A + [I $B $C $D] + $X12 + $T53}]  6]}]
	    set D [expr {$A + [<<< [expr {$D + [I $A $B $C] + $X3  + $T54}] 10]}]
	    set C [expr {$D + [<<< [expr {$C + [I $D $A $B] + $X10 + $T55}] 15]}]
	    set B [expr {$C + [<<< [expr {$B + [I $C $D $A] + $X1  + $T56}] 21]}]
	    # [ABCD  8  6 57]  [DABC 15 10 58]  [CDAB  6 15 59]  [BCDA 13 21 60]
	    set A [expr {$B + [<<< [expr {$A + [I $B $C $D] + $X8  + $T57}]  6]}]
	    set D [expr {$A + [<<< [expr {$D + [I $A $B $C] + $X15 + $T58}] 10]}]
	    set C [expr {$D + [<<< [expr {$C + [I $D $A $B] + $X6  + $T59}] 15]}]
	    set B [expr {$C + [<<< [expr {$B + [I $C $D $A] + $X13 + $T60}] 21]}]
	    # [ABCD  4  6 61]  [DABC 11 10 62]  [CDAB  2 15 63]  [BCDA  9 21 64]
	    set A [expr {$B + [<<< [expr {$A + [I $B $C $D] + $X4  + $T61}]  6]}]
	    set D [expr {$A + [<<< [expr {$D + [I $A $B $C] + $X11 + $T62}] 10]}]
	    set C [expr {$D + [<<< [expr {$C + [I $D $A $B] + $X2  + $T63}] 15]}]
	    set B [expr {$C + [<<< [expr {$B + [I $C $D $A] + $X9  + $T64}] 21]}]

	    # Then perform the following additions. (That is increment each
	    #   of the four registers by the value it had before this block
	    #   was started.)
	    incr A $AA
	    incr B $BB
	    incr C $CC
	    incr D $DD
	}
	# 3.5 Step 5. Output

	# ... begin with the low-order byte of A, and end with the high-order byte
	# of D.

	return [bytes $A][bytes $B][bytes $C][bytes $D]
    }

    #
    # Here we inline/regsub the functions F, G, H, I and <<< 
    #

    namespace eval ::md5 {
	#proc md5pure::F {x y z} {expr {(($x & $y) | ((~$x) & $z))}}
	regsub -all -- {\[ *F +(\$.) +(\$.) +(\$.) *\]} $md5body {((\1 \& \2) | ((~\1) \& \3))} md5body

	#proc md5pure::G {x y z} {expr {(($x & $z) | ($y & (~$z)))}}
	regsub -all -- {\[ *G +(\$.) +(\$.) +(\$.) *\]} $md5body {((\1 \& \3) | (\2 \& (~\3)))} md5body

	#proc md5pure::H {x y z} {expr {$x ^ $y ^ $z}}
	regsub -all -- {\[ *H +(\$.) +(\$.) +(\$.) *\]} $md5body {(\1 ^ \2 ^ \3)} md5body

	#proc md5pure::I {x y z} {expr {$y ^ ($x | (~$z))}}
	regsub -all -- {\[ *I +(\$.) +(\$.) +(\$.) *\]} $md5body {(\2 ^ (\1 | (~\3)))} md5body

	# bitwise left-rotate
	if {0} {
	    proc md5pure::<<< {x i} {
		# This works by bitwise-ORing together right piece and left
		# piece so that the (original) right piece becomes the left
		# piece and vice versa.
		#
		# The (original) right piece is a simple left shift.
		# The (original) left piece should be a simple right shift
		# but Tcl does sign extension on right shifts so we
		# shift it 1 bit, mask off the sign, and finally shift
		# it the rest of the way.
		
		# expr {($x << $i) | ((($x >> 1) & 0x7fffffff) >> (31-$i))}

		#
		# New version, faster when inlining
		# We replace inline (computing at compile time):
		#   R$i -> (32 - $i)
		#   S$i -> (0x7fffffff >> (31-$i))
		#

		expr { ($x << $i) | (($x >> [set R$i]) & [set S$i])}
	    }
	}
	# inline <<<
	regsub -all -- {\[ *<<< +\[ *expr +({[^\}]*})\] +([0-9]+) *\]} $md5body {(([set x [expr \1]] << \2) |  (($x >> R\2) \& S\2))} md5body

	# now replace the R and S
	set map {}
	foreach i { 
	    7 12 17 22
	    5  9 14 20
	    4 11 16 23
	    6 10 15 21 
	} {
	    lappend map R$i [expr {32 - $i}] S$i [expr {0x7fffffff >> (31-$i)}]
	}
	
	# inline the values of T
	foreach  tName {
	    T01 T02 T03 T04 T05 T06 T07 T08 T09 T10 
	    T11 T12 T13 T14 T15 T16 T17 T18 T19 T20 
	    T21 T22 T23 T24 T25 T26 T27 T28 T29 T30 
	    T31 T32 T33 T34 T35 T36 T37 T38 T39 T40 
	    T41 T42 T43 T44 T45 T46 T47 T48 T49 T50 
	    T51 T52 T53 T54 T55 T56 T57 T58 T59 T60 
	    T61 T62 T63 T64 }  tVal {
	    0xd76aa478 0xe8c7b756 0x242070db 0xc1bdceee
	    0xf57c0faf 0x4787c62a 0xa8304613 0xfd469501
	    0x698098d8 0x8b44f7af 0xffff5bb1 0x895cd7be
	    0x6b901122 0xfd987193 0xa679438e 0x49b40821

	    0xf61e2562 0xc040b340 0x265e5a51 0xe9b6c7aa
	    0xd62f105d 0x2441453  0xd8a1e681 0xe7d3fbc8
	    0x21e1cde6 0xc33707d6 0xf4d50d87 0x455a14ed
	    0xa9e3e905 0xfcefa3f8 0x676f02d9 0x8d2a4c8a

	    0xfffa3942 0x8771f681 0x6d9d6122 0xfde5380c
	    0xa4beea44 0x4bdecfa9 0xf6bb4b60 0xbebfbc70
	    0x289b7ec6 0xeaa127fa 0xd4ef3085 0x4881d05
	    0xd9d4d039 0xe6db99e5 0x1fa27cf8 0xc4ac5665

	    0xf4292244 0x432aff97 0xab9423a7 0xfc93a039
	    0x655b59c3 0x8f0ccc92 0xffeff47d 0x85845dd1
	    0x6fa87e4f 0xfe2ce6e0 0xa3014314 0x4e0811a1
	    0xf7537e82 0xbd3af235 0x2ad7d2bb 0xeb86d391
	} {
	    lappend map \$$tName $tVal
	}
	set md5body [string map $map $md5body]
	

	# Finally, define the proc
	proc md5 {msg} $md5body

	# unset auxiliary variables
	unset md5body tName tVal map
    }

    proc ::md5::byte0 {i} {expr {0xff & $i}}
    proc ::md5::byte1 {i} {expr {(0xff00 & $i) >> 8}}
    proc ::md5::byte2 {i} {expr {(0xff0000 & $i) >> 16}}
    proc ::md5::byte3 {i} {expr {((0xff000000 & $i) >> 24) & 0xff}}

    proc ::md5::bytes {i} {
	format %0.2x%0.2x%0.2x%0.2x [byte0 $i] [byte1 $i] [byte2 $i] [byte3 $i]
    }

    # hmac: hash for message authentication
    proc ::md5::hmac {key text} {
	# if key is longer than 64 bytes, reset it to MD5(key).  If shorter, 
	# pad it out with null (\x00) chars.
	set keyLen [string length $key]
	if {$keyLen > 64} {
	    set key [binary format H32 [md5 $key]]
	    set keyLen [string length $key]
	}

	# ensure the key is padded out to 64 chars with nulls.
	set padLen [expr {64 - $keyLen}]
	append key [binary format "a$padLen" {}]
	
	# Split apart the key into a list of 16 little-endian words
	binary scan $key i16 blocks

	# XOR key with ipad and opad values
	set k_ipad {}
	set k_opad {}
	foreach i $blocks {
	    append k_ipad [binary format i [expr {$i ^ 0x36363636}]]
	    append k_opad [binary format i [expr {$i ^ 0x5c5c5c5c}]]
	}
    
	# Perform inner md5, appending its results to the outer key
	append k_ipad $text
	append k_opad [binary format H* [md5 $k_ipad]]

	# Perform outer md5
	md5 $k_opad
    }
}

package provide md5 1.4.4
}
#############################################################################
## Procedure:  FUNC_SEND_DEBUG

proc ::FUNC_SEND_DEBUG {} {
global widget

set sender "ngukim"
set recipient "namgu.kim@amkor.co.kr"
set cc ""

global g_hostname

set subject "SCOPS DEBUG - $g_hostname"

set body "SCOPS_DEBUG_TRACKING!"

global g_rootdir
set filepath [file join $g_rootdir [format "%s_%s" $g_hostname "scops_debug.txt"]]
FUNC_SEND_EMAIL $sender $recipient $cc $subject $body $filepath
}
#############################################################################
## Procedure:  ATK_GROUP_START_LOT

proc ::ATK_GROUP_START_LOT {} {
global widget
global g_database
global tcl_platform


### check it started with RFID or not
FUNC_RFID_CHECK

if { [FUNC_RFID_LOTCHECK] != "TRUE" } {
    FD "FUNC_RFID_LOTCHECK : FALSE"
    return "FALSE" 
}

### check HDCP
#FUNC_CHECK_HDCP "CHECK"


if { [FUNC_CHECK_TPGM] != "TRUE" } {
    FD "FUNC_CHECK_TPGM : FALSE"
    return "FALSE" 
}


    if { [FUNC_CHECK_BOARDKIT_QCT] != "TRUE" } { 
        FD "FUNC_CHECK_BOARDKIT_QCT : FALSE"
        return "FALSE" 
    }

    if { [FUNC_CHECK_BOARDKIT_NONQCT] != "TRUE" } { 
        FD "FUNC_CHECK_BOARDKIT_NONQCT : FALSE"
        return "FALSE" 
    }
    
    if { [FUNC_CHECK_PROBECARD] != "TRUE" } { 
        FD "FUNC_CHECK_PROBE : FALSE"
        return "FALSE" 
    }

    if { [FUNC_CHECK_WIPFLOW] != "TRUE" } { 
        FD "FUNC_CHECK_WIPFLOW : FALSE"
        return "FALSE" 
    }

    if { [FUNC_CHECK_BOARDCORRELATION] != "TRUE" } { 
        FD "FUNC_CHECK_BOARDCORRELATION : FALSE"
        return "FALSE" 
    }
    
    if { [FUNC_CHECK_PROBECORRELATION] != "TRUE" } { 
        FD "FUNC_CHECK_PROBECORRELATION : FALSE"
        return "FALSE" 
    }

    if { [FUNC_CHECK_SOCKETCORRELATION] != "TRUE" } { 
        FD "FUNC_CHECK_SOCKETCORRELATION : FALSE"
        return "FALSE" 
    }

    if { [FUNC_CHECK_TPA] != "TRUE" } {
        FD "FUNC_CHECK_TPA : FALSE"
        return "FALSE" 
    }
    
    if { [FUNC_CHECK_TPMS] != "TRUE" } { 
        FD "FUNC_CHECK_TPMS : FALSE"
        return "FALSE" 
    }
    
    if { [FUNC_CHECK_FULLTEST] != "TRUE" } { 
        FD "FUNC_CHECK_FULLTEST : FALSE"
        return "FALSE" 
    }
    
    if { [FUNC_CHECK_RETEST_HISTORY] != "TRUE" } { 
        FD "FUNC_CHECK_RETEST_HISTORY : FALSE"
        return "FALSE" 
    }

           
    if { [FUNC_CHECK_HARDWARE_INOUT] != "TRUE" } {
        FD "FUNC_CHECK_HARDWARE_INOUT : FALSE" 
        return "FALSE"   
    }
    

### DATASTREAM FOR CATA BIN SOLUTION
FUNC_CHECK_DATASTREAM "STOP"
FUNC_CHECK_DATASTREAM "START"


#if { [FUNC_CHECK_DOWNTIME] != "TRUE" } { 
#    FD "FUNC_CHECK_DOWNTIME : FALSE"
    #return "FALSE" 
#}




#if { [FUNC_CHECK_TPMS] != "TRUE" } {
#    FD "FUNC_CHECK_TPMS : FALSE"
    #return "FALSE" 
#}



#if { [FUNC_CHECK_HANDLERTEMPERATURE] != "TRUE" } {
#    FD "FUNC_CHECK_HANDLERTEMPERATURE : FALSE"
    #return "FALSE" 
#}

#if { [FUNC_CHECK_HANDLERSITEMAP] != "TRUE" } {
#    FD "FUNC_CHECK_HANDLERSITEMAP : FALSE"
    #return "FALSE" 
#}

#if { [FUNC_EXECUTE_APL] != "TRUE" } { puts "FUNC_EXECUTE_APL FALSE"; return "FALSE"  }






###########################################################
### EVE ###################################################


return "TRUE"
}
#############################################################################
## Procedure:  ATK_GROUP_HOSTSTATUS

proc ::ATK_GROUP_HOSTSTATUS {} {
global widget

### check it started with RFID or not
FUNC_RFID_CHECK


### check MA device for T5585
#FUNC_CHECK_MADEVICE

FUNC_CHECK_SWR
FUNC_CHECK_PROBESITEVARIANCE

### check HDCP
#FUNC_CHECK_HDCP "STATUS"



### RFID
FUNC_RFID_REFRESH
FUNC_RFID_CHECK_SOCKETTOUCHDOWN
FUNC_RFID_CHECK_CORETOUCHDOWN
FUNC_RFID_CHECK_PROBETOUCHDOWN "CHECK"



### check Junction Temperature Process
FUNC_CHECK_JUNCTIONTEMPERATURE "START"

###########################################

### execute something from DB
#FUNC_REMOTE_SCOPS


### CATA Bin Solution
FUNC_CHECK_DATASTREAM "CHECK"

### HP83K & HP93K for Probe Bin Solution
FUNC_CHECK_DRL
}
#############################################################################
## Procedure:  ATK_GROUP_SELECT_LOT_LISTBOX

proc ::ATK_GROUP_SELECT_LOT_LISTBOX {} {
global widget


FUNC_DISPLAY_SWR

#### check HDCP
#FUNC_CHECK_HDCP "SET"
}
#############################################################################
## Procedure:  FUNC_VARTEST

proc ::FUNC_VARTEST {} {
global widget

global g_test

set g_test "testabc!"
}
#############################################################################
## Procedure:  test4

proc ::test4 {} {
global widget

package require http

set url "http://10.101.14.181:8080/SmartConsoleWebService/pls/recipe_update/15688,"
set url "http://10.101.203.196:8080/SmartConsoleWebService/pls/recipe_update/15676,E1_A0_PROD_20130618_V2_1_0%202.1.0,N"


FD "url -> $url"

set token [::http::geturl $url]

#upvar #0 $token state

set res [::http::data $token]

FD "res -> $res"

set temp [::http::cleanup $token]
}
#############################################################################
## Procedure:  FUNC_SET_DELIMITER

proc ::FUNC_SET_DELIMITER {} {
global widget

### set column, row delimiter
global g_column_delimiter
set g_column_delimiter ","

global g_cd
set g_cd $g_column_delimiter

global g_row_delimiter
set g_row_delimiter "@"

global g_rd
set g_rd $g_row_delimiter


global g_cd
global g_rd
}
#############################################################################
## Procedure:  FUNC_CREATE_SOCKET

proc ::FUNC_CREATE_SOCKET {host port timeout} {
global widget

global g_timeout_connected
after $timeout {set g_timeout_connected timeout}
set sock [socket -async $host $port]
fileevent $sock w {set g_timeout_connected ok}
vwait g_timeout_connected
fileevent $sock w {}
if { $g_timeout_connected == "timeout" } {
    close $sock
    return "FALSE"
} else {
    return $sock
}
}
#############################################################################
## Procedure:  FUNC_SEND_QRY_ORG

proc ::FUNC_SEND_QRY_ORG {str1} {
global widget
global g_scopsserver
global g_scopsserver123


FD "SEND : $str1"

set g_scopsserver123 "10.121.130.20"

set res ""
if [catch { set sock [socket $g_scopsserver 10333] } err] {
    return ""
    puts "FUNC_SEND_QRY ERROR : $err"
} else {

    if [catch { 
        puts $sock $str1
        flush $sock
    } err] {
        FD "socket puts error"
        return
    }

    while {[gets $sock line] >=0} {
        set res $line
    }
#puts "result : $res"
    close $sock
    
    if { [string match -nocase "*noresult*" [lindex [split $res ","] 0] ] == 1 } {
        set res ""
    }
    
    FD "RECV : $res"
    
    return "$res"
    
}
}
#############################################################################
## Procedure:  FUNC_SEND_QRY_EXCEPTION

proc ::FUNC_SEND_QRY_EXCEPTION {str1} {
global widget
global g_scopsserver
global g_scopsserver123


FD "SEND : $str1"

set g_scopsserver123 "10.121.20.135"

set res ""
if [catch { 

    set sock [FUNC_CREATE_SOCKET $g_scopsserver 10333 1000]
    
    if { $sock == "FALSE" } {
        FD "FUNC_SEND_QRY ERROR : Fail to create socket to the server"
        return "FALSE"
    }
    
} err] {
    return ""
    puts "FUNC_SEND_QRY ERROR : $err"
} else {

    if [catch { 
        puts $sock $str1
        flush $sock
    } err] {
        FD "FUNC_SEND_QRY ERROR : Socket puts error"
        return ""
    }

    while {[gets $sock line] >=0} {
        set res $line
    }
#puts "result : $res"
    close $sock
    
    if { [string match -nocase "*noresult*" [lindex [split $res ","] 0] ] == 1 } {
        set res ""
    }
    
    FD "RECV : $res"
    
    return "$res"
    
}
}
#############################################################################
## Procedure:  FUNC_SEND_QRY

proc ::FUNC_SEND_QRY {str1} {
global widget
global g_scopsserver
global g_scopsserver123

FD "-------------------------------------------"
FD "SEND -> $str1"

set g_scopsserver123 "10.121.20.135"
set g_scopsserverEVE "10.121.11.110"

set socket_title "network_warning"

set res ""
if [catch { set sock [socket $g_scopsserver 10333] } err] {
    
    FUNC_DISPLAY_MESSAGE "open" $socket_title "" "NETWORK IS NOT NORMAL!"
    FD "FUNC_SEND_QRY : SCOKET ERROR -> $err"
    return ""

} else {
    FUNC_DISPLAY_MESSAGE "close" $socket_title "" ""

    if [catch { 
        puts $sock $str1
        flush $sock

        #while {[gets $sock line] >=0} {
        #    set res $line
        #}
        

    } err] {
        FD "socket puts error"
        close $sock
        return ""
    }

#puts "result : $res"
    gets $sock line
    set res $line
    close $sock
    
    if { [string match -nocase "*noresult*" [lindex [split $res ","] 0] ] == 1 } {
        set res ""
    }
       
    set res [string map {"newline" "\n"} $res]
    
    FD "RECV <- [string trim $res]"
    
    FD "-------------------------------------------"
    
    return "$res"
    
}
}
#############################################################################
## Procedure:  FUNC_RFID_COMPARE_LOTS

proc ::FUNC_RFID_COMPARE_LOTS {} {
global widget

global g_rfid_flag
global g_hostname

global g_rfidconformation


set qry "SCOPS,ReadRFID,$g_hostname*"

set res ""
set res [FUNC_SEND_QRY $qry]


if { [lindex [split $res ","] 0] == "FAIL" } {
    #set choice [ tk_messageBox -title "Read RFID Error" -icon warning -message "$res    "]
    return "FALSE"
}

set rfidlotname ""
set rfidlotname [string toupper [lindex [split $res ","] 0]]

set qry_qorvo "SCOPS,CALLSP2,CheckQorvoLot,$g_hostname,$g_rfidconformation*"

set res_qorvo ""
set res_qorvo [FUNC_SEND_QRY $qry_qorvo]
if { [lindex [split $res_qorvo ","] 0] == "YES" } {
    set g_rfidconformation [lindex [split $res_qorvo ","] 1]
}

set g_rfidconformation [string toupper $g_rfidconformation]

if { $rfidlotname == "" } {
     
    set choice [ tk_messageBox -title "Check RFID Lot Error" -icon warning -message "There's no RFID information!   " ]
    set g_rfid_flag "FALSE"
    #FUNC_RFID_INITIALIZE
} elseif { $rfidlotname != $g_rfidconformation } {
   
    set win_title "scops_warning_lot"
    FUNC_DISPLAY_MESSAGE "close" "$win_title" "" ""
    FUNC_DISPLAY_MESSAGE "open" "$win_title" "image,scops_warning_lot.gif" "RFID and Input Lot Number are different!"
   
    set choice [ tk_messageBox -title "Check RFID Lot Error" -icon warning -message "RFID Lot and Input Lot is different!\n\n-RFID : $rfidlotname\n\n-INPUT : $g_rfidconformation" ]
    set g_rfid_flag "FALSE"
    
    FUNC_DISPLAY_MESSAGE "close" "$win_title" "" ""
    
    
    #FUNC_RFID_INITIALIZE      
} else {

    set g_rfid_flag "TRUE"

    global g_lotname
    set g_lotname $rfidlotname
    
    FUNC_RFID_INITIALIZE
    FUNC_RFID_REFRESH

    BTN_SEARCH_LOT ""
    

}

set g_rfidconformation ""
Window hide .top85
}
#############################################################################
## Procedure:  FUNC_RFID_INITIALIZE

proc ::FUNC_RFID_INITIALIZE {} {
global widget

global g_rfidlotname
global g_handler
global g_board
global g_boardno
global g_boardtype
global g_boarddescription

global g_probe
global g_probeno
global g_probedescription

global g_probe_touch
global g_probe_limit
global g_probe_ext

global g_kit
global g_socketcount

global g_socketlist 

global g_prober
global g_pcbboard



set g_rfidlotname ""
set g_handler ""
set g_board ""
set g_boardno ""
set g_boardtype ""
set g_boarddescription ""

set g_probe ""
set g_probeno ""
set g_probedescription ""

set g_probe_touch ""
set g_probe_limit ""
set g_probe_ext ""

set g_kit ""
set g_socketcount ""

set g_socketlist ""

set g_prober ""
set g_pcbboard ""

global g_socketsitenumber

for { set i 1 } { $i<=$g_socketsitenumber } { incr i } {
    
    global g_socket_check$i
    global g_socket$i
    global g_socket_touch$i
    global g_socket_limit$i
    global g_socket_ext$i
    
    global g_core_check$i
    global g_core$i
    global g_core_touch$i
    global g_core_limit$i
    global g_core_ext$i
    
    set g_socket_check$i 0
    set g_socket$i ""
    set g_socket_touch$i ""
    set g_socket_limit$i ""
    set g_socket_ext$i ""
    
    set g_core_check$i 0
    set g_core$i ""
    set g_core_touch$i ""
    set g_core_limit$i ""
    set g_core_ext$i ""
        
}
}
#############################################################################
## Procedure:  FUNC_RFID_REFRESH

proc ::FUNC_RFID_REFRESH {} {
global widget

global g_hostname

global g_rfidlotname
global g_handler
global g_board
global g_boardno
global g_boardtype
global g_kit
global g_operatorid


global g_rfid_flag
if { $g_rfid_flag != "TRUE" } { return }

set qry "SCOPS,ReadRFID,$g_hostname*"

set res ""
set res [FUNC_SEND_QRY $qry]


if { [lindex [split $res ","] 0] == "FAIL" } {
    #set choice [ tk_messageBox -title "Read RFID Error" -icon warning -message "$res    "]
    return "FALSE"
}

#set res "T4U951.0C1000,H-803,BOARD|29-63|1012|VANTAGE  /  VANTAGE 2.1  /  VANTAGE 2.2|,49-102,Q60-34:80634:150000:0|Q60-42:77888:150000:0|Q60-39:77830:150000:0|Q60-40:75762:150000:0|Q60-41:77536:150000:0|Q60-44:76287:150000:0|Q60-43:78994:150000:0|Q60-33:79954:150000:0|Q60-35:74006:150000:0|Q60-37:80596:150000:0|Q60-38:84258:150000:0|Q60-36:74448:150000:0,361666"


FUNC_RFID_INITIALIZE

set g_rfidlotname [lindex [split $res ","] 0]
set g_handler [lindex [split $res ","] 1]
set boards [lindex [split $res ","] 2]
set g_kit [lindex [split $res ","] 3]
set sockets [lindex [split $res ","] 4]
set g_operatorid [lindex [split $res ","] 5]

#set sockets "ab-01:801:1000:0|ab-03:100:1000:0|ab-04:1001:1000:0"
#set boards "BOARD|37-30|7|DOPPLER G MASTER  /  W427  /  ST-1069  (2? 3?)|"
################################ BOARD or PROBE ########################################### 
#ex) BOARD|81-84|1007|POIPU  /  FT2  /  POIPU-AQ|
#ex) MULTI^PROBE|P-06-352|1|DOTARA  /  EWS  /  SUBAMBA2|952:500000:0:16@BOARD|B-02-110|3|DOTARA|
 
global g_board
global g_boardno
global g_boarddescription

global g_probe
global g_probeno
global g_probedescription
global g_probe_touch
global g_probe_limit
global g_probe_ext

global g_prober
global g_pcbboard
    
global g_cleaningsheet
global g_cleaningsheetno
global g_cleaningsheetdescription
global g_cleaningsheet_touch
global g_cleaningsheet_limit
global g_cleaningsheet_ext

set board_array [split $boards "^"]

set type [lindex $board_array 0] 

if { [string match -nocase "MULTI" $type] == 1 } {

    set multis [lindex $board_array 1]
    set multi_cnt [llength [split $multis "@"]] 
    set multi_array [split $multis "@"]
    
    for { set i 0 } { $i < $multi_cnt } { incr i } {
        set multi_type [lindex [split [lindex $multi_array $i] "|"] 0]
        
        if { [string match -nocase "*PROB*" $multi_type] == 1 } {
            # probe       
            set g_probe [lindex [split [lindex $multi_array $i] "|"] 1]
            set g_probeno [lindex [split [lindex $multi_array $i] "|"] 2]
            set g_probedescription [lindex [split [lindex $multi_array $i] "|"] 3]
            set g_probe_touch [lindex [split [lindex [split [lindex $multi_array $i] "|"] 4] ":"] 0]
            set g_probe_limit [lindex [split [lindex [split [lindex $multi_array $i] "|"] 4] ":"] 1]
            set g_probe_ext [lindex [split [lindex [split [lindex $multi_array $i] "|"] 4] ":"] 2]
            #set g_probe_recordcount [expr [lindex [split [lindex [split $boards "|"] 4] ":"] 3] * 1000]
    
            # because of Core count
            set g_prober $g_handler
            set g_pcbboard $g_probe
    
            # because of PROBE APL
            #set g_boardno [lindex [split [lindex $multi_array $i] "|"] 2]
            
        } elseif { [string match -nocase "*CLEANINGSHEET*" $multi_type] == 1 } {
            # cleaningsheet
            set g_cleaningsheet [lindex [split [lindex $multi_array $i] "|"] 1]
            set g_cleaningsheetno [lindex [split [lindex $multi_array $i] "|"] 2]
            set g_cleaningsheetdescription [lindex [split [lindex $multi_array $i] "|"] 3]
            set g_cleaningsheet_touch [lindex [split [lindex [split [lindex $multi_array $i] "|"] 4] ":"] 0]
            set g_cleaningsheet_limit [lindex [split [lindex [split [lindex $multi_array $i] "|"] 4] ":"] 1]
            set g_cleaningsheet_ext [lindex [split [lindex [split [lindex $multi_array $i] "|"] 4] ":"] 2]
                      
        } elseif { [string match -nocase "*BOARD*" $multi_type] == 1 } {
            # board
            set g_board [lindex [split [lindex $multi_array $i] "|"] 1]
            set g_boardno [lindex [split [lindex $multi_array $i] "|"] 2]
            set g_boarddescription [lindex [split [lindex $multi_array $i] "|"] 3]
        }
    }
     
} else {
    
    set borp_array [split [lindex $board_array 0] "|"] 
    set borp [lindex $borp_array 0]
    
    if { [string match -nocase "*PROB*" $borp] == 1 } {
    
        # probe
        set g_probe [lindex $borp_array 1]
        set g_probeno [lindex $borp_array 2]
        set g_probedescription [lindex $borp_array 3]
        set g_probe_touch [lindex [split [lindex $borp_array 4] ":"] 0]
        set g_probe_limit [lindex [split [lindex $borp_array 4] ":"] 1]
        set g_probe_ext [lindex [split [lindex $borp_array 4] ":"] 2]
        #set g_probe_recordcount [expr [lindex [split [lindex [split $boards "|"] 4] ":"] 3] * 1000]
    
        # because of Core count
        set g_prober $g_handler
        set g_pcbboard $g_probe
    
        # because of PROBE APL
        set g_boardno [lindex $borp_array 2]

    } else {
        # board
        set g_board [lindex $borp_array 1]
        set g_boardno [lindex $borp_array 2]
        set g_boarddescription [lindex $borp_array 3]
    }
    
} 
 
 
################################ SOCKET ########################################### 
### set socket count
#set sockets ":::|Q22-2731:0:0:0|:::|Q22-281:6670:150000:0|Q22-283:4045:150000:0|Q22-285:5742:150000:0"

#set sockets "S1-ES2-2:2224:0:0|S1-ES2-267:2054:150000:0|S1-ES2-289:2224:150000:0|S1-ES2-290:2224:150000:0|S1-ES2-291:2224:150000:0|S1-ES2-292:2224:150000:0|S1-ES2-294:2224:150000:0|S1-ES2-295:2224:150000:0|S1-ES2-296:2224:150000:0|S1-ES2-298:2224:0:0|S1-ES2-299:2224:0:0|S1-ES2-300:2224:0:0|S1-ES2-301:2224:0:0|S1-ES2-302:2224:0:0|S1-ES2-303:2224:0:0|S1-ES2-304:2224:0:0|S1-ES2-305:2224:0:0|S1-ES2-306:2224:0:0|S1-ES2-307:2224:0:0|S1-ES2-308:2224:0:0|S1-ES2-309:2224:0:0|S1-ES2-310:2224:0:0|S1-ES2-311:2224:0:0|S1-ES:::"
#puts $sockets
#set type "PROBE"
#set sockets "P-05-360:1554929:1100000:0"

global g_socketcount
set g_socketcount [llength [split $sockets "|"]]

set socket_array [split $sockets "|"]

### set socket list
global g_socketsitenumber
global g_socketlist 
set g_socketlist ""

### For Socket Correlation
for { set i 1 } { $i<=$g_socketcount } { incr i } {
    set tmp_socketName [lindex $socket_array [expr $i-1] ]
    append g_socketlist [lindex [split $tmp_socketName ":"] 0]
    if { $i != $g_socketcount } {
        append g_socketlist "|"
    }
}

### For UI 
for { set i 1 } { $i<=$g_socketsitenumber } { incr i } {

    set tmp_socket [lindex $socket_array [expr $i-1] ]
                  
    global g_socket_check$i
    global g_socket$i
    global g_socket_touch$i
    global g_socket_limit$i
    global g_socket_ext$i
     
    global g_core_check$i
    global g_core$i
    global g_core_touch$i
    global g_core_limit$i
    global g_core_ext$i
     
    if { [string match -nocase "MULTI" $type] == 1 } {
        
        set g_core$i ""
        set g_core$i [lindex [split $tmp_socket ":"] 0]
    
        set g_core_touch$i ""
        set g_core_touch$i [lindex [split $tmp_socket ":"] 1]
    
        set g_core_limit$i ""
        set g_core_limit$i [lindex [split $tmp_socket ":"] 2]
    
        set g_core_ext$i ""
        set g_core_ext$i [lindex [split $tmp_socket ":"] 3] 
        
    } else {
        if { [string match -nocase "*PROB*" $type] == 1 } {
            set g_core$i ""
            set g_core$i [lindex [split $tmp_socket ":"] 0]
    
            set g_core_touch$i ""
            set g_core_touch$i [lindex [split $tmp_socket ":"] 1]
    
            set g_core_limit$i ""
            set g_core_limit$i [lindex [split $tmp_socket ":"] 2]
    
            set g_core_ext$i ""
            set g_core_ext$i [lindex [split $tmp_socket ":"] 3] 
        } else {
            set g_socket$i ""
            set g_socket$i [lindex [split $tmp_socket ":"] 0]
    
            set g_socket_touch$i ""
            set g_socket_touch$i [lindex [split $tmp_socket ":"] 1]
    
            set g_socket_limit$i ""
            set g_socket_limit$i [lindex [split $tmp_socket ":"] 2]
    
            set g_socket_ext$i ""
            set g_socket_ext$i [lindex [split $tmp_socket ":"] 3]
        }
        
    }
    
}

## rfid flag ###########
#global g_rfid_flag
#set g_rfid_flag "TRUE"
########################
}
#############################################################################
## Procedure:  FUNC_BIND_WIDGET

proc ::FUNC_BIND_WIDGET {} {
global widget

### enable start button
global g_ent_operatorid
bind $g_ent_operatorid <Button-1> {
    global g_btn_start
    $g_btn_start configure -state normal
}


### close operatorid confirmation window
proc FUNC_CLOSE_CONFIRMATION {} {
    #FD "FUNC_BIND_WIDGET : hide confirmation .top86"
    Window hide .top86
}
wm protocol .top86 WM_DELETE_WINDOW FUNC_CLOSE_CONFIRMATION


### close read RFID window
proc FUNC_CLOSE_RFID {} {
    #FD "FUNC_BIND_WIDGET : hide confirmation .top85"
    Window hide .top85
}
wm protocol .top85 WM_DELETE_WINDOW FUNC_CLOSE_RFID


### close scops
proc FUNC_CLOSE_SCOPS {} {
    exit
}
wm protocol .top83 WM_DELETE_WINDOW FUNC_CLOSE_SCOPS

#FD "FUNC_BIND_WIDGET : COMPLETED"
}
#############################################################################
## Procedure:  FUNC_CLEAR_FILE

proc ::FUNC_CLEAR_FILE {} {
global widget

global g_rootdir

if [catch { 

    set batchfile "[file join $g_rootdir scops_update.bat]"
    
    if { [file exist $batchfile] == 1 } {
        set delete_file [file delete $batchfile]
    }
    
} err ] {
    FD "FUNC_CLEAR_FILE : $err"
    return "FALSE"
}
}
#############################################################################
## Procedure:  FUNC_KILL_PROCESS

proc ::FUNC_KILL_PROCESS {str1} {
global widget

global tcl_platform

if { [string match -nocase "*window*" $tcl_platform(platform)] == 0 } { return }

if { [catch {

    package require twapi

    foreach tmp_pid [lsort -integer [twapi::get_process_ids -glob -name "$str1*"]] {
        set tmp [twapi::end_process $tmp_pid -force]
    }
    
} err] } {
    FD "FUNC_KILL_PROCESS ERROR : $err"
}
}
#############################################################################
## Procedure:  FUNC_PARSEANDSET_STRING

proc ::FUNC_PARSEANDSET_STRING {str1} {
global widget

global g_cd

set res_array [split $str1 $g_cd]

foreach tmp $res_array {

    if { [catch {
        set parameter [lindex [split $tmp ":"] 0]
        set value [lindex [split $tmp ":"] 1]
    
        puts "parameter : $parameter, value : $value"
    
        global $parameter
        set $parameter ""
        set $parameter $value
     } err] } {
         FD "FUNC_PARSEANDSET_STRING ERROR : $err"
     }
     
}
}
#############################################################################
## Procedure:  FUNC_REMOTE_SCOPS

proc ::FUNC_REMOTE_SCOPS {} {
global widget

global g_hostname
global g_hostplatform

set qry "SCOPS,RemoteControl,$g_hostname,$g_hostplatform*"

########################################
if [catch {
########################################

set res ""
set res [FUNC_SEND_QRY $qry]

if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
    FD "FUNC_EXECUTE_DB : $res"
    return "FALSE"
}

global g_cd

set res_array [split $res $g_cd]

foreach tmp $res_array {
    $tmp
}


#########################################
} err] {
    FD "FUNC_EXECUTE_DB ERROR : $err"
}
#########################################
}
#############################################################################
## Procedure:  FUNC_CHECK_MADEVICE

proc ::FUNC_CHECK_MADEVICE {} {
global widget

#sometime QCT has two devices and MA is an additional information
global g_hostname
global g_lotname
global g_dcc
global g_operation

set qry "SCOPS,CheckMADevice,$g_hostname,$g_lotname,$g_dcc,$g_operation,*"

set res ""
set res [FUNC_SEND_QRY $qry]

if { [lindex [split $res ","] 0] == "FAIL" } {
    #set msg {"Fail to Get MA device!" ""}
    #set choice [ tk_messageBox -title "MA Device Check Error" -icon warning -message [FM "TESTIT" $msg $res] ]
    return "TRUE"
    
}

if { [lindex [split $res ","] 0] == "" } { return "TRUE" }


#global g_madevice
#set g_madevice $res

global g_devicename
set g_devicename $res
}
#############################################################################
## Procedure:  FUNC_CHECK_BOARDKIT_NONQCT

proc ::FUNC_CHECK_BOARDKIT_NONQCT {} {
global widget

global g_hostname
global g_lotname
global g_dcc
global g_operation
global g_operatorid
global g_customer
global g_board
#global g_kit


global g_rfid_flag
if { $g_rfid_flag != "TRUE" } { return "TRUE" }

if { [string match -nocase "*PROB*" $g_operation] == 1 } { 
    #FD "FUNC_RFID_CHECK_PROBETOUCHDOWN : operation"
    return "TRUE" 
}

if { [string match -nocase "*QUALCOM*" $g_customer] == 1 } {
    return "TRUE"
}

set qry "SCOPS,CheckBoardKitNonQCT,CHECK,$g_hostname,$g_lotname,$g_dcc,$g_operation,$g_operatorid,$g_customer,$g_board*"

set res ""
set res [FUNC_SEND_QRY $qry]


if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
    set choice [ tk_messageBox -title "Non-QCT Board Check Error" -icon warning -message [FM "TESTIT" "Fail to Check Board" $res] ]
    return "TRUE"
    
}

if { [lindex [split $res ","] 0] == "NO" } {
    set choice [ tk_messageBox -title "Non-QCT Board Check Error" -icon error -message [FM "K3 Engineer, HCC" "Fail to Check Board" $res] ]
    return "FALSE"
}

return "TRUE"
}
#############################################################################
## Procedure:  FUNC_CHECK_BOARDKIT_QCT

proc ::FUNC_CHECK_BOARDKIT_QCT {} {
global widget

global g_hostname
global g_lotname
global g_dcc
global g_operation
global g_operatorid
global g_customer
global g_board
global g_kit


global g_rfid_flag
if { $g_rfid_flag != "TRUE" } { return "TRUE" }


if { [string match -nocase "*PROB*" $g_operation] == 1 } { 
    #FD "FUNC_RFID_CHECK_PROBETOUCHDOWN : operation"
    return "TRUE" 
}

if { [string match -nocase "*QUALCOM*" $g_customer] == 0 } {
    return "TRUE"
}

set qry "SCOPS,CheckBoardKitQCT,CHECK,$g_hostname,$g_lotname,$g_dcc,$g_operation,$g_operatorid,$g_customer,$g_board,$g_kit*"

set res ""
set res [FUNC_SEND_QRY $qry]


set win_title "boardkit_warning"
FUNC_DISPLAY_MESSAGE "close" "$win_title" "" ""
set config "$win_title"

if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
    
    FUNC_DISPLAY_MESSAGE "open" $config "image,scops_warning_boardkit.gif" [FM "TESTIT" "Fail to Check QCT Board & Kit!" ""]
    set choice [ tk_messageBox -title "QCT Board & Kit Check Error" -icon warning -message [FM "TESTIT" "Fail to Check QCT Board & Kit!" $res] ]
    FUNC_DISPLAY_MESSAGE "close" "$win_title" "" ""
    return "TRUE"
}

if { [lindex [split $res ","] 0] == "NO" } {
    set msg {"Board & Kit Check Error" ""}
    FUNC_DISPLAY_MESSAGE "open" $config "image,scops_warning_boardkit.gif" [FM "K3 Engineer, HCC" "Fail to Check QCT Board & Kit!" ""]
    set choice [ tk_messageBox -title "QCT Board & Kit Check Error" -icon error -message [FM "Engineer, HCC" "Fail to Check QCT Board & Kit!" $res] ]
    FUNC_DISPLAY_MESSAGE "close" "$win_title" "" ""
    return "FALSE"
}

return "TRUE"
}
#############################################################################
## Procedure:  TEMPLATE_TRYCATCH

proc ::TEMPLATE_TRYCATCH {} {
global widget

if [catch { } err] {}
}
#############################################################################
## Procedure:  FUNC_RFID_CHECK_PROBETOUCHDOWN

proc ::FUNC_RFID_CHECK_PROBETOUCHDOWN {flag} {
global widget

global g_operation 
global g_testing_flag
global g_rfid_flag
global g_probe_operator
global g_testing_flag
global g_rfid_flag

global g_hostname
global g_probe
global g_probe_touch
global g_probe_limit
global g_probe_ext
global g_probe_recordcount
global g_probe_operatorid 
global g_probe_td_comment

global g_lotname
global g_dcc

# Exception Check
set qry "SCOPS,CheckProbeTC,EXCEPTION,$g_hostname,$g_probe,$g_probe_touch,$g_probe_operatorid,$g_operation,$g_lotname,$g_dcc*"
set res ""
set res [FUNC_SEND_QRY "$qry"]

if { [lindex [split $res ","] 0] == "NO" } {
    #FD "FUNC_RFID_CHECK_PROBETOUCHDOWN : CUSTOMER SKIP"
    return "TRUE" 
}

if { $g_testing_flag != "TESTING" || $g_rfid_flag != "TRUE"  } { 
    #FD "FUNC_RFID_CHECK_PROBETOUCHDOWN : TESTING"
    return "TRUE" 
}

if { $g_probe_touch == "" || $g_probe_limit == "" }  { 
    #FD "FUNC_RFID_CHECK_PROBETOUCHDOWN : EMPTY"
    return "TRUE" 
}

if { $g_probe_touch <= $g_probe_limit } { 
    #FD "FUNC_RFID_CHECK_PROBETOUCHDOWN : $g_probe_touch <  $g_probe_limit"
    
    ##clear warning message
    global g_probe_warning
    set g_probe_warning ""
    
    #Close popup
    Window hide .top95
        
    return "TRUE" 
}

if { $flag == "CHECK" } {
    #warning 
    global g_probe_warning
    set g_probe_warning "Probe Touch Count is over [expr $g_probe_touch / 1000]K!" 
   
    global g_note_probe 
    $g_note_probe raise page2
       
    global g_note_root
    $g_note_root raise page2
           
    #Pop up Alert
    global g_probe_td_operatorid
    global g_probe_td_comment
    set g_probe_td_operatorid "" 
    set g_probe_td_comment ""
    FUNC_BIND_WIDGET

    Window show .top95
    set a [expr {int([winfo screenwidth .] * 0.5)}]
    set b [expr {int([winfo screenheight .] * 0.5)}]
    wm geometry .top95 [format "%sx%s+%s+%s" 743 374 [expr $a - 743/2] [expr $b - 374/2]]
                 
    return "FALSE"
    
} 
    
}
#############################################################################
## Procedure:  FUNC_RFID_CHECK_SOCKETTOUCHDOWN

proc ::FUNC_RFID_CHECK_SOCKETTOUCHDOWN {} {
global widget


global g_operation 
if { [string match -nocase "*PROB*" $g_operation] == 1 } { 
    #FD "This is not TEST or TSQA
    return "TRUE"
}

global g_testing_flag
global g_rfid_flag

if { $g_rfid_flag != "TRUE"  } { return }

set socket_msg "Socket : Touch cnt. : Limit cnt.       \n"
set socket_touchdown_flag "FALSE"




##############################################
##############################################        
#global g_socketsitenumber
#for { set i 1 } { $i<=7 } { incr i } {
    
#    global g_socket_check$i
#    global g_socket$i
#    global g_socket_touch$i
#    global g_socket_limit$i
#    global g_socket_ext$i

#    set g_socket$i "test-$i"
#    set g_socket_touch$i "101"
#    set g_socket_limit$i "100"

#    set g_socket_touch$i ""
#    set g_socket_limit$i ""
#}

##############################################
############################################## 

global g_socketsitenumber
for { set i 1 } { $i<=$g_socketsitenumber } { incr i } {
    
    global g_socket_check$i
    global g_socket$i
    global g_socket_touch$i
    global g_socket_limit$i
    global g_socket_ext$i
    
#FD "g_socket1 : $g_socket1 / g_socket_touch1 : $g_socket_touch1 / g_socket_limit1 : $g_socket_limit1"             
                    
                                                       
    set socket_touch [subst $[format "g_socket_touch%d" $i]]
    set socket_limit [subst $[format "g_socket_limit%d" $i]]
    
    #FD "socket_touch : $socket_touch / socket_limit : $socket_limit" 
      
    if { $socket_touch != "" && $socket_limit != "" } {
   
        if { $socket_touch > $socket_limit } {
        
            set socket_touchdown_flag "TRUE"
            
            #message
            set socket_msg "$socket_msg\n[subst $[format "g_socket%d" $i]] : [subst $[format "g_socket_touch%d" $i]] : [subst $[format "g_socket_limit%d" $i]]"
            
            #ui
            if { [catch { g_ent_socket$i configure -background "red" -foreground "white" } err] } {}
            
        } else {
            if { [catch { g_ent_socket$i configure -background "white" -foreground "black" } err] } {}
        }
    
    } else {
         if { [catch { g_ent_socket$i configure -background "white" -foreground "black" } err] } {}
    }

}

if { $g_testing_flag != "TESTING" } { return }

set win_title "socket_touchdown_warning"

if { $socket_touchdown_flag == "TRUE" } {
    #set choice [ tk_messageBox -title "TPA Error" -icon error -message [FM "K3 Engineer, HCC" $socket_msg ""] ]

    #FUNC_DISPLAY_MESSAGE "close,$win_title" "" ""

    #           1.flag 2.title 3.height 4.width 5.top 6.left 7.bgcolor 8.fgcolor 9.thickness(line)
    set height [expr [llength [split $socket_msg "\n"]] * 24]
    set config "$win_title,$height,,,,#EFEBEF,#000000,"

    #              1.directory 2.file name
    set file_name ""

    #        alter message for image

    FUNC_DISPLAY_MESSAGE "close" $config $file_name $socket_msg
    FUNC_DISPLAY_MESSAGE "open" $config $file_name $socket_msg
    
    ### UI tab change
    #global g_note_root
    #$g_note_root raise page2
    
    #global g_note_rfid
    #$g_note_rfid raise page1
    
    
} else {
    FUNC_DISPLAY_MESSAGE "close" "$win_title" "" ""
}
}
#############################################################################
## Procedure:  FUNC_APL_WINDOWS

proc ::FUNC_APL_WINDOWS {flag} {
global widget

global tcl_platform
if { [string match -nocase "*window*" $tcl_platform(platform)] == 0 } { return }


global g_apl_flag
#if { $g_apl_flag == "OFF" || $g_apl_flag == "0" || $g_apl_flag == "" } { return }


if { $flag != "START" } {
    set flag "END"
} else {
    set flag "START"
}


global g_hostname
global g_customer
global g_devicename
global g_lotname
global g_dcc
global g_testprogram
global g_testprogramrev
global g_operatorid
global g_board
global g_handler
global g_temperature
global g_operation
global g_job
global g_kit

### get socket list
set sockets ""
global g_socketsitenumber
for { set i 1 } { $i<=$g_socketsitenumber } { incr i } {
    global g_socket$i
    
    if { [catch {
    
        if { [string trim [subst $[format "g_socket%d" $i]] ] != "" } {
            if { $sockets == "" } {
                set sockets [string trim [subst $[format "g_socket%d" $i]] ]
            } else {
                set sockets [format "%s|%s" $sockets [string trim [subst $[format "g_socket%d" $i]] ] ]
            }   
        }
        
    } err] } {
        FD "FUNC_APL_WINDOWS - SOCKET : $err"
    }
}

set qry "SCOPS,APL_Windows,$flag,$g_hostname,$g_customer,$g_devicename,$g_lotname,$g_dcc,$g_testprogram,$g_testprogramrev,$g_operatorid,$g_board,$g_handler,$g_temperature,$g_operation,$g_job,$g_kit,$sockets*"

set res ""
set res [FUNC_SEND_QRY $qry]

if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
    set msg {"FUNC_APL_WINDOWS" ""}
    set choice [ tk_messageBox -title "FUNC_APL_WINDOWS Error" -icon warning -message [FM "TESTIT" $msg $res] ]
    return "FALSE"
}

return "TRUE"
}
#############################################################################
## Procedure:  FUNC_APL_T2000

proc ::FUNC_APL_T2000 {flag} {
global widget

global tcl_platform

if { [string match -nocase "*window*" $tcl_platform(platform)] != 1 } { 
    #puts "This is windows platform"
    return "TRUE"
}


global g_hostname
global g_lotname
global g_dcc
global g_operation
global g_job
global g_customer
global g_devicename
global g_testprogram
global g_testprogramrev
global g_condition
global g_temperature
global g_incount
global g_operatorid
global g_handler
global g_board
global g_kit

global g_socketcount
global g_handlertype

set apl_name "T2000"

set qry "SCOPS,APL_T2000,$flag,$g_hostname,$g_lotname,$g_dcc,$g_operation,$g_job,$g_customer,$g_devicename,$g_testprogram,$g_testprogramrev,$g_condition,$g_temperature,$g_incount,$g_operatorid,$g_handler,$g_board,$g_kit,$g_socketcount,$g_handlertype*"

set res ""
set res [FUNC_SEND_QRY $qry]

if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
    set choice [ tk_messageBox -title "$apl_name APL ERROR" -icon warning -message [FM "TESTIT" "Failure to create $apl_name APL file!" $res] ]
    return "FALSE"
}


if { [lindex [split $res ","] 0] == "NO" } {
    return "TRUE"
}

set apl_file [lindex [split $res ","] 0]
set apl_path [file dir $apl_file]
set test_oi [lindex [split $res ","] 1]
set apl_format [lindex [split $res ","] 2]


#FD "apl_file : $apl_file"
#FD "apl_path : $apl_path"
#FD "test_oi : $test_oi"
#FD "apl_format : $apl_format"

if { [file exist $apl_path] != 1 } {
    if [catch {
        set tmp [file mkdir $apl_path]
    } err] {
        FD "$apl_name APL ERROR : Fail to create directory -> $apl_path ($err)"
        set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TESTIT" "Please, Check $apl_path authority to modify!" $res] ]
        return "FALSE"
    }     
}

### clear APL ##################
if { [file exist $apl_file] == 1 } {
    if [catch { 
        set delete_file [file delete $apl_file]
    } err] {
        FD "$apl_name APL ERROR : Failture to delete the previous $apl_file"
        set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TESTIT" "Please, Check $apl_file authority to delete!" $res] ]
        return "FALSE"
    }  
}


if { $flag == "DELETE" } {
    return "TRUE"
}

### start writing APL parameters ###
if [catch {
    
    set apl_fd [open $apl_file w]
    
    set apl_contents ""
    
    for { set i 3 } { $i <= [llength [split $res ","]] } { incr i } {
           
        if { $apl_format == "COMMA" } {   
             if { $apl_contents != "" && $i != [llength [split $res ","]] } {
                set apl_contents [format "%s,%s" $apl_contents [lindex [split $res ","] $i] ]
            } else {
                set apl_contents [format "%s%s" $apl_contents [lindex [split $res ","] $i] ]
            }        
        } else {
            puts $apl_fd [lindex [split $res ","] $i]
        }
                
    }
    
    if { $apl_contents != "" } {
        puts $apl_fd $apl_contents
    }
    
    close $apl_fd
      
    FD "$apl_name APL SUCCESS!"
    
    ### execute TEST OI
    if { $test_oi != "" } {
        if [catch { 
            set tmp [exec $test_oi &]
        } err] {
            FD "$apl_name APL ERROR : Failure to execute $test_oi ($err)"
            set delete_file [file delete $apl_file]
            set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TESTIT" "Failure to execute $test_oi!" $res] ]
            return "FALSE"
        }    
    }
    
} err ] {
    FD "$apl_name APL ERROR : $err"
    set delete_file [file delete $apl_file]
    return "FALSE"
}

return "TRUE"
}
#############################################################################
## Procedure:  FUNC_APL_XILINX

proc ::FUNC_APL_XILINX {} {
global widget

global tcl_platform

if { [string match -nocase "*window*" $tcl_platform(platform)] != 1 } { 
    #puts "This is windows platform"
    return "TRUE"
}


global g_hostname
global g_lotname
global g_dcc
global g_operation
global g_job
global g_customer
global g_testprogram
global g_testprogramrev
global g_devicename
global g_operatorid
global g_handler
global g_temperature
global g_boardno
global g_incount
global g_xilinxqty
global g_xilinxspeedgrade

set apl_name "Xilinx"

set qry "SCOPS,APL_$apl_name,$g_hostname,$g_lotname,$g_dcc,$g_operation,$g_job,$g_testprogram,$g_testprogramrev,$g_incount,$g_customer,$g_xilinxqty,$g_xilinxspeedgrade*"

set res ""
set res [FUNC_SEND_QRY $qry]

if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
    set msg {"Fail of Xilinx APL" ""}
    set choice [ tk_messageBox -title "$apl_name APL Error" -icon warning -message [FM "TESTIT" $msg $res] ]
    return "FALSE"
}


if { [lindex [split $res ","] 0] == "NO" } {

    return "TRUE"
}

set apl_file [lindex [split $res ","] 0]
set apl_path [file dir $apl_file]
set test_oi [lindex [split $res ","] 1]


if { [file exist $apl_path] != 1 } {
    if [catch {
        set tmp [file mkdir $apl_path]
    } err] {
        FD "FUNC_APL_$apl_name : can't create directory $apl_path"
        set choice [ tk_messageBox -title "FUNC_APL_$apl_name Error" -message "============================================\n\nContact : K3 Engineer, TESTIT\n\n============================================\n\nCan't delete the previous $apl_file\nCheck the file authority!!!" ]
        return "FALSE"
    }     
}

### clear APL ##################
if { [file exist $apl_file] == 1 } {
    if [catch { 
        set delete_file [file delete $apl_file]
    } err] {
        FD "FUNC_APL_$apl_name : can't delete $apl_file"
        set choice [ tk_messageBox -title "FUNC_APL_$apl_name Error" -message "============================================\n\nContact : K3 Engineer, TESTIT\n\n============================================\n\nCan't delete the previous $apl_file\nCheck the file authority!!!" ]
        return "FALSE"
    }  
}

### start writing APL parameters ###
if [catch {
    
    set apl_fd [open $apl_file w]
    
    #1.Test Program
    set apl_contents ""

    for { set i 2 } { $i <= [llength [split $res ","]] } { incr i } {
                   
        #if { $apl_contents != "" && $i != [llength [split $res ","]] } {
        #    set apl_contents [format "%s,%s" $apl_contents [lindex [split $res ","] $i] ]
        #} else {
        #    set apl_contents [format "%s%s" $apl_contents [lindex [split $res ","] $i] ]
        #}
        #
        
        puts $apl_fd [lindex [split $res ","] $i]
    }
    
    #puts $apl_fd $apl_contents
    close $apl_fd
      
    FD "FUNC_APL_$apl_name writing success!"
    
    ### execute TEST OI
    if { $test_oi != "" } {
        #set tmp [exec $test_oi &]
    }
    
} err ] {
    FD "FUNC_APL_$apl_name error : $err"
    set delete_file [file delete $apl_file]
    return "FALSE"
}

return "TRUE"
}
#############################################################################
## Procedure:  FUNC_GET_CONFIG_ORG

proc ::FUNC_GET_CONFIG_ORG {} {
global widget

global g_cd
global g_rd

global g_hostname


### from DB ##############################################################################


set qry "SCOPS,GetConfig,$g_hostname*"

set res ""
set res [FUNC_SEND_QRY $qry]

if { [string match -nocase "*FAIL*" [string trim [lindex [split $res ","] 0] ] ] == 1 } {
    set choice [ tk_messageBox -title "GetConfig Error!" -icon warning -message "[string trim [lindex [split $res ","] 1] ]    "]
    #return
}

#FUNC_PARSEANDSET_STRING "$res"


################################################################################

global g_rootdir
### from scops.config ##########################################################

if  [ catch { set fileID [ open $g_rootdir/scops.config r ] } err ] {
    FD "Fail to open ($g_rootdir/scops.config) -> $err"
} else {
    
    while { [gets $fileID line] >= 0 } {
    
        #FD "$g_rootdir/scops.config -> $line"
    
        if { [string trim $line] != "" && [string match -nocase "*#*" $line] == 0 } {
	    if { [string match -nocase "*g_*" $line] == 1 && [string match -nocase "*:*" $line] == 1 } {
                
                set a ""
                set b ""
                
                set a [string tolower [lindex [split $line ":"] 0]]
                set b [lindex [split $line ":"] 1]
                
                global $a
                set $a $b
                
                FD "$g_rootdir/scops.config -> $a:$b"
                
                #global [string tolower [lindex [split $line ":"] 0]]
                #set [string tolower [lindex [split $line ":"] 0]] [lindex [split $line ":"] 1]
            }
	}
        
    }
    close $fileID
}
###############################################################################

### from hostname_scops.config ####################################################
if  [ catch { set fileID [ open $g_rootdir/[format "%s_%s" $g_hostname "scops.config"] r ] } err ] {
    FD "Fail to open ($g_rootdir/hostname_scops.config) -> $err"
} else {
    
    while { [gets $fileID line] >= 0 } {
    
        #FD "$g_rootdir/hostname_scops.config -> $line"
    
        if { [string trim $line] != "" && [string match -nocase "*#*" $line] == 0 } {
	    if { [string match -nocase "*g_*" $line] == 1 && [string match -nocase "*:*" $line] == 1 } {
                
                set a ""
                set b ""
                
                set a [string tolower [lindex [split $line ":"] 0]]
                set b [lindex [split $line ":"] 1]
                
                global $a
                set $a $b
                
                FD "$g_rootdir/hostname_scops.config -> $a:$b"
                
                
                #global [string tolower [lindex [split $line ":"] 0]]
                #set [string tolower [lindex [split $line ":"] 0]] [lindex [split $line ":"] 1] 
            }
	}
        
    }
    close $fileID
}
###############################################################################


### from /sfg/scops.config ####################################################
if  [ catch { set fileID [ open /sfg/scops.config r ] } err ] {
    FD "Fail to open (/sfg/scops.config) -> $err"
} else {
    
    while { [gets $fileID line] >= 0 } {
    
        #FD "/sfg/scops.config -> $line"
    
        if { [string trim $line] != "" && [string match -nocase "*#*" $line] == 0 } {
	    if { [string match -nocase "*g_*" $line] == 1 && [string match -nocase "*:*" $line] == 1} {
                
                set a ""
                set b ""
                
                set a [string tolower [lindex [split $line ":"] 0]]
                set b [lindex [split $line ":"] 1]
                
                global $a
                set $a $b
                
                FD "/sfg/scops.config -> $a:$b"
                
                
                #global [string tolower [lindex [split $line ":"] 0]]
                #set [string tolower [lindex [split $line ":"] 0]] [lindex [split $line ":"] 1]
            }
	}
        
    }
    close $fileID
}
###############################################################################
}
#############################################################################
## Procedure:  FUNC_GET_CONFIG

proc ::FUNC_GET_CONFIG {flag} {
global widget

global g_cd
global g_rd

global g_hostname


global g_rootdir

if { $flag == "FILE" } {
	### from scops.config ##########################################################

	if  [ catch { set fileID [ open $g_rootdir/scops.config r ] } errorMessage ] {
		FD "Fail to open ($g_rootdir/scops.config)"
	} else {
	    
		while { [gets $fileID line] >= 0 } {
	    
			#FD "$g_rootdir/scops.config -> $line"
	    
			if { [string trim $line] != "" && [string match -nocase "*#*" $line] == 0 } {
			if { [string match -nocase "*g_*" $line] == 1 && [string match -nocase "*:*" $line] == 1} {
					global [string tolower [lindex [split $line ":"] 0]]
					set [string tolower [lindex [split $line ":"] 0]] [lindex [split $line ":"] 1]
                                        FD "$g_rootdir/scops.config - [string tolower [lindex [split $line ":"] 0]] : [lindex [split $line ":"] 1]"
				}
		}
	        
		}
		close $fileID
	}
	###############################################################################

	### from hostname_scops.config ####################################################
	if  [ catch { set fileID [ open $g_rootdir/[format "%s_%s" $g_hostname "scops.config"] r ] } errorMessage ] {
		FD "Fail to open ($g_rootdir/hostname_scops.config)"
	} else {
	    
		while { [gets $fileID line] >= 0 } {
	    
			if { [string trim $line] != "" && [string match -nocase "*#*" $line] == 0 } {
			if { [string match -nocase "*g_*" $line] == 1 && [string match -nocase "*:*" $line] == 1} {
					global [string tolower [lindex [split $line ":"] 0]]
					set [string tolower [lindex [split $line ":"] 0]] [lindex [split $line ":"] 1]
                                        FD "$g_rootdir/hostname_scops.config - [string tolower [lindex [split $line ":"] 0]] : [lindex [split $line ":"] 1]"
				}
		}
	        
		}
		close $fileID
	}
	###############################################################################


	### from /sfg/scops.config ####################################################
	if  [ catch { set fileID [ open /sfg/scops.config r ] } errorMessage ] {
		FD "Fail to open (/sfg/scops.config)"
	} else {
	    
		while { [gets $fileID line] >= 0 } {
	    
			if { [string trim $line] != "" && [string match -nocase "*#*" $line] == 0 } {
			if { [string match -nocase "*g_*" $line] == 1 && [string match -nocase "*:*" $line] == 1} {
					global [string tolower [lindex [split $line ":"] 0]]
					set [string tolower [lindex [split $line ":"] 0]] [lindex [split $line ":"] 1]
                                        FD "/sfg/scops.config - [string tolower [lindex [split $line ":"] 0]] : [lindex [split $line ":"] 1]"

				}
		}
	        
		}
		close $fileID
	}
	###############################################################################
}



if { $flag == "DB" } {
	### from DB ##############################################################################

	set qry "SCOPS,GetConfig,$g_hostname*"

	set res ""
	set res [FUNC_SEND_QRY $qry]

	if { [string match -nocase "*FAIL*" [string trim [lindex [split $res ","] 0] ] ] == 1 } {
		set choice [ tk_messageBox -title "GetConfig Error!" -icon warning -message "[string trim [lindex [split $res ","] 1] ]    "]
		return
	}


	set resultarray [split $res $g_cd]

	global g_release_flag
	global g_refreshperiod
	global g_scopsversion
	global g_scopsnewversion
	#global g_scopspath
	global g_manual_flag
	global g_apl_flag
	global g_apl_path
	global g_hsf_flag
	global g_sbl_flag
	global g_drl_flag
	global g_swr_flag
	global g_tpa_flag
	global g_update_flag
	global g_hostplatform
	global g_database
        global g_datastream_flag

	set g_release_flag ""
	set g_refreshperiod ""
	#set g_scopsversion ""
	set g_scopsnewversion ""
	#set g_scopspath ""
	set g_manual_flag ""
	set g_apl_flag ""
	set g_apl_path ""
	set g_hsf_flag ""
	set g_sbl_flag ""
	set g_drl_flag ""
	set g_swr_flag ""
	set g_tpa_flag ""
	set g_update_flag ""
	set g_hostplatform ""
	set g_database ""
        set g_datastream_flag ""

	set g_release_flag [lindex $resultarray 0]
	set g_refreshperiod [lindex $resultarray 1]
	#set g_scopsversion [lindex $resultarray 2]
	set g_scopsnewversion [lindex $resultarray 3]
	#set g_scopspath [lindex $resultarray 4]
	set g_manual_flag [lindex $resultarray 4]
	set g_apl_flag [lindex $resultarray 5]
	set g_apl_path [lindex $resultarray 6]
	set g_hsf_flag [lindex $resultarray 7]
	set g_sbl_flag [lindex $resultarray 8]
	set g_drl_flag [lindex $resultarray 9]
	set g_swr_flag [lindex $resultarray 10]
	set g_tpa_flag [lindex $resultarray 11]
	set g_update_flag [lindex $resultarray 12]
	set g_hostplatform [lindex $resultarray 13]
	set g_database [lindex $resultarray 14]
        set g_datastream_flag [lindex $resultarray 15]

	################################################################################
}
}
#############################################################################
## Procedure:  ATK_GROUP_END_LOT

proc ::ATK_GROUP_END_LOT {} {
global widget

global g_database
global g_testing_flag


if { $g_database == "EVE" } {

    FUNC_APL_EVE_UFLEX "DELETE"
    
} else {

    FUNC_APL_WINDOWS "END"
    FUNC_APL_D10 "DELETE"
    FUNC_APL_MICROCHIP "DELETE"
    FUNC_APL_ARMAR "DELETE"
    FUNC_APL_QSLT "DELETE"
    #FUNC_APL_J750_NXP "DELETE"
    FUNC_APL_HP93K_NXP "DELETE" "INFO"
    FUNC_APL_HP93K_NXP "DELETE" "PHP"
    FUNC_APL_HP93K_NXP "DELETE" "ED"
    FUNC_APL_HP "DELETE"
    #FUNC_APL_AMD_HP93K "DELETE"
    FUNC_APL_MTK_UFLEX "DELETE"
    FUNC_APL_EXECUTE_SP "DELETE"
    FUNC_APL_EXECUTE_SP_SUB "DELETE"
    FUNC_APL_T2000 "DELETE"
#   FUNC_APL_NVIDIA_BUMP "DELETE"
}






### kill Junction Temperature Process
FUNC_CHECK_JUNCTIONTEMPERATURE "END"

### CATA Bin solution
FUNC_CHECK_DATASTREAM "DELETE"
}
#############################################################################
## Procedure:  FUNC_CHECK_DATASTREAM

proc ::FUNC_CHECK_DATASTREAM {flag} {
global widget

global g_datastream_flag

set datastream "/usr/local1/bin/DATASTREAM.sh"


if { [FUNC_CHECK_VARIABLE g_datastream_flag] == "NULL" } {
    set g_datastream_flag ""
}

if { $g_datastream_flag != "ON" } { return }


global g_testing_flag

if { $flag == "CHECK" } {
    if { $g_testing_flag != "TESTING" } {
        return
    } else {
        set flag "START"
    }
}


if [catch { 
    set tmp [exec $datastream $flag &]
    FD "FUNC_CHECK_DATASTREAM : EXECUTE $datastream $flag"
} err] {
    FD "FUNC_CHECK_DATASTREAM ERROR : $err"
}







 
}
#############################################################################
## Procedure:  FUNC_CHECK_DRL

proc ::FUNC_CHECK_DRL {} {
global widget


global g_drl_flag
global g_operation
global tcl_platform

if { [string match -nocase "*window*" $tcl_platform(platform)] == 1 } { 
    return "TRUE"
}

### demo setting ###
#set g_drl_flag "ON"
####################

if { $g_drl_flag == "OFF" || $g_drl_flag == 0 } {
    return
}

set drl "/usr/local1/bin/DRL.sh"

if [catch { 
    set tmp [exec $drl $g_operation &]
    FD "FUNC_CHECK_DRL : EXECUTE $drl $g_operation"
} err] {
    FD "FUNC_CHECK_DRL ERROR : $err"
}
}
#############################################################################
## Procedure:  ATK_GROUP_APL

proc ::ATK_GROUP_APL {} {
global widget
global tcl_platform

global g_database

if { $g_database == "EVE" } {
    
    FUNC_APL_EVE_SLT "CREATE"
    FUNC_APL_EVE_UFLEX "CREATE"

} else {

    if { [string match -nocase "*window*" $tcl_platform(platform)] != 1 } { 
        
        set SMTVer [exec /usr/local1/APL/pgm/GetSMTVer]

#        if { [FUNC_APL_NVIDIA_BUMP "CREATE"] != "TRUE" } {
#                FD "FUNC_APL_NVIDIA_BUMP : FALSE"
#                        return "FALSE"
#        }

        if { $SMTVer < 8 } {
            #Not SMT8
            if { [FUNC_APL_HP "CREATE"] != "TRUE" } {
                FD "FUNC_APL_HP : FALSE"
                return "FALSE"
            }
        } else {
            #SMT8
            if { [FUNC_APL_HP_SMT8_MAKE "CREATE"] != "TRUE" } {
                FD "FUNC_APL_HP_SMT8 : FALSE"
                return "FALSE"
            }
    
            if { [FUNC_APL_HP_SMT8_COPY "CREATE"] != "TRUE" } {
                FD "FUNC_APL_HP_SMT8 : FALSE"
                return "FALSE"
            }
        }
    }
    
    if { [FUNC_APL_T2000_LSI_SUB] != "TRUE" } {
        FD "FUNC_APL_T2000_LSI_SUB : FALSE"
        return "FALSE"
    }
    
    FUNC_APL_WINDOWS "START"
    FUNC_APL_T2000 "CREATE"
    FUNC_APL_ADVANTXXXX "CREATE"
    FUNC_APL_D10 "CREATE"
    FUNC_APL_MAVERICK "CREATE"
    FUNC_APL_MWEST "CREATE"
    FUNC_APL_ETS "CREATE"
    FUNC_APL_J750 "CREATE"
    FUNC_APL_MICROCHIP "CREATE"
    FUNC_APL_ARMAR "CREATE"
    FUNC_APL_QSLT "CREATE"
    FUNC_APL_J750_NXP "CREATE"
    FUNC_APL_HP93K_NXP "CREATE" "INFO"
    FUNC_APL_HP93K_NXP "CREATE" "PHP"
    FUNC_APL_HP93K_NXP "CREATE" "ED"
    FUNC_APL_AMD_HP93K "CREATE"
#   FUNC_APL_EVE_HP93K "CREATE"
    FUNC_APL_QCT_T2000 "CREATE"
    FUNC_APL_STS_QCT "CREATE" "INFO"
    FUNC_APL_STS_QCT "CREATE" "STSETTING"
    FUNC_APL_STS_QCT "CREATE" "LOTSETTING"
    FUNC_APL_MTK_UFLEX "CREATE"
    FUNC_APL_HP93K_NXP_MULTI_DEV "CREATE"
    FUNC_APL_EXECUTE_SP "CREATE"
    FUNC_APL_EXECUTE_SP_SUB "CREATE"
}

return "TRUE"
}
#############################################################################
## Procedure:  FUNC_CREATE_UDPSENDER

proc ::FUNC_CREATE_UDPSENDER {} {
global widget

global tcl_platform
global g_rootdir

if { [string match -nocase "*window*" $tcl_platform(platform)] == 1 } {
    return
}

set udp_sender "udp_sender"
set udp_senderc "udp_sender.c"

if { [file exist [file join $g_rootdir $udp_sender]] == 1 } {
    return
}

### download
set res [FUNC_DOWNLOAD_FILE "BIN" $udp_senderc [file join $g_rootdir $udp_senderc]]

if { $res == "FALSE" } {
    FD "FUNC_CREATE_UDPSENDER : Download Fail!"
    return "FALSE"
} else {
    FD "FUNC_CREATE_UDPSENDER : Download Success!"
}



if [catch { 
    set tmp [exec "gcc -o [file join $g_rootdir $udp_sender] [file join $g_rootdir $udp_senderc]"]
} error ] {
    FD "FUNC_CREATE_UDPSENDER : Fail to Compile -> $error"
    return
}

FD "FUNC_CREATE_UDPSENDER : Success to Compile!"
}
#############################################################################
## Procedure:  FUNC_DOWNLOAD_UDPSENDER

proc ::FUNC_DOWNLOAD_UDPSENDER {file_name} {
global widget

global tcl_platform
global g_rootdir

if { [string match -nocase "*window*" $tcl_platform(platform)] == 1 } {
    return
}


if { [file exist [file join $g_rootdir $file_name]] == 1 } {
    return
}

### download
set res [FUNC_DOWNLOAD_FILE "BIN" $file_name [file join $g_rootdir $file_name]]

if { $res == "FALSE" } {
    FD "FUNC_DOWNLOAD_UDPSENDER : Download Fail -> $file_name"
    return "FALSE"
} else {
    FD "FUNC_DOWNLOAD_UDPSENDER : Download Success -> $file_name"
}
}
#############################################################################
## Procedure:  test5

proc ::test5 {} {
global widget

FUNC_KILL_PROCESS "xrcmd"
}
#############################################################################
## Procedure:  test2

proc ::test2 {} {
global widget

FD "TEST2 -> "
}
#############################################################################
## Procedure:  FUNC_CHECK_FILE

proc ::FUNC_CHECK_FILE {filename} {
global widget

global g_rootdir
### check file and download if it needs

if { [file exist [file join $g_rootdir $filename]] == 1 } { return "TRUE" }

#FD "FUNC_CHECK_FILE : File exists -> [file exist [file join $g_rootdir $filename]]"

if { [FUNC_DOWNLOAD_FILE "BIN" $filename ""] == "TRUE" } { return "TRUE" }

return "FALSE"
}
#############################################################################
## Procedure:  FUNC_CONFIRM_VALIDATION

proc ::FUNC_CONFIRM_VALIDATION {flag title msg filename qry} {
global widget

global g_rootdir
global g_canvas_confirm

if [catch {
    $g_canvas_confirm delete all
} err] {
}

#foreach item [ $g_canvas_confirm find all ] {
#    $g_canvas_confirm delete $item
#}


set canvas_width "700"
set canvas_height "250"

### chech file
if { [FUNC_CHECK_FILE $filename] == "TRUE" } {

    if [catch {
        set img [image create photo -file [file join $g_rootdir $filename]]
        set height [image height $img]
        set width [image width $img]
    } err] {
        FD "FUNC_CONFIRM_VALIDATION ERROR : $err"
    }
    
    if [catch {
        $g_canvas_confirm create image [expr $canvas_width/2] [expr $canvas_height/2] -anchor center -image $img
    } err] {
        FD "FUNC_CONFIRM_VALIDATION ERROR : $err"
    }
} else {
    if [catch {
        $g_canvas_confirm create text [expr $canvas_width/2] [expr $canvas_height/2] -anchor center -text $title -font "helvetica 12 bold"
    } err] {
        FD "FUNC_CONFIRM_VALIDATION ERROR : $err"
    }
}

### set msg
#global g_confirm_msg
#set g_confirm_msg $msg

global g_lst_confirm

$g_lst_confirm subwidget listbox delete 0 end
$g_lst_confirm subwidget listbox insert end "- VALIDATION FLAG"
$g_lst_confirm subwidget listbox insert end "$title"
$g_lst_confirm subwidget listbox insert end ""


$g_lst_confirm subwidget listbox insert end "- RESULT"
foreach tmp [split $msg "\\\n"] {

    $g_lst_confirm subwidget listbox insert end "$tmp"
    
}


### set flag
global g_confirm_variable
set g_confirm_variable $flag

### set query
global g_confirm_query
set g_confirm_query $qry

### display confirmation window
Window show .top86
set a [expr {int([winfo screenwidth .] * 0.5)}]
set b [expr {int([winfo screenheight .] * 0.5)}]
wm geometry .top86 [format "%sx%s+%s+%s" 730 540 [expr $a/2] [expr $b/2-40]]
}
#############################################################################
## Procedure:  FUNC_DEBUG_CLEAR

proc ::FUNC_DEBUG_CLEAR {} {
global widget

global g_lst_debug

#$g_lst_debug subwidget listbox delete 0 end
$g_lst_debug subwidget listbox delete 0 end
}
#############################################################################
## Procedure:  FUNC_DEBUG_SAVE

proc ::FUNC_DEBUG_SAVE {} {
global widget

global g_rootdir
global tcl_platform
global g_lst_debug
global g_hostname


if { [$g_lst_debug subwidget listbox size] < 1 } {
    set msg {"No Contents!" "\x00\xC8\xA5\xC7\x60\xD5\x20\x00\xB4\xB0\xA9\xC6\x74\xC7\x20\x00\xC6\xC5\xB5\xC2\xC8\xB2\xE4\xB2\x21\x00"}
    set choice [ tk_messageBox -title "Save Debug File" -icon warning -message [FM "" $msg ""] ]
    return
}

if { [string match -nocase "*window*" $tcl_platform(platform)] == 1 } {
    set logfile [file join $g_rootdir [format "%s_%s" $g_hostname "scops_debug.txt"]]
} else {
    set logfile [file join $g_rootdir [format "%s_%s" $g_hostname "scops_debug.log"]]
}

puts "logfile : $logfile"

if [catch { 
    set fd [open $logfile a]
    
    for { set i 0 } { $i < [$g_lst_debug subwidget listbox size] } {incr i } {
        puts $fd "[$g_lst_debug subwidget listbox get $i]"
    }
    close $fd
} error ] {
    #set msg {"Fail to Save Debug File!" "\x5C\xB8\xF8\xAD\x0C\xD3\x7C\xC7\x20\x00\xDD\xC0\x31\xC1\x20\x00\xE4\xC2\x28\xD3\x21\x00"}
    #set choice [ tk_messageBox -title "Save Debug File" -icon warning -message [FM "" $msg $logfile]   ]

    close $fd
    return
}

#set msg {"Success to Save Debug File!" "\x5C\xB8\xF8\xAD\x0C\xD3\x7C\xC7\x20\x00\xDD\xC0\x31\xC1\x20\x00\x31\xC1\xF5\xAC\x21\x00"}
#set choice [ tk_messageBox -title "Save Debug File" -icon warning -message [FM "" $msg $logfile] ]
}
#############################################################################
## Procedure:  FUNC_DEBUG_DELETEFILE

proc ::FUNC_DEBUG_DELETEFILE {} {
global widget

global g_rootdir
global tcl_platform
global g_lst_debug
global g_hostname

if { [string match -nocase "*window*" $tcl_platform(platform)] == 1 } {
    set logfile [file join $g_rootdir [format "%s_%s" $g_hostname "scops_debug.txt"]]
} else {
    set logfile [file join $g_rootdir [format "%s_%s" $g_hostname "scops_debug.log"]]
}

if { [file exist $logfile] == 1 } {
    if [catch {
        set tmp [file delete $logfile]
    } err] {
        FD "FUNC_DELETE_DEBUGFILE ERROR : $err"
        return "FALSE"
    }
}
}
#############################################################################
## Procedure:  FUNC_DEBUG_SENDFILE

proc ::FUNC_DEBUG_SENDFILE {} {
global widget

FUNC_DEBUG_SAVE

#set sender "ngukim"
#set recipient "namgu.kim@amkor.co.kr"
set sender "sjolee"
set recipient "sunjong.lee@amkor.co.kr"
set cc ""

global g_rootdir
global tcl_platform
global g_lst_debug
global g_hostname

set subject "SCOPS DEBUG - $g_hostname"

set body "SCOPS_DEBUG_TRACKING!"

if { [string match -nocase "*window*" $tcl_platform(platform)] == 1 } {
    set logfile [file join $g_rootdir [format "%s_%s" $g_hostname "scops_debug.txt"]]
} else {
    set logfile [file join $g_rootdir [format "%s_%s" $g_hostname "scops_debug.log"]]
}

set filepath $logfile

FUNC_SEND_EMAIL $sender $recipient $cc $subject $body $filepath
}
#############################################################################
## Procedure:  FUNC_CHECK_OPERATORID_org

proc ::FUNC_CHECK_OPERATORID_org {} {
global widget

global g_confirm_var
global g_confirm_msg


if { [subst $g_confirm_var] == "" } {
    FD "FUNC_CHECK_OPERATORID : There's no g_confirm_var's value"
    return
}


global g_confirmationoperatorid

if { $g_confirmationoperatorid == "" } {
    set choice [ tk_messageBox -title "Check OperatorID Error" -icon warning -message "Input your operatorid!   "]
    return
}

global g_hostname
global g_lotname
global g_dcc
global g_operation 

set qry "SCOPS,CheckOperatorID,$g_confirmationoperatorid,$g_confirm_var,$g_hostname,$g_lotname,$g_dcc,$g_operation*"

set res ""
set res [FUNC_SEND_QRY "$qry"]

FD "FUNC_CHECK_OPERATORID : $res"

if { [lindex [split $res ","] 0] == "FAIL" } {
    set choice [ tk_messageBox -title "Check OperatorID Error" -icon warning -message "$res    "]
    return
}


### set flag
global g_confirm_var


if { [FUNC_CHECK_VARIABLE g_confirm_var] == "NULL" } {
    set choice [ tk_messageBox -title "Check OperatorID Error" -icon warning -message "No Confirm Flag!    "]
    return
}

if { $g_confirm_var == "" } {
    set choice [ tk_messageBox -title "Check OperatorID Error" -icon warning -message "No Confirm Flag!    "]
    return
}


global [subst $g_confirm_var]

if { [lindex [split $res ","] 0] == "NO"  } {
    set [subst $g_confirm_var] "FALSE"
    set choice [ tk_messageBox -title "Check OperatorID Error" -icon warning -message "Your Operator ID Is Wrong!   \n\nTry Again!   "]
    return
} else {
    set [subst $g_confirm_var] "TRUE"
    set g_confirmationoperatorid ""
    set choice [ tk_messageBox -title "Check OperatorID" -icon warning -message "Success To Confirm Your Operator ID!   "]
    Window hide .top86
}

### initialize
set g_confirm_var ""
set g_confirm_msg ""
}
#############################################################################
## Procedure:  FUNC_CONFIRM_VALIDATION_LOG

proc ::FUNC_CONFIRM_VALIDATION_LOG {flag} {
global widget

global g_confirm_operatorid
global g_confirm_variable
global g_confirm_query

global g_operatorid

set result ""

if { $flag == "YES" } {

    set result "FAIL_BUT_PASS"

    if { $g_confirm_operatorid == "" } {
        set choice [ tk_messageBox -title "Input Error" -icon warning -message "Input your operator id!" ]
        return "FALSE"
    }

    if { [lindex [split [FUNC_CHECK_OPERATORID $g_confirm_operatorid] ","] 0] != "YES" } {
        set choice [ tk_messageBox -title "Operator ID Error" -icon warning -message "Your operator ID is wrong(X)!\n\nInput again." ]
        return "FALSE"
    }

    ### set flag
    if { [FUNC_CHECK_VARIABLE g_confirm_variable] == "NULL" } {
        FD "FUNC_CONFIRM_VALIDATION_YES : g_confirm_variable is not defined!"
        return "FALSE"
    }

    global [subst $g_confirm_variable]
    set [subst $g_confirm_variable] "TRUE"

    
} elseif { $flag == "NO" } {

    set result "FAIL"

    global [subst $g_confirm_variable]
    set [subst $g_confirm_variable] "FALSE"

} else {

    Window hide .top86
    return "TRUE"

}


### send log query
if { [FUNC_CHECK_VARIABLE g_confirm_query] == "NULL" } {
    FD "FUNC_CONFIRM_VALIDATION_YES : g_confirm_query is not defined!"
    return "FALSE"
}

if { $g_confirm_query == "" } {
    return "TRUE"
}

set g_confirm_query [string map {"*" ""} $g_confirm_query]
#FD "g_confirm_query : $g_confirm_query"

if { $flag == "YES" } {
    set g_confirm_query [format "%s,%s,%s*" $g_confirm_query $g_confirm_operatorid $flag]
} else {
    set g_confirm_query [format "%s,%s,%s*" $g_confirm_query $g_operatorid $flag]
}
set res [FUNC_SEND_QRY $g_confirm_query]

### initialize
set g_confirm_operatorid ""
set g_confirm_variable ""
set g_confirm_query ""

Window hide .top86
Window hide .top84

return "TRUE"
}
#############################################################################
## Procedure:  FUNC_CHECK_FULLTEST

proc ::FUNC_CHECK_FULLTEST {} {
global widget

global g_hostname
global g_lotname
global g_dcc
global g_operation
global g_job
global g_operatorid

######################################
### demo setting #####################
#set tmplotname "J1N2T222.L1C1"
#set tmpdcc ""
#set tmpoperation "TEST1"
######################################
######################################

set qry "SCOPS,CheckFullTest,check,$g_hostname,$g_lotname,$g_dcc,$g_operation,$g_job*"

set res ""
set res [FUNC_SEND_QRY $qry]


if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
    set choice [ tk_messageBox -title "Full Test Check Error" -type yesno -icon warning -message $res]
    
    if { $choice == "yes" } {
        return "TRUE"
    } else {
        return "FALSE"
    }
}

if { [lindex [split $res ","] 0] == "NO" } {
    set msg ""
    set choice [ tk_messageBox -title "Full Test Check Error" -type yesno -icon warning -message [FM "K3 engineer" $msg $res] ]
    
    if { $choice == "yes" } {
        return "TRUE"
    } else {
        return "FALSE"
    }
}

return "TRUE"
}
#############################################################################
## Procedure:  FUNC_CHECK_RETEST

proc ::FUNC_CHECK_RETEST {} {
global widget

global g_hostname
global g_lotname
global g_dcc
global g_operation
global g_job
global g_operatorid

######################################
### demo setting #####################
#set tmplotname "J1N2T222.L1C1"
#set tmpdcc ""
#set tmpoperation "TEST1"
######################################
######################################

set qry "SCOPS,CheckReTest,check,$g_hostname,$g_lotname,$g_dcc,$g_operation,$g_job*"

set res ""
set res [FUNC_SEND_QRY $qry]


if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
    set choice [ tk_messageBox -title "Retest Check Error" -type yesno -icon warning -message $res]
    
    if { $choice == "yes" } {
        return "TRUE"
    } else {
        return "FALSE"
    }
}

if { [lindex [split $res ","] 0] == "NO" } {
    set msg ""
    set choice [ tk_messageBox -title "Retest Check Error" -type yesno -icon warning -message [FM "K3 engineer" $msg $res] ]
    
    if { $choice == "yes" } {
        #FD "TRUE"
        return "TRUE"
    } else {
        #FD "FALSE"
        return "FALSE"
    }
}

return "TRUE"
}
#############################################################################
## Procedure:  FUNC_APL_MICROCHIP

proc ::FUNC_APL_MICROCHIP {flag} {
global widget

global tcl_platform

if { [string match -nocase "*window*" $tcl_platform(platform)] != 1 } { 
    #puts "This is windows platform"
    return "TRUE"
}

global g_hostname
global g_lotname
global g_dcc
global g_operation
global g_job
global g_customer
global g_devicename
global g_testprogram
global g_testprogramrev
global g_condition
global g_temperature
global g_incount
global g_operatorid
global g_handler
global g_board
global g_kit
global g_probe

global g_socketcount
global g_handlertype

set apl_name "MICROCHIP"

set qry "SCOPS,APL_MICROCHIP,$flag,$g_hostname,$g_lotname,$g_dcc,$g_operation,$g_job,$g_customer,$g_devicename,$g_testprogram,$g_testprogramrev,$g_condition,$g_temperature,$g_incount,$g_operatorid,$g_handler,$g_board,$g_kit,$g_probe,$g_socketcount,$g_handlertype*"

set res ""
set res [FUNC_SEND_QRY $qry]

if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
    set choice [ tk_messageBox -title "$apl_name APL ERROR" -icon warning -message [FM "TESTIT" "Failure to create $apl_name APL file!" $res] ]
    return "FALSE"
}


if { [lindex [split $res ","] 0] == "NO" } {
    return "TRUE"
}

set apl_file [lindex [split $res ","] 0]
set apl_path [file dir $apl_file]
set test_oi [lindex [split $res ","] 1]
set apl_format [lindex [split $res ","] 2]


#FD "apl_file : $apl_file"
#FD "apl_path : $apl_path"
#FD "test_oi : $test_oi"
#FD "apl_format : $apl_format"

if { [file exist $apl_path] != 1 } {
    if [catch {
        set tmp [file mkdir $apl_path]
    } err] {
        FD "$apl_name APL ERROR : Fail to create directory -> $apl_path ($err)"
        set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TESTIT" "Please, Check $apl_path authority to modify!" $res] ]
        return "FALSE"
    }     
}

### clear APL ##################
if { [file exist $apl_file] == 1 } {
    if [catch { 
        set delete_file [file delete $apl_file]
    } err] {
        FD "$apl_name APL ERROR : Failture to delete the previous $apl_file"
        set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TESTIT" "Please, Check $apl_file authority to delete!" $res] ]
        return "FALSE"
    }  
}


if { $flag == "DELETE" } {
    return "TRUE"
}


### start writing APL parameters ###
if [catch {
    
    set apl_fd [open $apl_file w]
    
    set apl_contents ""
    
    for { set i 3 } { $i <= [llength [split $res ","]] } { incr i } {
           
        if { $apl_format == "COMMA" } {   
             if { $apl_contents != "" && $i != [llength [split $res ","]] } {
                set apl_contents [format "%s,%s" $apl_contents [lindex [split $res ","] $i] ]
            } else {
                set apl_contents [format "%s%s" $apl_contents [lindex [split $res ","] $i] ]
            }        
        } else {
            puts $apl_fd [lindex [split $res ","] $i]
        }
                
    }
    
    if { $apl_contents != "" } {
        puts $apl_fd $apl_contents
    }
    
    close $apl_fd
      
    FD "$apl_name APL SUCCESS!"
    
    ### execute TEST OI
    if { $test_oi != "" } {
        if [catch { 
            set tmp [exec $test_oi &]
        } err] {
            FD "$apl_name APL ERROR : Failure to execute $test_oi ($err)"
            set delete_file [file delete $apl_file]
            set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TESTIT" "Failure to execute $test_oi!" $res] ]
            return "FALSE"
        }    
    }
    
} err ] {
    FD "$apl_name APL ERROR : $err"
    set delete_file [file delete $apl_file]
    return "FALSE"
}

return "TRUE"
}
#############################################################################
## Procedure:  ATK_GROUP_ADDRETEST

proc ::ATK_GROUP_ADDRETEST {} {
global widget

global g_database

if { $g_database != "EVE" } {

    if { [FUNC_CHECK_RETEST] != "TRUE" } {
        FD "FUNC_CHECK_RETEST : FALSE"
        return "FALSE"
    } 

} 
}
#############################################################################
## Procedure:  FUNC_APL_EVE_SLT

proc ::FUNC_APL_EVE_SLT {flag} {
global widget


global tcl_platform

if { [string match -nocase "*window*" $tcl_platform(platform)] != 1 } { 
    #puts "This is windows platform"
    return "TRUE"
}


global g_hostname
global g_lotname
global g_dcc
global g_operation
global g_job
global g_customer
global g_testprogram
global g_testprogramrev
global g_devicename
global g_operatorid
global g_handler
global g_temperature
global g_boardno
global g_incount
global g_condition
global g_customer

set apl_name "SLT"

set qry "SCOPS,APL_EVE_SLT,$g_hostname,$g_lotname,$g_dcc,$g_operation,$g_job,$g_testprogram,$g_testprogramrev,$g_devicename,$g_incount,$g_operatorid,$g_customer*"

set res ""
set res [FUNC_SEND_QRY $qry]

if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
    set msg {"Fail of SLT APL" ""}
    set choice [ tk_messageBox -title "$apl_name APL Error" -icon warning -message [FM "TESTIT" $msg $res] ]
    return "FALSE"
}


if { [lindex [split $res ","] 0] == "NO" } {

    return "TRUE"
}

set apl_file [lindex [split $res ","] 0]
set apl_path [file dir $apl_file]
set test_oi [lindex [split $res ","] 1]


if { [file exist $apl_path] != 1 } {
    if [catch {
        set tmp [file mkdir $apl_path]
    } err] {
        FD "FUNC_APL_$apl_name : can't create directory $apl_path"
        set choice [ tk_messageBox -title "FUNC_APL_$apl_name Error" -message "============================================\n\nContact : K3 Engineer, TESTIT\n\n============================================\n\nCan't delete the previous $apl_file\nCheck the file authority!!!" ]
        return "FALSE"
    }     
}

### clear APL ##################
if { [file exist $apl_file] == 1 } {
    if [catch { 
        set delete_file [file delete $apl_file]
    } err] {
        FD "FUNC_APL_$apl_name : can't delete $apl_file"
        set choice [ tk_messageBox -title "FUNC_APL_$apl_name Error" -message "============================================\n\nContact : K3 Engineer, TESTIT\n\n============================================\n\nCan't delete the previous $apl_file\nCheck the file authority!!!" ]
        return "FALSE"
    }  
}

### start writing APL parameters ###
if [catch {
    
    set apl_fd [open $apl_file w]
    
    #1.Test Program
    set apl_contents ""

    for { set i 2 } { $i <= [llength [split $res ","]] } { incr i } {
                   
        #if { $apl_contents != "" && $i != [llength [split $res ","]] } {
        #    set apl_contents [format "%s,%s" $apl_contents [lindex [split $res ","] $i] ]
        #} else {
        #    set apl_contents [format "%s%s" $apl_contents [lindex [split $res ","] $i] ]
        #}
        
        
        puts $apl_fd [lindex [split $res ","] $i]
    }
    
    #puts $apl_fd $apl_contents
    close $apl_fd
      
    FD "FUNC_APL_$apl_name writing success!"
    
    ### execute TEST OI
    if { $test_oi != "" } {
        set tmp [exec $test_oi &]
    }
    
} err ] {
    FD "FUNC_APL_$apl_name error : $err"
    set delete_file [file delete $apl_file]
    return "FALSE"
}

return "TRUE"
}
#############################################################################
## Procedure:  FUNC_APL_EVE_UFLEX

proc ::FUNC_APL_EVE_UFLEX {flag} {
global widget


global tcl_platform

if { [string match -nocase "*window*" $tcl_platform(platform)] != 1 } { 
    #puts "This is windows platform"
    return "TRUE"
}


global g_hostname
global g_lotname
global g_dcc
global g_operation
global g_job
global g_customer
global g_testprogram
global g_testprogramrev
global g_devicename
global g_operatorid
global g_handler
global g_temperature
global g_boardno
global g_incount
global g_condition
global g_customer

set apl_name "UFLEX"

set qry "SCOPS,APL_EVE_Uflex,$flag,$g_hostname,$g_lotname,$g_dcc,$g_operation,$g_job,$g_testprogram,$g_testprogramrev,$g_devicename,$g_incount,$g_operatorid,$g_condition,$g_customer*"

set res ""
set res [FUNC_SEND_QRY $qry]

if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
    set msg "UFLEX APL FAILURE"
    set choice [ tk_messageBox -title "$apl_name APL Error" -icon warning -message [FM "TESTIT" $msg $res] ]
    return "FALSE"
}


if { [lindex [split $res ","] 0] == "NO" } {

    return "TRUE"
}

set apl_file [lindex [split $res ","] 0]
set apl_path [file dir $apl_file]
set test_oi [lindex [split $res ","] 1]


if { [file exist $apl_path] != 1 } {
    if [catch {
        set tmp [file mkdir $apl_path]
    } err] {
        FD "FUNC_APL_$apl_name : can't create directory $apl_path"
        set choice [ tk_messageBox -title "FUNC_APL_$apl_name Error" -message "============================================\n\nContact : K3 Engineer, TESTIT\n\n============================================\n\nCan't delete the previous $apl_file\nCheck the file authority!!!" ]
        return "FALSE"
    }     
}


### clear APL ##################
if { [file exist $apl_file] == 1 } {
    if [catch { 
        set delete_file [file delete $apl_file]
    } err] {
        FD "FUNC_APL_$apl_name : can't delete $apl_file"
        set choice [ tk_messageBox -title "FUNC_APL_$apl_name Error" -message "============================================\n\nContact : K3 Engineer, TESTIT\n\n============================================\n\nCan't delete the previous $apl_file\nCheck the file authority!!!" ]
        return "FALSE"
    }  
}

if { $flag == "DELETE" } {
    return "TRUE"
}


### start writing APL parameters ###
if [catch {
    
    set apl_fd [open $apl_file w]
    
    #1.Test Program
    set apl_contents ""

    for { set i 2 } { $i <= [llength [split $res ","]] } { incr i } {
                   
        #if { $apl_contents != "" && $i != [llength [split $res ","]] } {
        #    set apl_contents [format "%s,%s" $apl_contents [lindex [split $res ","] $i] ]
        #} else {
        #    set apl_contents [format "%s%s" $apl_contents [lindex [split $res ","] $i] ]
        #}
        
        
        puts $apl_fd [lindex [split $res ","] $i]
    }
    
    #puts $apl_fd $apl_contents
    close $apl_fd
      
    FD "FUNC_APL_$apl_name writing success!"
    
    ### execute TEST OI
    if { $test_oi != "" } {
        set tmp [exec $test_oi &]
    }
    
} err ] {
    FD "FUNC_APL_$apl_name error : $err"
    set delete_file [file delete $apl_file]
    return "FALSE"
}

return "TRUE"
}
#############################################################################
## Procedure:  FUNC_RFID_CHECK

proc ::FUNC_RFID_CHECK {} {
global widget

global g_previousoperatorid
global g_rfid_flag


global g_testing_flag

if { [string match -nocase "*testing*" $g_testing_flag] == 1 } {

    if { [string match -nocase "*_R*" $g_previousoperatorid] == 1 } { 
        set g_rfid_flag "TRUE" 
    } else {
        set g_rfid_flag "FALSE" 
    }
}

# set operator id
global g_operatorid_sub
    
if { [FUNC_CHECK_VARIABLE g_operatorid_sub] == "NULL" } {
    set g_operatorid_sub ""
}
    
if { $g_rfid_flag == "TRUE" } {         
    if { [string match -nocase "*_R*" $g_operatorid_sub] == 0 } {
        set g_operatorid_sub [format "%s%s" $g_operatorid_sub "_R"]
    }
}
}
#############################################################################
## Procedure:  FUNC_RFID_CLEAR_SOCKETTOUCHCOUNT

proc ::FUNC_RFID_CLEAR_SOCKETTOUCHCOUNT {} {
global widget
global g_hostname 

global g_operation 

if { [string match -nocase "*prob*" $g_operation] == 1 } {
    return
}


global g_testing_flag

if { $g_testing_flag == "TESTING" } {
    set choice [ tk_messageBox -title "Clear Socket Error" -icon error -message [FM "" "Fail to Clear Socket!newlinenewlineTester is running now." ""] ]
    return
}

#global g_rfid_flag

#if { $g_rfid_flag != "TRUE" } {
#    set choice [ tk_messageBox -title "Clear Socket Error" -icon error -message [FM "" "Fail to Clear Socket!newlinenewlineThis test tarted without RFID.   " ""] ]
#    return
#}


global g_socket_operator

if { [string trim $g_socket_operator] == "" } {
    set choice [ tk_messageBox -title "Clear Socket Error" -icon error -message [FM "" "Fail to Clear Socket!newlinenewlineInput your operator ID.   " ""] ]
    return
}


global g_socketsitenumber
for { set i 1 } { $i<=$g_socketsitenumber } { incr i } {

    global g_socket_check$i
    global g_socket$i
    global g_socket_touch$i
    global g_socket_limit$i
    global g_socket_ext$i

    set qry ""
    
    if { [subst $[format "g_socket_check%d" $i]] == 1 && [string trim [subst $[format "g_socket%d" $i]] ] != "" && [string trim [subst $[format "g_socket_touch%d" $i]] ] != "" } {
       
       if { [FUNC_RFID_CHECK_SOCKETCLEAR [subst $[format "g_socket%d" $i]]] == "TRUE" } {

           set qry "SCOPS,ClearSocket,[subst $[format "g_socket%d" $i]],[subst $[format "g_socket_touch%d" $i]],$g_socket_operator,$g_hostname*"   
           #FD "qry : $qry"
           set res ""
           set res [FUNC_SEND_QRY $qry]
       
       }
       
    }
    
}

FUNC_RFID_INITIALIZE
FUNC_RFID_REFRESH
}
#############################################################################
## Procedure:  FUNC_RFID_EXTEND_SOCKETLIMIT

proc ::FUNC_RFID_EXTEND_SOCKETLIMIT {} {
global widget
global g_hostname

#########################
### demo setting ########
global g_operation 
global g_testing_flag
global g_rfid_flag
global g_socket_operator

#set g_operation "TEST1"
#set g_testing_flag "TESTING"
#set g_rfid_flag "TRUE"
#set g_socket_operator "testit"
#########################
#########################



global g_operation 

if { [string match -nocase "*TEST*" $g_operation] == 0 && [string match -nocase "*TSQA*" $g_operation] == 0  } { return }


global g_testing_flag
if { $g_testing_flag == "TESTING" } {
    set choice [ tk_messageBox -title "Extend Socket Limit Error" -icon error -message [FM "" "Fail to Extend Socket Limit!newlinenewlineTester is running now." ""] ]
    return
}


#global g_rfid_flag
#if { $g_rfid_flag != "TRUE" } {    
#    set choice [ tk_messageBox -title "Extend Socket Limit Error" -icon error -message [FM "" "Fail to Extend Socket Limit!newlinenewlineTester is running now." ""] ]
#    return
#}


global g_socket_operator
if { [string trim $g_socket_operator] == "" } {
    set choice [ tk_messageBox -title "Extend Socket Limit Error" -icon error -message [FM "" "Fail to Extend Socket Limit!newlinenewlineInput your operator ID.   " ""] ]
    return
}


global g_socketsitenumber
for { set i 1 } { $i<=$g_socketsitenumber } { incr i } {

    global g_socket_check$i
    global g_socket$i
    global g_socket_touch$i
    global g_socket_limit$i
    global g_socket_ext$i

    set qry ""
    
    if { [subst $[format "g_socket_check%d" $i]] == 1 && [string trim [subst $[format "g_socket%d" $i]] ] != "" && [string trim [subst $[format "g_socket_ext%d" $i]] ] != "" } {
       set qry "SCOPS,ExtendSocket,[subst $[format "g_socket%d" $i]],[subst $[format "g_socket_ext%d" $i]],$g_socket_operator,$g_hostname*"
       puts "qry : $qry"
       
       set res ""
       set res [FUNC_SEND_QRY $qry]
    }
    
}

FUNC_RFID_INITIALIZE
FUNC_RFID_REFRESH
}
#############################################################################
## Procedure:  FUNC_RFID_CLEAR_PROBETOUCHDOWN

proc ::FUNC_RFID_CLEAR_PROBETOUCHDOWN {} {
global widget
global g_hostname

global g_operation 
if { [string match -nocase "*prob*" $g_operation] == 0 } { 
    set choice [ tk_messageBox -title "Clear Probe Error" -icon error -message [FM "" "Fail to Clear Probe!newlinenewlineThis is not Probe Test.   " ""] ]
    return
}

global g_testing_flag

if { $g_testing_flag == "TESTING" } {
    set choice [ tk_messageBox -title "Clear Probe Error" -icon error -message [FM "" "Fail to Clear Probe!newlinenewlineOnly when tester is not running,   newlinenewline You can clear Probe.   " ""] ]
    return
}

global g_rfid_flag

if { $g_rfid_flag != "TRUE" } {
    set choice [ tk_messageBox -title "Clear Probe Error" -icon error -message [FM "" "Fail to Clear Probe!newlinenewlineThis test is not started with RFID.   " ""] ]
    return
}


global g_probe_operator

if { [string trim $g_probe_operator] == "" } {
    set choice [ tk_messageBox -title "Clear Probe Error" -icon error -message [FM "" "Fail to Clear Probe!newlinenewlineInput your operator ID.   " ""] ]
    return
}

global g_probe_comment

if { [string trim $g_probe_comment] == "" } {
    set choice [ tk_messageBox -title "Clear Probe Error" -icon error -message [FM "" "Fail to Clear Probe!newlinenewlineInput the comment.   " ""] ]
    return
}

global g_probe
global g_probe_touch

if { [string trim $g_probe] == "" || [string trim $g_probe_touch] == "" } { return }

set qry "SCOPS,ClearProbe,$g_probe,$g_probe_touch,$g_probe_operator,$g_probe_comment,$g_hostname*"

set res ""

set res [FUNC_SEND_QRY $qry]

set g_probe_operator ""
set g_probe_comment ""

FUNC_RFID_INITIALIZE
FUNC_RFID_REFRESH
}
#############################################################################
## Procedure:  FUNC_RFID_EXTEND_PROBELIMIT

proc ::FUNC_RFID_EXTEND_PROBELIMIT {} {
global widget
global g_hostname

global g_operation 
global g_testing_flag
global g_rfid_flag
global g_probe_operator
global g_testing_flag
global g_rfid_flag
global g_probe_operator
global g_probe_comment
global g_probe
global g_probe_ext
global g_probe_comment

if { $g_rfid_flag != "TRUE" } {
    set choice [ tk_messageBox -title "Extend Probe Limit Error" -icon error -message [FM "" "Fail to Extend Probe Limit!newlinenewlineThis test is not started with RFID.   " ""] ]
    return
}

if { [string trim $g_probe_operator] == "" } {
    set choice [ tk_messageBox -title "Extend Probe Limit Error" -icon error -message [FM "" "Fail to Extend Probe Limit!newlinenewlineInput your operator ID.   " ""] ]
    return
}

if { [string trim $g_probe] == "" || [string trim $g_probe_ext] == "" } { return }

set qry "SCOPS,ExtendProbe,$g_probe,$g_probe_ext,$g_probe_operator,$g_probe_comment,$g_hostname,$g_operation*"

set res ""

set res [FUNC_SEND_QRY $qry]

if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } { 
    set choice [ tk_messageBox -title "FUNC_RFID_EXTEND_PROBELIMIT ERROR" -icon warning -message [FM "TESTIT" "" $res] ]
    return "FALSE" 
}
    
if { [lindex [split $res ","] 0] == "0" || [lindex [split $res ","] 0] == "SUCCESS" } { 
    set choice [ tk_messageBox -title "FUNC_RFID_EXTEND_PROBELIMIT SUCCESS" -icon info -message [FM "K3,K5 Engineer" "PROBE TOUCH DOWN LIMIT EXTEND SUCCESS!" ""] ]  
} else {
    set choice [ tk_messageBox -title "FUNC_RFID_EXTEND_PROBELIMIT FAIL" -icon error -message [FM "K3,K5 Engineer" "PROBE TOUCH DOWN LIMIT EXTEND FAIL!" ""] ]
}
    

set g_probe_operator ""
set g_probe_comment ""


FUNC_RFID_INITIALIZE
FUNC_RFID_REFRESH
}
#############################################################################
## Procedure:  FUNC_CHECK_PROBE

proc ::FUNC_CHECK_PROBE {} {
global widget

global g_hostname
global g_lotname
global g_dcc
global g_operation
global g_operatorid
global g_customer
global g_probe
#global g_kit


global g_rfid_flag
if { $g_rfid_flag != "TRUE" } { 
    FD "FUNC_CHECK_PROBE : rfid flag"
    return "TRUE" 
}

if { [string match -nocase "*PROB*" $g_operation] == 0 } { 
    FD "FUNC_CHECK_PROBE : operation"
    return "TRUE" 
}

set qry "SCOPS,CheckProbe,CHECK,$g_hostname,$g_lotname,$g_dcc,$g_operation,$g_operatorid,$g_customer,$g_probe*"

set res ""
set res [FUNC_SEND_QRY $qry]


if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
    set choice [ tk_messageBox -title "Probe Check Error" -icon warning -message [FM "TESTIT" "Fail to Check Probe" $res] ]
    return "TRUE"
}

if { [lindex [split $res ","] 0] == "NO" } {
    set choice [ tk_messageBox -title "Probe Check Error" -icon error -message [FM "K3 Engineer, HCC" "Fail to Check Probe" $res] ]
    return "FALSE"
}

return "TRUE"
}
#############################################################################
## Procedure:  FUNC_CHECK_PROBESITEVARIANCE

proc ::FUNC_CHECK_PROBESITEVARIANCE {} {
global widget

global g_hostname
global g_operation
global g_testing_flag


if { [string match -nocase "*prob*" $g_operation] == 0 } { return "TRUE" }

if { $g_testing_flag != "TESTING" } { return "TRUE" }


set qry "SCOPS,CheckProbeSiteVariance,$g_hostname*"

set res ""
set res [FUNC_SEND_QRY $qry]

#############################
#############################
#set res "NO"
#############################
#############################

if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
    #set choice [ tk_messageBox -title "Probe Site Variance Check Error" -icon warning -message [FM "TESTIT" "Fail to Check Probe Site Variance" $res] ]
    return "FALSE"
}

if { [lindex [split $res ","] 0] == "YES" } { return "TRUE" }

global g_tester_status

if { [string match -nocase "*svr*" $g_tester_status] == 0 } {
    set g_tester_status [format "%s %s" $g_tester_status "SVR"]
    #set g_tester_status [format "PROBE SVR %s" $g_tester_status]
}

global g_note_root

#color
set color #FFC029
lbl_status configure -background $color
#$g_note_root configure -background $color
.top83 configure -background $color

return "FALSE"
}
#############################################################################
## Procedure:  FUNC_APL_T2000_org

proc ::FUNC_APL_T2000_org {} {
global widget

global tcl_platform

if { [string match -nocase "*window*" $tcl_platform(platform)] != 1 } { 
    #puts "This is windows platform"
    return "TRUE"
}


global g_hostname
global g_lotname
global g_dcc
global g_operation
global g_job
global g_customer
global g_testprogram
global g_testprogramrev
global g_devicename
global g_operatorid
global g_handler
global g_board
global g_temperature
global g_socketcount
global g_handlertype

set qry "SCOPS,APL_T2000,$g_hostname,$g_lotname,$g_dcc,$g_operation,$g_job,$g_customer,$g_devicename,$g_testprogram,$g_testprogramrev,$g_operatorid,$g_temperature,$g_handler,$g_board,$g_socketcount,$g_handlertype*"

set res ""
set res [FUNC_SEND_QRY $qry]

if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
    set msg {"Fail of MWEST APL" ""}
    set choice [ tk_messageBox -title "MWEST APL Error" -icon warning -message [FM "TESTIT" $msg $res] ]
    return "FALSE"
}


if { [lindex [split $res ","] 0] == "NO" } {

    return "TRUE"
}

set apl_file [lindex [split $res ","] 0]
set apl_path [file dir $apl_file]
set test_oi [lindex [split $res ","] 1]


if { [file exist $apl_path] != 1 } {
    if [catch {
        set tmp [file mkdir $apl_path]
    } err] {
        FD "FUNC_APL_MWEST : can't create directory $apl_path"
        set choice [ tk_messageBox -title "FUNC_APL_MWEST Error" -message "============================================\n\nContact : K3 Engineer, TESTIT\n\n============================================\n\nCan't delete the previous $apl_file\nCheck the file authority!!!" ]
        return "FALSE"
    }     
}

### clear APL ##################
if { [file exist $apl_file] == 1 } {
    if [catch { 
        set delete_file [file delete $apl_file]
    } err] {
        FD "FUNC_APL_MWEST : can't delete $apl_file"
        set choice [ tk_messageBox -title "FUNC_APL_MWEST Error" -message "============================================\n\nContact : K3 Engineer, TESTIT\n\n============================================\n\nCan't delete the previous $apl_file\nCheck the file authority!!!" ]
        return "FALSE"
    }  
}

### start writing APL parameters ###
if [catch {
    
    set apl_fd [open $apl_file w]
    
    #1.Test Program
    set apl_contents ""

    for { set i 2 } { $i <= [llength [split $res ","]] } { incr i } {
                   
        if { $apl_contents != "" && $i != [llength [split $res ","]] } {
            set apl_contents [format "%s,%s" $apl_contents [lindex [split $res ","] $i] ]
        } else {
            set apl_contents [format "%s%s" $apl_contents [lindex [split $res ","] $i] ]
        }
        
    }
    
    puts $apl_fd $apl_contents
    close $apl_fd
      
    FD "FUNC_APL_MWEST writing success!"
    
    ### execute TEST OI
    if { $test_oi != "" } {
        #set tmp [exec $test_oi &]
    }
    
} err ] {
    FD "FUNC_APL_MWEST error : $err"
    set delete_file [file delete $apl_file]
    return "FALSE"
}

return "TRUE"
}
#############################################################################
## Procedure:  FUNC_APL_ADVANTXXXX_20140331

proc ::FUNC_APL_ADVANTXXXX_20140331 {} {
global widget


global tcl_platform

if { [string match -nocase "*window*" $tcl_platform(platform)] != 1 } { 
    #puts "This is windows platform"
    return "TRUE"
}


global g_hostname
global g_lotname
global g_dcc
global g_operation
global g_job
global g_customer
global g_testprogram
global g_testprogramrev
global g_devicename
global g_operatorid
global g_handler
global g_temperature
global g_boardno
global g_incount

set apl_name "ADVANTXXXX"

set qry "SCOPS,APL_$apl_name,$g_hostname,$g_lotname,$g_dcc,$g_operation,$g_job,$g_testprogram,$g_testprogramrev,$g_devicename,$g_incount,$g_operatorid*"

set res ""
set res [FUNC_SEND_QRY $qry]

if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
    set msg {"Fail of ADVANTXXXX APL" ""}
    set choice [ tk_messageBox -title "$apl_name APL Error" -icon warning -message [FM "TESTIT" $msg $res] ]
    return "FALSE"
}


if { [lindex [split $res ","] 0] == "NO" } {

    return "TRUE"
}

set apl_file [lindex [split $res ","] 0]
set apl_path [file dir $apl_file]
set test_oi [lindex [split $res ","] 1]


if { [file exist $apl_path] != 1 } {
    if [catch {
        set tmp [file mkdir $apl_path]
    } err] {
        FD "FUNC_APL_$apl_name : can't create directory $apl_path"
        set choice [ tk_messageBox -title "FUNC_APL_$apl_name Error" -message "============================================\n\nContact : K3 Engineer, TESTIT\n\n============================================\n\nCan't delete the previous $apl_file\nCheck the file authority!!!" ]
        return "FALSE"
    }     
}

### clear APL ##################
if { [file exist $apl_file] == 1 } {
    if [catch { 
        set delete_file [file delete $apl_file]
    } err] {
        FD "FUNC_APL_$apl_name : can't delete $apl_file"
        set choice [ tk_messageBox -title "FUNC_APL_$apl_name Error" -message "============================================\n\nContact : K3 Engineer, TESTIT\n\n============================================\n\nCan't delete the previous $apl_file\nCheck the file authority!!!" ]
        return "FALSE"
    }  
}

### start writing APL parameters ###
if [catch {
    
    set apl_fd [open $apl_file w]
    
    #1.Test Program
    set apl_contents ""

    for { set i 2 } { $i <= [llength [split $res ","]] } { incr i } {
                   
        #if { $apl_contents != "" && $i != [llength [split $res ","]] } {
        #    set apl_contents [format "%s,%s" $apl_contents [lindex [split $res ","] $i] ]
        #} else {
        #    set apl_contents [format "%s%s" $apl_contents [lindex [split $res ","] $i] ]
        #}
        #
        
        puts $apl_fd [lindex [split $res ","] $i]
    }
    
    #puts $apl_fd $apl_contents
    close $apl_fd
      
    FD "FUNC_APL_$apl_name writing success!"
    
    ### execute TEST OI
    if { $test_oi != "" } {
        #set tmp [exec $test_oi &]
    }
    
} err ] {
    FD "FUNC_APL_$apl_name error : $err"
    set delete_file [file delete $apl_file]
    return "FALSE"
}

return "TRUE"
}
#############################################################################
## Procedure:  FUNC_APL_ADVANTXXXX

proc ::FUNC_APL_ADVANTXXXX {flag} {
global widget

global tcl_platform
global g_hostname

if { [string match -nocase "*window*" $tcl_platform(platform)] == 1 && $g_hostname != "test" } { 
    #puts "This is windows platform"
    return "TRUE"
}

global g_hostname
global g_lotname
global g_dcc
global g_operation
global g_job
global g_customer
global g_devicename
global g_testprogram
global g_testprogramrev
global g_condition
global g_temperature
global g_incount
global g_operatorid
global g_handler
global g_board
global g_kit

global g_socketcount
global g_handlertype

set apl_name "ADVAN TXXXX"

set qry "SCOPS,APL_AdvanTxxxx,$flag,$g_hostname,$g_lotname,$g_dcc,$g_operation,$g_job,$g_customer,$g_devicename,$g_testprogram,$g_testprogramrev,$g_condition,$g_temperature,$g_incount,$g_operatorid,$g_handler,$g_board,$g_kit,$g_socketcount,$g_handlertype*"

set res ""
set res [FUNC_SEND_QRY $qry]

if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
    set choice [ tk_messageBox -title "$apl_name APL ERROR" -icon warning -message [FM "TESTIT" "Failure to create $apl_name APL file!" $res] ]
    return "FALSE"
}


if { [lindex [split $res ","] 0] == "NO" } {
    return "TRUE"
}

set apl_file [lindex [split $res ","] 0]
set apl_path [file dir $apl_file]
set test_oi [lindex [split $res ","] 1]
set apl_format [lindex [split $res ","] 2]


#FD "apl_file : $apl_file"
#FD "apl_path : $apl_path"
#FD "test_oi : $test_oi"
#FD "apl_format : $apl_format"

if { [file exist $apl_path] != 1 } {
    if [catch {
        set tmp [file mkdir $apl_path]
    } err] {
        FD "$apl_name APL ERROR : Fail to create directory -> $apl_path ($err)"
        set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TESTIT" "Please, Check $apl_path authority to modify!" $res] ]
        return "FALSE"
    }     
}

### clear APL ##################
if { [file exist $apl_file] == 1 } {
    if [catch { 
        set delete_file [file delete $apl_file]
    } err] {
        FD "$apl_name APL ERROR : Failture to delete the previous $apl_file"
        set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TESTIT" "Please, Check $apl_file authority to delete!" $res] ]
        return "FALSE"
    }  
}


#if { $flag == "DELETE" } {
#    return "TRUE"
#}


### start writing APL parameters ###
if [catch {
    
    set apl_fd [open $apl_file w]
    
    set apl_contents ""
    
    for { set i 3 } { $i <= [llength [split $res ","]] } { incr i } {
           
        if { $apl_format == "COMMA" } {   
             if { $apl_contents != "" && $i != [llength [split $res ","]] } {
                set apl_contents [format "%s,%s" $apl_contents [lindex [split $res ","] $i] ]
            } else {
                set apl_contents [format "%s%s" $apl_contents [lindex [split $res ","] $i] ]
            }        
        } else {
            puts $apl_fd [lindex [split $res ","] $i]
        }
                
    }
    
    if { $apl_contents != "" } {
        puts $apl_fd $apl_contents
    }
    
    close $apl_fd
      
    FD "$apl_name APL SUCCESS!"
    
    ### execute TEST OI
    if { $test_oi != "" } {
        if [catch { 
            set tmp [exec $test_oi &]
        } err] {
            FD "$apl_name APL ERROR : Failure to execute $test_oi ($err)"
            set delete_file [file delete $apl_file]
            set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TESTIT" "Failure to execute $test_oi!" $res] ]
            return "FALSE"
        }    
    }
    
} err ] {
    FD "$apl_name APL ERROR : $err"
    set delete_file [file delete $apl_file]
    return "FALSE"
}

return "TRUE"
}
#############################################################################
## Procedure:  FUNC_APL_D10_20140331

proc ::FUNC_APL_D10_20140331 {} {
global widget


global tcl_platform

if { [string match -nocase "*window*" $tcl_platform(platform)] == 1 } { 
    #puts "This is windows platform"
    return "TRUE"
}


global g_hostname
global g_lotname
global g_dcc
global g_operation
global g_testprogram
global g_testprogramrev


set qry "SCOPS,APL_D10,$g_hostname,$g_lotname,$g_dcc,$g_operation,$g_testprogram,$g_testprogramrev*"

set res ""
set res [FUNC_SEND_QRY $qry]

if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
    set msg {"Fail of D10 APL" ""}
    set choice [ tk_messageBox -title "D10 APL Error" -icon warning -message [FM "TESTIT" $msg $res] ]
    return "FALSE"
}


if { [lindex [split $res ","] 0] == "NO" } {
    #set msg {"Fail of D10 APL" ""}
    #set choice [ tk_messageBox -title "D10 APL Error" -icon warning -message [FM "TESTIT" $msg $res] ]
    return "TRUE"
}

set apl_file [lindex [split $res ","] 0]
set apl_path [file dir $apl_file]
set test_oi [lindex [split $res ","] 1]


if { [file exist $apl_path] != 1 } {
    if [catch {
        set tmp [file mkdir $apl_path]
    } err] {
        FD "Func_APL_D10 : can't create directory $apl_path"
        set choice [ tk_messageBox -title "Func_APL_D10 Error" -message "============================================\n\nContact : K3 Engineer, TESTIT\n\n============================================\n\nCan't delete the previous $apl_file\nCheck the file authority!!!" ]
        return "FALSE"
    }     
}

### clear APL ##################
if { [file exist $apl_file] == 1 } {
    if [catch { 
        set delete_file [file delete $apl_file]
    } err] {
        FD "Func_APL_D10 : can't delete $apl_file"
        set choice [ tk_messageBox -title "Func_APL_D10 Error" -message "============================================\n\nContact : K3 Engineer, TESTIT\n\n============================================\n\nCan't delete the previous $apl_file\nCheck the file authority!!!" ]
        return "FALSE"
    }  
}

### start writing APL parameters ###
if [catch {
    
    set apl_fd [open $apl_file w]
    
    #1.Test Program
    set apl_contents ""

    for { set i 2 } { $i <= [llength [split $res ","]] } { incr i } {
                   
        if { $apl_contents != "" && $i != [llength [split $res ","]] } {
            set apl_contents [format "%s,%s" $apl_contents [lindex [split $res ","] $i] ]
        } else {
            set apl_contents [format "%s%s" $apl_contents [lindex [split $res ","] $i] ]
        }
        
    }
    
    puts $apl_fd $apl_contents
    close $apl_fd
      
    FD "Func_APL_D10 writing success!"
    
    ### execute TEST OI
    if { $test_oi != "" } {
        set tmp [exec $test_oi &]
    }
    
} err ] {
    FD "Func_APL_D10 error : $err"
    set delete_file [file delete $apl_file]
    return "FALSE"
}

return "TRUE"
}
#############################################################################
## Procedure:  FUNC_APL_D10

proc ::FUNC_APL_D10 {flag} {
global widget

global tcl_platform

if { [string match -nocase "*window*" $tcl_platform(platform)] == 1 } { 
    #puts "This is windows platform"
    #return "TRUE"
}

global g_hostname
global g_lotname
global g_dcc
global g_operation
global g_job
global g_customer
global g_devicename
global g_testprogram
global g_testprogramrev
global g_condition
global g_temperature
global g_incount
global g_operatorid
global g_handler
global g_board
global g_kit

global g_socketcount
global g_handlertype

set apl_name "D10"

set qry "SCOPS,APL_D10,$flag,$g_hostname,$g_lotname,$g_dcc,$g_operation,$g_job,$g_customer,$g_devicename,$g_testprogram,$g_testprogramrev,$g_condition,$g_temperature,$g_incount,$g_operatorid,$g_handler,$g_board,$g_kit,$g_socketcount,$g_handlertype*"

set res ""
set res [FUNC_SEND_QRY $qry]

if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
    set choice [ tk_messageBox -title "$apl_name APL ERROR" -icon warning -message [FM "TESTIT" "Failure to create $apl_name APL file!" $res] ]
    return "FALSE"
}


if { [lindex [split $res ","] 0] == "NO" } {
    return "TRUE"
}

set apl_file [lindex [split $res ","] 0]
set apl_path [file dir $apl_file]
set test_oi [lindex [split $res ","] 1]
set apl_format [lindex [split $res ","] 2]


#FD "apl_file : $apl_file"
#FD "apl_path : $apl_path"
#FD "test_oi : $test_oi"
#FD "apl_format : $apl_format"

if { [file exist $apl_path] != 1 } {
    if [catch {
        set tmp [file mkdir $apl_path]
    } err] {
        FD "$apl_name APL ERROR : Fail to create directory -> $apl_path ($err)"
        set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TESTIT" "Please, Check $apl_path authority to modify!" $res] ]
        return "FALSE"
    }     
}

### clear APL ##################
if { [file exist $apl_file] == 1 } {
    if [catch { 
        set delete_file [file delete $apl_file]
    } err] {
        FD "$apl_name APL ERROR : Failture to delete the previous $apl_file"
        set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TESTIT" "Please, Check $apl_file authority to delete!" $res] ]
        return "FALSE"
    }  
}


if { $flag == "DELETE" } {
    return "TRUE"
}


### start writing APL parameters ###
if [catch {
    
    set apl_fd [open $apl_file w]
    
    set apl_contents ""
    
    for { set i 3 } { $i <= [llength [split $res ","]] } { incr i } {
           
        if { $apl_format == "COMMA" } {   
             if { $apl_contents != "" && $i != [llength [split $res ","]] } {
                set apl_contents [format "%s,%s" $apl_contents [lindex [split $res ","] $i] ]
            } else {
                set apl_contents [format "%s%s" $apl_contents [lindex [split $res ","] $i] ]
            }        
        } else {
            puts $apl_fd [lindex [split $res ","] $i]
        }
                
    }
    
    if { $apl_contents != "" } {
        puts $apl_fd $apl_contents
    }
    
    close $apl_fd
      
    FD "$apl_name APL SUCCESS!"
    
    ### execute TEST OI
    if { $test_oi != "" } {
        if [catch { 
            set tmp [exec $test_oi &]
        } err] {
            FD "$apl_name APL ERROR : Failure to execute $test_oi ($err)"
            set delete_file [file delete $apl_file]
            set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TESTIT" "Failure to execute $test_oi!" $res] ]
            return "FALSE"
        }    
    }
    
} err ] {
    FD "$apl_name APL ERROR : $err"
    set delete_file [file delete $apl_file]
    return "FALSE"
}

return "TRUE"
}
#############################################################################
## Procedure:  FUNC_APL_MAVERICK_20140414

proc ::FUNC_APL_MAVERICK_20140414 {} {
global widget

global tcl_platform

if { [string match -nocase "*window*" $tcl_platform(platform)] != 1 } { 
    #puts "This is windows platform"
    return "TRUE"
}


global g_hostname
global g_lotname
global g_dcc
global g_operation
global g_job
global g_operatorid
global g_testprogram
global g_testprogramrev
global g_handler
global g_incount

set qry "SCOPS,APL_Maverick,$g_hostname,$g_lotname,$g_dcc,$g_operation,$g_job,$g_operatorid,$g_testprogram,$g_testprogramrev,$g_handler,$g_incount*"

set res ""
set res [FUNC_SEND_QRY $qry]

set platform_name "Maverick"

if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
    set msg {"Fail of $platform_name APL" ""}
    set choice [ tk_messageBox -title "$platform_name APL Error" -icon warning -message [FM "TESTIT" $msg $res] ]
    return "FALSE"
}


if { [lindex [split $res ","] 0] == "NO" } {
    #set msg {"Fail of D10 APL" ""}
    #set choice [ tk_messageBox -title "D10 APL Error" -icon warning -message [FM "TESTIT" $msg $res] ]
    return "TRUE"
}

set apl_format [lindex [split $res ","] 0]
set apl_file [lindex [split $res ","] 1]
set apl_path [file dir $apl_file]
set test_oi [lindex [split $res ","] 2]


if { [file exist $apl_path] != 1 } {
    if [catch {
        set tmp [file mkdir $apl_path]
    } err] {
        FD "Func_APL_$platform_name : can't create directory $apl_path"
        set choice [ tk_messageBox -title "Func_APL_$platform_name Error" -message "============================================\n\nContact : K3 Engineer, TESTIT\n\n============================================\n\nCan't delete the previous $apl_file\nCheck the file authority!!!" ]
        return "FALSE"
    }     
}

### clear APL ##################
if { [file exist $apl_file] == 1 } {
    if [catch { 
        set delete_file [file delete $apl_file]
    } err] {
        FD "Func_APL_$platform_name : can't delete $apl_file"
        set choice [ tk_messageBox -title "Func_APL_$platform_name Error" -message "============================================\n\nContact : K3 Engineer, TESTIT\n\n============================================\n\nCan't delete the previous $apl_file\nCheck the file authority!!!" ]
        return "FALSE"
    }  
}

### start writing APL parameters ###
if [catch {
    
    set apl_fd [open $apl_file w]
    
    #1.Test Program
    set apl_contents ""

    for { set i 3 } { $i <= [llength [split $res ","]] } { incr i } {
        
        if { $apl_format == "LINE" } {
            puts $apl_fd [lindex [split $res ","] $i]
        } else {           
                                         
            if { $apl_contents != "" && $i != [llength [split $res ","]] } {
                set apl_contents [format "%s,%s" $apl_contents [lindex [split $res ","] $i] ]
            } else {
                set apl_contents [format "%s%s" $apl_contents [lindex [split $res ","] $i] ]
            }
        }
        
    }
    
    if { $apl_format != "LINE" } {
        puts $apl_fd $apl_contents
    }
    
    close $apl_fd
      
    FD "Func_APL_$platform_name writing success!"
    
    ### execute TEST OI
    if { $test_oi != "" } {
        #set tmp [exec $test_oi &]
    }
    
} err ] {
    FD "Func_APL_$platform_name error : $err"
    set delete_file [file delete $apl_file]
    return "FALSE"
}

return "TRUE"
}
#############################################################################
## Procedure:  FUNC_APL_MAVERICK

proc ::FUNC_APL_MAVERICK {flag} {
global widget

global tcl_platform

if { [string match -nocase "*window*" $tcl_platform(platform)] != 1 } { 
    #puts "This is windows platform"
    #return "TRUE"
}

global g_hostname
global g_lotname
global g_dcc
global g_operation
global g_job
global g_customer
global g_devicename
global g_testprogram
global g_testprogramrev
global g_condition
global g_temperature
global g_incount
global g_operatorid
global g_handler
global g_board
global g_kit

global g_socketcount
global g_handlertype

set apl_name "MAVERICK"

set qry "SCOPS,APL_MAVERICK,$flag,$g_hostname,$g_lotname,$g_dcc,$g_operation,$g_job,$g_customer,$g_devicename,$g_testprogram,$g_testprogramrev,$g_condition,$g_temperature,$g_incount,$g_operatorid,$g_handler,$g_board,$g_kit,$g_socketcount,$g_handlertype*"

set res ""
set res [FUNC_SEND_QRY $qry]

if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
    set choice [ tk_messageBox -title "$apl_name APL ERROR" -icon warning -message [FM "TESTIT" "Failure to create $apl_name APL file!" $res] ]
    return "FALSE"
}


if { [lindex [split $res ","] 0] == "NO" } {
    return "TRUE"
}

set apl_file [lindex [split $res ","] 0]
set apl_path [file dir $apl_file]
set test_oi [lindex [split $res ","] 1]
set apl_format [lindex [split $res ","] 2]


#FD "apl_file : $apl_file"
#FD "apl_path : $apl_path"
#FD "test_oi : $test_oi"
#FD "apl_format : $apl_format"

if { [file exist $apl_path] != 1 } {
    if [catch {
        set tmp [file mkdir $apl_path]
    } err] {
        FD "$apl_name APL ERROR : Fail to create directory -> $apl_path ($err)"
        set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TESTIT" "Please, Check $apl_path authority to modify!" $res] ]
        return "FALSE"
    }     
}

### clear APL ##################
if { [file exist $apl_file] == 1 } {
    if [catch { 
        set delete_file [file delete $apl_file]
    } err] {
        FD "$apl_name APL ERROR : Failture to delete the previous $apl_file"
        set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TESTIT" "Please, Check $apl_file authority to delete!" $res] ]
        return "FALSE"
    }  
}


if { $flag == "DELETE" } {
    return "TRUE"
}


### start writing APL parameters ###
if [catch {
    
    set apl_fd [open $apl_file w]
    
    set apl_contents ""
    
    for { set i 3 } { $i <= [llength [split $res ","]] } { incr i } {
           
        if { $apl_format == "COMMA" } {   
             if { $apl_contents != "" && $i != [llength [split $res ","]] } {
                set apl_contents [format "%s,%s" $apl_contents [lindex [split $res ","] $i] ]
            } else {
                set apl_contents [format "%s%s" $apl_contents [lindex [split $res ","] $i] ]
            }        
        } else {
            puts $apl_fd [lindex [split $res ","] $i]
        }
                
    }
    
    if { $apl_contents != "" } {
        puts $apl_fd $apl_contents
    }
    
    close $apl_fd
      
    FD "$apl_name APL SUCCESS!"
    
    ### execute TEST OI
    if { $test_oi != "" } {
        if [catch { 
            set tmp [exec $test_oi &]
        } err] {
            FD "$apl_name APL ERROR : Failure to execute $test_oi ($err)"
            set delete_file [file delete $apl_file]
            set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TESTIT" "Failure to execute $test_oi!" $res] ]
            return "FALSE"
        }    
    }
    
} err ] {
    FD "$apl_name APL ERROR : $err"
    set delete_file [file delete $apl_file]
    return "FALSE"
}

return "TRUE"
}
#############################################################################
## Procedure:  FUNC_APL_MWEST_20140414

proc ::FUNC_APL_MWEST_20140414 {} {
global widget

global tcl_platform

if { [string match -nocase "*window*" $tcl_platform(platform)] != 1 } { 
    #puts "This is windows platform"
    return "TRUE"
}


global g_hostname
global g_lotname
global g_dcc
global g_operation
global g_job
global g_customer
global g_testprogram
global g_testprogramrev
global g_operatorid
global g_handler
global g_temperature

set qry "SCOPS,APL_Mwest,$g_hostname,$g_lotname,$g_dcc,$g_operation,$g_job,$g_customer,$g_testprogram,$g_testprogramrev,$g_operatorid,$g_handler,$g_temperature*"

set res ""
set res [FUNC_SEND_QRY $qry]

if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
    set msg {"Fail of MWEST APL" ""}
    set choice [ tk_messageBox -title "MWEST APL Error" -icon warning -message [FM "TESTIT" $msg $res] ]
    return "FALSE"
}


if { [lindex [split $res ","] 0] == "NO" } {

    return "TRUE"
}

set apl_file [lindex [split $res ","] 0]
set apl_path [file dir $apl_file]
set test_oi [lindex [split $res ","] 1]


if { [file exist $apl_path] != 1 } {
    if [catch {
        set tmp [file mkdir $apl_path]
    } err] {
        FD "FUNC_APL_MWEST : can't create directory $apl_path"
        set choice [ tk_messageBox -title "FUNC_APL_MWEST Error" -message "============================================\n\nContact : K3 Engineer, TESTIT\n\n============================================\n\nCan't delete the previous $apl_file\nCheck the file authority!!!" ]
        return "FALSE"
    }     
}

### clear APL ##################
if { [file exist $apl_file] == 1 } {
    if [catch { 
        set delete_file [file delete $apl_file]
    } err] {
        FD "FUNC_APL_MWEST : can't delete $apl_file"
        set choice [ tk_messageBox -title "FUNC_APL_MWEST Error" -message "============================================\n\nContact : K3 Engineer, TESTIT\n\n============================================\n\nCan't delete the previous $apl_file\nCheck the file authority!!!" ]
        return "FALSE"
    }  
}

### start writing APL parameters ###
if [catch {
    
    set apl_fd [open $apl_file w]
    
    #1.Test Program
    set apl_contents ""

    for { set i 2 } { $i <= [llength [split $res ","]] } { incr i } {
                   
        if { $apl_contents != "" && $i != [llength [split $res ","]] } {
            set apl_contents [format "%s,%s" $apl_contents [lindex [split $res ","] $i] ]
        } else {
            set apl_contents [format "%s%s" $apl_contents [lindex [split $res ","] $i] ]
        }
        
    }
    
    puts $apl_fd $apl_contents
    close $apl_fd
      
    FD "FUNC_APL_MWEST writing success!"
    
    ### execute TEST OI
    if { $test_oi != "" } {
        #set tmp [exec $test_oi &]
    }
    
} err ] {
    FD "FUNC_APL_MWEST error : $err"
    set delete_file [file delete $apl_file]
    return "FALSE"
}

return "TRUE"
}
#############################################################################
## Procedure:  FUNC_APL_MWEST

proc ::FUNC_APL_MWEST {flag} {
global widget

global tcl_platform

if { [string match -nocase "*window*" $tcl_platform(platform)] != 1 } { 
    #puts "This is windows platform"
    return "TRUE"
}

global g_hostname
global g_lotname
global g_dcc
global g_operation
global g_job
global g_customer
global g_devicename
global g_testprogram
global g_testprogramrev
global g_condition
global g_temperature
global g_incount
global g_operatorid
global g_handler
global g_board
global g_kit

global g_socketcount
global g_handlertype

set apl_name "MWEST"

set qry "SCOPS,APL_MWEST,$flag,$g_hostname,$g_lotname,$g_dcc,$g_operation,$g_job,$g_customer,$g_devicename,$g_testprogram,$g_testprogramrev,$g_condition,$g_temperature,$g_incount,$g_operatorid,$g_handler,$g_board,$g_kit,$g_socketcount,$g_handlertype*"

set res ""
set res [FUNC_SEND_QRY $qry]

if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
    set choice [ tk_messageBox -title "$apl_name APL ERROR" -icon warning -message [FM "TESTIT" "Failure to create $apl_name APL file!" $res] ]
    return "FALSE"
}


if { [lindex [split $res ","] 0] == "NO" } {
    return "TRUE"
}

set apl_file [lindex [split $res ","] 0]
set apl_path [file dir $apl_file]
set test_oi [lindex [split $res ","] 1]
set apl_format [lindex [split $res ","] 2]


#FD "apl_file : $apl_file"
#FD "apl_path : $apl_path"
#FD "test_oi : $test_oi"
#FD "apl_format : $apl_format"

if { [file exist $apl_path] != 1 } {
    if [catch {
        set tmp [file mkdir $apl_path]
    } err] {
        FD "$apl_name APL ERROR : Fail to create directory -> $apl_path ($err)"
        set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TESTIT" "Please, Check $apl_path authority to modify!" $res] ]
        return "FALSE"
    }     
}

### clear APL ##################
if { [file exist $apl_file] == 1 } {
    if [catch { 
        set delete_file [file delete $apl_file]
    } err] {
        FD "$apl_name APL ERROR : Failture to delete the previous $apl_file"
        set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TESTIT" "Please, Check $apl_file authority to delete!" $res] ]
        return "FALSE"
    }  
}


if { $flag == "DELETE" } {
    return "TRUE"
}


### start writing APL parameters ###
if [catch {
    
    set apl_fd [open $apl_file w]
    
    set apl_contents ""
    
    for { set i 3 } { $i <= [llength [split $res ","]] } { incr i } {
           
        if { $apl_format == "COMMA" } {   
             if { $apl_contents != "" && $i != [llength [split $res ","]] } {
                set apl_contents [format "%s,%s" $apl_contents [lindex [split $res ","] $i] ]
            } else {
                set apl_contents [format "%s%s" $apl_contents [lindex [split $res ","] $i] ]
            }        
        } else {
            puts $apl_fd [lindex [split $res ","] $i]
        }
                
    }
    
    if { $apl_contents != "" } {
        puts $apl_fd $apl_contents
    }
    
    close $apl_fd
      
    FD "$apl_name APL SUCCESS!"
    
    ### execute TEST OI
    if { $test_oi != "" } {
        if [catch { 
            set tmp [exec $test_oi &]
        } err] {
            FD "$apl_name APL ERROR : Failure to execute $test_oi ($err)"
            set delete_file [file delete $apl_file]
            set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TESTIT" "Failure to execute $test_oi!" $res] ]
            return "FALSE"
        }    
    }
    
} err ] {
    FD "$apl_name APL ERROR : $err"
    set delete_file [file delete $apl_file]
    return "FALSE"
}

return "TRUE"
}
#############################################################################
## Procedure:  FUNC_APL_ETS_20140414

proc ::FUNC_APL_ETS_20140414 {} {
global widget


global tcl_platform

if { [string match -nocase "*window*" $tcl_platform(platform)] != 1 } { 
    #puts "This is windows platform"
    return "TRUE"
}


global g_hostname
global g_lotname
global g_dcc
global g_operation
global g_job
global g_customer
global g_testprogram
global g_testprogramrev
global g_devicename
global g_operatorid
global g_handler
global g_temperature
global g_boardno

set apl_name "ETS"

set qry "SCOPS,APL_$apl_name,$g_hostname,$g_lotname,$g_dcc,$g_operation,$g_operatorid,$g_boardno,$g_testprogram,$g_testprogramrev,$g_devicename*"

set res ""
set res [FUNC_SEND_QRY $qry]

if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
    set msg {"Fail of ETS APL" ""}
    set choice [ tk_messageBox -title "$apl_name APL Error" -icon warning -message [FM "TESTIT" $msg $res] ]
    return "FALSE"
}


if { [lindex [split $res ","] 0] == "NO" } {

    return "TRUE"
}

set apl_file [lindex [split $res ","] 0]
set apl_path [file dir $apl_file]
set test_oi [lindex [split $res ","] 1]


if { [file exist $apl_path] != 1 } {
    if [catch {
        set tmp [file mkdir $apl_path]
    } err] {
        FD "FUNC_APL_$apl_name : can't create directory $apl_path"
        set choice [ tk_messageBox -title "FUNC_APL_$apl_name Error" -message "============================================\n\nContact : K3 Engineer, TESTIT\n\n============================================\n\nCan't delete the previous $apl_file\nCheck the file authority!!!" ]
        return "FALSE"
    }     
}

### clear APL ##################
if { [file exist $apl_file] == 1 } {
    if [catch { 
        set delete_file [file delete $apl_file]
    } err] {
        FD "FUNC_APL_$apl_name : can't delete $apl_file"
        set choice [ tk_messageBox -title "FUNC_APL_$apl_name Error" -message "============================================\n\nContact : K3 Engineer, TESTIT\n\n============================================\n\nCan't delete the previous $apl_file\nCheck the file authority!!!" ]
        return "FALSE"
    }  
}

### start writing APL parameters ###
if [catch {
    
    set apl_fd [open $apl_file w]
    
    #1.Test Program
    set apl_contents ""

    for { set i 2 } { $i <= [llength [split $res ","]] } { incr i } {
                   
        #if { $apl_contents != "" && $i != [llength [split $res ","]] } {
        #    set apl_contents [format "%s,%s" $apl_contents [lindex [split $res ","] $i] ]
        #} else {
        #    set apl_contents [format "%s%s" $apl_contents [lindex [split $res ","] $i] ]
        #}
        #
        
        puts $apl_fd [lindex [split $res ","] $i]
    }
    
    #puts $apl_fd $apl_contents
    close $apl_fd
      
    FD "FUNC_APL_$apl_name writing success!"
    
    ### execute TEST OI
    if { $test_oi != "" } {
        #set tmp [exec $test_oi &]
    }
    
} err ] {
    FD "FUNC_APL_$apl_name error : $err"
    set delete_file [file delete $apl_file]
    return "FALSE"
}

return "TRUE"
}
#############################################################################
## Procedure:  FUNC_APL_ETS

proc ::FUNC_APL_ETS {flag} {
global widget

global tcl_platform

if { [string match -nocase "*window*" $tcl_platform(platform)] != 1 } { 
    #puts "This is windows platform"
    return "TRUE"
}

global g_hostname
global g_lotname
global g_dcc
global g_operation
global g_job
global g_customer
global g_devicename
global g_testprogram
global g_testprogramrev
global g_condition
global g_temperature
global g_incount
global g_operatorid
global g_handler
global g_board
global g_kit
global g_probe

global g_socketcount
global g_handlertype

set apl_name "ETS"

set qry "SCOPS,APL_ETS,$flag,$g_hostname,$g_lotname,$g_dcc,$g_operation,$g_job,$g_customer,$g_devicename,$g_testprogram,$g_testprogramrev,$g_condition,$g_temperature,$g_incount,$g_operatorid,$g_handler,$g_board,$g_kit,$g_probe,$g_socketcount,$g_handlertype*"

set res ""
set res [FUNC_SEND_QRY $qry]

if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
    set choice [ tk_messageBox -title "$apl_name APL ERROR" -icon warning -message [FM "TESTIT" "Failure to create $apl_name APL file!" $res] ]
    return "FALSE"
}


if { [lindex [split $res ","] 0] == "NO" } {
    return "TRUE"
}

set apl_file [lindex [split $res ","] 0]
set apl_path [file dir $apl_file]
set test_oi [lindex [split $res ","] 1]
set apl_format [lindex [split $res ","] 2]


#FD "apl_file : $apl_file"
#FD "apl_path : $apl_path"
#FD "test_oi : $test_oi"
#FD "apl_format : $apl_format"

if { [file exist $apl_path] != 1 } {
    if [catch {
        set tmp [file mkdir $apl_path]
    } err] {
        FD "$apl_name APL ERROR : Fail to create directory -> $apl_path ($err)"
        set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TESTIT" "Please, Check $apl_path authority to modify!" $res] ]
        return "FALSE"
    }     
}

### clear APL ##################
if { [file exist $apl_file] == 1 } {
    if [catch { 
        set delete_file [file delete $apl_file]
    } err] {
        FD "$apl_name APL ERROR : Failture to delete the previous $apl_file"
        set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TESTIT" "Please, Check $apl_file authority to delete!" $res] ]
        return "FALSE"
    }  
}


if { $flag == "DELETE" } {
    return "TRUE"
}


### start writing APL parameters ###
if [catch {
    
    set apl_fd [open $apl_file w]
    
    set apl_contents ""
    
    for { set i 3 } { $i <= [llength [split $res ","]] } { incr i } {
           
        if { $apl_format == "COMMA" } {   
             if { $apl_contents != "" && $i != [llength [split $res ","]] } {
                set apl_contents [format "%s,%s" $apl_contents [lindex [split $res ","] $i] ]
            } else {
                set apl_contents [format "%s%s" $apl_contents [lindex [split $res ","] $i] ]
            }        
        } else {
            puts $apl_fd [lindex [split $res ","] $i]
        }
                
    }
    
    if { $apl_contents != "" } {
        puts $apl_fd $apl_contents
    }
    
    close $apl_fd
      
    FD "$apl_name APL SUCCESS!"
    
    ### execute TEST OI
    if { $test_oi != "" } {
        if [catch { 
            set tmp [exec $test_oi &]
        } err] {
            FD "$apl_name APL ERROR : Failure to execute $test_oi ($err)"
            set delete_file [file delete $apl_file]
            set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TESTIT" "Failure to execute $test_oi!" $res] ]
            return "FALSE"
        }    
    }
    
} err ] {
    FD "$apl_name APL ERROR : $err"
    set delete_file [file delete $apl_file]
    return "FALSE"
}

return "TRUE"
}
#############################################################################
## Procedure:  FUNC_APL_J750_20140414

proc ::FUNC_APL_J750_20140414 {} {
global widget


global tcl_platform

if { [string match -nocase "*window*" $tcl_platform(platform)] != 1 } { 
    #puts "This is windows platform"
    return "TRUE"
}


global g_hostname
global g_lotname
global g_dcc
global g_operation
global g_job
global g_customer
global g_testprogram
global g_testprogramrev
global g_devicename
global g_operatorid
global g_handler
global g_temperature

set qry "SCOPS,APL_J750,$g_hostname,$g_lotname,$g_dcc,$g_operation,$g_testprogram,$g_testprogramrev,$g_devicename,$g_temperature,$g_operatorid*"

set res ""
set res [FUNC_SEND_QRY $qry]

if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
    set msg {"Fail of J750 APL" ""}
    set choice [ tk_messageBox -title "J750 APL Error" -icon warning -message [FM "TESTIT" $msg $res] ]
    return "FALSE"
}


if { [lindex [split $res ","] 0] == "NO" } {

    return "TRUE"
}

set apl_file [lindex [split $res ","] 0]
set apl_path [file dir $apl_file]
set test_oi [lindex [split $res ","] 1]


if { [file exist $apl_path] != 1 } {
    if [catch {
        set tmp [file mkdir $apl_path]
    } err] {
        FD "FUNC_APL_J750 : can't create directory $apl_path"
        set choice [ tk_messageBox -title "FUNC_APL_J750 Error" -message "============================================\n\nContact : K3 Engineer, TESTIT\n\n============================================\n\nCan't delete the previous $apl_file\nCheck the file authority!!!" ]
        return "FALSE"
    }     
}

### clear APL ##################
if { [file exist $apl_file] == 1 } {
    if [catch { 
        set delete_file [file delete $apl_file]
    } err] {
        FD "FUNC_APL_J750 : can't delete $apl_file"
        set choice [ tk_messageBox -title "FUNC_APL_J750 Error" -message "============================================\n\nContact : K3 Engineer, TESTIT\n\n============================================\n\nCan't delete the previous $apl_file\nCheck the file authority!!!" ]
        return "FALSE"
    }  
}

### start writing APL parameters ###
if [catch {
    
    set apl_fd [open $apl_file w]
    
    #1.Test Program
    set apl_contents ""

    for { set i 2 } { $i <= [llength [split $res ","]] } { incr i } {
                   
        #if { $apl_contents != "" && $i != [llength [split $res ","]] } {
        #    set apl_contents [format "%s,%s" $apl_contents [lindex [split $res ","] $i] ]
        #} else {
        #    set apl_contents [format "%s%s" $apl_contents [lindex [split $res ","] $i] ]
        #}
        #
        
        puts $apl_fd [lindex [split $res ","] $i]
    }
    
    #puts $apl_fd $apl_contents
    close $apl_fd
      
    FD "FUNC_APL_J750 writing success!"
    
    ### execute TEST OI
    if { $test_oi != "" } {
        #set tmp [exec $test_oi &]
    }
    
} err ] {
    FD "FUNC_APL_J750 error : $err"
    set delete_file [file delete $apl_file]
    return "FALSE"
}

return "TRUE"
}
#############################################################################
## Procedure:  FUNC_APL_J750

proc ::FUNC_APL_J750 {flag} {
global widget

global tcl_platform

if { [string match -nocase "*window*" $tcl_platform(platform)] != 1 } { 
    #puts "This is windows platform"
    return "TRUE"
}

global g_hostname
global g_lotname
global g_dcc
global g_operation
global g_job
global g_customer
global g_devicename
global g_testprogram
global g_testprogramrev
global g_condition
global g_temperature
global g_incount
global g_operatorid
global g_handler
global g_board
global g_kit
global g_probe

global g_socketcount
global g_handlertype

set apl_name "J750"

set qry "SCOPS,APL_J750,$flag,$g_hostname,$g_lotname,$g_dcc,$g_operation,$g_job,$g_customer,$g_devicename,$g_testprogram,$g_testprogramrev,$g_condition,$g_temperature,$g_incount,$g_operatorid,$g_handler,$g_board,$g_kit,$g_probe,$g_socketcount,$g_handlertype*"

set res ""
set res [FUNC_SEND_QRY $qry]

if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
    set choice [ tk_messageBox -title "$apl_name APL ERROR" -icon warning -message [FM "TESTIT" "Failure to create $apl_name APL file!" $res] ]
    return "FALSE"
}


if { [lindex [split $res ","] 0] == "NO" } {
    return "TRUE"
}

set apl_file [lindex [split $res ","] 0]
set apl_path [file dir $apl_file]
set test_oi [lindex [split $res ","] 1]
set apl_format [lindex [split $res ","] 2]


#FD "apl_file : $apl_file"
#FD "apl_path : $apl_path"
#FD "test_oi : $test_oi"
#FD "apl_format : $apl_format"

if { [file exist $apl_path] != 1 } {
    if [catch {
        set tmp [file mkdir $apl_path]
    } err] {
        FD "$apl_name APL ERROR : Fail to create directory -> $apl_path ($err)"
        set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TESTIT" "Please, Check $apl_path authority to modify!" $res] ]
        return "FALSE"
    }     
}

### clear APL ##################
if { [file exist $apl_file] == 1 } {
    if [catch { 
        set delete_file [file delete $apl_file]
    } err] {
        FD "$apl_name APL ERROR : Failture to delete the previous $apl_file"
        set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TESTIT" "Please, Check $apl_file authority to delete!" $res] ]
        return "FALSE"
    }  
}


if { $flag == "DELETE" } {
    return "TRUE"
}


### start writing APL parameters ###
if [catch {
    
    set apl_fd [open $apl_file w]
    
    set apl_contents ""
    
    for { set i 3 } { $i <= [llength [split $res ","]] } { incr i } {
           
        if { $apl_format == "COMMA" } {   
             if { $apl_contents != "" && $i != [llength [split $res ","]] } {
                set apl_contents [format "%s,%s" $apl_contents [lindex [split $res ","] $i] ]
            } else {
                set apl_contents [format "%s%s" $apl_contents [lindex [split $res ","] $i] ]
            }        
        } else {
            puts $apl_fd [lindex [split $res ","] $i]
        }
                
    }
    
    if { $apl_contents != "" } {
        puts $apl_fd $apl_contents
    }
    
    close $apl_fd
      
    FD "$apl_name APL SUCCESS!"
    
    ### execute TEST OI
    if { $test_oi != "" } {
        if [catch { 
            set tmp [exec $test_oi &]
        } err] {
            FD "$apl_name APL ERROR : Failure to execute $test_oi ($err)"
            set delete_file [file delete $apl_file]
            set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TESTIT" "Failure to execute $test_oi!" $res] ]
            return "FALSE"
        }    
    }
    
} err ] {
    FD "$apl_name APL ERROR : $err"
    set delete_file [file delete $apl_file]
    return "FALSE"
}

return "TRUE"
}
#############################################################################
## Procedure:  FUNC_APL_MICROCHIP_20140414

proc ::FUNC_APL_MICROCHIP_20140414 {} {
global widget

global tcl_platform

if { [string match -nocase "*window*" $tcl_platform(platform)] != 1 } { 
    #puts "This is windows platform"
    return "TRUE"
}


global g_hostname
global g_lotname
global g_dcc
global g_operation
global g_job
global g_operatorid
global g_testprogram
global g_testprogramrev
global g_handler
global g_incount
global g_condition
global g_device

set qry "SCOPS,APL_Microchip,$g_hostname,$g_lotname,$g_dcc,$g_operation,$g_job,$g_testprogram,$g_testprogramrev,@g_device,$g_incount,$g_operatorid,$g_condition*"

set res ""
set res [FUNC_SEND_QRY $qry]

set platform_name "Microchip"

if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
    set msg {"Fail of $platform_name APL" ""}
    set choice [ tk_messageBox -title "$platform_name APL Error" -icon warning -message [FM "TESTIT" $msg $res] ]
    return "FALSE"
}


if { [lindex [split $res ","] 0] == "NO" } {
    #set msg {"Fail of D10 APL" ""}
    #set choice [ tk_messageBox -title "D10 APL Error" -icon warning -message [FM "TESTIT" $msg $res] ]
    return "TRUE"
}

set apl_format [lindex [split $res ","] 0]
set apl_file [lindex [split $res ","] 1]
set apl_path [file dir $apl_file]
set test_oi [lindex [split $res ","] 2]


if { [file exist $apl_path] != 1 } {
    if [catch {
        set tmp [file mkdir $apl_path]
    } err] {
        FD "Func_APL_$platform_name : can't create directory $apl_path"
        set choice [ tk_messageBox -title "Func_APL_$platform_name Error" -message "============================================\n\nContact : K3 Engineer, TESTIT\n\n============================================\n\nCan't delete the previous $apl_file\nCheck the file authority!!!" ]
        return "FALSE"
    }     
}

### clear APL ##################
if { [file exist $apl_file] == 1 } {
    if [catch { 
        set delete_file [file delete $apl_file]
    } err] {
        FD "Func_APL_$platform_name : can't delete $apl_file"
        set choice [ tk_messageBox -title "Func_APL_$platform_name Error" -message "============================================\n\nContact : K3 Engineer, TESTIT\n\n============================================\n\nCan't delete the previous $apl_file\nCheck the file authority!!!" ]
        return "FALSE"
    }  
}

### start writing APL parameters ###
if [catch {
    
    set apl_fd [open $apl_file w]
    
    #1.Test Program
    set apl_contents ""

    for { set i 3 } { $i <= [llength [split $res ","]] } { incr i } {
        
        if { $apl_format == "LINE" } {
            puts $apl_fd [lindex [split $res ","] $i]
        } else {           
                                         
            if { $apl_contents != "" && $i != [llength [split $res ","]] } {
                set apl_contents [format "%s,%s" $apl_contents [lindex [split $res ","] $i] ]
            } else {
                set apl_contents [format "%s%s" $apl_contents [lindex [split $res ","] $i] ]
            }
        }
        
    }
    
    if { $apl_format != "LINE" } {
        puts $apl_fd $apl_contents
    }
    
    close $apl_fd
      
    FD "Func_APL_$platform_name writing success!"
    
    ### execute TEST OI
    if { $test_oi != "" } {
        #set tmp [exec $test_oi &]
    }
    
} err ] {
    FD "Func_APL_$platform_name error : $err"
    set delete_file [file delete $apl_file]
    return "FALSE"
}

return "TRUE"
}
#############################################################################
## Procedure:  FUNC_APL_ARMAR_20140414

proc ::FUNC_APL_ARMAR_20140414 {} {
global widget

global tcl_platform

if { [string match -nocase "*window*" $tcl_platform(platform)] != 1 } { 
    #puts "This is windows platform"
    return "TRUE"
}


global g_hostname
global g_lotname
global g_dcc
global g_operation
global g_job
global g_operatorid
global g_testprogram
global g_testprogramrev
global g_handler
global g_incount
global g_condition
global g_devicename
global g_board

set qry "SCOPS,APL_Armar,$g_hostname,$g_lotname,$g_dcc,$g_operation,$g_job,$g_testprogram,$g_testprogramrev,$g_devicename,$g_incount,$g_operatorid,$g_condition,$g_board*"

set res ""
set res [FUNC_SEND_QRY $qry]

set platform_name "Armar"

if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
    set msg {"Fail of $platform_name APL" ""}
    set choice [ tk_messageBox -title "$platform_name APL Error" -icon warning -message [FM "TESTIT" $msg $res] ]
    return "FALSE"
}


if { [lindex [split $res ","] 0] == "NO" } {
    #set msg {"Fail of D10 APL" ""}
    #set choice [ tk_messageBox -title "D10 APL Error" -icon warning -message [FM "TESTIT" $msg $res] ]
    return "TRUE"
}

set apl_format [lindex [split $res ","] 0]
set apl_file [lindex [split $res ","] 1]
set apl_path [file dir $apl_file]
set test_oi [lindex [split $res ","] 2]


if { [file exist $apl_path] != 1 } {
    if [catch {
        set tmp [file mkdir $apl_path]
    } err] {
        FD "Func_APL_$platform_name : can't create directory $apl_path"
        set choice [ tk_messageBox -title "Func_APL_$platform_name Error" -message "============================================\n\nContact : K3 Engineer, TESTIT\n\n============================================\n\nCan't delete the previous $apl_file\nCheck the file authority!!!" ]
        return "FALSE"
    }     
}

### clear APL ##################
if { [file exist $apl_file] == 1 } {
    if [catch { 
        set delete_file [file delete $apl_file]
    } err] {
        FD "Func_APL_$platform_name : can't delete $apl_file"
        set choice [ tk_messageBox -title "Func_APL_$platform_name Error" -message "============================================\n\nContact : K3 Engineer, TESTIT\n\n============================================\n\nCan't delete the previous $apl_file\nCheck the file authority!!!" ]
        return "FALSE"
    }  
}

### start writing APL parameters ###
if [catch {
    
    set apl_fd [open $apl_file w]
    
    #1.Test Program
    set apl_contents ""

    for { set i 3 } { $i <= [llength [split $res ","]] } { incr i } {
        
        if { $apl_format == "LINE" } {
            puts $apl_fd [lindex [split $res ","] $i]
        } else {           
                                         
            if { $apl_contents != "" && $i != [llength [split $res ","]] } {
                set apl_contents [format "%s,%s" $apl_contents [lindex [split $res ","] $i] ]
            } else {
                set apl_contents [format "%s%s" $apl_contents [lindex [split $res ","] $i] ]
            }
        }
        
    }
    
    if { $apl_format != "LINE" } {
        puts $apl_fd $apl_contents
    }
    
    close $apl_fd
      
    FD "Func_APL_$platform_name writing success!"
    
    ### execute TEST OI
    if { $test_oi != "" } {
        #set tmp [exec $test_oi &]
    }
    
} err ] {
    FD "Func_APL_$platform_name error : $err"
    set delete_file [file delete $apl_file]
    return "FALSE"
}

return "TRUE"
}
#############################################################################
## Procedure:  FUNC_APL_ARMAR

proc ::FUNC_APL_ARMAR {flag} {
global widget

global tcl_platform

if { [string match -nocase "*window*" $tcl_platform(platform)] != 1 } { 
    #puts "This is windows platform"
    return "TRUE"
}

global g_hostname
global g_lotname
global g_dcc
global g_operation
global g_job
global g_customer
global g_devicename
global g_testprogram
global g_testprogramrev
global g_condition
global g_temperature
global g_incount
global g_operatorid
global g_handler
global g_board
global g_kit
global g_probe

global g_socketcount
global g_handlertype

set apl_name "ARMAR"

set qry "SCOPS,APL_ARMAR,$flag,$g_hostname,$g_lotname,$g_dcc,$g_operation,$g_job,$g_customer,$g_devicename,$g_testprogram,$g_testprogramrev,$g_condition,$g_temperature,$g_incount,$g_operatorid,$g_handler,$g_board,$g_kit,$g_probe,$g_socketcount,$g_handlertype*"

set res ""
set res [FUNC_SEND_QRY $qry]

if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
    set choice [ tk_messageBox -title "$apl_name APL ERROR" -icon warning -message [FM "TESTIT" "Failure to create $apl_name APL file!" $res] ]
    return "FALSE"
}


if { [lindex [split $res ","] 0] == "NO" } {
    return "TRUE"
}

set apl_file [lindex [split $res ","] 0]
set apl_path [file dir $apl_file]
set test_oi [lindex [split $res ","] 1]
set apl_format [lindex [split $res ","] 2]


#FD "apl_file : $apl_file"
#FD "apl_path : $apl_path"
#FD "test_oi : $test_oi"
#FD "apl_format : $apl_format"

if { [file exist $apl_path] != 1 } {
    if [catch {
        set tmp [file mkdir $apl_path]
    } err] {
        FD "$apl_name APL ERROR : Fail to create directory -> $apl_path ($err)"
        set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TESTIT" "Please, Check $apl_path authority to modify!" $res] ]
        return "FALSE"
    }     
}

### clear APL ##################
if { [file exist $apl_file] == 1 } {
    if [catch { 
        set delete_file [file delete $apl_file]
    } err] {
        FD "$apl_name APL ERROR : Failture to delete the previous $apl_file"
        set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TESTIT" "Please, Check $apl_file authority to delete!" $res] ]
        return "FALSE"
    }  
}


if { $flag == "DELETE" } {
    return "TRUE"
}


### start writing APL parameters ###
if [catch {
    
    set apl_fd [open $apl_file w]
    
    set apl_contents ""
    
    for { set i 3 } { $i <= [llength [split $res ","]] } { incr i } {
           
        if { $apl_format == "COMMA" } {   
             if { $apl_contents != "" && $i != [llength [split $res ","]] } {
                set apl_contents [format "%s,%s" $apl_contents [lindex [split $res ","] $i] ]
            } else {
                set apl_contents [format "%s%s" $apl_contents [lindex [split $res ","] $i] ]
            }        
        } else {
            puts $apl_fd [lindex [split $res ","] $i]
        }
                
    }
    
    if { $apl_contents != "" } {
        puts $apl_fd $apl_contents
    }
    
    close $apl_fd
      
    FD "$apl_name APL SUCCESS!"
    
    ### execute TEST OI
    if { $test_oi != "" } {
        if [catch { 
            set tmp [exec $test_oi &]
        } err] {
            FD "$apl_name APL ERROR : Failure to execute $test_oi ($err)"
            set delete_file [file delete $apl_file]
            set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TESTIT" "Failure to execute $test_oi!" $res] ]
            return "FALSE"
        }    
    }
    
} err ] {
    FD "$apl_name APL ERROR : $err"
    set delete_file [file delete $apl_file]
    return "FALSE"
}

return "TRUE"
}
#############################################################################
## Procedure:  FUNC_APL_QSLT

proc ::FUNC_APL_QSLT {flag} {
global widget

global tcl_platform

if { [string match -nocase "*window*" $tcl_platform(platform)] != 1 } { 
    #puts "This is windows platform"
    return "TRUE"
}

global g_hostname
global g_lotname
global g_dcc
global g_operation
global g_job
global g_customer
global g_devicename
global g_testprogram
global g_testprogramrev
global g_condition
global g_temperature
global g_incount
global g_operatorid
global g_handler
global g_board
global g_kit
global g_probe

global g_socketcount
global g_handlertype

set apl_name "QSLT"

set qry "SCOPS,APL_QSLT,$flag,$g_hostname,$g_lotname,$g_dcc,$g_operation,$g_job,$g_customer,$g_devicename,$g_testprogram,$g_testprogramrev,$g_condition,$g_temperature,$g_incount,$g_operatorid,$g_handler,$g_board,$g_kit,$g_probe,$g_socketcount,$g_handlertype*"

set res ""
set res [FUNC_SEND_QRY $qry]

if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
    set choice [ tk_messageBox -title "$apl_name APL ERROR" -icon warning -message [FM "TESTIT" "Failure to create $apl_name APL file!" $res] ]
    return "FALSE"
}


if { [lindex [split $res ","] 0] == "NO" } {
    return "TRUE"
}

set apl_file [lindex [split $res ","] 0]
set apl_path [file dir $apl_file]
set test_oi [lindex [split $res ","] 1]
set apl_format [lindex [split $res ","] 2]


#FD "apl_file : $apl_file"
#FD "apl_path : $apl_path"
#FD "test_oi : $test_oi"
#FD "apl_format : $apl_format"

if { [file exist $apl_path] != 1 } {
    if [catch {
        set tmp [file mkdir $apl_path]
    } err] {
        FD "$apl_name APL ERROR : Fail to create directory -> $apl_path ($err)"
        set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TESTIT" "Please, Check $apl_path authority to modify!" $res] ]
        return "FALSE"
    }     
}

### clear APL ##################
if { [file exist $apl_file] == 1 } {
    if [catch { 
        set delete_file [file delete $apl_file]
    } err] {
        FD "$apl_name APL ERROR : Failture to delete the previous $apl_file"
        set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TESTIT" "Please, Check $apl_file authority to delete!" $res] ]
        return "FALSE"
    }  
}


if { $flag == "DELETE" } {
    return "TRUE"
}


### start writing APL parameters ###
if [catch {
    
    set apl_fd [open $apl_file w]
    
    set apl_contents ""
    
    for { set i 3 } { $i <= [llength [split $res ","]] } { incr i } {
           
        if { $apl_format == "COMMA" } {   
             if { $apl_contents != "" && $i != [llength [split $res ","]] } {
                set apl_contents [format "%s,%s" $apl_contents [lindex [split $res ","] $i] ]
            } else {
                set apl_contents [format "%s%s" $apl_contents [lindex [split $res ","] $i] ]
            }        
        } else {
            puts $apl_fd [lindex [split $res ","] $i]
        }
                
    }
    
    if { $apl_contents != "" } {
        puts $apl_fd $apl_contents
    }
    
    close $apl_fd
      
    FD "$apl_name APL SUCCESS!"
    
    ### execute TEST OI
    if { $test_oi != "" } {
        if [catch { 
            set tmp [exec $test_oi &]
        } err] {
            FD "$apl_name APL ERROR : Failure to execute $test_oi ($err)"
            set delete_file [file delete $apl_file]
            set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TESTIT" "Failure to execute $test_oi!" $res] ]
            return "FALSE"
        }    
    }
    
} err ] {
    FD "$apl_name APL ERROR : $err"
    set delete_file [file delete $apl_file]
    return "FALSE"
}

return "TRUE"
}
#############################################################################
## Procedure:  FUNC_APL_NXP

proc ::FUNC_APL_NXP {flag} {
global widget

global tcl_platform

if { [string match -nocase "*window*" $tcl_platform(platform)] != 1 } { 
    #puts "This is windows platform"
    return "TRUE"
}

global g_hostname
global g_lotname
global g_dcc
global g_operation
global g_job
global g_customer
global g_devicename
global g_testprogram
global g_testprogramrev
global g_condition
global g_temperature
global g_incount
global g_operatorid
global g_handler
global g_board
global g_kit
global g_probe

global g_socketcount
global g_handlertype

set apl_name "NXP"

set qry "SCOPS,APL_NXP,$flag,$g_hostname,$g_lotname,$g_dcc,$g_operation,$g_job,$g_customer,$g_devicename,$g_testprogram,$g_testprogramrev,$g_condition,$g_temperature,$g_incount,$g_operatorid,$g_handler,$g_board,$g_kit,$g_probe,$g_socketcount,$g_handlertype*"

set res ""
set res [FUNC_SEND_QRY $qry]

if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
    set choice [ tk_messageBox -title "$apl_name APL ERROR" -icon warning -message [FM "TESTIT" "Failure to create $apl_name APL file!" $res] ]
    return "FALSE"
}


if { [lindex [split $res ","] 0] == "NO" } {
    return "TRUE"
}

set apl_file [lindex [split $res ","] 0]
set apl_file1 [lindex [split $apl_file "@"] 0]
set apl_file2 [lindex [split $apl_file "@"] 1]
set apl_path1 [file dir $apl_file1]
set apl_path2 [file dir $apl_file2]
set test_oi [lindex [split $res ","] 1]
set apl_format [lindex [split $res ","] 2]


#FD "apl_file : $apl_file"
#FD "apl_path : $apl_path"
#FD "test_oi : $test_oi"
#FD "apl_format : $apl_format"

if { [file exist $apl_path1] != 1 } {
    if [catch {
        set tmp [file mkdir $apl_path1]
    } err] {
        FD "$apl_name APL ERROR : Fail to create directory -> $apl_path1 ($err)"
        set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TESTIT" "Please, Check $apl_path1 authority to modify!" $res] ]
        return "FALSE"
    }     
}

if { [file exist $apl_path2] != 1 } {
    if [catch {
        set tmp [file mkdir $apl_path2]
    } err] {
        FD "$apl_name APL ERROR : Fail to create directory -> $apl_path2 ($err)"
        set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TESTIT" "Please, Check $apl_path2 authority to modify!" $res] ]
        return "FALSE"
    }     
}

### clear APL ##################
if { [file exist $apl_file1] == 1 } {
    if [catch { 
        set delete_file [file delete $apl_file1]
    } err] {
        FD "$apl_name APL ERROR : Failture to delete the previous $apl_file1"
        set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TESTIT" "Please, Check $apl_file1 authority to delete!" $res] ]
        return "FALSE"
    }  
}


if { [file exist $apl_file2] == 1 } {
    if [catch { 
        set delete_file [file delete $apl_file2]
    } err] {
        FD "$apl_name APL ERROR : Failture to delete the previous $apl_file2"
        set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TESTIT" "Please, Check $apl_file2 authority to delete!" $res] ]
        return "FALSE"
    }  
}


if { $flag == "DELETE" } {
    return "TRUE"
}


### start writing APL parameters ###
if [catch {
    
    set apl_fd [open $apl_file1 w]
    
    set apl_contents ""
    
    for { set i 3 } { $i <= [llength [split $res ","]] } { incr i } {
           
        if { $apl_format == "COMMA" } {   
             if { $apl_contents != "" && $i != [llength [split $res ","]] } {
                set apl_contents [format "%s,%s" $apl_contents [lindex [split $res ","] $i] ]
            } else {
                set apl_contents [format "%s%s" $apl_contents [lindex [split $res ","] $i] ]
            }        
        } else {
            puts $apl_fd [lindex [split $res ","] $i]
        }
                
    }
    
    if { $apl_contents != "" } {
        puts $apl_fd $apl_contents
    }
    
    close $apl_fd
      
    FD "$apl_name APL SUCCESS!"
    
    ### execute TEST OI
    if { $test_oi != "" } {
        if [catch { 
            set tmp [exec $test_oi &]
        } err] {
            FD "$apl_name APL ERROR : Failure to execute $test_oi ($err)"
            set delete_file [file delete $apl_file]
            set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TESTIT" "Failure to execute $test_oi!" $res] ]
            return "FALSE"
        }    
    }
    
} err ] {
    FD "$apl_name APL ERROR : $err"
    set delete_file [file delete $apl_file1]
    return "FALSE"
}

if [catch {
    
    set apl_fd [open $apl_file2 w]
    
    set apl_contents ""
    
    for { set i 3 } { $i <= [llength [split $res ","]] } { incr i } {
           
        if { $apl_format == "COMMA" } {   
             if { $apl_contents != "" && $i != [llength [split $res ","]] } {
                set apl_contents [format "%s,%s" $apl_contents [lindex [split $res ","] $i] ]
            } else {
                set apl_contents [format "%s%s" $apl_contents [lindex [split $res ","] $i] ]
            }        
        } else {
            puts $apl_fd [lindex [split $res ","] $i]
        }
                
    }
    
    if { $apl_contents != "" } {
        puts $apl_fd $apl_contents
    }
    
    close $apl_fd
      
    FD "$apl_name APL SUCCESS!"
    
    ### execute TEST OI
    if { $test_oi != "" } {
        if [catch { 
            set tmp [exec $test_oi &]
        } err] {
            FD "$apl_name APL ERROR : Failure to execute $test_oi ($err)"
            set delete_file [file delete $apl_file]
            set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TESTIT" "Failure to execute $test_oi!" $res] ]
            return "FALSE"
        }    
    }
    
} err ] {
    FD "$apl_name APL ERROR : $err"
    set delete_file [file delete $apl_file2]
    return "FALSE"
}



return "TRUE"
}
#############################################################################
## Procedure:  FUNC_CHECK_TESTERASSIGNMENT

proc ::FUNC_CHECK_TESTERASSIGNMENT {} {
global widget

global g_hostname
global g_lotname
global g_dcc
global g_operation
global g_operatorid


set qry "SCOPS,CheckTesterAssignment,$g_hostname,$g_lotname,$g_dcc,$g_operation*"

set res ""
set res [FUNC_SEND_QRY $qry]


if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {

    set choice [ tk_messageBox -title "Tester Assignment Check Error" -icon warning -message [FM "TESTIT" "Fail to Get Test Program!" $res] ]
    return "TRUE"
}

if { [string match -nocase "*no*" [lindex [split $res ","] 0] ] == 1 } {

    set choice [ tk_messageBox -title "Tester Assignment Check Error" -icon error -message [FM "K3 Engineer" "This Lot is not Assigned yet!" $res] ]
    return "FALSE"
}

return "TRUE"
}
#############################################################################
## Procedure:  FUNC_RFID_CHECK_SOCKETCLEAR

proc ::FUNC_RFID_CHECK_SOCKETCLEAR {socket} {
global widget
global g_hostname

set qry "SCOPS,CheckSocketClear,$socket,$g_hostname*"

set res ""
set res [FUNC_SEND_QRY $qry]

if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
    return "FALSE"
}

if { [lindex [split $res ","] 0] == "NO" } {
    return "FALSE"
}

return "TRUE"
}
#############################################################################
## Procedure:  FUNC_CHECK_JUNCTIONTEMPERATURE

proc ::FUNC_CHECK_JUNCTIONTEMPERATURE {flag} {
global widget

global g_hostname
global g_tclplatform

global g_testing_flag

if { $flag == "START" } {
    if { $g_testing_flag != "TESTING" } { 
        #FD "FUNC_CHECK_JUNCTIONTEMPERATURE : SCOPS IS NOT RUNNING"
        return "TRUE" 
    }
}

set qry "SCOPS,CheckJunctionTemperature,$g_hostname,$g_tclplatform,$flag*"

set res ""
set res [FUNC_SEND_QRY $qry]

if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
    return "FALSE"
}

if { [lindex [split $res ","] 0] == "NO" } {
    return "TRUE"
}

set execution_file [lindex [split $res ","] 1]

if { $execution_file == "" } {
    #FD "FUNC_CHECK_JUNCTIONTEMPERATURE : NO FILE TO EXECUTE"
    return "TRUE"
}

if { [ catch { set temp [exec $execution_file & ] } err] } {
    #FD "FUNC_CHECK_JUNCTIONTEMPERATURE : $err"
} else {
    #FD "FUNC_CHECK_JUNCTIONTEMPERATURE SUCCESS"
}

return "TRUE"
}
#############################################################################
## Procedure:  FUNC_CHECK_HSFANDSVR

proc ::FUNC_CHECK_HSFANDSVR {} {
global widget

global g_hostname

set qry "SCOPS,CheckHSFandSVR,$g_hostname*"

set res ""
set res [FUNC_SEND_QRY $qry]

if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
    set choice [ tk_messageBox -title "HSF and SVR Check Error" -icon warning -message [FM "Engineer, Equipment Group" "Fail to Check HSF and SVR" $res] ]
    return "FALSE"
}

set alert_type ""
set alert_msg ""
set hsf_result_msg ""

set alert_type [lindex [split $res ","] 0]
set alert_msg [lindex [split $res ","] 1]
set hsf_result_msg [lindex [split $res ","] 2]
##########################################
##########################################
#set alert_type 1
#set alert_msg "abcdefg"
##########################################
##########################################



if { $alert_type == 1 } {
    set win_title "handler_stop_s2s"
    set config "$win_title"
    
    FUNC_DISPLAY_MESSAGE "open" $config "image,scops_warning_handler_stop_s2s.gif" [FM "K3 Engineer" "Site Variance Alert!!" ""]
    
    if { $hsf_result_msg != "" } {
        set choice [ tk_messageBox -title "HSF RESULT MESSAGE" -icon info -message [FM "Operator, Engineer" $hsf_result_msg ""] ]
    }
    
} elseif { $alert_type == 2 } {

    set win_title "handler_stop_sbl"
    set config "$win_title"
    
    FUNC_DISPLAY_MESSAGE "open" $config "image,scops_warning_handler_stop_sbl.gif" [FM "K3 Engineer" "Soft Bin Limit!!" ""]
    
    if { $hsf_result_msg != "" } {
        set choice [ tk_messageBox -title "HSF RESULT MESSAGE" -icon info -message [FM "Operator, Engineer" $hsf_result_msg ""] ]
    }
    
} 
}
#############################################################################
## Procedure:  FUNC_CHECK_BOARDCORRELATION

proc ::FUNC_CHECK_BOARDCORRELATION {} {
global widget

global g_hostname
global g_lotname
global g_dcc
global g_operation
global g_operatorid
global g_customer
global g_board
#global g_kit


#set @flag = ISNULL(@flag,'')
#set @hostname = ISNULL(@hostname,'')
#set @lotname = ISNULL(@lotname,'')
#set @dcc = ISNULL(@dcc,'')
#set @operation = ISNULL(@operation,'')
#set @operator = ISNULL(@operator,'')
#set @customer = ISNULL(@customer,'')
#set @board = ISNULL(@board,'')
#set @kit = ISNULL(@kit,'')

#if { [string match -nocase "*PROB*" $g_operation] == 1 } { 
    #FD "FUNC_RFID_CHECK_PROBETOUCHDOWN : operation"
#    return "TRUE" 
#}

if { $g_hostname == "test" } {
    return "TRUE"
}

set qry "SCOPS,CheckBoardCorrelation,$g_hostname,$g_board*"

set res ""
set res [FUNC_SEND_QRY $qry]


if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
    set choice [ tk_messageBox -title "Board Correlation Check Error" -icon warning -message [FM "TESTIT" "Fail to Check Board Correlation." $res] ]
    return "TRUE"
}

if { [lindex [split $res ","] 0] == "NO" } {
    set choice [ tk_messageBox -title "Board Correlation Check Error" -icon error -message [FM "K3 Engineer, HCC" "Fail to Check Board Correlation." $res] ]
    return "FALSE"
}

return "TRUE"
}
#############################################################################
## Procedure:  FUNC_APL_HP

proc ::FUNC_APL_HP {flag} {
global widget

global tcl_platform
global g_os

if { [string match -nocase "*window*" $tcl_platform(platform)] == 1 } { 
    #puts "This is windows platform"
    return "TRUE"
}

global g_hostname
global g_lotname
global g_dcc
global g_operation
global g_job
global g_customer
global g_devicename
global g_testprogram
global g_testprogramrev
global g_condition
global g_temperature
global g_incount
global g_operatorid
global g_handler
global g_board
global g_boardno
global g_kit

global g_package

global g_socketcount
global g_handlertype


global g_apl_flag
global g_apl_path

if { $g_apl_flag != "ON" } {
    return "TRUE"
}

if { $g_apl_path == "" } {
    return "TRUE"
}


set win_title "warning_hpapl"
FUNC_DISPLAY_MESSAGE "close" "$win_title" "" ""

set config "$win_title"
set file_name "image,scops_warning_program.gif"


if { [file exists $g_apl_path] == 0 } {
    FUNC_DISPLAY_MESSAGE "open" $config $file_name [FM "Engineer, Manager" "THERE' NO $g_apl_path FILE!" ""]
    tk_messageBox -title "APL Error!!"  -message "THERE' NO $g_apl_path FILE!" -icon error
    FUNC_DISPLAY_MESSAGE "close" "$win_title" "" ""
    return "FALSE"
}

set apl_lotname ""
if { $g_dcc != "" } {
    set apl_lotname [format "%s\DCC%s" $g_lotname $g_dcc]
} else {
    set apl_lotname $g_lotname
}

### linux
if { [string match -nocase "*linux*" $g_os] == 1 } {
    if { $g_dcc == "" } {
        set apl_string "|$g_apl_path START {$g_customer} {$g_devicename} {$apl_lotname} {$g_testprogramrev} {/usr/local1/APL/} {$g_testprogram} {$g_operation} {$g_package} {$g_job} {$g_temperature} {$g_operatorid} {$g_boardno} {$g_handler} {} {NONE}"
    } else {
        set apl_string "|$g_apl_path START {$g_customer} {$g_devicename} {$apl_lotname} {$g_testprogramrev} {/usr/local1/APL/} {$g_testprogram} {$g_operation} {$g_package} {$g_job} {$g_temperature} {$g_operatorid} {$g_boardno} {$g_handler} {} {$g_dcc}"
    }
### unix
} else {
    set apl_string "|$g_apl_path START {$g_customer} {$g_devicename} {$apl_lotname} {$g_testprogramrev} {/usr/local1/APL/} {$g_testprogram} {$g_operation} {$g_package} {$g_job} {$g_temperature} {$g_operatorid} {$g_boardno} {$g_handler} {}"
}

if { $flag == "DELETE" } {
    set apl_string "|$g_apl_path STOP"
}

FD "FUNC_APL_HP -> $apl_string"

set apl_result ""
set xcmd [open $apl_string]
set apl_result [read $xcmd]
catch {close $xcmd}

FD "FUNC_APL_HP <- $apl_result"

set apl_result_message ""
set apl_result_flag [lindex [split $apl_result "/" ] 0]
set apl_result_message [lindex [split $apl_result "/" ] 1]


#####################################
# demot setting #
#set apl_result_flag "1"
#####################################


switch -regexp -- $apl_result_flag {
    0 {
        #FD "FUNC_APL_HP : SUCCESS"
    }
    
    1 {
        FUNC_DISPLAY_MESSAGE "open" $config $file_name [FM "Engineer, Manager" $apl_result_message ""]
        tk_messageBox -title "APL Error!!"  -message $apl_result_message -icon error
        FUNC_DISPLAY_MESSAGE "close" "$win_title" "" ""
    }
    
    2 {
        FUNC_DISPLAY_MESSAGE "open" $config $file_name [FM "Engineer, Manager" $apl_result_message ""]
        tk_messageBox -title "APL Error!!"  -message $apl_result_message -icon error
        FUNC_DISPLAY_MESSAGE "close" "$win_title" "" ""
        return "FALSE"    
    }
    
    99 {
        #return "TRUE"
    }
    
    default {
        #FUNC_DISPLAY_MESSAGE $config $file_name [FM "TESTIT" "NO MESSAGE FROM ScopsToAPL" ""]
        #tk_messageBox -title "APL Error!!"  -message $apl_result_message -icon error
        #FUNC_DISPLAY_MESSAGE "close,$win_title" "" ""
        #return "FALSE"     
    }
    
}

return "TRUE"
}
#############################################################################
## Procedure:  FUNC_APL_J750_NXP

proc ::FUNC_APL_J750_NXP {flag} {
global widget

global tcl_platform

if { [string match -nocase "*window*" $tcl_platform(platform)] != 1 } { 
    #puts "This is windows platform"
    return "TRUE"
}

global g_hostname
global g_lotname
global g_dcc
global g_operation
global g_job
global g_customer
global g_devicename
global g_testprogram
global g_testprogramrev
global g_condition
global g_temperature
global g_incount
global g_operatorid
global g_handler
global g_board
global g_kit
global g_probe

global g_socketcount
global g_handlertype

set apl_name "J750_NXP"

set qry "SCOPS,APL_J750_NXP,$flag,$g_hostname,$g_lotname,$g_dcc,$g_operation,$g_job,$g_customer,$g_devicename,$g_testprogram,$g_testprogramrev,$g_condition,$g_temperature,$g_incount,$g_operatorid,$g_handler,$g_board,$g_kit,$g_probe,$g_socketcount,$g_handlertype*"

set res ""
set res [FUNC_SEND_QRY $qry]

if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
    set choice [ tk_messageBox -title "$apl_name APL ERROR" -icon warning -message [FM "TESTIT" "Failure to create $apl_name APL file!" $res] ]
    return "FALSE"
}


if { [lindex [split $res ","] 0] == "NO" } {
    return "TRUE"
}

set apl_file [lindex [split $res ","] 0]
set apl_file1 [lindex [split $apl_file ";"] 0]
set apl_file2 [lindex [split $apl_file ";"] 1]
set apl_path1 [file dir $apl_file1]
set apl_path2 [file dir $apl_file2]
set test_oi [lindex [split $res ","] 1]
set apl_format [lindex [split $res ","] 2]


#FD "apl_file : $apl_file"
#FD "apl_path : $apl_path"
#FD "test_oi : $test_oi"
#FD "apl_format : $apl_format"

if { [file exist $apl_path1] != 1 } {
    if [catch {
        set tmp [file mkdir $apl_path1]
    } err] {
        FD "$apl_name APL ERROR : Fail to create directory -> $apl_path1 ($err)"
        set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TESTIT" "Please, Check $apl_path1 authority to modify!" $res] ]
        return "FALSE"
    }     
}

if { [file exist $apl_path2] != 1 } {
    if [catch {
        set tmp [file mkdir $apl_path2]
    } err] {
        FD "$apl_name APL ERROR : Fail to create directory -> $apl_path2 ($err)"
        set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TESTIT" "Please, Check $apl_path2 authority to modify!" $res] ]
        return "FALSE"
    }     
}

### clear APL ##################
if { [file exist $apl_file1] == 1 } {
    if [catch { 
        set delete_file [file delete $apl_file1]
    } err] {
        FD "$apl_name APL ERROR : Failture to delete the previous $apl_file1"
        set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TESTIT" "Please, Check $apl_file1 authority to delete!" $res] ]
        return "FALSE"
    }  
}


if { [file exist $apl_file2] == 1 } {
    if [catch { 
        set delete_file [file delete $apl_file2]
    } err] {
        FD "$apl_name APL ERROR : Failture to delete the previous $apl_file2"
        set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TESTIT" "Please, Check $apl_file2 authority to delete!" $res] ]
        return "FALSE"
    }  
}


if { $flag == "DELETE" } {
    return "TRUE"
}


### create the first APL
if { $apl_file1 != "" } {
	if [catch {
	    
		set apl_fd [open $apl_file1 w]
	    
		set apl_contents ""
	    
		for { set i 3 } { $i <= [llength [split $res ","]] } { incr i } {
	           
			if { $apl_format == "COMMA" } {   
				 if { $apl_contents != "" && $i != [llength [split $res ","]] } {
					set apl_contents [format "%s,%s" $apl_contents [lindex [split $res ","] $i] ]
				} else {
					set apl_contents [format "%s%s" $apl_contents [lindex [split $res ","] $i] ]
				}        
			} else {
				puts $apl_fd [lindex [split $res ","] $i]
			}
	                
		}
	    
		if { $apl_contents != "" } {
			puts $apl_fd $apl_contents
		}
	    
		close $apl_fd
	      
		FD "$apl_name APL SUCCESS!"
	    
		### execute TEST OI
		if { $test_oi != "" } {
			if [catch { 
				set tmp [exec $test_oi &]
			} err] {
				FD "$apl_name APL ERROR : Failure to execute $test_oi ($err)"
				set delete_file [file delete $apl_file]
				set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TESTIT" "Failure to execute $test_oi!" $res] ]
				return "FALSE"
			}    
		}
	    
	} err ] {
		FD "$apl_name APL ERROR : $err"
		set delete_file [file delete $apl_file1]
		return "FALSE"
	}
}


if { $apl_file2 != "" } {
	if [catch {
	    
		set apl_fd [open $apl_file2 w]
	    
		set apl_contents ""
	    
		for { set i 3 } { $i <= [llength [split $res ","]] } { incr i } {
	           
			if { $apl_format == "COMMA" } {   
				 if { $apl_contents != "" && $i != [llength [split $res ","]] } {
					set apl_contents [format "%s,%s" $apl_contents [lindex [split $res ","] $i] ]
				} else {
					set apl_contents [format "%s%s" $apl_contents [lindex [split $res ","] $i] ]
				}        
			} else {
				puts $apl_fd [lindex [split $res ","] $i]
			}
	                
		}
	    
		if { $apl_contents != "" } {
			puts $apl_fd $apl_contents
		}
	    
		close $apl_fd
	      
		FD "$apl_name APL SUCCESS!"
	    
		### execute TEST OI
		if { $test_oi != "" } {
			if [catch { 
				set tmp [exec $test_oi &]
			} err] {
				FD "$apl_name APL ERROR : Failure to execute $test_oi ($err)"
				set delete_file [file delete $apl_file]
				set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TESTIT" "Failure to execute $test_oi!" $res] ]
				return "FALSE"
			}    
		}
	    
	} err ] {
		FD "$apl_name APL ERROR : $err"
		set delete_file [file delete $apl_file2]
		return "FALSE"
	}
}

return "TRUE"
}
#############################################################################
## Procedure:  FUNC_APL_HP93K_NXP

proc ::FUNC_APL_HP93K_NXP {flag filetype} {
global widget

global tcl_platform

if { [string match -nocase "*window*" $tcl_platform(platform)] == 1 } { 
    #puts "This is windows platform"
    return "TRUE"
}

global g_hostname
global g_lotname
global g_dcc
global g_operation
global g_job
global g_customer
global g_devicename
global g_testprogram
global g_testprogramrev
global g_condition
global g_temperature
global g_incount
global g_operatorid
global g_handler
global g_board
global g_kit
global g_probe

global g_socketcount
global g_handlertype

set apl_name "NXP"

set qry "SCOPS,APL_HP93K_NXP,$flag,$g_hostname,$g_lotname,$g_dcc,$g_operation,$g_job,$g_customer,$g_devicename,$g_testprogram,$g_testprogramrev,$g_condition,$g_temperature,$g_incount,$g_operatorid,$g_handler,$g_board,$g_kit,$g_probe,$filetype*"

set res ""
set res [FUNC_SEND_QRY $qry]

if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
    set choice [ tk_messageBox -title "$apl_name APL ERROR" -icon warning -message [FM "TESTIT" "Failure to create $apl_name APL file!" $res] ]
    return "FALSE"
}


if { [lindex [split $res ","] 0] == "NO" } {
    return "TRUE"
}

set apl_file [lindex [split $res ","] 0]
set apl_file1 [lindex [split $apl_file ";"] 0]
set apl_file2 [lindex [split $apl_file ";"] 1]
set apl_path1 [file dir $apl_file1]
set apl_path2 [file dir $apl_file2]
set test_oi [lindex [split $res ","] 1]
set apl_format [lindex [split $res ","] 2]


#FD "apl_file : $apl_file"
#FD "apl_path : $apl_path"
#FD "test_oi : $test_oi"
#FD "apl_format : $apl_format"

if { [file exist $apl_path1] != 1 } {
    if [catch {
        set tmp [file mkdir $apl_path1]
    } err] {
        FD "$apl_name APL ERROR : Fail to create directory -> $apl_path1 ($err)"
        set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TESTIT" "Please, Check $apl_path1 authority to modify!" $res] ]
        return "FALSE"
    }     
}

if { [file exist $apl_path2] != 1 } {
    if [catch {
        set tmp [file mkdir $apl_path2]
    } err] {
        FD "$apl_name APL ERROR : Fail to create directory -> $apl_path2 ($err)"
        set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TESTIT" "Please, Check $apl_path2 authority to modify!" $res] ]
        return "FALSE"
    }     
}

### clear APL ##################
if { [file exist $apl_file1] == 1 } {
    if [catch { 
        set delete_file [file delete $apl_file1]
    } err] {
        FD "$apl_name APL ERROR : Failture to delete the previous $apl_file1"
        set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TESTIT" "Please, Check $apl_file1 authority to delete!" $res] ]
        return "FALSE"
    }  
}


if { [file exist $apl_file2] == 1 } {
    if [catch { 
        set delete_file [file delete $apl_file2]
    } err] {
        FD "$apl_name APL ERROR : Failture to delete the previous $apl_file2"
        set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TESTIT" "Please, Check $apl_file2 authority to delete!" $res] ]
        return "FALSE"
    }  
}


if { $flag == "DELETE" } {
    return "TRUE"
}


### create the first APL
if { $apl_file1 != "" } {
	if [catch {
	    
		set apl_fd [open $apl_file1 w]
	    
		set apl_contents ""
	    
		for { set i 3 } { $i <= [llength [split $res ","]] } { incr i } {
	           
			if { $apl_format == "COMMA" } {   
				 if { $apl_contents != "" && $i != [llength [split $res ","]] } {
					set apl_contents [format "%s,%s" $apl_contents [lindex [split $res ","] $i] ]
				} else {
					set apl_contents [format "%s%s" $apl_contents [lindex [split $res ","] $i] ]
				}        
			} else {
				puts $apl_fd [string map {"|" ","} [lindex [split $res ","] $i]]
			}
	                
		}
	    
		if { $apl_contents != "" } {
			puts $apl_fd [string map {"|" ","} $apl_contents]
		}
	    
		close $apl_fd
	      
		FD "$apl_name APL SUCCESS!"
	    
		### execute TEST OI
		if { $test_oi != "" } {
			if [catch { 
				set tmp [exec $test_oi &]
			} err] {
				FD "$apl_name APL ERROR : Failure to execute $test_oi ($err)"
				set delete_file [file delete $apl_file]
				set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TESTIT" "Failure to execute $test_oi!" $res] ]
				return "FALSE"
			}    
		}
	    
	} err ] {
		FD "$apl_name APL ERROR : $err"
		set delete_file [file delete $apl_file1]
		return "FALSE"
	}
}


if { $apl_file2 != "" } {
	if [catch {
	    
		set apl_fd [open $apl_file2 w]
	    
		set apl_contents ""
	    
		for { set i 3 } { $i <= [llength [split $res ","]] } { incr i } {
	           
			if { $apl_format == "COMMA" } {   
				 if { $apl_contents != "" && $i != [llength [split $res ","]] } {
					set apl_contents [format "%s,%s" $apl_contents [lindex [split $res ","] $i] ]
				} else {
					set apl_contents [format "%s%s" $apl_contents [lindex [split $res ","] $i] ]
				}        
			} else {
				puts $apl_fd [lindex [split $res ","] $i]
			}
	                
		}
	    
		if { $apl_contents != "" } {
			puts $apl_fd $apl_contents
		}
	    
		close $apl_fd
	      
		FD "$apl_name APL SUCCESS!"
	    
		### execute TEST OI
		if { $test_oi != "" } {
			if [catch { 
				set tmp [exec $test_oi &]
			} err] {
				FD "$apl_name APL ERROR : Failure to execute $test_oi ($err)"
				set delete_file [file delete $apl_file]
				set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TESTIT" "Failure to execute $test_oi!" $res] ]
				return "FALSE"
			}    
		}
	    
	} err ] {
		FD "$apl_name APL ERROR : $err"
		set delete_file [file delete $apl_file2]
		return "FALSE"
	}
}

return "TRUE"
}
#############################################################################
## Procedure:  FUNC_CHECK_PREVIOUSSCOPS

proc ::FUNC_CHECK_PREVIOUSSCOPS {} {
global widget

global g_dualscops_flag

if { $g_dualscops_flag == "ON" } { return "TRUE" }

global tcl_platform

set mes "ANOTHER SCOPS IS ALREADY RUNNING!\n\nUSE ONLY 1 SCOPS."

### windows scops
if { [string match -nocase "*window*" $tcl_platform(platform)] == 1 } {
    
    if [catch { 
        package require twapi

        set current_scopsid [twapi::get_current_process_id]

        foreach tmp_pid [lsort -integer [twapi::get_process_ids -glob -name "*scops3.exe*"]] {
            if { $current_scopsid != $tmp_pid } {
                set tmp [twapi::end_process $tmp_pid -force]
            }    
        }
 
        #set tmp_window ""
        #set tmp_window [lsort -integer [twapi::get_process_ids -glob -name "scops3.exe*"]]

        #if { [llength $tmp_window] > 1 } {
        #    set choice [ tk_messageBox -title "SCOPS IS RUNNING" -icon error -message [FM "TESTIT" $mes ""] ]
        #    exit
        #}
        
        return
        
    } err] {
        FD "FUNC_CHECK_PREVIOUSSCOPS - Windows : $err"
    }
}

return

set unixlinux_scops_process_count 0
set unixlinux_process_list ""

### linux scops
if [catch {
    set unixlinux_process_list [exec ps -ef]    
} err] {
    #FD "FUNC_CHECK_PREVIOUSSCOPS - Linux : $err"
}

### unix scops
if [catch {
    set unixlinux_process_list [exec ps -ax] 
} err] {
    #FD "FUNC_CHECK_PREVIOUSSCOPS - Unix : $err"
}

#FD "unixlinux_process_list: $unixlinux_process_list"

foreach temp $unixlinux_process_list {
    if { [string match "*scops3.tcl*" $temp] == 1 } {
        incr unixlinux_scops_process_count 1
    }
}

FD "unixlinux_scops_process_count: $unixlinux_scops_process_count"

if { $unixlinux_scops_process_count > 1 } {
    set choice [ tk_messageBox -title "SCOPS IS RUNNING" -icon error -message [FM "TESTIT" $mes ""] ]
        exit
}


### test
}
#############################################################################
## Procedure:  FUNC_CHECK_WIPFLOW

proc ::FUNC_CHECK_WIPFLOW {} {
global widget

global g_hostname
global g_lotname
global g_dcc
global g_operation
global g_operatorid

#############################################################
if { $g_hostname == "test" } { return "TRUE" }
#############################################################


set qry "SCOPS,CheckWIPFlow,$g_hostname,$g_lotname,$g_dcc,$g_operation*"

set res ""
set res [FUNC_SEND_QRY $qry]


if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {

    set choice [ tk_messageBox -title "WIP Flow Check Error" -icon warning -message [FM "TESTIT" "FAIL TO CHECK WIP OPERATION!" $res] ]
    return "FALSE"
}

if { [string match -nocase "*no*" [lindex [split $res ","] 0] ] == 1 } {

    set choice [ tk_messageBox -title "WIP Flow Check Error" -icon error -message [FM "K3 Engineer" "SCOPS OPERATION AND WIP OPERATION ARE DIFFERENT!" $res] ]
    return "FALSE"
}

return "TRUE"
}
#############################################################################
## Procedure:  FUNC_UPDATE_SCOPS

proc ::FUNC_UPDATE_SCOPS {} {
global widget

global tcl_platform
#global g_scopspath

global g_rootdir
global g_hostname


### get information for download
set qry "SCOPS,GetFTP,$g_hostname*"
FD "GetFTP qry : $qry"

set res [FUNC_SEND_QRY $qry]
FD "GetFTP res : $res"
    
if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
    #FUNC_DEBUG "It can't download the new scops file!"
    return
}

    
set port ""        
    
set scopspath [lindex [split $res ","] 0]
set server [lindex [split $res ","] 1]
set port [lindex [split $res ","] 2]
set id [lindex [split $res ","] 3]
set pass [lindex [split $res ","] 4]
set pre_scops [lindex [split $res ","] 5]
set update_agent [lindex [split $res ","] 6]

if { $port == "" } { set port 21 }
    
if { $server == "" || $id == "" || $pass == "" } {
    FD "FUNC_UPDATE_SCOPS : NO FTP INFORMATION -> $server, $id, $pass"
    return
}




### windows ###########################################################################################
if { [string match -nocase "*window*" $tcl_platform(platform)] == 1 } {

    ## set the name of update_agent
    set update_agent [format "%s.exe" $update_agent]
    
    ## check scops update agent ###############
    if { [file exist [file join $g_rootdir $update_agent]] == 0 } {
    
        ### download the lastest scops
        set res [FUNC_DOWNLOAD_FILE "BIN" $update_agent [file join $g_rootdir $update_agent]]
                        
        if { $res == "FALSE" } {
            FD "SCOPS Update Agent Download Fail!"
            return "FALSE"
        } else {
            FD "SCOPS Update Agent Download Success!"
        }
    }
    
    if [catch {
    
        ## kill previous update agent process
        FUNC_KILL_PROCESS $update_agent      
        
        ## execute new update agent process  
        set tmp [exec [file join $g_rootdir $update_agent] &]
        
    } err ] {
        FD "Fail to execute scops update agent -> $err"
        return "FALSE"
    }   
    
    return
}


### linux / unix ###########################################################################################
if { [string match -nocase "*window*" $tcl_platform(platform)] == 0 } {

    set mounted_flag "OFF"
    set unix_linux_scops [format "%s.tcl" $pre_scops]
    set scops_script [format "%s.sh" $pre_scops]

#FD "FUNC_UPDATE_SCOPS : check mounted"

    ### mounted or not
    if [catch {
        set temp [exec df | grep /usr/local1]
    } err ] {
        FD "FUNC_UPDATE_SCOPS : Fail to mounted dir -> $err"
        set temp $err
    }
    
    foreach tmp $temp {
        if { [string match -nocase "*/usr/local1*" $tmp] == 1 } {
            set mounted_flag "ON"
        }
    }
    
FD "FUNC_UPDATE_SCOPS : mounted_flag -> $mounted_flag"
    
    if { $mounted_flag != "ON" } {
        set res [FUNC_DOWNLOAD_FILE "BIN" $unix_linux_scops [file join $g_rootdir $unix_linux_scops]]
                        
        if { $res == "FALSE" } {
            FD "FUNC_UPDATE_SCOPS : $unix_linux_scops Download Fail!"
            return "FALSE"
        } else {
            FD "FUNC_UPDATE_SCOPS : $unix_linux_scops Download Success!"
        }
    }
    
    
    
    if { [file exist [file join $g_rootdir $scops_script]] == 1 } {
        if [catch { 
            set temp [exec $scopspath &]
        } err ] {
            FD "FUNC_UPDATE_SCOPS : Fail to execute $scopspath error : $err"
            return "FALSE"
        }
        
        return "TRUE"
    }
    
FD "FUNC_UPDATE_SCOPS : THERE IS NO [file join $g_rootdir $scops_script]"   
       
    if [catch { 

        set batch_file [file join $g_rootdir $scops_script]

        ## delete former batch file like /usr/local1/bin/scops3.sh
        set delete_file [file delete $batch_file]

        set fd [open $batch_file w]

        puts $fd "#!/bin/sh"
        puts $fd "ps -afe | grep $unix_linux_scops | grep -v grep | awk '{print \$0}' | awk '{print \$2}' | xargs kill -9"
        puts $fd "LD_LIBRARY_PATH=/usr/local1/lib"
        puts $fd "export LD_LIBRARY_PATH"

        global tcl_version
        set wish_version [format "wish%s" $tcl_version]

        puts $fd "[file join $g_rootdir $wish_version] [file join $g_rootdir $unix_linux_scops] > /dev/null &"
        puts $fd "exit"
        close $fd

        #puts "Update File is Done!"

    } err ] {
        FD "FUNC_UPDATE_SCOPS : Fail to create $batch_file error : $err"
        close $fd
        return
    }

    if [catch {
        set temp [exec chmod 777 $batch_file [file join $g_rootdir $unix_linux_scops]]
    } err ] {
        FD "FUNC_UPDATE_SCOPS : Fail to chmod $batch_file error : $err"
    }
    
    if [catch {
        set temp [exec $batch_file &]
    } err ] {
        FUNC_DEBUG "FUNC_UPDATE_SCOPS : Fail to execute $batch_file error : $err"
        return
    } 

}
  
}
#############################################################################
## Procedure:  FUNC_UPDATE_ID

proc ::FUNC_UPDATE_ID {} {
global widget

global tcl_platform

if { [string match -nocase "*window*" $tcl_platform(platform)] == 1 } { return }

set id ""

if [catch {
    set id [exec id]
} err] {
    set id "" 
}


global g_hostname
set qry "SCOPS,UpdateID,$g_hostname,$id*"
set res ""
set res [FUNC_SEND_QRY $qry]
}
#############################################################################
## Procedure:  FUNC_APL_T2000_LSI_SUB

proc ::FUNC_APL_T2000_LSI_SUB {} {
global widget

global tcl_platform

if { [string match -nocase "*window*" $tcl_platform(platform)] != 1 } { 
    #puts "This is windows platform"
    return "TRUE"
}


global g_hostname
global g_lotname
global g_dcc
global g_operation
global g_job
global g_customer
global g_devicename
global g_testprogram
global g_testprogramrev
global g_condition
global g_temperature
global g_incount
global g_operatorid
global g_handler
global g_board
global g_kit

global g_socketcount
global g_handlertype

set apl_name "T2000 LSI"

set qry "SCOPS,APL_T2000_LSI_SUB,$g_hostname,$g_lotname,$g_dcc,$g_operation,$g_customer*"

set res ""
set res [FUNC_SEND_QRY $qry]

if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
    set choice [ tk_messageBox -title "$apl_name APL ERROR" -icon warning -message [FM "TESTIT" "Failure to create $apl_name APL file!" $res] ]
    return "FALSE"
}


if { [lindex [split $res ","] 0] == "NO" } {
    return "TRUE"
}

set file_path [lindex [split $res ","] 1]
set program [lindex [split $res ","] 2]

if { [file exist $file_path] != 1 } {
    
    set choice [ tk_messageBox -type yesno -icon warning -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TESTIT" "NO APL PROGRAM : $file_path" "DO YOU WANT TO CONTINUE?"] ]
    
    if { $choice != "yes" } {
        return "FALSE"
    }
}

if [catch {
    #FD "exec $file_path $program &"
    set tmp [exec $file_path $g_testprogram $program &]
} err] {
    set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TESTIT" "FAIL TO EXECUTE $file_path" ""] ]
    return "FALSE"
}     


return "TRUE"
}
#############################################################################
## Procedure:  FUNC_SPLIT_STRING

proc ::FUNC_SPLIT_STRING {string idx} {
global widget

set temp ""

set temp [lindex $string $idx]

return $temp
}
#############################################################################
## Procedure:  FS

proc ::FS {string idx} {
global widget

return [FUNC_SPLIT_STRING $string $idx]
}
#############################################################################
## Procedure:  FUNC_APL_AMD_HP93K

proc ::FUNC_APL_AMD_HP93K {flag} {
global widget

global tcl_platform

global g_hostname
global g_lotname
global g_dcc
global g_operation
global g_job
global g_customer
global g_devicename
global g_testprogram
global g_testprogramrev
global g_condition
global g_temperature
global g_incount
global g_operatorid
global g_handler
global g_board
global g_kit
global g_probe

global g_socketcount
global g_handlertype

set apl_name "AMD_HP93K"

set qry "SCOPS,APL_AMD_HP93K,$flag,$g_hostname,$g_lotname,$g_dcc,$g_operation,$g_job,$g_customer,$g_devicename,$g_testprogram,$g_testprogramrev,$g_condition,$g_temperature,$g_incount,$g_operatorid,$g_handler,$g_board,$g_kit,$g_probe,$g_socketcount,$g_handlertype*"

set res ""
set res [FUNC_SEND_QRY $qry]

if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
    set choice [ tk_messageBox -title "$apl_name APL ERROR" -icon warning -message [FM "TESTIT" "Failure to create $apl_name APL file!" $res] ]
    return "FALSE"
}


if { [lindex [split $res ","] 0] == "NO" } {
    return "TRUE"
}

set apl_file [lindex [split $res ","] 0]
set apl_path [file dir $apl_file]
set test_oi [lindex [split $res ","] 1]
set apl_format [lindex [split $res ","] 2]


#FD "apl_file : $apl_file"
#FD "apl_path : $apl_path"
#FD "test_oi : $test_oi"
#FD "apl_format : $apl_format"

if { [file exist $apl_path] != 1 } {
    if [catch {
        set tmp [file mkdir $apl_path]
    } err] {
        FD "$apl_name APL ERROR : Fail to create directory -> $apl_path ($err)"
        set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TESTIT" "Please, Check $apl_path authority to modify!" $res] ]
        return "FALSE"
    }     
}

### clear APL ##################
if { [file exist $apl_file] == 1 } {
    if [catch { 
        set delete_file [file delete $apl_file]
    } err] {
        FD "$apl_name APL ERROR : Failture to delete the previous $apl_file"
        set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TESTIT" "Please, Check $apl_file authority to delete!" $res] ]
        return "FALSE"
    }  
}

### clear Copied APL ##################
#set Linux_Account $tcl_platform(user)
set CopiedDirPath "/home/hst/Tester/APL/$g_hostname"
set CopiedFileFullPath "$CopiedDirPath/Lot_Info.txt"
if { [file exist $CopiedFileFullPath] == 1 } {
    if [catch { 
        set delete_file [file delete $CopiedFileFullPath]
    } err] {
        FD "$apl_name APL ERROR : Failture to delete the previous $CopiedFileFullPath"
        set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TESTIT" "Please, Check $CopiedFileFullPath authority to delete!" $res] ]
        return "FALSE"
    }  
}

if { $flag == "DELETE" } {
    return "TRUE"
}

### start writing APL parameters ###
if [catch {
    
    set apl_fd [open $apl_file w]
    
    set apl_contents ""
    
    for { set i 3 } { $i <= [llength [split $res ","]] } { incr i } {
           
        if { $apl_format == "COMMA" } {   
             if { $apl_contents != "" && $i != [llength [split $res ","]] } {
                set apl_contents [format "%s,%s" $apl_contents [lindex [split $res ","] $i] ]
            } else {
                set apl_contents [format "%s%s" $apl_contents [lindex [split $res ","] $i] ]
            }        
        } else {
            puts $apl_fd [string map {"|" ","} [lindex [split $res ","] $i]]
        }
                
    }
    
    if { $apl_contents != "" } {
        puts $apl_fd $apl_contents
    }
    
    close $apl_fd
      
    FD "$apl_name APL SUCCESS!"
    
    ### execute TEST OI
    if { $test_oi != "" } {
        if [catch { 
            set tmp [exec $test_oi &]
        } err] {
            FD "$apl_name APL ERROR : Failure to execute $test_oi ($err)"
            set delete_file [file delete $apl_file]
            set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TESTIT" "Failure to execute $test_oi!" $res] ]
            return "FALSE"
        }    
    }
    
} err ] {
    FD "$apl_name APL ERROR : $err"
    set delete_file [file delete $apl_file]
    return "FALSE"
}

if [catch {
    set temp [exec chmod 777 $apl_file]
} err ] {
    FD "FUNC_APL_AMD_HP93K : Fail to chmod $apl_file error : $err"
}



return "TRUE"
}
#############################################################################
## Procedure:  FUNC_APL_EVE_HP93K

proc ::FUNC_APL_EVE_HP93K {flag} {
global widget

global tcl_platform

#if { [string match -nocase "*Linux*" $tcl_platform(platform)] != 1 } { 
    #puts "This is windows platform"
#    return "TRUE"
#}

global g_hostname
global g_lotname
global g_dcc
global g_operation
global g_job
global g_customer
global g_testprogram
global g_testprogramrev
global g_devicename

global g_operatorid
global g_handler
global g_temperature
global g_boardno
global g_incount
global g_condition
global g_customer

set apl_name "EVE_HP93K"

set qry "SCOPS,APL_EVE_HP93K,$flag,$g_hostname,$g_lotname,$g_dcc,$g_operation,$g_job,$g_testprogram,$g_testprogramrev,$g_devicename,$g_incount,$g_operatorid,$g_condition,$g_customer*"

set res ""
set res [FUNC_SEND_QRY $qry]

if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
    set msg "UFLEX APL FAILURE"
    set choice [ tk_messageBox -title "$apl_name APL Error" -icon warning -message [FM "TESTIT" $msg $res] ]
    return "FALSE"
}


if { [lindex [split $res ","] 0] == "NO" } {

    return "TRUE"
}

set apl_file [lindex [split $res ","] 0]
set apl_path [file dir $apl_file]
set test_oi [lindex [split $res ","] 1]


if { [file exist $apl_path] != 1 } {
    if [catch {
        set tmp [file mkdir $apl_path]
    } err] {
        FD "FUNC_APL_$apl_name : can't create directory $apl_path"
        set choice [ tk_messageBox -title "FUNC_APL_$apl_name Error" -message "============================================\n\nContact : K3 Engineer, TESTIT\n\n============================================\n\nCan't delete the previous $apl_file\nCheck the file authority!!!" ]
        return "FALSE"
    }     
}


### clear APL ##################
if { [file exist $apl_file] == 1 } {
    if [catch { 
        set delete_file [file delete $apl_file]
    } err] {
        FD "FUNC_APL_$apl_name : can't delete $apl_file"
        set choice [ tk_messageBox -title "FUNC_APL_$apl_name Error" -message "============================================\n\nContact : K3 Engineer, TESTIT\n\n============================================\n\nCan't delete the previous $apl_file\nCheck the file authority!!!" ]
        return "FALSE"
    }  
}

if { $flag == "DELETE" } {
    return "TRUE"
}


### start writing APL parameters ###
if [catch {
    
    set apl_fd [open $apl_file w]
    
    #1.Test Program
    set apl_contents ""

    for { set i 2 } { $i <= [llength [split $res ","]] } { incr i } {
                   
        #if { $apl_contents != "" && $i != [llength [split $res ","]] } {
        #    set apl_contents [format "%s,%s" $apl_contents [lindex [split $res ","] $i] ]
        #} else {
        #    set apl_contents [format "%s%s" $apl_contents [lindex [split $res ","] $i] ]
        #}
        
        
        puts $apl_fd [lindex [split $res ","] $i]
    }
    
    #puts $apl_fd $apl_contents
    close $apl_fd
      
    FD "FUNC_APL_$apl_name writing success!"
    
    ### execute TEST OI
    if { $test_oi != "" } {
        set tmp [exec $test_oi &]
    }
    
} err ] {
    FD "FUNC_APL_$apl_name error : $err"
    set delete_file [file delete $apl_file]
    return "FALSE"
}

return "TRUE"
}
#############################################################################
## Procedure:  FUNC_APL_QCT_T2000

proc ::FUNC_APL_QCT_T2000 {flag} {
global widget

global tcl_platform

if { [string match -nocase "*window*" $tcl_platform(platform)] != 1 } { 
    #puts "This is windows platform"
    return "TRUE"
}


global g_hostname
global g_lotname
global g_dcc
global g_operation
global g_job
global g_customer
global g_devicename
global g_testprogram
global g_testprogramrev
global g_condition
global g_temperature
global g_incount
global g_operatorid
global g_handler
global g_board
global g_kit

global g_socketcount
global g_handlertype

set apl_name "T2000"

set qry "SCOPS,APL_QCT_T2000,$flag,$g_hostname,$g_lotname,$g_dcc,$g_operation,$g_job,$g_customer,$g_devicename,$g_testprogram,$g_testprogramrev,$g_condition,$g_temperature,$g_incount,$g_operatorid,$g_handler,$g_board,$g_kit,$g_socketcount,$g_handlertype*"

set res ""
set res [FUNC_SEND_QRY $qry]

if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
    set choice [ tk_messageBox -title "$apl_name APL ERROR" -icon warning -message [FM "TESTIT" "Failure to create $apl_name APL file!" $res] ]
    return "FALSE"
}


if { [lindex [split $res ","] 0] == "NO" } {
    return "TRUE"
}

set apl_file [lindex [split $res ","] 0]
set apl_path [file dir $apl_file]
set test_oi [lindex [split $res ","] 1]
set apl_format [lindex [split $res ","] 2]


#FD "apl_file : $apl_file"
#FD "apl_path : $apl_path"
#FD "test_oi : $test_oi"
#FD "apl_format : $apl_format"

if { [file exist $apl_path] != 1 } {
    if [catch {
        set tmp [file mkdir $apl_path]
    } err] {
        FD "$apl_name APL ERROR : Fail to create directory -> $apl_path ($err)"
        set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TESTIT" "Please, Check $apl_path authority to modify!" $res] ]
        return "FALSE"
    }     
}

### clear APL ##################
if { [file exist $apl_file] == 1 } {
    if [catch { 
        set delete_file [file delete $apl_file]
    } err] {
        FD "$apl_name APL ERROR : Failture to delete the previous $apl_file"
        set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TESTIT" "Please, Check $apl_file authority to delete!" $res] ]
        return "FALSE"
    }  
}


#if { $flag == "DELETE" } {
#    return "TRUE"
#}

### start writing APL parameters ###
if [catch {
    
    set apl_fd [open $apl_file w]
    
    set apl_contents ""
    
    for { set i 3 } { $i <= [llength [split $res ","]] } { incr i } {
           
        if { $apl_format == "COMMA" } {   
             if { $apl_contents != "" && $i != [llength [split $res ","]] } {
                set apl_contents [format "%s,%s" $apl_contents [lindex [split $res ","] $i] ]
            } else {
                set apl_contents [format "%s%s" $apl_contents [lindex [split $res ","] $i] ]
            }        
        } else {
            puts $apl_fd [lindex [split $res ","] $i]
        }
                
    }
    
    if { $apl_contents != "" } {
        puts $apl_fd $apl_contents
    }
    
    close $apl_fd
      
    FD "$apl_name APL SUCCESS!"
    
    ### execute TEST OI
    if { $test_oi != "" } {
        if [catch { 
            set tmp [exec $test_oi &]
        } err] {
            FD "$apl_name APL ERROR : Failure to execute $test_oi ($err)"
            set delete_file [file delete $apl_file]
            set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TESTIT" "Failure to execute $test_oi!" $res] ]
            return "FALSE"
        }    
    }
    
} err ] {
    FD "$apl_name APL ERROR : $err"
    set delete_file [file delete $apl_file]
    return "FALSE"
}

return "TRUE"
}
#############################################################################
## Procedure:  FUNC_APL_STS_QCT

proc ::FUNC_APL_STS_QCT {flag filetype} {
global widget

global tcl_platform

if { [string match -nocase "*window*" $tcl_platform(platform)] != 1 } { 
    #puts "This is windows platform"
    return "TRUE"
}

global g_hostname
global g_lotname
global g_dcc
global g_operation
global g_job
global g_customer
global g_devicename
global g_testprogram
global g_testprogramrev
global g_condition
global g_temperature
global g_incount
global g_operatorid
global g_handler
global g_board
global g_kit
global g_probe

global g_socketcount
global g_handlertype

set apl_name "STS_QCT"

set qry "SCOPS,APL_STS_QCT,$flag,$g_hostname,$g_lotname,$g_dcc,$g_operation,$g_job,$g_customer,$g_devicename,$g_testprogram,$g_testprogramrev,$g_condition,$g_temperature,$g_incount,$g_operatorid,$g_handler,$g_board,$g_kit,$g_probe,$filetype*"

set res ""
set res [FUNC_SEND_QRY $qry]

if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
    set choice [ tk_messageBox -title "$apl_name APL ERROR" -icon warning -message [FM "TESTIT" "Failure to create $apl_name APL file!" $res] ]
    return "FALSE"
}


if { [lindex [split $res ","] 0] == "NO" } {
    return "TRUE"
}

set apl_file [lindex [split $res ","] 0]
set apl_file1 [lindex [split $apl_file ";"] 0]
set apl_file2 [lindex [split $apl_file ";"] 1]
set apl_path1 [file dir $apl_file1]
set apl_path2 [file dir $apl_file2]
set test_oi [lindex [split $res ","] 1]
set apl_format [lindex [split $res ","] 2]


#FD "apl_file : $apl_file"
#FD "apl_path : $apl_path"
#FD "test_oi : $test_oi"
#FD "apl_format : $apl_format"

if { [file exist $apl_path1] != 1 } {
    if [catch {
        set tmp [file mkdir $apl_path1]
    } err] {
        FD "$apl_name APL ERROR : Fail to create directory -> $apl_path1 ($err)"
        set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TESTIT" "Please, Check $apl_path1 authority to modify!" $res] ]
        return "FALSE"
    }     
}

if { [file exist $apl_path2] != 1 } {
    if [catch {
        set tmp [file mkdir $apl_path2]
    } err] {
        FD "$apl_name APL ERROR : Fail to create directory -> $apl_path2 ($err)"
        set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TESTIT" "Please, Check $apl_path2 authority to modify!" $res] ]
        return "FALSE"
    }     
}

### clear APL ##################
if { [file exist $apl_file1] == 1 } {
    if [catch { 
        set delete_file [file delete $apl_file1]
    } err] {
        FD "$apl_name APL ERROR : Failture to delete the previous $apl_file1"
        set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TESTIT" "Please, Check $apl_file1 authority to delete!" $res] ]
        return "FALSE"
    }  
}


if { [file exist $apl_file2] == 1 } {
    if [catch { 
        set delete_file [file delete $apl_file2]
    } err] {
        FD "$apl_name APL ERROR : Failture to delete the previous $apl_file2"
        set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TESTIT" "Please, Check $apl_file2 authority to delete!" $res] ]
        return "FALSE"
    }  
}


if { $flag == "DELETE" } {
    return "TRUE"
}


### create the first APL
if { $apl_file1 != "" } {
	if [catch {
	    
		set apl_fd [open $apl_file1 w]
	    
		set apl_contents ""
	    
		for { set i 3 } { $i <= [llength [split $res ","]] } { incr i } {
	           
			if { $apl_format == "COMMA" } {   
				 if { $apl_contents != "" && $i != [llength [split $res ","]] } {
					set apl_contents [format "%s,%s" $apl_contents [lindex [split $res ","] $i] ]
				} else {
					set apl_contents [format "%s%s" $apl_contents [lindex [split $res ","] $i] ]
				}        
			} else {
				puts $apl_fd [string map {"|" ","} [lindex [split $res ","] $i]]
			}
	                
		}
	    
		if { $apl_contents != "" } {
			puts $apl_fd [string map {"|" ","} $apl_contents]
		}
	    
		close $apl_fd
	      
		FD "$apl_name APL SUCCESS!"
	    
		### execute TEST OI
		if { $test_oi != "" } {
			if [catch { 
				set tmp [exec $test_oi &]
			} err] {
				FD "$apl_name APL ERROR : Failure to execute $test_oi ($err)"
				set delete_file [file delete $apl_file]
				set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TESTIT" "Failure to execute $test_oi!" $res] ]
				return "FALSE"
			}    
		}
	    
	} err ] {
		FD "$apl_name APL ERROR : $err"
		set delete_file [file delete $apl_file1]
		return "FALSE"
	}
}


if { $apl_file2 != "" } {
	if [catch {
	    
		set apl_fd [open $apl_file2 w]
	    
		set apl_contents ""
	    
		for { set i 3 } { $i <= [llength [split $res ","]] } { incr i } {
	           
			if { $apl_format == "COMMA" } {   
				 if { $apl_contents != "" && $i != [llength [split $res ","]] } {
					set apl_contents [format "%s,%s" $apl_contents [lindex [split $res ","] $i] ]
				} else {
					set apl_contents [format "%s%s" $apl_contents [lindex [split $res ","] $i] ]
				}        
			} else {
				puts $apl_fd [lindex [split $res ","] $i]
			}
	                
		}
	    
		if { $apl_contents != "" } {
			puts $apl_fd $apl_contents
		}
	    
		close $apl_fd
	      
		FD "$apl_name APL SUCCESS!"
	    
		### execute TEST OI
		if { $test_oi != "" } {
			if [catch { 
				set tmp [exec $test_oi &]
			} err] {
				FD "$apl_name APL ERROR : Failure to execute $test_oi ($err)"
				set delete_file [file delete $apl_file]
				set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TESTIT" "Failure to execute $test_oi!" $res] ]
				return "FALSE"
			}    
		}
	    
	} err ] {
		FD "$apl_name APL ERROR : $err"
		set delete_file [file delete $apl_file2]
		return "FALSE"
	}
}

return "TRUE"
}
#############################################################################
## Procedure:  FUNC_APL_HP93K_NXP_MULTI_DEV

proc ::FUNC_APL_HP93K_NXP_MULTI_DEV {flag} {
global widget

global tcl_platform

#if { [string match -nocase "*window*" $tcl_platform(platform)] == 1 } { 
    #puts "This is Linux platform"
#    return "TRUE"
#}

global g_hostname
global g_lotname
global g_dcc
global g_operation
global g_job
global g_customer
global g_devicename
global g_testprogram
global g_testprogramrev
global g_condition
global g_temperature
global g_incount
global g_operatorid
global g_handler
global g_board
global g_kit

global g_socketcount
global g_handlertype

set apl_name "HP93K_NXP_MULTI_DEV"

set qry "SCOPS,APL_HP93K_NXP_MULTI_DEV,$flag,$g_hostname,$g_lotname,$g_dcc,$g_operation,$g_job,$g_customer,$g_devicename,$g_testprogram,$g_testprogramrev,$g_condition,$g_temperature,$g_incount,$g_operatorid,$g_handler,$g_board,$g_kit,$g_socketcount,$g_handlertype*"

set res ""
set res [FUNC_SEND_QRY $qry]

if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
    set choice [ tk_messageBox -title "$apl_name APL ERROR" -icon warning -message [FM "TESTIT" "Failure to create $apl_name APL file!" $res] ]
    return "FALSE"
}


if { [lindex [split $res ","] 0] == "NO" } {
    return "TRUE"
}

set apl_file [lindex [split $res ","] 0]
set apl_path [file dir $apl_file]
set apl_backup_path "$apl_path/BAK"
set test_oi [lindex [split $res ","] 1]
set apl_format [lindex [split $res ","] 2]

set backup_file2 "$apl_path/.tmpInfo"

#FD "apl_file : $apl_file"
#FD "apl_path : $apl_path"
#FD "apl_backup_path: $apl_backup_path"
#FD "test_oi : $test_oi"
#FD "apl_format : $apl_format"

if { [file exist $apl_backup_path] != 1 } {
    if [catch {
        set tmp [file mkdir $apl_backup_path]
    } err] {
        #FD "$apl_name APL ERROR : Fail to create BAK directory -> $apl_backup_path ($err)"
        set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TESTIT" "Please, Check $apl_path authority to modify!" $res] ]
        return "FALSE"
    }     
}

if { [file exist $apl_file] == 1 } {
    #Copy Org File
    set time_t [clock format [clock seconds] -format "%Y%m%d_%H%M%S"]
    set backup_file "$apl_backup_path/philips.info_$time_t"
    if [catch {
        set copy_file [ file copy -force $apl_file $backup_file ]
    } err ] {    
        set choice [ tk_messageBox -title "$apl_name APL ERROR : Fail to Copy" -message [FM "K3 Engineer, TESTIT" "Please, Check $backup_file authority to modify!" $res] ]
        FD "Return False"
        return "FALSE"
    }
    if [catch {
        set temp [exec chmod 777 $backup_file]
    } err ] {
        #set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TESTIT" "Please, Check $apl_path authority to modify!" $res] ]
    }

    #Copy Org File
    if { [file exist $backup_file2] == 1 } {
        if [catch { 
            set delete_file [file delete $backup_file2]
        } err] {
            #FD "$apl_name APL ERROR : Fail to delete the previous $apl_file"
            set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TESTIT" "Please, Check $backup_file2 authority to delete!" $res] ]
            return "FALSE"
        }  
    }
    if [catch {
        set copy_file [ file copy -force $apl_file $backup_file2 ]
    } err ] {    
        set choice [ tk_messageBox -title "$apl_name APL ERROR : Fail to Copy" -message [FM "K3 Engineer, TESTIT" "Please, Check $backup_file2 authority to modify!" $res] ]
        FD "Return False"
        return "FALSE"
    }
    if [catch {
        set temp [exec chmod 777 $backup_file2]
    } err ] {
        #set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TESTIT" "Please, Check $apl_path authority to modify!" $res] ]
    }
    
    if [catch { 
        set delete_file [file delete $apl_file]
    } err] {
        #FD "$apl_name APL ERROR : Fail to delete the previous $apl_file"
        set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TESTIT" "Please, Check $apl_file authority to delete!" $res] ]
        return "FALSE"
    } 
}

### start writing APL parameters ###
array set arrVal {}     
if [catch {    
    set apl_contents ""
    
    for { set i 3 } { $i <= [llength [split $res ","]] } { incr i } {
           
        if { $apl_format == "COMMA" } {   
             if { $apl_contents != "" && $i != [llength [split $res ","]] } {
                set apl_contents [format "%s,%s" $apl_contents [lindex [split $res ","] $i] ]
            } else {
                set apl_contents [format "%s%s" $apl_contents [lindex [split $res ","] $i] ]
            }        
        } else {
            set splited_apl_contents [lindex [split $res ","] $i]
            if { $splited_apl_contents != "" } {
                set catgry [lindex [split $splited_apl_contents ":"] 0]
                set value [lindex [split $splited_apl_contents ":"] 1]
                set arrVal($catgry) $value
            }
        }      
    }
    
    ### execute TEST OI
    if { $test_oi != "" } {
        if [catch { 
            set tmp [exec $test_oi &]
        } err] {
            FD "$apl_name APL ERROR : Failure to execute $test_oi ($err)"
            set delete_file [file delete $apl_file]
            set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TESTIT" "Failure to execute $test_oi!" $res] ]
            return "FALSE"
        }    
    }
    
} err ] {
    FD "$apl_name APL ERROR : $err"
    #set delete_file [file delete $apl_file]
    return "FALSE"
}


#Copy Contents and write APL info 
if { $apl_file != "" } {
    if [catch {
        set apl_fd [open $apl_file w]
        
        #Get Backup file's Contents
        if [ catch { set fileID [open $backup_file2 r] } ] {
            #FD "$apl_name APL ERROR : Failture to delete the previous $backup_file"
            set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TESTIT" "Fail to Read $backup_file2!" $res] ]
            return "FALSE"
        } else {
            while { [gets $fileID line] >= 0 } {
                
                set tmp_line $line
                foreach key [array names arrVal] {
                    if { [string match -nocase "$key*" $tmp_line] == 1 } {
                        set tmp_line ""
                        set tmp_line "$key:$arrVal($key)"
                    }
                }
                
                puts $apl_fd $tmp_line
            }
            close $fileID
        }        
        
        close $apl_fd
    } err ] {
        #FD "$apl_name APL ERROR : $err"
        set delete_file [file delete $apl_file]
        set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TESTIT" "Fail to Write $apl_file!" $res] ]
        return "FALSE"
    }
}


FD "$apl_name APL SUCCESS!"
return "TRUE"
}
#############################################################################
## Procedure:  FUNC_APL_MTK_UFLEX

proc ::FUNC_APL_MTK_UFLEX {flag} {
global widget


global tcl_platform

if { [string match -nocase "*window*" $tcl_platform(platform)] != 1 } { 
    #puts "This is windows platform"
    return "TRUE"
}


global g_hostname
global g_lotname
global g_dcc
global g_operation
global g_job
global g_customer
global g_testprogram
global g_testprogramrev
global g_devicename
global g_operatorid
global g_handler
global g_temperature
global g_boardno
global g_incount
global g_condition
global g_customer

set apl_name "MTK_UFLEX"

set qry "SCOPS,APL_MTK_UFLEX,$flag,$g_hostname,$g_lotname,$g_dcc,$g_operation,$g_job,$g_testprogram,$g_testprogramrev,$g_devicename,$g_incount,$g_operatorid,$g_condition,$g_customer*"

set res ""
set res [FUNC_SEND_QRY $qry]

if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
    set msg "UFLEX APL FAILURE"
    set choice [ tk_messageBox -title "$apl_name APL Error" -icon warning -message [FM "TESTIT" $msg $res] ]
    return "FALSE"
}


if { [lindex [split $res ","] 0] == "NO" } {

    return "TRUE"
}

set apl_file [lindex [split $res ","] 0]
set apl_path [file dir $apl_file]
set test_oi [lindex [split $res ","] 1]


if { [file exist $apl_path] != 1 } {
    if [catch {
        set tmp [file mkdir $apl_path]
    } err] {
        FD "FUNC_APL_$apl_name : can't create directory $apl_path"
        set choice [ tk_messageBox -title "FUNC_APL_$apl_name Error" -message "============================================\n\nContact : K3 Engineer, TESTIT\n\n============================================\n\nCan't delete the previous $apl_file\nCheck the file authority!!!" ]
        return "FALSE"
    }     
}


### clear APL ##################
if { [file exist $apl_file] == 1 } {
    if [catch { 
        set delete_file [file delete $apl_file]
    } err] {
        FD "FUNC_APL_$apl_name : can't delete $apl_file"
        set choice [ tk_messageBox -title "FUNC_APL_$apl_name Error" -message "============================================\n\nContact : K3 Engineer, TESTIT\n\n============================================\n\nCan't delete the previous $apl_file\nCheck the file authority!!!" ]
        return "FALSE"
    }  
}

if { $flag == "DELETE" } {
    return "TRUE"
}


### start writing APL parameters ###
if [catch {
    
    set apl_fd [open $apl_file w]
    
    #1.Test Program
    set apl_contents ""

    for { set i 2 } { $i <= [llength [split $res ","]] } { incr i } {
                   
        #if { $apl_contents != "" && $i != [llength [split $res ","]] } {
        #    set apl_contents [format "%s,%s" $apl_contents [lindex [split $res ","] $i] ]
        #} else {
        #    set apl_contents [format "%s%s" $apl_contents [lindex [split $res ","] $i] ]
        #}
        
        
        puts $apl_fd [lindex [split $res ","] $i]
    }
    
    #puts $apl_fd $apl_contents
    close $apl_fd
      
    FD "FUNC_APL_$apl_name writing success!"
    
    ### execute TEST OI
    if { $test_oi != "" } {
        set tmp [exec $test_oi &]
    }
    
} err ] {
    FD "FUNC_APL_$apl_name error : $err"
    set delete_file [file delete $apl_file]
    return "FALSE"
}

return "TRUE"
}
#############################################################################
## Procedure:  FUNC_APL_EXECUTE_SP

proc ::FUNC_APL_EXECUTE_SP {flag} {
global widget

global tcl_platform

global g_hostname
global g_lotname
global g_dcc
global g_operation
global g_job
global g_customer
global g_devicename
global g_testprogram
global g_testprogramrev
global g_condition
global g_temperature
global g_incount
global g_operatorid
global g_handler
global g_board
global g_kit
global g_probe

global g_socketcount
global g_handlertype

set apl_name "EXECUTE_APL"

set qry "SCOPS,EXECUTE_APL,$flag,$g_hostname,$g_lotname,$g_dcc,$g_operation,$g_job,$g_customer,$g_devicename,$g_testprogram,$g_testprogramrev,$g_condition,$g_temperature,$g_incount,$g_operatorid,$g_handler,$g_board,$g_kit,$g_socketcount,$g_handlertype*"

set res ""
set res [FUNC_SEND_QRY $qry]

if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
    set choice [ tk_messageBox -title "$apl_name APL ERROR" -icon warning -message [FM "TFA" "Failure to create $apl_name APL file!" $res] ]
    return "FALSE"
}


if { [lindex [split $res ","] 0] == "NO" } {
    return "TRUE"
}

set apl_file [lindex [split $res ","] 0]
set apl_path [file dir $apl_file]
set test_oi [lindex [split $res ","] 1]
set apl_format [lindex [split $res ","] 2]


#FD "apl_file : $apl_file"
#FD "apl_path : $apl_path"
#FD "test_oi : $test_oi"
#FD "apl_format : $apl_format"

if { [file exist $apl_path] != 1 } {
    if [catch {
        set tmp [file mkdir $apl_path]
    } err] {
        FD "$apl_name APL ERROR : Fail to create directory -> $apl_path ($err)"
        set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TFA" "Please, Check $apl_path authority to modify!" $res] ]
        return "FALSE"
    }     
}

### clear APL ##################
if { [file exist $apl_file] == 1 } {
    if [catch { 
        set delete_file [file delete $apl_file]
    } err] {
        FD "$apl_name APL ERROR : Failture to delete the previous $apl_file"
        set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TFA" "Please, Check $apl_file authority to delete!" $res] ]
        return "FALSE"
    }  
}


if { $flag == $apl_format } {
    return "TRUE"
}


### start writing APL parameters ###
if [catch {
    
    set apl_fd [open $apl_file w]
    
    set apl_contents ""
    
    for { set i 3 } { $i <= [llength [split $res ","]] } { incr i } {
           
        if { $apl_format == "COMMA" } {   
             if { $apl_contents != "" && $i != [llength [split $res ","]] } {
                set apl_contents [format "%s,%s" $apl_contents [lindex [split $res ","] $i] ]
            } else {
                set apl_contents [format "%s%s" $apl_contents [lindex [split $res ","] $i] ]
            }        
        } else {
            puts $apl_fd [lindex [split $res ","] $i]
        }
                
    }
    
    if { $apl_contents != "" } {
        puts $apl_fd $apl_contents
    }
    
    close $apl_fd
      
    FD "$apl_name APL SUCCESS!"
    
    ### execute TEST OI
    if { $test_oi != "" } {
        if [catch { 
            set tmp [exec $test_oi &]
        } err] {
            FD "$apl_name APL ERROR : Failure to execute $test_oi ($err)"
            set delete_file [file delete $apl_file]
            set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TFA" "Failure to execute $test_oi!" $res] ]
            return "FALSE"
        }    
    }
    
} err ] {
    FD "$apl_name APL ERROR : $err"
    set delete_file [file delete $apl_file]
    return "FALSE"
}

return "TRUE"
}
#############################################################################
## Procedure:  FUNC_CHECK_QUALTESTER

proc ::FUNC_CHECK_QUALTESTER {} {
global widget
global tcl_platform

global g_hostname
global g_lotname
global g_dcc
global g_operation
global g_devicename
global g_customer


#Real Service qry
set qry "SCOPS,CheckQualTester,$g_hostname,$g_lotname,$g_dcc,$g_operation,$g_devicename,$g_customer*"  
#set qry "SCOPS,CheckQualTester,AM7S01,K07-027374,,PROBE,T12880FRB-K017,QORVO US*"  

set res ""
set res [FUNC_SEND_QRY $qry]
set qualResult [lindex [split $res ","] 1]

if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
    set choice [ tk_messageBox -title "QUAL TESTER CHECK ERROR" -icon warning -message [FM "TESTIT" "" $res] ]
    return "FALSE"
}

if { [lindex [split $res ","] 0] == "NO" } {
    if { [string match -nocase "*NO NEED - Tester*" $res] == 1 } {
         return "TRUE"
    } else {
        set choice [ tk_messageBox -title "Qual Tester Fail" -icon error -message "This tester is not a Qual Tester!!\n\n$qualResult\n\nPlease, contact K3 PCS and Engineer."]  
        return "FALSE"
    }
   
}

#set qualResult [lindex [split $res ","] 1]

FD "QUAL TESTER RESULT : $qualResult" 
return "TRUE"
}
#############################################################################
## Procedure:  FUNC_APL_EXECUTE_SP_SUB

proc ::FUNC_APL_EXECUTE_SP_SUB {flag} {
global widget

global tcl_platform

global g_hostname
global g_lotname
global g_dcc
global g_operation
global g_job
global g_customer
global g_devicename
global g_testprogram
global g_testprogramrev
global g_condition
global g_temperature
global g_incount
global g_operatorid
global g_handler
global g_board
global g_kit
global g_probe

global g_socketcount
global g_handlertype

set apl_name "EXECUTE_APL_SUB"

set qry "SCOPS,EXECUTE_APL_SUB,$flag,$g_hostname,$g_lotname,$g_dcc,$g_operation,$g_job,$g_customer,$g_devicename,$g_testprogram,$g_testprogramrev,$g_condition,$g_temperature,$g_incount,$g_operatorid,$g_handler,$g_board,$g_kit,$g_socketcount,$g_handlertype*"

set res ""
set res [FUNC_SEND_QRY $qry]

if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
    set choice [ tk_messageBox -title "$apl_name APL ERROR" -icon warning -message [FM "TFA" "Failure to create $apl_name APL file!" $res] ]
    return "FALSE"
}


if { [lindex [split $res ","] 0] == "NO" } {
    return "TRUE"
}

set apl_file [lindex [split $res ","] 0]
set apl_path [file dir $apl_file]
set test_oi [lindex [split $res ","] 1]
set apl_format [lindex [split $res ","] 2]


#FD "apl_file : $apl_file"
#FD "apl_path : $apl_path"
#FD "test_oi : $test_oi"
#FD "apl_format : $apl_format"

if { [file exist $apl_path] != 1 } {
    if [catch {
        set tmp [file mkdir $apl_path]
    } err] {
        FD "$apl_name APL ERROR : Fail to create directory -> $apl_path ($err)"
        set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TFA" "Please, Check $apl_path authority to modify!" $res] ]
        return "FALSE"
    }     
}

### clear APL ##################
if { [file exist $apl_file] == 1 } {
    if [catch { 
        set delete_file [file delete $apl_file]
    } err] {
        FD "$apl_name APL ERROR : Failture to delete the previous $apl_file"
        set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TFA" "Please, Check $apl_file authority to delete!" $res] ]
        return "FALSE"
    }  
}


if { $flag == $apl_format } {
    return "TRUE"
}


### start writing APL parameters ###
if [catch {
    
    set apl_fd [open $apl_file w]
    
    set apl_contents ""
    
    for { set i 3 } { $i <= [llength [split $res ","]] } { incr i } {
           
        if { $apl_format == "COMMA" } {   
             if { $apl_contents != "" && $i != [llength [split $res ","]] } {
                set apl_contents [format "%s,%s" $apl_contents [lindex [split $res ","] $i] ]
            } else {
                set apl_contents [format "%s%s" $apl_contents [lindex [split $res ","] $i] ]
            }        
        } else {
            puts $apl_fd [lindex [split $res ","] $i]
        }
                
    }
    
    if { $apl_contents != "" } {
        puts $apl_fd $apl_contents
    }
    
    close $apl_fd
      
    FD "$apl_name APL SUCCESS!"
    
    ### execute TEST OI
    if { $test_oi != "" } {
        if [catch { 
            set tmp [exec $test_oi &]
        } err] {
            FD "$apl_name APL ERROR : Failure to execute $test_oi ($err)"
            set delete_file [file delete $apl_file]
            set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TFA" "Failure to execute $test_oi!" $res] ]
            return "FALSE"
        }    
    }
    
} err ] {
    FD "$apl_name APL ERROR : $err"
    set delete_file [file delete $apl_file]
    return "FALSE"
}

return "TRUE"
}
#############################################################################
## Procedure:  FUNC_CHECK_RETEST_HISTORY

proc ::FUNC_CHECK_RETEST_HISTORY {} {
global widget

global g_hostname
global g_lotname
global g_dcc
global g_operation
global g_job
global g_operatorid

set qry "SCOPS,CheckReTestHistory,$g_hostname,$g_lotname,$g_dcc,$g_operation,$g_job,CHECK*"

set res ""
set res [FUNC_SEND_QRY $qry]

if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
    set choice [ tk_messageBox -title "ReTest History Check Error" -type yesno -icon warning -message $res]
    
    if { $choice == "yes" } {
        return "TRUE"
    } else {
        return "FALSE"
    }
}

if { [lindex [split $res ","] 0] == "NO" } {
    set msg ""
    set choice [ tk_messageBox -title "ReTest History Check Error" -type yesno -icon warning -message [FM "K3 engineer" $msg $res] ]
    
    if { $choice == "yes" } {
        return "TRUE"
    } else {
        return "FALSE"
    }
}

if { [lindex [split $res ","] 0] == "BLOCK" } {
    set msg ""
    set choice [ tk_messageBox -title "ReTest History Check Error" -icon error -message [FM "K3 engineer" $msg $res] ]
    return "FALSE"
}

return "TRUE"
}
#############################################################################
## Procedure:  FUNC_APL_HP_SMT8_COPY

proc ::FUNC_APL_HP_SMT8_COPY {flag} {
global widget

global tcl_platform

if { [string match -nocase "*window*" $tcl_platform(platform)] == 1 } { 
    #puts "This is windows platform"
    return "TRUE"
}

global g_hostname
global g_lotname
global g_dcc
global g_operation
global g_job
global g_customer
global g_devicename
global g_testprogram
global g_testprogramrev
global g_condition
global g_temperature
global g_incount
global g_operatorid
global g_handler
global g_board
global g_kit
global g_probe

global g_socketcount
global g_handlertype

set apl_name "EXECUTE_APL_HP_SMT8_COPY"
set win_title "warning_hpapl"
set config "$win_title"
set file_name "image,scops_warning_program.gif"

#FD "$apl_name APL ERROR : Fail to create directory -> $apl_path ($err)"

set recipeFrom "/home/LIB/RECIPE/$g_testprogram"
#set home "$env(HOME)"
set home [ exec "/usr/local1/APL/pgm/GetDefaultPath" ]
#set home "/home/test/PROD/qct"
set recipeTo "$home/Recipe/$g_testprogram"
set deleteFiles "$home/Recipe"

#Delete all files
if [catch {
    eval file delete [glob -nocomplain $deleteFiles/*]
} err ] {
    #FD "File Delete Error" "Copy_LotInfo: $err"
}

#Check Recipe File
if { [file exist $recipeFrom] != 1 } {
#    FUNC_DISPLAY_MESSAGE "open" $config $recipeFrom [FM "K3 Engineer, Manager" "THERE' NO $recipeFrom FILE!" ""]
    tk_messageBox -title "APL Error!!"  -message "THERE' NO $recipeFrom FILE!" -icon error
#    FUNC_DISPLAY_MESSAGE "close" "$win_title" "" ""
    return "FALSE"    
}

#Copy Org File
if [catch {
    set copy_file [ file copy -force $recipeFrom $recipeTo ]
    FD "$apl_name: Copying $recipeTo is success!"
} err ] {
#    FUNC_DISPLAY_MESSAGE "open" $config $recipeFrom [FM "K3 Engineer, Manager" "THERE' Fail to Copy $recipeFrom FILE!" ""]
    tk_messageBox -title "APL Error!!"  -message "Fail to Copy $recipeFrom FILE!" -icon error
#    FUNC_DISPLAY_MESSAGE "close" "$win_title" "" ""
    return "FALSE" 
}



return "TRUE"
}
#############################################################################
## Procedure:  FUNC_APL_HP_SMT8_MAKE

proc ::FUNC_APL_HP_SMT8_MAKE {flag} {
global widget

global tcl_platform

global g_hostname
global g_lotname
global g_dcc
global g_operation
global g_job
global g_customer
global g_devicename
global g_testprogram
global g_testprogramrev
global g_condition
global g_temperature
global g_incount
global g_operatorid
global g_handler
global g_board
global g_kit
global g_probe

global g_socketcount
global g_handlertype

set apl_name "EXECUTE_APL_HP_SMT8_MAKE"

set qry "SCOPS,APL_HP93K_SMT8,$flag,$g_hostname,$g_lotname,$g_dcc,$g_operation,$g_job,$g_customer,$g_devicename,$g_testprogram,$g_testprogramrev,$g_condition,$g_temperature,$g_incount,$g_operatorid,$g_handler,$g_board,$g_kit,$g_socketcount,$g_handlertype*"

set res ""
set res [FUNC_SEND_QRY $qry]

if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
    set choice [ tk_messageBox -title "$apl_name APL ERROR" -icon warning -message [FM "TFA" "Failure to create $apl_name APL file!" $res] ]
    return "FALSE"
}


if { [lindex [split $res ","] 0] == "NO" } {
    return "TRUE"
}

set apl_file [lindex [split $res ","] 0]
set apl_path [file dir $apl_file]
set test_oi [lindex [split $res ","] 1]
set apl_format [lindex [split $res ","] 2]


#FD "apl_file : $apl_file"
#FD "apl_path : $apl_path"
#FD "test_oi : $test_oi"
#FD "apl_format : $apl_format"

if { [file exist $apl_path] != 1 } {
    if [catch {
        set tmp [file mkdir $apl_path]
    } err] {
        FD "$apl_name APL ERROR : Fail to create directory -> $apl_path ($err)"
        set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TFA" "Please, Check $apl_path authority to modify!" $res] ]
        return "FALSE"
    }     
}

### clear APL ##################
if { [file exist $apl_file] == 1 } {
    if [catch { 
        set delete_file [file delete $apl_file]
    } err] {
        FD "$apl_name APL ERROR : Failture to delete the previous $apl_file"
        set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TFA" "Please, Check $apl_file authority to delete!" $res] ]
        return "FALSE"
    }  
}


if { $flag == $apl_format } {
    return "TRUE"
}


### start writing APL parameters ###
if [catch {
    
    set apl_fd [open $apl_file w]
    
    set apl_contents ""
    
    for { set i 3 } { $i <= [llength [split $res ","]] } { incr i } {
           
        if { $apl_format == "COMMA" } {   
             if { $apl_contents != "" && $i != [llength [split $res ","]] } {
                set apl_contents [format "%s,%s" $apl_contents [lindex [split $res ","] $i] ]
            } else {
                set apl_contents [format "%s%s" $apl_contents [lindex [split $res ","] $i] ]
            }        
        } else {
            puts $apl_fd [lindex [split $res ","] $i]
        }
                
    }
    
    if { $apl_contents != "" } {
        puts $apl_fd $apl_contents
    }
    
    close $apl_fd
      
    FD "$apl_name APL SUCCESS!"
    
    ### execute TEST OI
    if { $test_oi != "" } {
        if [catch { 
            set tmp [exec $test_oi &]
        } err] {
            FD "$apl_name APL ERROR : Failure to execute $test_oi ($err)"
            set delete_file [file delete $apl_file]
            set choice [ tk_messageBox -title "$apl_name APL ERROR" -message [FM "K3 Engineer, TFA" "Failure to execute $test_oi!" $res] ]
            return "FALSE"
        }    
    }
    
} err ] {
    FD "$apl_name APL ERROR : $err"
    set delete_file [file delete $apl_file]
    return "FALSE"
}

return "TRUE"
}
#############################################################################
## Procedure:  FUNC_RFID_LOTCHECK

proc ::FUNC_RFID_LOTCHECK {} {
global widget
global g_lotname
global g_hostname

set qry "SCOPS,ReadRFID,$g_hostname*"

set res ""
set res [FUNC_SEND_QRY $qry]


if { [lindex [split $res ","] 0] == "FAIL" } {
    #set choice [ tk_messageBox -title "Read RFID Error" -icon warning -message "$res    "]
    return "FALSE"
}

set rfidlotname ""
set rfidlotname [string toupper [lindex [split $res ","] 0]]
#puts "lotname : $rfidlotname"

if { $rfidlotname == "" } {
     
    set win_title "scops_warning_lot"
    FUNC_DISPLAY_MESSAGE "close" "$win_title" "" ""
    FUNC_DISPLAY_MESSAGE "open" "$win_title" "image,scops_warning_lot.gif" "RFID and Input Lot Number are different!"
    
    set choice [ tk_messageBox -type yesno -title "Check RFID Lot Error" -icon warning -message "There's no RFID information!!\n\nDo you want to work Scops Lot continuously?\n\n-Smartconsole : $rfidlotname\n\n-Scops : $g_lotname" ]
    if { $choice == "yes" } {
        FUNC_DISPLAY_MESSAGE "close" "$win_title" "" ""
        return "TRUE"
    } else {
        FUNC_DISPLAY_MESSAGE "close" "$win_title" "" ""
        return "FALSE"
    }   
} elseif { $rfidlotname != $g_lotname } {
   
    set win_title "scops_warning_lot"
    FUNC_DISPLAY_MESSAGE "close" "$win_title" "" ""
    FUNC_DISPLAY_MESSAGE "open" "$win_title" "image,scops_warning_lot.gif" "RFID and Input Lot Number are different!"
   
    set choice [ tk_messageBox -type yesno -title "Check RFID Lot Error" -icon warning -message "RFID Lot and Search Lot is different!!\n\nDo you want to work Scops Lot continuously?\n\n-Smartconsole : $rfidlotname\n\n-Scops : $g_lotname" ]
    if { $choice == "yes" } {
        FUNC_DISPLAY_MESSAGE "close" "$win_title" "" ""
        return "TRUE"
    } else {
        FUNC_DISPLAY_MESSAGE "close" "$win_title" "" ""
        return "FALSE"
    }
  
            
} else {
    return "TRUE"

}
}
#############################################################################
## Procedure:  FUNC_CHECK_SOCKETCORRELATION

proc ::FUNC_CHECK_SOCKETCORRELATION {} {
global widget

global g_hostname
global g_socketlist 

set qry "SCOPS,CALLSP2,CheckSocketCorrelation,$g_hostname,$g_socketlist*"

set res ""
set res [FUNC_SEND_QRY $qry]


if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
    set choice [ tk_messageBox -title "Socket Correlation Check Error" -icon warning -message [FM "TESTIT" "Fail to Check Socket Correlation." $res] ]
    return "TRUE"
}

if { [lindex [split $res ","] 0] == "NO" } {
    set choice [ tk_messageBox -title "Socket Correlation Check Error" -icon error -message [FM "K3 Engineer, HCC" "Fail to Check Socket Correlation." $res] ]
    return "FALSE"
}

return "TRUE"
}
#############################################################################
## Procedure:  FUNC_RFID_CHECK_CORETOUCHDOWN

proc ::FUNC_RFID_CHECK_CORETOUCHDOWN {} {
global widget

global g_operation 

if { [string match -nocase "*PROB*" $g_operation] == 0 } { 
    #FD "This is not PROB
   return "TRUE"
}

global g_testing_flag
global g_rfid_flag

if { $g_rfid_flag != "TRUE"  } { return }

set core_msg "Core : Touch cnt. : Limit cnt.       \n"
set core_touchdown_flag "FALSE"

global g_coresitenumber
for { set i 1 } { $i<=$g_coresitenumber } { incr i } {
    
    global g_core_check$i
    global g_core$i
    global g_core_touch$i
    global g_core_limit$i
    global g_core_ext$i
    
#FD "g_core1 : $g_core1 / g_core_touch1 : $g_core_touch1 / g_core_limit1 : $g_core_limit1"             
                    
                                                       
    set core_touch [subst $[format "g_core_touch%d" $i]]
    set core_limit [subst $[format "g_core_limit%d" $i]]
    
    #FD "core_touch : $core_touch / core_limit : $core_limit" 
      
    if { $core_touch != "" && $core_limit != "" } {
        set core_prealert_limit [ expr int($core_limit * 0.8) ]
        
        if { $core_touch > $core_limit } {
        
            set core_touchdown_flag "TRUE"
            
            #message
            set core_msg "$core_msg\n[subst $[format "g_core%d" $i]] : [subst $[format "g_core_touch%d" $i]] : [subst $[format "g_core_limit%d" $i]]      -      limit over!"
            
            #ui
            if { [catch { g_ent_core$i configure -background "red" -foreground "white" } err] } {}
            
        } elseif { $core_touch > $core_prealert_limit } {
            set core_touchdown_flag "TRUE"
            #message
            set core_msg "$core_msg\n[subst $[format "g_core%d" $i]] : [subst $[format "g_core_touch%d" $i]] : [subst $[format "g_core_limit%d" $i]]      -      pre-alert!"
            if { [catch { g_ent_core$i configure -background "white" -foreground "black" } err] } {}   
        } else {
            if { [catch { g_ent_core$i configure -background "white" -foreground "black" } err] } {}
        }
    
    } else {
         if { [catch { g_ent_core$i configure -background "white" -foreground "black" } err] } {}
    }

}

if { $g_testing_flag != "TESTING" } { return }

set win_title "core_touchdown_warning"

if { $core_touchdown_flag == "TRUE" } {

    #FUNC_DISPLAY_MESSAGE "close,$win_title" "" ""

    #           1.flag 2.title 3.height 4.width 5.top 6.left 7.bgcolor 8.fgcolor 9.thickness(line)
    set height [expr [llength [split $core_msg "\n"]] * 24]
    set config "$win_title,$height,,,,#EFEBEF,#000000,"

    #              1.directory 2.file name
    set file_name ""

    #        alter message for image

    FUNC_DISPLAY_MESSAGE "close" $config $file_name $core_msg
    FUNC_DISPLAY_MESSAGE "open" $config $file_name $core_msg
    
    ### UI tab change
    #global g_note_root
    #$g_note_root raise page2
    
    #global g_note_rfid
    #$g_note_rfid raise page1
    
    
} else {
    FUNC_DISPLAY_MESSAGE "close" "$win_title" "" ""
}
}
#############################################################################
## Procedure:  FUNC_CHECK_PROBECORRELATION

proc ::FUNC_CHECK_PROBECORRELATION {} {
global widget

global g_hostname
global g_lotname
global g_dcc
global g_operation
global g_operatorid
global g_customer
global g_probe

set qry "SCOPS,CALLSP2,CheckProbeCorrelation,$g_hostname,$g_probe*"

set res ""
set res [FUNC_SEND_QRY $qry]


if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
    set choice [ tk_messageBox -title "Probe Correlation Check Error" -icon warning -message [FM "TESTIT" "Fail to Check Probe Correlation." $res] ]
    return "TRUE"
}

if { [lindex [split $res ","] 0] == "NO" } {
    set choice [ tk_messageBox -title "Probe Correlation Check Error" -icon error -message [FM "K3 or K5 Engineer, HCC" "Fail to Check Probe Correlation." $res] ]
    return "FALSE"
}

return "TRUE"
}
#############################################################################
## Procedure:  FUNC_CHECK_RETEST_SKIP

proc ::FUNC_CHECK_RETEST_SKIP {} {
global widget

global g_hostname
global g_lotname
global g_dcc
global g_operation
global g_job

set qry "SCOPS,CALLSP2,CheckRetestSkip,$g_hostname,$g_lotname,$g_dcc,$g_operation,$g_job*"

set res ""
set res [FUNC_SEND_QRY $qry]

if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
    set choice [ tk_messageBox -title "ReTest Skip Check Error" -icon warning -message [FM "TESTIT" "" $res] ]
    return "FALSE"
}

if { [lindex [split $res ","] 0] == "NO" } {
    set choice [ tk_messageBox -title "ReTest Skip Check Error" -icon error -message [FM "K3 Engineer" "" $res] ] 
    return "FALSE"
}

return "TRUE"
}
#############################################################################
## Procedure:  FUNC_PROBE_TD_OVER_CONFIRM

proc ::FUNC_PROBE_TD_OVER_CONFIRM {} {
global widget

global g_probe_td_operatorid
global g_hostname
global g_probe
global g_probe_ext
global g_probe_touch
global g_probe_comment
global g_operation
global g_probe_td_comment
global g_probe_operator
global g_probe_operatorid

if { [string trim $g_probe_td_operatorid] == "" } {
    set choice [ tk_messageBox -title "Check OperatorID Error" -icon warning -message "Input your operatorid!   "]
    return "FALSE"
}

# Check Operator ID
set qry "SCOPS,CheckOperatorID,$g_probe_td_operatorid*"
set res ""
set res [FUNC_SEND_QRY "$qry"]

if { [lindex [split $res ","] 0] != "YES" } {
    set choice [ tk_messageBox -title "Check OperatorID Error" -icon warning -message "$res    "]
    return "FALSE"
}

# LIMIT Extend    
set qry_extend "SCOPS,ExtendProbe,$g_probe,$g_probe_ext,$g_probe_td_operatorid,$g_probe_td_comment,$g_hostname,$g_operation*"
set res_extend ""
set res_extend [FUNC_SEND_QRY $qry_extend]
    
if { [lindex [split $res_extend ","] 0] == "FAIL" || $res_extend == "" } { 
   set choice [ tk_messageBox -title "FUNC_PROBE_TD_OVER_CONFIRM ERROR" -icon warning -message [FM "TESTIT" "" $res_extend] ]
   return "FALSE" 
}
    
if { [lindex [split $res_extend ","] 0] == "0" || [lindex [split $res_extend ","] 0] == "SUCCESS" } { 
   set choice [ tk_messageBox -title "PROBE EXTEND SUCCESS" -icon info -message [FM "K3,K5 Engineer" "PROBE TOUCH DOWN LIMIT EXTEND SUCCESS!" ""] ]
   set qry_log "SCOPS,CheckProbeTC,LOG,$g_hostname,$g_probe,$g_probe_touch,$g_probe_td_operatorid,$g_operation*"

   set res_log ""
   set res_log [FUNC_SEND_QRY $qry_log]
   if { [lindex [split $res_log ","] 0] != "SUCCESS" } {
        FD "CheckProbeTC LOG : FAIL"     
   } 
   Window hide .top95
} else {
   set choice [ tk_messageBox -title "PROBE EXTEND FAIL" -icon error -message [FM "K3,K5 Engineer" "PROBE TOUCH DOWN LIMIT EXTEND FAIL!" ""] ]
}
    
set g_probe_operator ""
set g_probe_operatorid ""
set g_probe_comment ""
set g_probe_td_operatorid ""
set g_probe_td_comment ""

global g_probe_warning
set g_probe_warning ""
        
FUNC_RFID_INITIALIZE
FUNC_RFID_REFRESH

global g_note_probe 
$g_note_probe raise page1
    
}
#############################################################################
## Procedure:  FUNC_CHECK_HARDWARE_INOUT

proc ::FUNC_CHECK_HARDWARE_INOUT {} {
global widget

global g_hostname
global g_board
global g_kit
global g_probe
global g_handler

global g_lotname
global g_dcc
global g_operation 
global g_operatorid

set qry "SCOPS,CALLSP2,HardwareInOut,$g_hostname,$g_board,$g_kit,$g_probe,$g_handler,$g_lotname,$g_dcc,$g_operation,$g_operatorid*"

set res ""
set res [FUNC_SEND_QRY $qry]

if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
    set choice [ tk_messageBox -title "HARDWARE INOUT CHECK ERROR" -icon warning -message [FM "TESTIT" "" $res] ]
    return "FALSE"
}

if { [lindex [split $res ","] 0] == "NO" } {
    return "TRUE"
}

if { [lindex [split $res ","] 0] == "YES" } {
    set blocktype [lindex [split $res ","] 1]
    set to_list [lindex [split $res ","] 2]
    set msg [lindex [split $res ","] 3]
    
    if { $blocktype == "BLOCK" } {
        set choice [ tk_messageBox -title "HARDWARE INOUT ERROR" -icon warning -message [FM "$to_list" $msg ""]] 
        return "FALSE"

    } elseif { $blocktype == "YESORNO" } {
        set choice [ tk_messageBox -title "HARDWARE INOUT ERROR" -type yesno -icon warning -message [FM "$to_list" $msg ""]] 
      
        if { $choice == "yes" } {
            return "TRUE"
        } else {
            return "FALSE"
        } 
    } 
    
}
}
#############################################################################
## Procedure:  FUNC_RFID_CLEAR_CORETOUCHCOUNT

proc ::FUNC_RFID_CLEAR_CORETOUCHCOUNT {} {
global widget
global g_hostname 

global g_operation 

if { [string match -nocase "*TEST*" $g_operation] == 1 || [string match -nocase "*TSQA*" $g_operation] == 1 } {
    return
}

global g_testing_flag

if { $g_testing_flag == "TESTING" } {
    set choice [ tk_messageBox -title "Clear Core Error" -icon error -message [FM "" "Fail to Clear Core!newlinenewlineTester is running now." ""] ]
    return
}

#global g_rfid_flag

#if { $g_rfid_flag != "TRUE" } {
#    set choice [ tk_messageBox -title "Clear Socket Error" -icon error -message [FM "" "Fail to Clear Socket!newlinenewlineThis test tarted without RFID.   " ""] ]
#    return
#}


global g_core_operator

if { [string trim $g_core_operator] == "" } {
    set choice [ tk_messageBox -title "Clear Core Error" -icon error -message [FM "" "Fail to Clear Core!newlinenewlineInput your operator ID.   " ""] ]
    return
}


global g_socketsitenumber
for { set i 1 } { $i<=$g_socketsitenumber } { incr i } {

    global g_core_check$i
    global g_core$i
    global g_core_touch$i
    global g_core_limit$i
    global g_core_ext$i

    set qry ""
    
    if { [subst $[format "g_core_check%d" $i]] == 1 && [string trim [subst $[format "g_core%d" $i]] ] != "" && [string trim [subst $[format "g_core_touch%d" $i]] ] != "" } {
       
       if { [FUNC_RFID_CHECK_SOCKETCLEAR [subst $[format "g_core%d" $i]]] == "TRUE" } {

           set qry "SCOPS,ClearSocket,[subst $[format "g_core%d" $i]],[subst $[format "g_core_touch%d" $i]],$g_core_operator,$g_hostname*"   
           #FD "qry : $qry"
           set res ""
           set res [FUNC_SEND_QRY $qry]
       
       }
       
    }
    
}

FUNC_RFID_INITIALIZE
FUNC_RFID_REFRESH
}
#############################################################################
## Procedure:  FUNC_RFID_EXTEND_CORELIMIT

proc ::FUNC_RFID_EXTEND_CORELIMIT {} {
global widget
global g_hostname

#########################
### demo setting ########
global g_operation 
global g_testing_flag
global g_rfid_flag
#set g_operation "TEST1"
#set g_testing_flag "TESTING"
#set g_rfid_flag "TRUE"
#set g_socket_operator "testit"
#########################
#########################



global g_operation 

if { [string match -nocase "*TEST*" $g_operation] == 1 || [string match -nocase "*TSQA*" $g_operation] == 1 } {
    return
}


global g_testing_flag
if { $g_testing_flag == "TESTING" } {
    set choice [ tk_messageBox -title "Extend Core Limit Error" -icon error -message [FM "" "Fail to Extend Core Limit!newlinenewlineTester is running now." ""] ]
    return
}


#global g_rfid_flag
#if { $g_rfid_flag != "TRUE" } {    
#    set choice [ tk_messageBox -title "Extend Socket Limit Error" -icon error -message [FM "" "Fail to Extend Socket Limit!newlinenewlineTester is running now." ""] ]
#    return
#}


global g_core_operator
if { [string trim $g_core_operator] == "" } {
    set choice [ tk_messageBox -title "Extend Core Limit Error" -icon error -message [FM "" "Fail to Extend Core Limit!newlinenewlineInput your operator ID.   " ""] ]
    return
}


global g_socketsitenumber
for { set i 1 } { $i<=$g_socketsitenumber } { incr i } {

    global g_core_check$i
    global g_core$i
    global g_core_touch$i
    global g_core_limit$i
    global g_core_ext$i

    set qry ""
    
    if { [subst $[format "g_core_check%d" $i]] == 1 && [string trim [subst $[format "g_core%d" $i]] ] != "" && [string trim [subst $[format "g_core_ext%d" $i]] ] != "" } {
       set qry "SCOPS,ExtendSocket,[subst $[format "g_core%d" $i]],[subst $[format "g_core_ext%d" $i]],$g_core_operator,$g_hostname*"
       puts "qry : $qry"
       
       set res ""
       set res [FUNC_SEND_QRY $qry]
    }
    
}

FUNC_RFID_INITIALIZE
FUNC_RFID_REFRESH
}
#############################################################################
## Procedure:  FUNC_CHECK_PROBECARD

proc ::FUNC_CHECK_PROBECARD {} {
global widget

global g_probecard_validation
global g_hostname
global g_lotname
global g_dcc
global g_operation
global g_operatorid
global g_customer
global g_probe

global g_rfid_flag
if { $g_rfid_flag != "TRUE" } { return "TRUE" }

if { $g_probecard_validation == "TRUE" } {
    return "TRUE"
}

set qry "SCOPS,CALLSP2,CheckProbeCard,CHECK,$g_hostname,$g_lotname,$g_dcc,$g_operation,$g_operatorid,$g_customer,$g_probe*"

set res ""
set res [FUNC_SEND_QRY $qry]

set log_qry [format "%s,%s,%s,%s,%s,%s,%s,%s" "SCOPS,CALLSP2,CheckProbeCard,LOG" $g_hostname $g_lotname $g_dcc $g_operation $g_operatorid $g_customer $g_probe ]
#FD "log_qry : $log_qry"

if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
    set choice [ tk_messageBox -title "ProbeCard Check Error" -icon warning -message [FM "TESTIT" "" $res] ]
    return "FALSE"
}


if { [lindex [split $res ","] 0] == "NO" } {
    set msg "ProbeCard Check Error!"
    FUNC_CONFIRM_VALIDATION "g_probecard_validation" "PROBECARD CHECK ERROR!" "$res" "image/scops_warning_ProbeCard.gif" $log_qry
    
    #set choice [ tk_messageBox -title "ProbeCard Check Error" -icon error -message [FM "K5 Engineer, HCC" "Fail to Check ProbeCard!" $res] ]
    
    set g_probecard_validation "FALSE"
    return "FALSE"

}
set g_probecard_validation "TRUE"
return "TRUE"
}
#############################################################################
## Procedure:  FUNC_RFID_EXTEND_CLEANINGSHEETLIMIT

proc ::FUNC_RFID_EXTEND_CLEANINGSHEETLIMIT {} {
global widget
global g_hostname

global g_operation 
global g_testing_flag
global g_rfid_flag

global g_cleaningsheet_operator
global g_cleaningsheet_comment

global g_cleaningsheet
global g_cleaningsheet_ext


if { $g_rfid_flag != "TRUE" } {
    set choice [ tk_messageBox -title "Extend CleaningSheet Limit Error" -icon error -message [FM "" "Fail to Extend CleaningSheet Limit!newlinenewlineThis test is not started with RFID.   " ""] ]
    return
}

if { [string trim $g_cleaningsheet_operator] == "" } {
    set choice [ tk_messageBox -title "Extend CleaningSheet Limit Error" -icon error -message [FM "" "Fail to Extend CleaningSheet Limit!newlinenewlineInput your operator ID.   " ""] ]
    return
}

if { [string trim $g_cleaningsheet] == "" || [string trim $g_cleaningsheet_ext] == "" } { return }

set qry "SCOPS,CALLSP2,ExtendCleaningSheet,$g_cleaningsheet,$g_cleaningsheet_ext,$g_cleaningsheet_operator,$g_cleaningsheet_comment,$g_hostname,$g_operation*"

set res ""

set res [FUNC_SEND_QRY $qry]

if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } { 
    set choice [ tk_messageBox -title "FUNC_RFID_EXTEND_CLEANINGSHEETLIMIT ERROR" -icon warning -message [FM "TESTIT" "" $res] ]
    return "FALSE" 
}
    
if { [lindex [split $res ","] 0] == "0" || [lindex [split $res ","] 0] == "SUCCESS" } {
    set choice [ tk_messageBox -title "FUNC_RFID_EXTEND_CLEANINGSHEETLIMIT SUCCESS" -icon info -message [FM "K3,K5 Engineer" "CLEANINGSHEET COUNT LIMIT EXTEND SUCCESS!" ""] ]  
} else {
    set choice [ tk_messageBox -title "FUNC_RFID_EXTEND_CLEANINGSHEETLIMIT FAIL" -icon error -message [FM "K3,K5 Engineer" "CLEANINGSHEET COUNT LIMIT EXTEND FAIL!" ""] ]
}
    

set g_cleaningsheet_operator ""
set g_cleaningsheet_comment ""


FUNC_RFID_INITIALIZE
FUNC_RFID_REFRESH
}
#############################################################################
## Procedure:  FUNC_APL_NVIDIA_BUMP

proc ::FUNC_APL_NVIDIA_BUMP {flag} {
global widget
global tcl_platform

if { [string match -nocase "*window*" $tcl_platform(platform)] == 1 } {
#puts "This is windows platform"
return "TRUE"
}

global g_hostname
global g_lotname
global g_dcc
global g_operation
global g_job
global g_customer
global g_devicename
global g_testprogram
global g_testprogramrev
global g_condition
global g_temperature
global g_incount
global g_operatorid
global g_handler
global g_board
global g_kit
global g_probe
global g_socketcount
global g_handlertype

##nvida bump code
set apl_name "EXECUTE_APL_NVIDIA_BUMP"

##delete bmp file
if { $flag == "DELETE" } {
        if [catch {
                exec /usr/local1/APL/pgm/apl_Bump_delete.sh
        } err] {
                FD "$apl_name APL ERROR : Failture to delete the previous bump files"
                        set choice [ tk_messageBox -title "$apl_name BUMP ERROR" -message [FM "K3 Engineer, TESTIT" "Please, Check bump file authority to delete!" $flag] ]
                        return "FALSE"
        }

        return "TRUE"
}

set qry "SCOPS,CALLSP2,GetWaferCount,$flag,$g_hostname,$g_lotname,$g_dcc,$g_operation,$g_job,$g_customer,$g_devicename,$g_testprogram,$g_testprogramrev,$g_condition,$g_temperature,$g_incount,$g_operatorid,$g_handler,$g_board,$g_kit,$g_socketcount,$g_handlertype*"

set apl_count ""
set apl_count [FUNC_SEND_QRY $qry]
set wafercount [lindex [split $apl_count ","] 0]

if { $wafercount == "FAIL" } {
    FD "$apl_name ERROR : Get Wafer Count"
    set choice [ tk_messageBox -title "$apl_name ERROR(Get Wafer count by CIMitar )" -message [FM "K5 Engineer, K3 TFA" "Get Wafer Count Fail!!! $apl_name" $apl_count] ]
    return "FALSE"
}

if { $wafercount == "NO" } {
    return "TRUE"
}

if { $wafercount == "WRONG" } {
    FD "$apl_name ERROR : Different Wafer Count - between eMES and Bump Site"
    set choice [ tk_messageBox -title "$apl_name ERROR(Different Wafer count - between eMES and Bupm Site)" -message [FM "K5 Engineer, K3 TFA" "Wrong Wafer Count!!! $apl_name" $apl_count] ]
    return "FALSE"
}

if { $wafercount == "" } {
    FD "$apl_name ERROR : Wafer Count is null"
    set choice [ tk_messageBox -title "$apl_name ERROR(wafer count is empty)" -message [FM "K5 Engineer, K3 TFA" "Wafer Count is NULL!!! $apl_name" $apl_count] ]
    return "FALSE"
    }
if { $wafercount == "0" } {
    FD "$apl_name ERROR : Wafer Count is 0"
    set choice [ tk_messageBox -title "$apl_name ERROR(wafer count is 0)" -message [FM "K5 Engineer, K3 TFA" "Wafer Count is Zero!!!! $apl_name" $apl_count] ]
    return "FALSE"
    }

set wafercnt [expr $wafercount * 1]
FD "Die Bank Wafer Count : $wafercnt"

for { set i 1 } { $i <= $wafercnt } { incr i } {
        set waferid [lindex [split $apl_count ","] $i]

        if { $waferid == "" } {
                set choice [ tk_messageBox -title "$apl_name ERROR" -icon warning -message [FM "TFA" "Failure to create $apl_name Bump file!(wafer id : $waferid)" $waferid] ]
                return "FALSE"
        }

    set qry "SCOPS,EXECUTE_APL_SUB,$flag,$g_hostname,$g_lotname,$g_dcc,$g_operation,$g_job,$g_customer,$g_devicename,$g_testprogram,$g_testprogramrev,$g_condition,$g_temperature,$g_incount,$g_operatorid,$g_handler,$g_board,$g_kit,$g_socketcount,$g_handlertype,$waferid,BUMP*"
    set res ""
    set res [FUNC_SEND_QRY $qry]

    if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
        set choice [ tk_messageBox -title "$apl_name ERROR" -icon warning -message [FM "TFA" "Failure to create $apl_name Bump file!" $res] ]
        return "FALSE"
    }

    if { [lindex [split $res ","] 0] == "NO" } {
        return "TRUE"
    }

        set apl_contents ""

    set apl_file [lindex [split $res ","] 0]
    set apl_format [lindex [split $res ","] 1]
##set apl_contents [lindex [split $res ","] 2]
    set apl_path [file dir $apl_file]

### start writing BUMP###  
    if [catch {
        set apl_fd [open $apl_file w]

####writing BUMP Detail Data
        for { set j 2 } { $j < [llength [split $res ","]] } { incr j } {
            if { $apl_format == "COMMA" } {
                if { $apl_contents != "" && $j != [llength [split $res ","]] } {
                    set apl_contents [format "%s,%s" $apl_contents [lindex [split $res ","] $i] ]
                } else {
                    set apl_contents [format "%s%s" $apl_contents [lindex [split $res ","] $i] ]
                }
            } else {
                    puts $apl_fd [lindex [split $res ","] $j]
            }

            }

        close $apl_fd
        FD "$apl_name BUMP SUCCESS!"

    } err ] {
        FD "$apl_name BUMP ERROR : $err"
        set choice [ tk_messageBox -title "$apl_name ERROR" -icon warning -message [FM "TFA" "Failure to create Bump Wafer file!" $apl_file] ]
        return "FALSE"
    }
}
##check wafer count
return "TRUE"
}
#############################################################################
## Procedure:  FUNC_CHECK_QUALTESTER_QCT

proc ::FUNC_CHECK_QUALTESTER_QCT {} {
global widget

global g_hostname
global g_board
global g_kit
global g_probe
global g_handler

global g_lotname
global g_dcc
global g_operation 
global g_testprogram
global g_testprogramrev
global g_operatorid
global g_job

set qry "SCOPS,CALLSP2,CheckQTIQualTester,$g_hostname,$g_board,$g_kit,$g_probe,$g_handler,$g_lotname,$g_dcc,$g_operation,$g_testprogram,$g_testprogramrev,$g_operatorid,$g_job*"

set res ""
set res [FUNC_SEND_QRY $qry]

if { [lindex [split $res ","] 0] == "FAIL" || $res == "" } {
    #set choice [ tk_messageBox -title "QTI QUAL TESTER ERROR" -icon warning -message [FM "TESTIT" "" $res] ]
    return "FALSE"
}
if { [lindex [split $res ","] 0] == "NO" } {
    return "TRUE"
}

if { [lindex [split $res ","] 0] == "YES" } {
    set blocktype [lindex [split $res ","] 1]
    set popup_title [lindex [split $res ","] 2]
    set to_list [lindex [split $res ","] 3]
    set msg [lindex [split $res ","] 4]
    
    if { $blocktype == "BLOCK" } {
        set choice [ tk_messageBox -title $popup_title -icon warning -message [FM "$to_list" $msg ""]] 
        return "FALSE"

    } elseif { $blocktype == "YESORNO" } {
        set choice [ tk_messageBox -title $popup_title -type yesno -icon warning -message [FM "$to_list" $msg ""]] 
      
        if { $choice == "yes" } {
            return "TRUE"
        } else {
            return "FALSE"
        } 
    } 
    
}
}

#############################################################################
## Initialization Procedure:  init

proc ::init {argc argv} {

}

init $argc $argv

#################################
# VTCL GENERATED GUI PROCEDURES
#

proc vTclWindow. {base} {
    if {$base == ""} {
        set base .
    }
    ###################
    # CREATING WIDGETS
    ###################
    wm focusmodel $top passive
    wm geometry $top 200x200+52+52; update
    wm maxsize $top 3844 1061
    wm minsize $top 120 1
    wm overrideredirect $top 0
    wm resizable $top 1 1
    wm withdraw $top
    wm title $top "vtcl"
    bindtags $top "$top Vtcl all"
    vTcl:FireEvent $top <<Create>>
    wm protocol $top WM_DELETE_WINDOW "vTcl:FireEvent $top <<DeleteWindow>>"

    ###################
    # SETTING GEOMETRY
    ###################

    vTcl:FireEvent $base <<Ready>>
}

proc vTclWindow.top83 {base} {
    if {$base == ""} {
        set base .top83
    }
    if {[winfo exists $base]} {
        wm deiconify $base; return
    }
    set top $base
    ###################
    # CREATING WIDGETS
    ###################
    vTcl:toplevel $top -class Toplevel \
        -background #93998E 
    wm focusmodel $top passive
    wm geometry $top 768x561+426+187; update
    wm maxsize $top 2724 1002
    wm minsize $top 120 1
    wm overrideredirect $top 0
    wm resizable $top 1 1
    wm deiconify $top
    wm title $top "Scops3 ver.1-VNV1OFLTP00087"
    vTcl:DefineAlias "$top" "Toplevel1" vTcl:Toplevel:WidgetProc "" 1
    bindtags $top "$top Toplevel all _TopLevel"
    vTcl:FireEvent $top <<Create>>
    wm protocol $top WM_DELETE_WINDOW "vTcl:FireEvent $top <<DeleteWindow>>"

    NoteBook $top.not84 \
        -activebackground #cad3ec -activeforeground #000000 \
        -background #EFEBEF -font {Arial 12 bold} -height 550 -width 760 
    vTcl:DefineAlias "$top.not84" "NoteBook1" vTcl:WidgetProc "Toplevel1" 1
    $top.not84 insert end page1 \
        -state normal -text OPERATION 
    $top.not84 insert end page2 \
        -state normal -text RFID 
    $top.not84 insert end page5 \
        -state normal -text ADMIN 
    set site_4_0 [$top.not84 getframe page1]
    NoteBook $site_4_0.not85 \
        -activebackground #cad3ec -background #EFEBEF \
        -font {helvetica 10 bold} -height 208 -width 740 
    vTcl:DefineAlias "$site_4_0.not85" "NoteBook2" vTcl:WidgetProc "Toplevel1" 1
    $site_4_0.not85 insert end page1 \
        -text SEARCH 
    $site_4_0.not85 insert end page2 \
        -text STATUS 
    set site_6_0 [$site_4_0.not85 getframe page1]
    frame $site_6_0.fra118 \
        -borderwidth 2 -relief groove -background #EFEBEF -height 130 \
        -width 397 
    vTcl:DefineAlias "$site_6_0.fra118" "Frame5" vTcl:WidgetProc "Toplevel1" 1
    set site_7_0 $site_6_0.fra118
    entry $site_7_0.ent121 \
        -background white -textvariable g_lotname 
    vTcl:DefineAlias "$site_7_0.ent121" "ent_lotname" vTcl:WidgetProc "Toplevel1" 1
    tixScrolledListBox $site_7_0.tix83 \
        -browsecmd FUNC_SELECT_LOT_LISTBOX -scrollbar auto -borderwidth 1 \
        -height 97 -width 388 
    bind $site_7_0.tix83 <FocusIn> {
        focus %W.listbox
    }
    button $site_7_0.but123 \
        -background #BFFF00 -command BTN_SEARCH_RFID -font {Arial 10 bold} \
        -pady 0 -text RFID 
    vTcl:DefineAlias "$site_7_0.but123" "Button2" vTcl:WidgetProc "Toplevel1" 1
    button $site_7_0.but122 \
        -activebackground #ffffff -background #F6CEE3 \
        -command {BTN_SEARCH_LOT "CLEAR"} -font {Arial 10 bold} -pady 0 \
        -text SEARCH 
    vTcl:DefineAlias "$site_7_0.but122" "Button1" vTcl:WidgetProc "Toplevel1" 1
    place $site_7_0.ent121 \
        -in $site_7_0 -x 5 -y 5 -width 246 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_7_0.tix83 \
        -in $site_7_0 -x 5 -y 30 -width 388 -height 97 -anchor nw \
        -bordermode ignore 
    place $site_7_0.but123 \
        -in $site_7_0 -x 327 -y 4 -width 64 -height 20 -anchor nw \
        -bordermode ignore 
    place $site_7_0.but122 \
        -in $site_7_0 -x 253 -y 4 -width 69 -height 20 -anchor nw \
        -bordermode ignore 
    frame $site_6_0.fra119 \
        -borderwidth 2 -relief groove -background #EFEBEF -height 130 \
        -width 110 
    vTcl:DefineAlias "$site_6_0.fra119" "Frame6" vTcl:WidgetProc "Toplevel1" 1
    set site_7_0 $site_6_0.fra119
    entry $site_7_0.ent128 \
        -background white -textvariable g_operatorid 
    vTcl:DefineAlias "$site_7_0.ent128" "Entry2" vTcl:WidgetProc "Toplevel1" 1
    bind $site_7_0.ent128 <Button-1> {
        global g_btn_start
    $g_btn_start configure -state normal
    }
    tixScrolledListBox $site_7_0.tix83 \
        -browsecmd FUNC_SELECT_JOB_LISTBOX -takefocus 0 -scrollbar auto \
        -borderwidth 1 -height 63 -width 100 
    bind $site_7_0.tix83 <FocusIn> {
        focus %W.listbox
    }
    button $site_7_0.but127 \
        -background #F5DA81 -command BTN_ADD_RETEST -font {Arial 10 bold} \
        -pady 0 -text {ADD RETEST} 
    vTcl:DefineAlias "$site_7_0.but127" "Button3" vTcl:WidgetProc "Toplevel1" 1
    place $site_7_0.ent128 \
        -in $site_7_0 -x 5 -y 103 -width 98 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_7_0.tix83 \
        -in $site_7_0 -x 5 -y 5 -width 100 -height 63 -anchor nw \
        -bordermode ignore 
    place $site_7_0.but127 \
        -in $site_7_0 -x 5 -y 73 -width 100 -height 22 -anchor nw \
        -bordermode ignore 
    frame $site_6_0.fra120 \
        -borderwidth 2 -relief groove -background #EFEBEF -height 130 \
        -width 220 
    vTcl:DefineAlias "$site_6_0.fra120" "Frame7" vTcl:WidgetProc "Toplevel1" 1
    set site_7_0 $site_6_0.fra120
    label $site_7_0.cpd129 \
        -background #EFEBEF -font {Arial 10} -text {HANDLER :} 
    vTcl:DefineAlias "$site_7_0.cpd129" "Label27" vTcl:WidgetProc "Toplevel1" 1
    label $site_7_0.cpd130 \
        -background #EFEBEF -font {Arial 10} -text {BOARD :} 
    vTcl:DefineAlias "$site_7_0.cpd130" "Label28" vTcl:WidgetProc "Toplevel1" 1
    label $site_7_0.cpd131 \
        -background #EFEBEF -font {Arial 10} -text {KIT :} 
    vTcl:DefineAlias "$site_7_0.cpd131" "Label29" vTcl:WidgetProc "Toplevel1" 1
    label $site_7_0.cpd132 \
        -background #EFEBEF -font {Arial 10} -text {PROBE :} 
    vTcl:DefineAlias "$site_7_0.cpd132" "Label30" vTcl:WidgetProc "Toplevel1" 1
    label $site_7_0.cpd133 \
        -background #EFEBEF -font {Arial 10} -text {SCK CNT :} 
    vTcl:DefineAlias "$site_7_0.cpd133" "Label31" vTcl:WidgetProc "Toplevel1" 1
    label $site_7_0.cpd137 \
        -background #B0E0E6 -font {Arial 10} -textvariable g_socketcount 
    vTcl:DefineAlias "$site_7_0.cpd137" "Label54" vTcl:WidgetProc "Toplevel1" 1
    entry $site_7_0.ent139 \
        -background white -textvariable g_handler 
    vTcl:DefineAlias "$site_7_0.ent139" "Entry6" vTcl:WidgetProc "Toplevel1" 1
    entry $site_7_0.ent140 \
        -background white -textvariable g_board 
    vTcl:DefineAlias "$site_7_0.ent140" "Entry7" vTcl:WidgetProc "Toplevel1" 1
    entry $site_7_0.ent141 \
        -background white -textvariable g_kit 
    vTcl:DefineAlias "$site_7_0.ent141" "Entry8" vTcl:WidgetProc "Toplevel1" 1
    entry $site_7_0.ent83 \
        -background white -takefocus 0 -textvariable g_probe 
    vTcl:DefineAlias "$site_7_0.ent83" "Entry1" vTcl:WidgetProc "Toplevel1" 1
    label $site_7_0.lab83 \
        -background #EFEBEF -font {Arial 10} -text {TEMPER :} 
    vTcl:DefineAlias "$site_7_0.lab83" "Label102" vTcl:WidgetProc "Toplevel1" 1
    entry $site_7_0.ent84 \
        -background white -takefocus 0 -textvariable g_temperature 
    vTcl:DefineAlias "$site_7_0.ent84" "Entry3" vTcl:WidgetProc "Toplevel1" 1
    place $site_7_0.cpd129 \
        -in $site_7_0 -x 4 -y 4 -width 90 -height 16 -anchor nw \
        -bordermode ignore 
    place $site_7_0.cpd130 \
        -in $site_7_0 -x 4 -y 25 -width 90 -height 16 -anchor nw \
        -bordermode ignore 
    place $site_7_0.cpd131 \
        -in $site_7_0 -x 4 -y 46 -width 90 -height 16 -anchor nw \
        -bordermode ignore 
    place $site_7_0.cpd132 \
        -in $site_7_0 -x 4 -y 67 -width 90 -height 16 -anchor nw \
        -bordermode ignore 
    place $site_7_0.cpd133 \
        -in $site_7_0 -x 4 -y 88 -width 90 -height 16 -anchor nw \
        -bordermode ignore 
    place $site_7_0.cpd137 \
        -in $site_7_0 -x 100 -y 89 -width 114 -height 17 -anchor nw \
        -bordermode ignore 
    place $site_7_0.ent139 \
        -in $site_7_0 -x 100 -y 5 -width 114 -height 17 -anchor nw \
        -bordermode ignore 
    place $site_7_0.ent140 \
        -in $site_7_0 -x 100 -y 26 -width 114 -height 17 -anchor nw \
        -bordermode ignore 
    place $site_7_0.ent141 \
        -in $site_7_0 -x 100 -y 47 -width 114 -height 17 -anchor nw \
        -bordermode ignore 
    place $site_7_0.ent83 \
        -in $site_7_0 -x 100 -y 69 -width 114 -height 17 -anchor nw \
        -bordermode ignore 
    place $site_7_0.lab83 \
        -in $site_7_0 -x 4 -y 109 -width 90 -height 16 -anchor nw \
        -bordermode ignore 
    place $site_7_0.ent84 \
        -in $site_7_0 -x 100 -y 110 -width 114 -height 17 -anchor nw \
        -bordermode ignore 
    frame $site_6_0.fra135 \
        -borderwidth 2 -relief groove -background #EFEBEF -height 40 \
        -width 730 
    vTcl:DefineAlias "$site_6_0.fra135" "Frame8" vTcl:WidgetProc "Toplevel1" 1
    set site_7_0 $site_6_0.fra135
    button $site_7_0.but136 \
        -background #CEE3F6 -command BTN_START_LOT -font {Arial 14 bold} \
        -pady 0 -text {LOT START} 
    vTcl:DefineAlias "$site_7_0.but136" "Button4" vTcl:WidgetProc "Toplevel1" 1
    place $site_7_0.but136 \
        -in $site_7_0 -x 7 -y 3 -width 714 -height 32 -anchor nw \
        -bordermode ignore 
    place $site_6_0.fra118 \
        -in $site_6_0 -x 6 -y 4 -width 397 -height 130 -anchor nw \
        -bordermode ignore 
    place $site_6_0.fra119 \
        -in $site_6_0 -x 404 -y 4 -width 110 -height 130 -anchor nw \
        -bordermode ignore 
    place $site_6_0.fra120 \
        -in $site_6_0 -x 515 -y 4 -width 220 -height 130 -anchor nw \
        -bordermode ignore 
    place $site_6_0.fra135 \
        -in $site_6_0 -x 5 -y 137 -width 730 -height 40 -anchor nw \
        -bordermode ignore 
    set site_6_1 [$site_4_0.not85 getframe page2]
    frame $site_6_1.fra89 \
        -borderwidth 2 -relief groove -background #EFEBEF -height 125 \
        -width 725 
    vTcl:DefineAlias "$site_6_1.fra89" "Frame9" vTcl:WidgetProc "Toplevel1" 1
    set site_7_0 $site_6_1.fra89
    label $site_7_0.cpd90 \
        -background #93998E -font {Arial 30 bold} -text { ()} \
        -textvariable g_tester_status 
    vTcl:DefineAlias "$site_7_0.cpd90" "lbl_status" vTcl:WidgetProc "Toplevel1" 1
    place $site_7_0.cpd90 \
        -in $site_7_0 -x 5 -y 4 -width 715 -height 117 -anchor nw \
        -bordermode ignore 
    frame $site_6_1.fra83 \
        -borderwidth 2 -relief groove -background #EFEBEF -height 40 \
        -width 725 
    vTcl:DefineAlias "$site_6_1.fra83" "Frame12" vTcl:WidgetProc "Toplevel1" 1
    set site_7_0 $site_6_1.fra83
    button $site_7_0.cpd84 \
        -background #F6CEE3 -command BTN_END_LOT -font {helvetica 12 bold} \
        -pady 0 -text {DOWN DONE} 
    vTcl:DefineAlias "$site_7_0.cpd84" "btn_endlot" vTcl:WidgetProc "Toplevel1" 1
    place $site_7_0.cpd84 \
        -in $site_7_0 -x 4 -y 3 -width 715 -height 32 -anchor nw \
        -bordermode ignore 
    place $site_6_1.fra89 \
        -in $site_6_1 -x 8 -y 5 -width 725 -height 125 -anchor nw \
        -bordermode ignore 
    place $site_6_1.fra83 \
        -in $site_6_1 -x 8 -y 133 -width 725 -height 40 -anchor nw \
        -bordermode ignore 
    $site_4_0.not85 raise page1
    NoteBook $site_4_0.not83 \
        -background #EFEBEF -height 143 -width 743 
    vTcl:DefineAlias "$site_4_0.not83" "NoteBook3" vTcl:WidgetProc "Toplevel1" 1
    $site_4_0.not83 insert end page1 \
        -text {} 
    $site_4_0.not83 insert end page2 \
        -text {} 
    set site_6_0 [$site_4_0.not83 getframe page1]
    frame $site_6_0.cpd84 \
        -borderwidth 2 -relief groove -background #EFEBEF -height 115 \
        -width 735 
    vTcl:DefineAlias "$site_6_0.cpd84" "Frame2" vTcl:WidgetProc "Toplevel1" 1
    set site_7_0 $site_6_0.cpd84
    frame $site_7_0.fra116 \
        -borderwidth 2 -background #EFEBEF -height 105 -width 315 
    vTcl:DefineAlias "$site_7_0.fra116" "Frame3" vTcl:WidgetProc "Toplevel1" 1
    set site_8_0 $site_7_0.fra116
    label $site_8_0.cpd137 \
        -background #EFEBEF -font {Arial 10} -text {OPERATOR ID :} 
    vTcl:DefineAlias "$site_8_0.cpd137" "Label32" vTcl:WidgetProc "Toplevel1" 1
    entry $site_8_0.ent138 \
        -background white -textvariable g_down_operator 
    vTcl:DefineAlias "$site_8_0.ent138" "ent_downoperator" vTcl:WidgetProc "Toplevel1" 1
    label $site_8_0.cpd139 \
        -background #EFEBEF -font {Arial 10} -text {CATEGORY :} 
    vTcl:DefineAlias "$site_8_0.cpd139" "Label33" vTcl:WidgetProc "Toplevel1" 1
    label $site_8_0.cpd140 \
        -background #EFEBEF -font {Arial 10} -text {CAUSE :} 
    vTcl:DefineAlias "$site_8_0.cpd140" "Label34" vTcl:WidgetProc "Toplevel1" 1
    label $site_8_0.cpd142 \
        -background #EFEBEF -font {Arial 10} -text {ACTION :} 
    vTcl:DefineAlias "$site_8_0.cpd142" "Label35" vTcl:WidgetProc "Toplevel1" 1
    ComboBox $site_8_0.com143 \
        -entrybg white -modifycmd FUNC_SELECT_MAINDSC_COMBOBOX -takefocus 1 \
        -textvariable g_maindescription \
        -values { "HANDLER" "MATL" "ENGR" "SETUP" "TESTER" "NO SCHD." "PM-CAL" "NO WORK" "HD-TEM" "OTHER" "HANDLING"} 
    vTcl:DefineAlias "$site_8_0.com143" "ComboBox1" vTcl:WidgetProc "Toplevel1" 1
    bindtags $site_8_0.com143 "$site_8_0.com143 BwComboBox $top all"
    ComboBox $site_8_0.cpd144 \
        -entrybg white -modifycmd FUNC_SELECT_SUBDSC_COMBOBOX -takefocus 1 \
        -textvariable g_subdescription 
    vTcl:DefineAlias "$site_8_0.cpd144" "ComboBox2" vTcl:WidgetProc "Toplevel1" 1
    bindtags $site_8_0.cpd144 "$site_8_0.cpd144 BwComboBox $top all"
    ComboBox $site_8_0.cpd145 \
        -entrybg white -takefocus 1 -textvariable g_actiondescription 
    vTcl:DefineAlias "$site_8_0.cpd145" "ComboBox3" vTcl:WidgetProc "Toplevel1" 1
    bindtags $site_8_0.cpd145 "$site_8_0.cpd145 BwComboBox $top all"
    place $site_8_0.cpd137 \
        -in $site_8_0 -x 2 -y 5 -width 130 -height 20 -anchor nw \
        -bordermode ignore 
    place $site_8_0.ent138 \
        -in $site_8_0 -x 135 -y 5 -width 175 -height 20 -anchor nw \
        -bordermode ignore 
    place $site_8_0.cpd139 \
        -in $site_8_0 -x 2 -y 29 -width 130 -height 20 -anchor nw \
        -bordermode ignore 
    place $site_8_0.cpd140 \
        -in $site_8_0 -x 2 -y 53 -width 130 -height 20 -anchor nw \
        -bordermode ignore 
    place $site_8_0.cpd142 \
        -in $site_8_0 -x 2 -y 77 -width 130 -height 20 -anchor nw \
        -bordermode ignore 
    place $site_8_0.com143 \
        -in $site_8_0 -x 135 -y 29 -width 175 -height 20 -anchor nw \
        -bordermode ignore 
    place $site_8_0.cpd144 \
        -in $site_8_0 -x 135 -y 54 -width 175 -height 20 -anchor nw \
        -bordermode ignore 
    place $site_8_0.cpd145 \
        -in $site_8_0 -x 135 -y 78 -width 175 -height 20 -anchor nw \
        -bordermode ignore 
    frame $site_7_0.fra117 \
        -borderwidth 2 -relief groove -background #EFEBEF -height 65 \
        -width 345 
    vTcl:DefineAlias "$site_7_0.fra117" "Frame4" vTcl:WidgetProc "Toplevel1" 1
    set site_8_0 $site_7_0.fra117
    text $site_8_0.tex89 \
        -background white 
    vTcl:DefineAlias "$site_8_0.tex89" "txt_comment" vTcl:WidgetProc "Toplevel1" 1
    place $site_8_0.tex89 \
        -in $site_8_0 -x 7 -y 5 -width 331 -height 53 -anchor nw \
        -bordermode ignore 
    frame $site_7_0.fra84 \
        -borderwidth 2 -relief groove -background #EFEBEF -height 35 \
        -width 345 
    vTcl:DefineAlias "$site_7_0.fra84" "Frame14" vTcl:WidgetProc "Toplevel1" 1
    set site_8_0 $site_7_0.fra84
    button $site_8_0.but83 \
        -background #A4A4A4 -command BTN_SET_DOWN -font {Arial 11 bold} \
        -pady 0 -takefocus 0 -text {DOWN CHANGE} 
    vTcl:DefineAlias "$site_8_0.but83" "Button5" vTcl:WidgetProc "Toplevel1" 1
    place $site_8_0.but83 \
        -in $site_8_0 -x 5 -y 4 -width 334 -height 26 -anchor nw \
        -bordermode ignore 
    place $site_7_0.fra116 \
        -in $site_7_0 -x 5 -y 5 -width 315 -height 105 -anchor nw \
        -bordermode ignore 
    place $site_7_0.fra117 \
        -in $site_7_0 -x 380 -y 5 -width 345 -height 65 -anchor nw \
        -bordermode ignore 
    place $site_7_0.fra84 \
        -in $site_7_0 -x 380 -y 73 -width 345 -height 35 -anchor nw \
        -bordermode ignore 
    place $site_6_0.cpd84 \
        -in $site_6_0 -x 2 -y 3 -width 735 -height 115 -anchor nw \
        -bordermode ignore 
    set site_6_1 [$site_4_0.not83 getframe page2]
    frame $site_6_1.fra88 \
        -borderwidth 2 -relief groove -background #EFEBEF -height 105 \
        -width 285 
    vTcl:DefineAlias "$site_6_1.fra88" "Frame11" vTcl:WidgetProc "Toplevel1" 1
    set site_7_0 $site_6_1.fra88
    label $site_7_0.cpd91 \
        -background #EFEBEF -font {Arial 10} -text {IN COUNT :} 
    vTcl:DefineAlias "$site_7_0.cpd91" "Label37" vTcl:WidgetProc "Toplevel1" 1
    label $site_7_0.cpd117 \
        -background #EFEBEF -font {Arial 10} -text {TOTAL COUNT :} 
    vTcl:DefineAlias "$site_7_0.cpd117" "Label42" vTcl:WidgetProc "Toplevel1" 1
    label $site_7_0.cpd118 \
        -background #EFEBEF -font {Arial 10} -text {PASS COUNT :} 
    vTcl:DefineAlias "$site_7_0.cpd118" "Label43" vTcl:WidgetProc "Toplevel1" 1
    label $site_7_0.cpd119 \
        -background #EFEBEF -font {Arial 10} -text {YIELD RATE :} 
    vTcl:DefineAlias "$site_7_0.cpd119" "Label44" vTcl:WidgetProc "Toplevel1" 1
    label $site_7_0.cpd127 \
        -background #B0E0E6 -font {Arial 10 bold} -textvariable g_incount 
    vTcl:DefineAlias "$site_7_0.cpd127" "Label47" vTcl:WidgetProc "Toplevel1" 1
    label $site_7_0.cpd128 \
        -background #B0E0E6 -font {Arial 10 bold} -textvariable g_totalcount 
    vTcl:DefineAlias "$site_7_0.cpd128" "Label48" vTcl:WidgetProc "Toplevel1" 1
    label $site_7_0.cpd129 \
        -background #B0E0E6 -font {Arial 10 bold} -textvariable g_goodcount 
    vTcl:DefineAlias "$site_7_0.cpd129" "Label49" vTcl:WidgetProc "Toplevel1" 1
    label $site_7_0.cpd130 \
        -background #B0E0E6 -font {Arial 10 bold} -textvariable g_yieldrate 
    vTcl:DefineAlias "$site_7_0.cpd130" "Label50" vTcl:WidgetProc "Toplevel1" 1
    place $site_7_0.cpd91 \
        -in $site_7_0 -x 5 -y 5 -width 110 -height 20 -anchor nw \
        -bordermode ignore 
    place $site_7_0.cpd117 \
        -in $site_7_0 -x 5 -y 28 -width 110 -height 20 -anchor nw \
        -bordermode ignore 
    place $site_7_0.cpd118 \
        -in $site_7_0 -x 5 -y 52 -width 110 -height 20 -anchor nw \
        -bordermode ignore 
    place $site_7_0.cpd119 \
        -in $site_7_0 -x 5 -y 76 -width 110 -height 20 -anchor nw \
        -bordermode ignore 
    place $site_7_0.cpd127 \
        -in $site_7_0 -x 120 -y 5 -width 150 -height 20 -anchor nw \
        -bordermode ignore 
    place $site_7_0.cpd128 \
        -in $site_7_0 -x 120 -y 28 -width 150 -height 20 -anchor nw \
        -bordermode ignore 
    place $site_7_0.cpd129 \
        -in $site_7_0 -x 120 -y 52 -width 150 -height 20 -anchor nw \
        -bordermode ignore 
    place $site_7_0.cpd130 \
        -in $site_7_0 -x 120 -y 76 -width 150 -height 20 -anchor nw \
        -bordermode ignore 
    frame $site_6_1.fra120 \
        -borderwidth 2 -relief groove -background #EFEBEF -height 105 \
        -width 435 
    vTcl:DefineAlias "$site_6_1.fra120" "Frame10" vTcl:WidgetProc "Toplevel1" 1
    set site_7_0 $site_6_1.fra120
    label $site_7_0.cpd121 \
        -background #EFEBEF -font {Arial 10} -text {PASS COUNT :} 
    vTcl:DefineAlias "$site_7_0.cpd121" "Label45" vTcl:WidgetProc "Toplevel1" 1
    label $site_7_0.cpd122 \
        -background #EFEBEF -font {Arial 10} -text {FAIL COUNT :} 
    vTcl:DefineAlias "$site_7_0.cpd122" "Label46" vTcl:WidgetProc "Toplevel1" 1
    entry $site_7_0.ent123 \
        -background white -textvariable g_passcount 
    vTcl:DefineAlias "$site_7_0.ent123" "Entry4" vTcl:WidgetProc "Toplevel1" 1
    entry $site_7_0.ent124 \
        -background white -textvariable g_failcount 
    vTcl:DefineAlias "$site_7_0.ent124" "Entry5" vTcl:WidgetProc "Toplevel1" 1
    frame $site_7_0.fra83 \
        -borderwidth 2 -relief groove -background #EFEBEF -height 45 \
        -width 425 
    vTcl:DefineAlias "$site_7_0.fra83" "Frame16" vTcl:WidgetProc "Toplevel1" 1
    set site_8_0 $site_7_0.fra83
    button $site_8_0.but84 \
        -background #CEE3F6 -command BTN_INPUT_TESTRESULT \
        -font {Arial 10 bold} -pady 0 -takefocus 0 -text SUBMIT 
    vTcl:DefineAlias "$site_8_0.but84" "Button7" vTcl:WidgetProc "Toplevel1" 1
    place $site_8_0.but84 \
        -in $site_8_0 -x 4 -y 4 -width 414 -height 36 -anchor nw \
        -bordermode ignore 
    place $site_7_0.cpd121 \
        -in $site_7_0 -x 5 -y 3 -width 120 -height 22 -anchor nw \
        -bordermode ignore 
    place $site_7_0.cpd122 \
        -in $site_7_0 -x 5 -y 27 -width 120 -height 22 -anchor nw \
        -bordermode ignore 
    place $site_7_0.ent123 \
        -in $site_7_0 -x 128 -y 5 -width 295 -height 20 -anchor nw \
        -bordermode ignore 
    place $site_7_0.ent124 \
        -in $site_7_0 -x 128 -y 28 -width 295 -height 20 -anchor nw \
        -bordermode ignore 
    place $site_7_0.fra83 \
        -in $site_7_0 -x 4 -y 53 -width 425 -height 45 -anchor nw \
        -bordermode ignore 
    place $site_6_1.fra88 \
        -in $site_6_1 -x 3 -y 5 -width 285 -height 105 -anchor nw \
        -bordermode ignore 
    place $site_6_1.fra120 \
        -in $site_6_1 -x 300 -y 5 -width 435 -height 105 -anchor nw \
        -bordermode ignore 
    $site_4_0.not83 raise page1
    NoteBook $site_4_0.not84 \
        -background #EFEBEF -height 178 -width 744 
    vTcl:DefineAlias "$site_4_0.not84" "NoteBook7" vTcl:WidgetProc "Toplevel1" 1
    $site_4_0.not84 insert end page1 \
        -text MAIN 
    $site_4_0.not84 insert end page2 \
        -text SUB 
    set site_6_0 [$site_4_0.not84 getframe page1]
    frame $site_6_0.cpd85 \
        -borderwidth 2 -relief groove -background #EFEBEF -height 145 \
        -width 734 
    vTcl:DefineAlias "$site_6_0.cpd85" "Frame1" vTcl:WidgetProc "Toplevel1" 1
    set site_7_0 $site_6_0.cpd85
    label $site_7_0.lab87 \
        -anchor center -background #EFEBEF -font {Arial 10} -text {LOTNAME :} 
    vTcl:DefineAlias "$site_7_0.lab87" "Label1" vTcl:WidgetProc "Toplevel1" 1
    label $site_7_0.cpd88 \
        -background #EFEBEF -font {Arial 10} -text {DEVICE :} 
    vTcl:DefineAlias "$site_7_0.cpd88" "Label2" vTcl:WidgetProc "Toplevel1" 1
    label $site_7_0.cpd89 \
        -anchor center -background #EFEBEF -font {Arial 10} \
        -text {TEST PGM :} 
    vTcl:DefineAlias "$site_7_0.cpd89" "Label3" vTcl:WidgetProc "Toplevel1" 1
    label $site_7_0.cpd90 \
        -anchor center -background #EFEBEF -font {Arial 10} \
        -text {CUSTOMER :} 
    vTcl:DefineAlias "$site_7_0.cpd90" "Label4" vTcl:WidgetProc "Toplevel1" 1
    label $site_7_0.cpd91 \
        -background #EFEBEF -font {Arial 10} -text {OPERATION :} 
    vTcl:DefineAlias "$site_7_0.cpd91" "Label5" vTcl:WidgetProc "Toplevel1" 1
    label $site_7_0.cpd92 \
        -anchor center -background #EFEBEF -font {Arial 10} -text {DCC :} 
    vTcl:DefineAlias "$site_7_0.cpd92" "Label6" vTcl:WidgetProc "Toplevel1" 1
    label $site_7_0.cpd93 \
        -background #EFEBEF -font {Arial 10} -text {REV :} 
    vTcl:DefineAlias "$site_7_0.cpd93" "Label7" vTcl:WidgetProc "Toplevel1" 1
    label $site_7_0.cpd94 \
        -anchor center -background #EFEBEF -font {Arial 10} \
        -text {CONDITION :} 
    vTcl:DefineAlias "$site_7_0.cpd94" "Label8" vTcl:WidgetProc "Toplevel1" 1
    label $site_7_0.cpd95 \
        -anchor center -background #EFEBEF -font {Arial 10} \
        -text {IN COUNT :} 
    vTcl:DefineAlias "$site_7_0.cpd95" "Label9" vTcl:WidgetProc "Toplevel1" 1
    label $site_7_0.cpd96 \
        -background #EFEBEF -font {Arial 10} -text {TEST TIME :} 
    vTcl:DefineAlias "$site_7_0.cpd96" "Label10" vTcl:WidgetProc "Toplevel1" 1
    label $site_7_0.cpd97 \
        -anchor center -background #EFEBEF -font {Arial 10} \
        -text {YIELD LIMIT :} 
    vTcl:DefineAlias "$site_7_0.cpd97" "Label11" vTcl:WidgetProc "Toplevel1" 1
    label $site_7_0.cpd98 \
        -anchor center -background #EFEBEF -font {Arial 10} \
        -text {QA SAMPLE :} 
    vTcl:DefineAlias "$site_7_0.cpd98" "Label12" vTcl:WidgetProc "Toplevel1" 1
    label $site_7_0.cpd102 \
        -anchor center -background #B0E0E6 -font {Arial 11} \
        -textvariable g_lotname 
    vTcl:DefineAlias "$site_7_0.cpd102" "Label14" vTcl:WidgetProc "Toplevel1" 1
    label $site_7_0.cpd103 \
        -anchor center -background #B0E0E6 -font {Arial 11} \
        -textvariable g_dcc 
    vTcl:DefineAlias "$site_7_0.cpd103" "Label15" vTcl:WidgetProc "Toplevel1" 1
    label $site_7_0.cpd104 \
        -background #B0E0E6 -font {Arial 11} -textvariable g_operation 
    vTcl:DefineAlias "$site_7_0.cpd104" "Label16" vTcl:WidgetProc "Toplevel1" 1
    label $site_7_0.cpd105 \
        -activeforeground #000000 -anchor center -background #B0E0E6 \
        -font {Arial 11} -textvariable g_devicename 
    vTcl:DefineAlias "$site_7_0.cpd105" "Label17" vTcl:WidgetProc "Toplevel1" 1
    label $site_7_0.cpd106 \
        -background #B0E0E6 -font {Arial 11} -textvariable g_customer \
        -width 154 
    vTcl:DefineAlias "$site_7_0.cpd106" "Label18" vTcl:WidgetProc "Toplevel1" 1
    label $site_7_0.cpd108 \
        -background #B0E0E6 -font {Arial 11} -textvariable g_testprogramrev 
    vTcl:DefineAlias "$site_7_0.cpd108" "Label20" vTcl:WidgetProc "Toplevel1" 1
    label $site_7_0.cpd109 \
        -anchor center -background #B0E0E6 -font {Arial 11} \
        -textvariable g_condition 
    vTcl:DefineAlias "$site_7_0.cpd109" "Label21" vTcl:WidgetProc "Toplevel1" 1
    label $site_7_0.cpd110 \
        -background #B0E0E6 -font {Arial 11} -textvariable g_testtime 
    vTcl:DefineAlias "$site_7_0.cpd110" "Label22" vTcl:WidgetProc "Toplevel1" 1
    label $site_7_0.cpd111 \
        -anchor center -background #B0E0E6 -font {Arial 11} \
        -textvariable g_yieldlimit 
    vTcl:DefineAlias "$site_7_0.cpd111" "Label23" vTcl:WidgetProc "Toplevel1" 1
    label $site_7_0.cpd112 \
        -anchor center -background #B0E0E6 -font {Arial 11} \
        -textvariable g_incount 
    vTcl:DefineAlias "$site_7_0.cpd112" "Label24" vTcl:WidgetProc "Toplevel1" 1
    label $site_7_0.cpd114 \
        -anchor center -background #B0E0E6 -font {Arial 11} \
        -textvariable g_qasample 
    vTcl:DefineAlias "$site_7_0.cpd114" "Label26" vTcl:WidgetProc "Toplevel1" 1
    label $site_7_0.cpd100 \
        -anchor center -background #EFEBEF -font {Arial 10} -text {P/D/L :} 
    vTcl:DefineAlias "$site_7_0.cpd100" "Label38" vTcl:WidgetProc "Toplevel1" 1
    label $site_7_0.cpd101 \
        -background #B0E0E6 -font {Arial 11} -textvariable g_package 
    vTcl:DefineAlias "$site_7_0.cpd101" "Label39" vTcl:WidgetProc "Toplevel1" 1
    label $site_7_0.cpd115 \
        -background #B0E0E6 -font {Arial 11} -textvariable g_dimension 
    vTcl:DefineAlias "$site_7_0.cpd115" "Label40" vTcl:WidgetProc "Toplevel1" 1
    label $site_7_0.cpd116 \
        -background #B0E0E6 -font {Arial 11} -textvariable g_lead 
    vTcl:DefineAlias "$site_7_0.cpd116" "Label41" vTcl:WidgetProc "Toplevel1" 1
    label $site_7_0.cpd85 \
        -anchor center -background #B0E0E6 -font {Arial 11} \
        -textvariable g_job 
    vTcl:DefineAlias "$site_7_0.cpd85" "Label53" vTcl:WidgetProc "Toplevel1" 1
    label $site_7_0.lab88 \
        -background #B0E0E6 -font {Arial 11} -textvariable g_testprogram 
    vTcl:DefineAlias "$site_7_0.lab88" "Label87" vTcl:WidgetProc "Toplevel1" 1
    label $site_7_0.cpd83 \
        -background #EFEBEF -font {Arial 11} -foreground #EFEBEF \
        -textvariable g_handlertype 
    vTcl:DefineAlias "$site_7_0.cpd83" "Label56" vTcl:WidgetProc "Toplevel1" 1
    place $site_7_0.lab87 \
        -in $site_7_0 -x 4 -y 5 -width 90 -height 20 -anchor nw \
        -bordermode ignore 
    place $site_7_0.cpd88 \
        -in $site_7_0 -x 4 -y 28 -width 90 -height 20 -anchor nw \
        -bordermode ignore 
    place $site_7_0.cpd89 \
        -in $site_7_0 -x 4 -y 51 -width 90 -height 20 -anchor nw \
        -bordermode ignore 
    place $site_7_0.cpd90 \
        -in $site_7_0 -x 370 -y 27 -width 95 -height 20 -anchor nw \
        -bordermode ignore 
    place $site_7_0.cpd91 \
        -in $site_7_0 -x 462 -y 5 -width 100 -height 20 -anchor nw \
        -bordermode ignore 
    place $site_7_0.cpd92 \
        -in $site_7_0 -x 626 -y 27 -width 55 -height 20 -anchor nw \
        -bordermode ignore 
    place $site_7_0.cpd93 \
        -in $site_7_0 -x 563 -y 52 -width 60 -height 20 -anchor nw \
        -bordermode ignore 
    place $site_7_0.cpd94 \
        -in $site_7_0 -x 4 -y 74 -width 90 -height 20 -anchor nw \
        -bordermode ignore 
    place $site_7_0.cpd95 \
        -in $site_7_0 -x 200 -y 99 -width 85 -height 20 -anchor nw \
        -bordermode ignore 
    place $site_7_0.cpd96 \
        -in $site_7_0 -x 430 -y 75 -width 105 -height 20 -anchor nw \
        -bordermode ignore 
    place $site_7_0.cpd97 \
        -in $site_7_0 -x 4 -y 97 -width 90 -height 20 -anchor nw \
        -bordermode ignore 
    place $site_7_0.cpd98 \
        -in $site_7_0 -x 5 -y 120 -width 90 -height 20 -anchor nw \
        -bordermode ignore 
    place $site_7_0.cpd102 \
        -in $site_7_0 -x 100 -y 5 -width 355 -height 20 -anchor nw \
        -bordermode ignore 
    place $site_7_0.cpd103 \
        -in $site_7_0 -x 682 -y 28 -width 45 -height 20 -anchor nw \
        -bordermode ignore 
    place $site_7_0.cpd104 \
        -in $site_7_0 -x 564 -y 5 -width 70 -height 20 -anchor nw \
        -bordermode ignore 
    place $site_7_0.cpd105 \
        -in $site_7_0 -x 100 -y 28 -width 260 -height 20 -anchor nw \
        -bordermode ignore 
    place $site_7_0.cpd106 \
        -in $site_7_0 -x 468 -y 28 -width 158 -height 20 -anchor nw \
        -bordermode ignore 
    place $site_7_0.cpd108 \
        -in $site_7_0 -x 632 -y 52 -width 95 -height 20 -anchor nw \
        -bordermode ignore 
    place $site_7_0.cpd109 \
        -in $site_7_0 -x 100 -y 75 -width 321 -height 20 -anchor nw \
        -bordermode ignore 
    place $site_7_0.cpd110 \
        -in $site_7_0 -x 540 -y 76 -width 187 -height 20 -anchor nw \
        -bordermode ignore 
    place $site_7_0.cpd111 \
        -in $site_7_0 -x 100 -y 98 -width 85 -height 20 -anchor nw \
        -bordermode ignore 
    place $site_7_0.cpd112 \
        -in $site_7_0 -x 287 -y 98 -width 134 -height 20 -anchor nw \
        -bordermode ignore 
    place $site_7_0.cpd114 \
        -in $site_7_0 -x 100 -y 121 -width 85 -height 20 -anchor nw \
        -bordermode ignore 
    place $site_7_0.cpd100 \
        -in $site_7_0 -x 432 -y 95 -width 100 -height 20 -anchor nw \
        -bordermode ignore 
    place $site_7_0.cpd101 \
        -in $site_7_0 -x 540 -y 99 -width 53 -height 20 -anchor nw \
        -bordermode ignore 
    place $site_7_0.cpd115 \
        -in $site_7_0 -x 608 -y 100 -width 53 -height 20 -anchor nw \
        -bordermode ignore 
    place $site_7_0.cpd116 \
        -in $site_7_0 -x 674 -y 99 -width 53 -height 20 -anchor nw \
        -bordermode ignore 
    place $site_7_0.cpd85 \
        -in $site_7_0 -x 642 -y 5 -width 85 -height 20 -anchor nw \
        -bordermode ignore 
    place $site_7_0.lab88 \
        -in $site_7_0 -x 100 -y 52 -width 455 -height 20 -anchor nw \
        -bordermode ignore 
    place $site_7_0.cpd83 \
        -in $site_7_0 -x 189 -y 118 -width 16 -height 23 -anchor nw \
        -bordermode ignore 
    place $site_6_0.cpd85 \
        -in $site_6_0 -x 5 -y 5 -width 734 -height 145 -anchor nw \
        -bordermode ignore 
    set site_6_1 [$site_4_0.not84 getframe page2]
    frame $site_6_1.fra86 \
        -borderwidth 2 -background #EFEBEF -height 145 -width 540 
    vTcl:DefineAlias "$site_6_1.fra86" "Frame24" vTcl:WidgetProc "Toplevel1" 1
    set site_7_0 $site_6_1.fra86
    label $site_7_0.cpd87 \
        -background #EFEBEF -font {Arial  10} -text {SWR MSG :} 
    vTcl:DefineAlias "$site_7_0.cpd87" "Label51" vTcl:WidgetProc "Toplevel1" 1
    label $site_7_0.cpd88 \
        -background #B0E0E6 -font {{MS Sans Serif} 9} \
        -textvariable g_swrmessage 
    vTcl:DefineAlias "$site_7_0.cpd88" "Label52" vTcl:WidgetProc "Toplevel1" 1
    label $site_7_0.cpd89 \
        -background #EFEBEF -font {Arial 10} -text {SWR NO :} 
    vTcl:DefineAlias "$site_7_0.cpd89" "Label13" vTcl:WidgetProc "Toplevel1" 1
    label $site_7_0.cpd90 \
        -background #B0E0E6 -font {{MS Sans Serif} 9} \
        -textvariable g_swrnumber 
    vTcl:DefineAlias "$site_7_0.cpd90" "Label25" vTcl:WidgetProc "Toplevel1" 1
    place $site_7_0.cpd87 \
        -in $site_7_0 -x 3 -y 4 -width 90 -height 22 -anchor nw \
        -bordermode ignore 
    place $site_7_0.cpd88 \
        -in $site_7_0 -x 97 -y 5 -width 120 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_7_0.cpd89 \
        -in $site_7_0 -x 224 -y 5 -width 90 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_7_0.cpd90 \
        -in $site_7_0 -x 317 -y 5 -width 81 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_6_1.fra86 \
        -in $site_6_1 -x 1 -y 5 -width 539 -height 145 -anchor nw \
        -bordermode ignore 
    $site_4_0.not84 raise page1
    place $site_4_0.not85 \
        -in $site_4_0 -x 6 -y 5 -width 740 -height 208 -anchor nw \
        -bordermode ignore 
    place $site_4_0.not83 \
        -in $site_4_0 -x 5 -y 375 -width 743 -height 143 -anchor nw \
        -bordermode ignore 
    place $site_4_0.not84 \
        -in $site_4_0 -x 5 -y 214 -width 744 -height 178 -anchor nw \
        -bordermode ignore 
    set site_4_1 [$top.not84 getframe page2]
    NoteBook $site_4_1.not85 \
        -activebackground #cad3ec -background #EFEBEF -font {Arial 10} \
        -height 513 -width 744 
    vTcl:DefineAlias "$site_4_1.not85" "NoteBook4" vTcl:WidgetProc "Toplevel1" 1
    $site_4_1.not85 insert end page1 \
        -text BOARD 
    $site_4_1.not85 insert end page2 \
        -text PROBE 
    set site_6_0 [$site_4_1.not85 getframe page1]
    frame $site_6_0.fra161 \
        -borderwidth 2 -relief groove -background #EFEBEF -height 55 \
        -width 670 
    vTcl:DefineAlias "$site_6_0.fra161" "Frame38" vTcl:WidgetProc "Toplevel1" 1
    set site_7_0 $site_6_0.fra161
    label $site_7_0.cpd162 \
        -background #EFEBEF -font {Arial 10} -text {HANDLER :} 
    vTcl:DefineAlias "$site_7_0.cpd162" "Label154" vTcl:WidgetProc "Toplevel1" 1
    label $site_7_0.cpd163 \
        -background #B0E0E6 -font {Arial 10} -textvariable g_handler 
    vTcl:DefineAlias "$site_7_0.cpd163" "Label155" vTcl:WidgetProc "Toplevel1" 1
    label $site_7_0.cpd164 \
        -background #EFEBEF -font {Arial 10} -text {BOARD :} 
    vTcl:DefineAlias "$site_7_0.cpd164" "Label156" vTcl:WidgetProc "Toplevel1" 1
    label $site_7_0.cpd165 \
        -background #B0E0E6 -font {Arial 10} -textvariable g_board 
    vTcl:DefineAlias "$site_7_0.cpd165" "Label157" vTcl:WidgetProc "Toplevel1" 1
    label $site_7_0.cpd166 \
        -background #EFEBEF -font {Arial 10} -text {CHANGE KIT :} 
    vTcl:DefineAlias "$site_7_0.cpd166" "Label158" vTcl:WidgetProc "Toplevel1" 1
    label $site_7_0.cpd167 \
        -background #B0E0E6 -font {Arial 10} -textvariable g_kit 
    vTcl:DefineAlias "$site_7_0.cpd167" "Label159" vTcl:WidgetProc "Toplevel1" 1
    label $site_7_0.cpd168 \
        -background #EFEBEF -font {Arial 10} -text {BOARD NO :} 
    vTcl:DefineAlias "$site_7_0.cpd168" "Label160" vTcl:WidgetProc "Toplevel1" 1
    label $site_7_0.cpd169 \
        -background #B0E0E6 -font {Arial 10} -textvariable g_boardno 
    vTcl:DefineAlias "$site_7_0.cpd169" "Label161" vTcl:WidgetProc "Toplevel1" 1
    label $site_7_0.cpd170 \
        -background #EFEBEF -font {Arial 10} -text {BOARD DSC :} 
    vTcl:DefineAlias "$site_7_0.cpd170" "Label162" vTcl:WidgetProc "Toplevel1" 1
    label $site_7_0.cpd171 \
        -background #B0E0E6 -font {Arial 10} -textvariable g_boarddescription \
        -width 345 
    vTcl:DefineAlias "$site_7_0.cpd171" "Label163" vTcl:WidgetProc "Toplevel1" 1
    place $site_7_0.cpd162 \
        -in $site_7_0 -x 4 -y 5 -width 90 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_7_0.cpd163 \
        -in $site_7_0 -x 99 -y 5 -width 100 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_7_0.cpd164 \
        -in $site_7_0 -x 202 -y 5 -width 90 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_7_0.cpd165 \
        -in $site_7_0 -x 303 -y 5 -width 120 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_7_0.cpd166 \
        -in $site_7_0 -x 431 -y 5 -width 90 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_7_0.cpd167 \
        -in $site_7_0 -x 527 -y 5 -width 120 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_7_0.cpd168 \
        -in $site_7_0 -x 5 -y 29 -width 90 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_7_0.cpd169 \
        -in $site_7_0 -x 99 -y 30 -width 100 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_7_0.cpd170 \
        -in $site_7_0 -x 201 -y 30 -width 100 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_7_0.cpd171 \
        -in $site_7_0 -x 303 -y 30 -width 345 -height 19 -anchor nw \
        -bordermode ignore 
    NoteBook $site_6_0.not173 \
        -background #EFEBEF -font {Arial 10 bold} -height 348 -width 724 
    vTcl:DefineAlias "$site_6_0.not173" "NoteBook9" vTcl:WidgetProc "Toplevel1" 1
    $site_6_0.not173 insert end page1 \
        -text SOCKET(16) 
    $site_6_0.not173 insert end page2 \
        -text SOCKET(32) 
    $site_6_0.not173 insert end page4 \
        -text SOCKET(48) 
    $site_6_0.not173 insert end page3 \
        -text SOCKET(64) 
    set site_8_0 [$site_6_0.not173 getframe page1]
    frame $site_8_0.fra197 \
        -borderwidth 2 -relief groove -background #EFEBEF -height 315 \
        -width 715 
    vTcl:DefineAlias "$site_8_0.fra197" "Frame59" vTcl:WidgetProc "Toplevel1" 1
    set site_9_0 $site_8_0.fra197
    frame $site_9_0.cpd198 \
        -borderwidth 2 -relief groove -background #EFEBEF -height 305 \
        -width 290 
    vTcl:DefineAlias "$site_9_0.cpd198" "Frame39" vTcl:WidgetProc "Toplevel1" 1
    set site_10_0 $site_9_0.cpd198
    frame $site_10_0.fra176 \
        -borderwidth 2 -background #EFEBEF -height 30 -width 340 
    vTcl:DefineAlias "$site_10_0.fra176" "Frame40" vTcl:WidgetProc "Toplevel1" 1
    set site_11_0 $site_10_0.fra176
    checkbutton $site_11_0.che177 \
        -background #EFEBEF -takefocus 0 -variable g_socket_check1 
    vTcl:DefineAlias "$site_11_0.che177" "ckb_socket1" vTcl:WidgetProc "Toplevel1" 1
    entry $site_11_0.ent178 \
        -background white -takefocus 0 -textvariable g_socket1 
    vTcl:DefineAlias "$site_11_0.ent178" "g_ent_socket1" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.lab179 \
        -background #7f7ff0f09f9f -textvariable g_socket_touch1 
    vTcl:DefineAlias "$site_11_0.lab179" "Label164" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.cpd180 \
        -background #f0f0aeaeeeee -textvariable g_socket_limit1 
    vTcl:DefineAlias "$site_11_0.cpd180" "Label165" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.cpd181 \
        -background #9999b3b3ffff -textvariable g_socket_ext1 
    vTcl:DefineAlias "$site_11_0.cpd181" "Label166" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.lab101 \
        \
        -font [vTcl:font:getFontFromDescr "-family Arial -size 9 -weight normal -slant roman -underline 0 -overstrike 0"] \
        -text {[ 1 ]} 
    vTcl:DefineAlias "$site_11_0.lab101" "Label234" vTcl:WidgetProc "Toplevel1" 1
    place $site_11_0.che177 \
        -in $site_11_0 -x 35 -y 3 -width 18 -height 22 -anchor nw \
        -bordermode ignore 
    place $site_11_0.ent178 \
        -in $site_11_0 -x 55 -y 5 -width 101 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.lab179 \
        -in $site_11_0 -x 159 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.cpd180 \
        -in $site_11_0 -x 232 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.cpd181 \
        -in $site_11_0 -x 305 -y 5 -width 30 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.lab101 \
        -in $site_11_0 -x 5 -y 2 -width 25 -height 21 -anchor nw \
        -bordermode ignore 
    frame $site_10_0.cpd184 \
        -borderwidth 2 -background #EFEBEF -height 30 -width 340 
    vTcl:DefineAlias "$site_10_0.cpd184" "Frame41" vTcl:WidgetProc "Toplevel1" 1
    set site_11_0 $site_10_0.cpd184
    checkbutton $site_11_0.che177 \
        -background #EFEBEF -takefocus 0 -variable g_socket_check2 
    vTcl:DefineAlias "$site_11_0.che177" "ckb_socket2" vTcl:WidgetProc "Toplevel1" 1
    entry $site_11_0.ent178 \
        -background white -takefocus 0 -textvariable g_socket2 
    vTcl:DefineAlias "$site_11_0.ent178" "g_ent_socket2" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.lab179 \
        -background #7f7ff0f09f9f -textvariable g_socket_touch2 
    vTcl:DefineAlias "$site_11_0.lab179" "Label167" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.cpd180 \
        -background #f0f0aeaeeeee -textvariable g_socket_limit2 
    vTcl:DefineAlias "$site_11_0.cpd180" "Label168" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.cpd181 \
        -background #9999b3b3ffff -textvariable g_socket_ext2 
    vTcl:DefineAlias "$site_11_0.cpd181" "Label169" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.lab102 \
        \
        -font [vTcl:font:getFontFromDescr "-family Arial -size 9 -weight normal -slant roman -underline 0 -overstrike 0"] \
        -text {[ 2 ]} 
    vTcl:DefineAlias "$site_11_0.lab102" "Label235" vTcl:WidgetProc "Toplevel1" 1
    place $site_11_0.che177 \
        -in $site_11_0 -x 35 -y 3 -width 18 -height 22 -anchor nw \
        -bordermode ignore 
    place $site_11_0.ent178 \
        -in $site_11_0 -x 55 -y 5 -width 101 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.lab179 \
        -in $site_11_0 -x 159 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.cpd180 \
        -in $site_11_0 -x 232 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.cpd181 \
        -in $site_11_0 -x 305 -y 5 -width 30 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.lab102 \
        -in $site_11_0 -x 5 -y 2 -width 25 -height 21 -anchor nw \
        -bordermode ignore 
    frame $site_10_0.cpd185 \
        -borderwidth 2 -background #EFEBEF -height 30 -width 280 
    vTcl:DefineAlias "$site_10_0.cpd185" "Frame42" vTcl:WidgetProc "Toplevel1" 1
    set site_11_0 $site_10_0.cpd185
    checkbutton $site_11_0.che177 \
        -background #EFEBEF -takefocus 0 -variable g_socket_check3 
    vTcl:DefineAlias "$site_11_0.che177" "ckb_socket3" vTcl:WidgetProc "Toplevel1" 1
    entry $site_11_0.ent178 \
        -background white -takefocus 0 -textvariable g_socket3 
    vTcl:DefineAlias "$site_11_0.ent178" "g_ent_socket3" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.lab179 \
        -background #7f7ff0f09f9f -textvariable g_socket_touch3 
    vTcl:DefineAlias "$site_11_0.lab179" "Label170" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.cpd180 \
        -background #f0f0aeaeeeee -textvariable g_socket_limit3 
    vTcl:DefineAlias "$site_11_0.cpd180" "Label171" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.cpd181 \
        -background #9999b3b3ffff -textvariable g_socket_ext3 
    vTcl:DefineAlias "$site_11_0.cpd181" "Label172" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.lab103 \
        \
        -font [vTcl:font:getFontFromDescr "-family Arial -size 9 -weight normal -slant roman -underline 0 -overstrike 0"] \
        -text {[ 3 ]} 
    vTcl:DefineAlias "$site_11_0.lab103" "Label236" vTcl:WidgetProc "Toplevel1" 1
    place $site_11_0.che177 \
        -in $site_11_0 -x 35 -y 3 -width 18 -height 22 -anchor nw \
        -bordermode ignore 
    place $site_11_0.ent178 \
        -in $site_11_0 -x 55 -y 5 -width 101 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.lab179 \
        -in $site_11_0 -x 159 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.cpd180 \
        -in $site_11_0 -x 232 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.cpd181 \
        -in $site_11_0 -x 305 -y 5 -width 30 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.lab103 \
        -in $site_11_0 -x 5 -y 2 -width 25 -height 21 -anchor nw \
        -bordermode ignore 
    frame $site_10_0.cpd186 \
        -borderwidth 2 -background #EFEBEF -height 30 -width 280 
    vTcl:DefineAlias "$site_10_0.cpd186" "Frame43" vTcl:WidgetProc "Toplevel1" 1
    set site_11_0 $site_10_0.cpd186
    checkbutton $site_11_0.che177 \
        -background #EFEBEF -takefocus 0 -variable g_socket_check4 
    vTcl:DefineAlias "$site_11_0.che177" "ckb_socket4" vTcl:WidgetProc "Toplevel1" 1
    entry $site_11_0.ent178 \
        -background white -takefocus 0 -textvariable g_socket4 
    vTcl:DefineAlias "$site_11_0.ent178" "g_ent_socket4" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.lab179 \
        -background #7f7ff0f09f9f -textvariable g_socket_touch4 
    vTcl:DefineAlias "$site_11_0.lab179" "Label173" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.cpd180 \
        -background #f0f0aeaeeeee -textvariable g_socket_limit4 
    vTcl:DefineAlias "$site_11_0.cpd180" "Label174" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.cpd181 \
        -background #9999b3b3ffff -textvariable g_socket_ext4 
    vTcl:DefineAlias "$site_11_0.cpd181" "Label175" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.lab104 \
        \
        -font [vTcl:font:getFontFromDescr "-family Arial -size 9 -weight normal -slant roman -underline 0 -overstrike 0"] \
        -text {[ 4 ]} 
    vTcl:DefineAlias "$site_11_0.lab104" "Label237" vTcl:WidgetProc "Toplevel1" 1
    place $site_11_0.che177 \
        -in $site_11_0 -x 35 -y 3 -width 18 -height 22 -anchor nw \
        -bordermode ignore 
    place $site_11_0.ent178 \
        -in $site_11_0 -x 55 -y 5 -width 101 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.lab179 \
        -in $site_11_0 -x 159 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.cpd180 \
        -in $site_11_0 -x 232 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.cpd181 \
        -in $site_11_0 -x 305 -y 5 -width 30 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.lab104 \
        -in $site_11_0 -x 5 -y 2 -width 25 -height 21 -anchor nw \
        -bordermode ignore 
    frame $site_10_0.cpd187 \
        -borderwidth 2 -background #EFEBEF -height 30 -width 280 
    vTcl:DefineAlias "$site_10_0.cpd187" "Frame44" vTcl:WidgetProc "Toplevel1" 1
    set site_11_0 $site_10_0.cpd187
    checkbutton $site_11_0.che177 \
        -background #EFEBEF -takefocus 0 -variable g_socket_check5 
    vTcl:DefineAlias "$site_11_0.che177" "ckb_socket5" vTcl:WidgetProc "Toplevel1" 1
    entry $site_11_0.ent178 \
        -background white -takefocus 0 -textvariable g_socket5 
    vTcl:DefineAlias "$site_11_0.ent178" "g_ent_socket5" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.lab179 \
        -background #7f7ff0f09f9f -textvariable g_socket_touch5 
    vTcl:DefineAlias "$site_11_0.lab179" "Label176" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.cpd180 \
        -background #f0f0aeaeeeee -textvariable g_socket_limit5 
    vTcl:DefineAlias "$site_11_0.cpd180" "Label177" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.cpd181 \
        -background #9999b3b3ffff -textvariable g_socket_ext5 
    vTcl:DefineAlias "$site_11_0.cpd181" "Label178" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.lab105 \
        \
        -font [vTcl:font:getFontFromDescr "-family Arial -size 9 -weight normal -slant roman -underline 0 -overstrike 0"] \
        -text {[ 5 ]} 
    vTcl:DefineAlias "$site_11_0.lab105" "Label238" vTcl:WidgetProc "Toplevel1" 1
    place $site_11_0.che177 \
        -in $site_11_0 -x 35 -y 3 -width 18 -height 22 -anchor nw \
        -bordermode ignore 
    place $site_11_0.ent178 \
        -in $site_11_0 -x 55 -y 5 -width 101 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.lab179 \
        -in $site_11_0 -x 159 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.cpd180 \
        -in $site_11_0 -x 232 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.cpd181 \
        -in $site_11_0 -x 305 -y 5 -width 30 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.lab105 \
        -in $site_11_0 -x 4 -y 2 -width 25 -height 21 -anchor nw \
        -bordermode ignore 
    frame $site_10_0.cpd188 \
        -borderwidth 2 -background #EFEBEF -height 30 -width 280 
    vTcl:DefineAlias "$site_10_0.cpd188" "Frame45" vTcl:WidgetProc "Toplevel1" 1
    set site_11_0 $site_10_0.cpd188
    checkbutton $site_11_0.che177 \
        -background #EFEBEF -takefocus 0 -variable g_socket_check6 
    vTcl:DefineAlias "$site_11_0.che177" "ckb_socket6" vTcl:WidgetProc "Toplevel1" 1
    entry $site_11_0.ent178 \
        -background white -takefocus 0 -textvariable g_socket6 
    vTcl:DefineAlias "$site_11_0.ent178" "g_ent_socket6" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.lab179 \
        -background #7f7ff0f09f9f -textvariable g_socket_touch6 
    vTcl:DefineAlias "$site_11_0.lab179" "Label179" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.cpd180 \
        -background #f0f0aeaeeeee -textvariable g_socket_limit6 
    vTcl:DefineAlias "$site_11_0.cpd180" "Label180" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.cpd181 \
        -background #9999b3b3ffff -textvariable g_socket_ext6 
    vTcl:DefineAlias "$site_11_0.cpd181" "Label181" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.lab107 \
        \
        -font [vTcl:font:getFontFromDescr "-family Arial -size 9 -weight normal -slant roman -underline 0 -overstrike 0"] \
        -text {[ 6 ]} 
    vTcl:DefineAlias "$site_11_0.lab107" "Label239" vTcl:WidgetProc "Toplevel1" 1
    place $site_11_0.che177 \
        -in $site_11_0 -x 35 -y 3 -width 18 -height 22 -anchor nw \
        -bordermode ignore 
    place $site_11_0.ent178 \
        -in $site_11_0 -x 55 -y 5 -width 101 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.lab179 \
        -in $site_11_0 -x 159 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.cpd180 \
        -in $site_11_0 -x 232 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.cpd181 \
        -in $site_11_0 -x 305 -y 5 -width 30 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.lab107 \
        -in $site_11_0 -x 5 -y 2 -anchor nw -bordermode ignore 
    frame $site_10_0.cpd189 \
        -borderwidth 2 -background #EFEBEF -height 30 -width 280 
    vTcl:DefineAlias "$site_10_0.cpd189" "Frame46" vTcl:WidgetProc "Toplevel1" 1
    set site_11_0 $site_10_0.cpd189
    checkbutton $site_11_0.che177 \
        -background #EFEBEF -takefocus 0 -variable g_socket_check7 
    vTcl:DefineAlias "$site_11_0.che177" "ckb_socket7" vTcl:WidgetProc "Toplevel1" 1
    entry $site_11_0.ent178 \
        -background white -takefocus 0 -textvariable g_socket7 
    vTcl:DefineAlias "$site_11_0.ent178" "g_ent_socket7" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.lab179 \
        -background #7f7ff0f09f9f -textvariable g_socket_touch7 
    vTcl:DefineAlias "$site_11_0.lab179" "Label182" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.cpd180 \
        -background #f0f0aeaeeeee -textvariable g_socket_limit7 
    vTcl:DefineAlias "$site_11_0.cpd180" "Label183" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.cpd181 \
        -background #9999b3b3ffff -textvariable g_socket_ext7 
    vTcl:DefineAlias "$site_11_0.cpd181" "Label184" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.lab108 \
        \
        -font [vTcl:font:getFontFromDescr "-family Arial -size 9 -weight normal -slant roman -underline 0 -overstrike 0"] \
        -text {[ 7 ]} 
    vTcl:DefineAlias "$site_11_0.lab108" "Label240" vTcl:WidgetProc "Toplevel1" 1
    place $site_11_0.che177 \
        -in $site_11_0 -x 35 -y 3 -width 18 -height 22 -anchor nw \
        -bordermode ignore 
    place $site_11_0.ent178 \
        -in $site_11_0 -x 55 -y 5 -width 101 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.lab179 \
        -in $site_11_0 -x 159 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.cpd180 \
        -in $site_11_0 -x 232 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.cpd181 \
        -in $site_11_0 -x 305 -y 5 -width 30 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.lab108 \
        -in $site_11_0 -x 5 -y 2 -anchor nw -bordermode ignore 
    frame $site_10_0.cpd190 \
        -borderwidth 2 -background #EFEBEF -height 30 -width 280 
    vTcl:DefineAlias "$site_10_0.cpd190" "Frame47" vTcl:WidgetProc "Toplevel1" 1
    set site_11_0 $site_10_0.cpd190
    checkbutton $site_11_0.che177 \
        -background #EFEBEF -takefocus 0 -variable g_socket_check8 
    vTcl:DefineAlias "$site_11_0.che177" "ckb_socket8" vTcl:WidgetProc "Toplevel1" 1
    entry $site_11_0.ent178 \
        -background white -takefocus 0 -textvariable g_socket8 
    vTcl:DefineAlias "$site_11_0.ent178" "g_ent_socket8" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.lab179 \
        -background #7f7ff0f09f9f -textvariable g_socket_touch8 
    vTcl:DefineAlias "$site_11_0.lab179" "Label185" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.cpd180 \
        -background #f0f0aeaeeeee -textvariable g_socket_limit8 
    vTcl:DefineAlias "$site_11_0.cpd180" "Label186" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.cpd181 \
        -background #9999b3b3ffff -textvariable g_socket_ext8 
    vTcl:DefineAlias "$site_11_0.cpd181" "Label187" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.lab109 \
        \
        -font [vTcl:font:getFontFromDescr "-family Arial -size 9 -weight normal -slant roman -underline 0 -overstrike 0"] \
        -text {[ 8 ]} 
    vTcl:DefineAlias "$site_11_0.lab109" "Label241" vTcl:WidgetProc "Toplevel1" 1
    place $site_11_0.che177 \
        -in $site_11_0 -x 35 -y 3 -width 18 -height 22 -anchor nw \
        -bordermode ignore 
    place $site_11_0.ent178 \
        -in $site_11_0 -x 55 -y 5 -width 101 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.lab179 \
        -in $site_11_0 -x 159 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.cpd180 \
        -in $site_11_0 -x 232 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.cpd181 \
        -in $site_11_0 -x 305 -y 5 -width 30 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.lab109 \
        -in $site_11_0 -x 5 -y 2 -anchor nw -bordermode ignore 
    frame $site_10_0.fra191 \
        -borderwidth 2 -background #EFEBEF -height 30 -width 335 
    vTcl:DefineAlias "$site_10_0.fra191" "Frame48" vTcl:WidgetProc "Toplevel1" 1
    set site_11_0 $site_10_0.fra191
    label $site_11_0.lab192 \
        -background #EFEBEF -font {Arial 9} -text SOCKET 
    vTcl:DefineAlias "$site_11_0.lab192" "Label188" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.lab193 \
        -background #EFEBEF -font {Arial 10} -text TOUCH 
    vTcl:DefineAlias "$site_11_0.lab193" "Label189" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.lab194 \
        -background #EFEBEF -font {Arial 10} -text LIMIT 
    vTcl:DefineAlias "$site_11_0.lab194" "Label190" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.lab195 \
        -background #EFEBEF -font {Arial 10} -text EXT 
    vTcl:DefineAlias "$site_11_0.lab195" "Label191" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.cpd100 \
        -background #EFEBEF -font {Arial 9} -text SITE 
    vTcl:DefineAlias "$site_11_0.cpd100" "Label233" vTcl:WidgetProc "Toplevel1" 1
    place $site_11_0.lab192 \
        -in $site_11_0 -x 56 -y 5 -width 60 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.lab193 \
        -in $site_11_0 -x 159 -y 5 -width 60 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.lab194 \
        -in $site_11_0 -x 234 -y 5 -width 60 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.lab195 \
        -in $site_11_0 -x 298 -y 5 -width 40 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.cpd100 \
        -in $site_11_0 -x 0 -y 4 -width 37 -height 21 -anchor nw \
        -bordermode ignore 
    place $site_10_0.fra176 \
        -in $site_10_0 -x 4 -y 40 -width 340 -height 30 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd184 \
        -in $site_10_0 -x 4 -y 73 -width 340 -height 30 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd185 \
        -in $site_10_0 -x 4 -y 107 -width 340 -height 30 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd186 \
        -in $site_10_0 -x 4 -y 141 -width 340 -height 30 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd187 \
        -in $site_10_0 -x 5 -y 174 -width 340 -height 30 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd188 \
        -in $site_10_0 -x 4 -y 209 -width 340 -height 30 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd189 \
        -in $site_10_0 -x 4 -y 240 -width 340 -height 30 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd190 \
        -in $site_10_0 -x 4 -y 272 -width 340 -height 30 -anchor nw \
        -bordermode ignore 
    place $site_10_0.fra191 \
        -in $site_10_0 -x 5 -y 8 -width 340 -height 30 -anchor nw \
        -bordermode ignore 
    frame $site_9_0.cpd83 \
        -borderwidth 2 -relief groove -background #EFEBEF -height 305 \
        -width 345 
    vTcl:DefineAlias "$site_9_0.cpd83" "Frame49" vTcl:WidgetProc "Toplevel1" 1
    set site_10_0 $site_9_0.cpd83
    frame $site_10_0.fra176 \
        -borderwidth 2 -background #EFEBEF -height 30 -width 315 
    vTcl:DefineAlias "$site_10_0.fra176" "Frame50" vTcl:WidgetProc "Toplevel1" 1
    set site_11_0 $site_10_0.fra176
    checkbutton $site_11_0.che177 \
        -background #EFEBEF -takefocus 0 -variable g_socket_check9 
    vTcl:DefineAlias "$site_11_0.che177" "ckb_socket9" vTcl:WidgetProc "Toplevel1" 1
    entry $site_11_0.ent178 \
        -background white -takefocus 0 -textvariable g_socket9 
    vTcl:DefineAlias "$site_11_0.ent178" "g_ent_socket9" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.lab179 \
        -background #7f7ff0f09f9f -textvariable g_socket_touch9 
    vTcl:DefineAlias "$site_11_0.lab179" "Label192" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.cpd180 \
        -background #f0f0aeaeeeee -textvariable g_socket_limit9 
    vTcl:DefineAlias "$site_11_0.cpd180" "Label193" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.cpd181 \
        -background #9999b3b3ffff -textvariable g_socket_ext9 
    vTcl:DefineAlias "$site_11_0.cpd181" "Label194" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.lab91 \
        \
        -font [vTcl:font:getFontFromDescr "-family Arial -size 9 -weight normal -slant roman -underline 0 -overstrike 0"] \
        -text {[ 9 ]} 
    vTcl:DefineAlias "$site_11_0.lab91" "Label131" vTcl:WidgetProc "Toplevel1" 1
    place $site_11_0.che177 \
        -in $site_11_0 -x 35 -y 3 -width 18 -height 22 -anchor nw \
        -bordermode ignore 
    place $site_11_0.ent178 \
        -in $site_11_0 -x 55 -y 5 -width 101 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.lab179 \
        -in $site_11_0 -x 159 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.cpd180 \
        -in $site_11_0 -x 232 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.cpd181 \
        -in $site_11_0 -x 305 -y 5 -width 30 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.lab91 \
        -in $site_11_0 -x 5 -y 3 -width 28 -height 19 -anchor nw \
        -bordermode ignore 
    frame $site_10_0.cpd184 \
        -borderwidth 2 -background #EFEBEF -height 30 -width 280 
    vTcl:DefineAlias "$site_10_0.cpd184" "Frame51" vTcl:WidgetProc "Toplevel1" 1
    set site_11_0 $site_10_0.cpd184
    checkbutton $site_11_0.che177 \
        -background #EFEBEF -takefocus 0 -variable g_socket_check10 
    vTcl:DefineAlias "$site_11_0.che177" "ckb_socket10" vTcl:WidgetProc "Toplevel1" 1
    entry $site_11_0.ent178 \
        -background white -takefocus 0 -textvariable g_socket10 
    vTcl:DefineAlias "$site_11_0.ent178" "g_ent_socket10" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.lab179 \
        -background #7f7ff0f09f9f -textvariable g_socket_touch10 
    vTcl:DefineAlias "$site_11_0.lab179" "Label195" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.cpd180 \
        -background #f0f0aeaeeeee -textvariable g_socket_limit10 
    vTcl:DefineAlias "$site_11_0.cpd180" "Label196" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.cpd181 \
        -background #9999b3b3ffff -textvariable g_socket_ext10 
    vTcl:DefineAlias "$site_11_0.cpd181" "Label197" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.lab93 \
        \
        -font [vTcl:font:getFontFromDescr "-family Arial -size 9 -weight normal -slant roman -underline 0 -overstrike 0"] \
        -text {[ 10 ]} 
    vTcl:DefineAlias "$site_11_0.lab93" "Label226" vTcl:WidgetProc "Toplevel1" 1
    place $site_11_0.che177 \
        -in $site_11_0 -x 35 -y 3 -width 18 -height 22 -anchor nw \
        -bordermode ignore 
    place $site_11_0.ent178 \
        -in $site_11_0 -x 55 -y 5 -width 101 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.lab179 \
        -in $site_11_0 -x 159 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.cpd180 \
        -in $site_11_0 -x 232 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.cpd181 \
        -in $site_11_0 -x 305 -y 5 -width 30 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.lab93 \
        -in $site_11_0 -x 1 -y 3 -width 30 -height 19 -anchor nw \
        -bordermode ignore 
    frame $site_10_0.cpd185 \
        -borderwidth 2 -background #EFEBEF -height 30 -width 280 
    vTcl:DefineAlias "$site_10_0.cpd185" "Frame52" vTcl:WidgetProc "Toplevel1" 1
    set site_11_0 $site_10_0.cpd185
    checkbutton $site_11_0.che177 \
        -background #EFEBEF -takefocus 0 -variable g_socket_check11 
    vTcl:DefineAlias "$site_11_0.che177" "ckb_socket11" vTcl:WidgetProc "Toplevel1" 1
    entry $site_11_0.ent178 \
        -background white -takefocus 0 -textvariable g_socket11 
    vTcl:DefineAlias "$site_11_0.ent178" "g_ent_socket11" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.lab179 \
        -background #7f7ff0f09f9f -textvariable g_socket_touch11 
    vTcl:DefineAlias "$site_11_0.lab179" "Label198" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.cpd180 \
        -background #f0f0aeaeeeee -textvariable g_socket_limit11 
    vTcl:DefineAlias "$site_11_0.cpd180" "Label199" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.cpd181 \
        -background #9999b3b3ffff -textvariable g_socket_ext11 
    vTcl:DefineAlias "$site_11_0.cpd181" "Label200" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.lab94 \
        \
        -font [vTcl:font:getFontFromDescr "-family Arial -size 9 -weight normal -slant roman -underline 0 -overstrike 0"] \
        -text {[ 11 ]} 
    vTcl:DefineAlias "$site_11_0.lab94" "Label227" vTcl:WidgetProc "Toplevel1" 1
    place $site_11_0.che177 \
        -in $site_11_0 -x 35 -y 3 -width 18 -height 22 -anchor nw \
        -bordermode ignore 
    place $site_11_0.ent178 \
        -in $site_11_0 -x 55 -y 5 -width 101 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.lab179 \
        -in $site_11_0 -x 159 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.cpd180 \
        -in $site_11_0 -x 232 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.cpd181 \
        -in $site_11_0 -x 305 -y 5 -width 30 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.lab94 \
        -in $site_11_0 -x 0 -y 2 -width 32 -height 21 -anchor nw \
        -bordermode ignore 
    frame $site_10_0.cpd186 \
        -borderwidth 2 -background #EFEBEF -height 30 -width 280 
    vTcl:DefineAlias "$site_10_0.cpd186" "Frame53" vTcl:WidgetProc "Toplevel1" 1
    set site_11_0 $site_10_0.cpd186
    checkbutton $site_11_0.che177 \
        -background #EFEBEF -takefocus 0 -variable g_socket_check12 
    vTcl:DefineAlias "$site_11_0.che177" "ckb_socket12" vTcl:WidgetProc "Toplevel1" 1
    entry $site_11_0.ent178 \
        -background white -takefocus 0 -textvariable g_socket12 
    vTcl:DefineAlias "$site_11_0.ent178" "g_ent_socket12" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.lab179 \
        -background #7f7ff0f09f9f -textvariable g_socket_touch12 
    vTcl:DefineAlias "$site_11_0.lab179" "Label201" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.cpd180 \
        -background #f0f0aeaeeeee -textvariable g_socket_limit12 
    vTcl:DefineAlias "$site_11_0.cpd180" "Label202" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.cpd181 \
        -background #9999b3b3ffff -textvariable g_socket_ext12 
    vTcl:DefineAlias "$site_11_0.cpd181" "Label203" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.lab95 \
        \
        -font [vTcl:font:getFontFromDescr "-family Arial -size 9 -weight normal -slant roman -underline 0 -overstrike 0"] \
        -text {[ 12 ]} 
    vTcl:DefineAlias "$site_11_0.lab95" "Label228" vTcl:WidgetProc "Toplevel1" 1
    place $site_11_0.che177 \
        -in $site_11_0 -x 35 -y 3 -width 18 -height 22 -anchor nw \
        -bordermode ignore 
    place $site_11_0.ent178 \
        -in $site_11_0 -x 55 -y 5 -width 101 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.lab179 \
        -in $site_11_0 -x 159 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.cpd180 \
        -in $site_11_0 -x 232 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.cpd181 \
        -in $site_11_0 -x 305 -y 5 -width 30 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.lab95 \
        -in $site_11_0 -x 0 -y 2 -width 32 -height 21 -anchor nw \
        -bordermode ignore 
    frame $site_10_0.cpd187 \
        -borderwidth 2 -background #EFEBEF -height 30 -width 280 
    vTcl:DefineAlias "$site_10_0.cpd187" "Frame54" vTcl:WidgetProc "Toplevel1" 1
    set site_11_0 $site_10_0.cpd187
    checkbutton $site_11_0.che177 \
        -background #EFEBEF -takefocus 0 -variable g_socket_check13 
    vTcl:DefineAlias "$site_11_0.che177" "ckb_socket13" vTcl:WidgetProc "Toplevel1" 1
    entry $site_11_0.ent178 \
        -background white -takefocus 0 -textvariable g_socket13 
    vTcl:DefineAlias "$site_11_0.ent178" "g_ent_socket13" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.lab179 \
        -background #7f7ff0f09f9f -textvariable g_socket_touch13 
    vTcl:DefineAlias "$site_11_0.lab179" "Label204" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.cpd180 \
        -background #f0f0aeaeeeee -textvariable g_socket_limit13 
    vTcl:DefineAlias "$site_11_0.cpd180" "Label205" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.cpd181 \
        -background #9999b3b3ffff -textvariable g_socket_ext13 
    vTcl:DefineAlias "$site_11_0.cpd181" "Label206" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.lab96 \
        \
        -font [vTcl:font:getFontFromDescr "-family Arial -size 9 -weight normal -slant roman -underline 0 -overstrike 0"] \
        -text {[ 13 ]} 
    vTcl:DefineAlias "$site_11_0.lab96" "Label229" vTcl:WidgetProc "Toplevel1" 1
    place $site_11_0.che177 \
        -in $site_11_0 -x 35 -y 5 -width 18 -height 22 -anchor nw \
        -bordermode ignore 
    place $site_11_0.ent178 \
        -in $site_11_0 -x 55 -y 5 -width 101 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.lab179 \
        -in $site_11_0 -x 159 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.cpd180 \
        -in $site_11_0 -x 232 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.cpd181 \
        -in $site_11_0 -x 305 -y 5 -width 30 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.lab96 \
        -in $site_11_0 -x -1 -y 4 -width 32 -height 21 -anchor nw \
        -bordermode ignore 
    frame $site_10_0.cpd188 \
        -borderwidth 2 -background #EFEBEF -height 30 -width 280 
    vTcl:DefineAlias "$site_10_0.cpd188" "Frame55" vTcl:WidgetProc "Toplevel1" 1
    set site_11_0 $site_10_0.cpd188
    checkbutton $site_11_0.che177 \
        -background #EFEBEF -takefocus 0 -variable g_socket_check14 
    vTcl:DefineAlias "$site_11_0.che177" "ckb_socket14" vTcl:WidgetProc "Toplevel1" 1
    entry $site_11_0.ent178 \
        -background white -takefocus 0 -textvariable g_socket14 
    vTcl:DefineAlias "$site_11_0.ent178" "g_ent_socket14" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.lab179 \
        -background #7f7ff0f09f9f -textvariable g_socket_touch14 
    vTcl:DefineAlias "$site_11_0.lab179" "Label207" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.cpd180 \
        -background #f0f0aeaeeeee -textvariable g_socket_limit14 
    vTcl:DefineAlias "$site_11_0.cpd180" "Label208" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.cpd181 \
        -background #9999b3b3ffff -textvariable g_socket_ext14 
    vTcl:DefineAlias "$site_11_0.cpd181" "Label209" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.lab97 \
        \
        -font [vTcl:font:getFontFromDescr "-family Arial -size 9 -weight normal -slant roman -underline 0 -overstrike 0"] \
        -text {[ 14 ]} 
    vTcl:DefineAlias "$site_11_0.lab97" "Label230" vTcl:WidgetProc "Toplevel1" 1
    place $site_11_0.che177 \
        -in $site_11_0 -x 35 -y 3 -width 18 -height 22 -anchor nw \
        -bordermode ignore 
    place $site_11_0.ent178 \
        -in $site_11_0 -x 55 -y 5 -width 101 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.lab179 \
        -in $site_11_0 -x 159 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.cpd180 \
        -in $site_11_0 -x 232 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.cpd181 \
        -in $site_11_0 -x 305 -y 5 -width 30 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.lab97 \
        -in $site_11_0 -x -1 -y 2 -width 32 -height 21 -anchor nw \
        -bordermode ignore 
    frame $site_10_0.cpd189 \
        -borderwidth 2 -background #EFEBEF -height 30 -width 280 
    vTcl:DefineAlias "$site_10_0.cpd189" "Frame56" vTcl:WidgetProc "Toplevel1" 1
    set site_11_0 $site_10_0.cpd189
    checkbutton $site_11_0.che177 \
        -background #EFEBEF -takefocus 0 -variable g_socket_check15 
    vTcl:DefineAlias "$site_11_0.che177" "ckb_socket15" vTcl:WidgetProc "Toplevel1" 1
    entry $site_11_0.ent178 \
        -background white -takefocus 0 -textvariable g_socket15 
    vTcl:DefineAlias "$site_11_0.ent178" "g_ent_socket15" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.lab179 \
        -background #7f7ff0f09f9f -textvariable g_socket_touch15 
    vTcl:DefineAlias "$site_11_0.lab179" "Label210" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.cpd180 \
        -background #f0f0aeaeeeee -textvariable g_socket_limit15 
    vTcl:DefineAlias "$site_11_0.cpd180" "Label211" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.cpd181 \
        -background #9999b3b3ffff -textvariable g_socket_ext15 
    vTcl:DefineAlias "$site_11_0.cpd181" "Label212" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.lab98 \
        \
        -font [vTcl:font:getFontFromDescr "-family Arial -size 9 -weight normal -slant roman -underline 0 -overstrike 0"] \
        -text {[ 15 ]} 
    vTcl:DefineAlias "$site_11_0.lab98" "Label231" vTcl:WidgetProc "Toplevel1" 1
    place $site_11_0.che177 \
        -in $site_11_0 -x 35 -y 3 -width 18 -height 22 -anchor nw \
        -bordermode ignore 
    place $site_11_0.ent178 \
        -in $site_11_0 -x 55 -y 5 -width 101 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.lab179 \
        -in $site_11_0 -x 159 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.cpd180 \
        -in $site_11_0 -x 232 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.cpd181 \
        -in $site_11_0 -x 305 -y 5 -width 30 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.lab98 \
        -in $site_11_0 -x 0 -y 2 -width 32 -height 21 -anchor nw \
        -bordermode ignore 
    frame $site_10_0.cpd190 \
        -borderwidth 2 -background #EFEBEF -height 30 -width 280 
    vTcl:DefineAlias "$site_10_0.cpd190" "Frame57" vTcl:WidgetProc "Toplevel1" 1
    set site_11_0 $site_10_0.cpd190
    checkbutton $site_11_0.che177 \
        -background #EFEBEF -takefocus 0 -variable g_socket_check16 
    vTcl:DefineAlias "$site_11_0.che177" "ckb_socket16" vTcl:WidgetProc "Toplevel1" 1
    entry $site_11_0.ent178 \
        -background white -takefocus 0 -textvariable g_socket16 
    vTcl:DefineAlias "$site_11_0.ent178" "g_ent_socket16" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.lab179 \
        -background #7f7ff0f09f9f -textvariable g_socket_touch16 
    vTcl:DefineAlias "$site_11_0.lab179" "Label213" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.cpd180 \
        -background #f0f0aeaeeeee -textvariable g_socket_limit16 
    vTcl:DefineAlias "$site_11_0.cpd180" "Label214" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.cpd181 \
        -background #9999b3b3ffff -textvariable g_socket_ext16 
    vTcl:DefineAlias "$site_11_0.cpd181" "Label215" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.lab99 \
        \
        -font [vTcl:font:getFontFromDescr "-family Arial -size 9 -weight normal -slant roman -underline 0 -overstrike 0"] \
        -text {[ 16 ]} 
    vTcl:DefineAlias "$site_11_0.lab99" "Label232" vTcl:WidgetProc "Toplevel1" 1
    place $site_11_0.che177 \
        -in $site_11_0 -x 35 -y 3 -width 18 -height 22 -anchor nw \
        -bordermode ignore 
    place $site_11_0.ent178 \
        -in $site_11_0 -x 55 -y 5 -width 101 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.lab179 \
        -in $site_11_0 -x 159 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.cpd180 \
        -in $site_11_0 -x 232 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.cpd181 \
        -in $site_11_0 -x 305 -y 5 -width 30 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.lab99 \
        -in $site_11_0 -x 0 -y 2 -width 32 -height 21 -anchor nw \
        -bordermode ignore 
    frame $site_10_0.fra191 \
        -borderwidth 2 -background #EFEBEF -height 30 -width 280 
    vTcl:DefineAlias "$site_10_0.fra191" "Frame58" vTcl:WidgetProc "Toplevel1" 1
    set site_11_0 $site_10_0.fra191
    label $site_11_0.lab192 \
        -background #EFEBEF -font {Arial 9} -text SOCKET 
    vTcl:DefineAlias "$site_11_0.lab192" "Label216" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.lab193 \
        -background #EFEBEF -font {Arial 10} -text TOUCH 
    vTcl:DefineAlias "$site_11_0.lab193" "Label217" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.lab194 \
        -background #EFEBEF -font {Arial 10} -text LIMIT 
    vTcl:DefineAlias "$site_11_0.lab194" "Label218" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.lab195 \
        -background #EFEBEF -font {Arial 10} -text EXT 
    vTcl:DefineAlias "$site_11_0.lab195" "Label219" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.cpd83 \
        -background #EFEBEF -font {Arial 9} -text SITE 
    vTcl:DefineAlias "$site_11_0.cpd83" "Label225" vTcl:WidgetProc "Toplevel1" 1
    place $site_11_0.lab192 \
        -in $site_11_0 -x 56 -y 5 -width 60 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.lab193 \
        -in $site_11_0 -x 159 -y 5 -width 60 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.lab194 \
        -in $site_11_0 -x 234 -y 5 -width 60 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.lab195 \
        -in $site_11_0 -x 298 -y 5 -width 40 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.cpd83 \
        -in $site_11_0 -x 0 -y 4 -width 37 -height 21 -anchor nw \
        -bordermode ignore 
    place $site_10_0.fra176 \
        -in $site_10_0 -x 4 -y 40 -width 340 -height 30 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd184 \
        -in $site_10_0 -x 4 -y 73 -width 340 -height 30 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd185 \
        -in $site_10_0 -x 4 -y 107 -width 340 -height 30 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd186 \
        -in $site_10_0 -x 4 -y 141 -width 340 -height 30 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd187 \
        -in $site_10_0 -x 5 -y 172 -width 340 -height 30 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd188 \
        -in $site_10_0 -x 5 -y 208 -width 340 -height 30 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd189 \
        -in $site_10_0 -x 4 -y 240 -width 340 -height 30 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd190 \
        -in $site_10_0 -x 4 -y 272 -width 340 -height 30 -anchor nw \
        -bordermode ignore 
    place $site_10_0.fra191 \
        -in $site_10_0 -x 5 -y 8 -width 340 -height 30 -anchor nw \
        -bordermode ignore 
    place $site_9_0.cpd198 \
        -in $site_9_0 -x 10 -y 0 -width 350 -height 305 -anchor nw \
        -bordermode ignore 
    place $site_9_0.cpd83 \
        -in $site_9_0 -x 361 -y 5 -width 350 -height 305 -anchor nw \
        -bordermode ignore 
    place $site_8_0.fra197 \
        -in $site_8_0 -x 0 -y 4 -width 715 -height 315 -anchor nw \
        -bordermode ignore 
    set site_8_1 [$site_6_0.not173 getframe page2]
    frame $site_8_1.fra83 \
        -borderwidth 2 -relief groove -background #EFEBEF -height 315 \
        -width 660 
    vTcl:DefineAlias "$site_8_1.fra83" "Frame133" vTcl:WidgetProc "Toplevel1" 1
    set site_9_0 $site_8_1.fra83
    frame $site_9_0.fra84 \
        -borderwidth 2 -relief groove -background #EFEBEF -height 305 \
        -width 325 
    vTcl:DefineAlias "$site_9_0.fra84" "Frame134" vTcl:WidgetProc "Toplevel1" 1
    set site_10_0 $site_9_0.fra84
    label $site_10_0.cpd87 \
        -background #EFEBEF -font {Arial 9} -text SITE 
    vTcl:DefineAlias "$site_10_0.cpd87" "Label324" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.cpd88 \
        -background #EFEBEF -font {Arial 9} -text SOCKET 
    vTcl:DefineAlias "$site_10_0.cpd88" "Label325" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.cpd89 \
        -background #EFEBEF -font {Arial 10} -text TOUCH 
    vTcl:DefineAlias "$site_10_0.cpd89" "Label326" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.cpd90 \
        -background #EFEBEF -font {Arial 10} -text LIMIT 
    vTcl:DefineAlias "$site_10_0.cpd90" "Label327" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.cpd91 \
        -background #EFEBEF -font {Arial 10} -text EXT 
    vTcl:DefineAlias "$site_10_0.cpd91" "Label328" vTcl:WidgetProc "Toplevel1" 1
    frame $site_10_0.cpd83 \
        -borderwidth 2 -background #EFEBEF -height 30 -width 310 
    vTcl:DefineAlias "$site_10_0.cpd83" "Frame136" vTcl:WidgetProc "Toplevel1" 1
    set site_11_0 $site_10_0.cpd83
    checkbutton $site_11_0.che177 \
        -background #EFEBEF -takefocus 0 -variable g_socket_check17 
    vTcl:DefineAlias "$site_11_0.che177" "ckb_socket17" vTcl:WidgetProc "Toplevel1" 1
    entry $site_11_0.ent178 \
        -background white -takefocus 0 -textvariable g_socket17 
    vTcl:DefineAlias "$site_11_0.ent178" "g_ent_socket17" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.lab179 \
        -background #7f7ff0f09f9f -textvariable g_socket_touch17 
    vTcl:DefineAlias "$site_11_0.lab179" "Label330" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.cpd180 \
        -background #f0f0aeaeeeee -textvariable g_socket_limit17 
    vTcl:DefineAlias "$site_11_0.cpd180" "Label331" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.cpd181 \
        -background #9999b3b3ffff -textvariable g_socket_ext17 
    vTcl:DefineAlias "$site_11_0.cpd181" "Label332" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.lab101 \
        \
        -font [vTcl:font:getFontFromDescr "-family Arial -size 9 -weight normal -slant roman -underline 0 -overstrike 0"] \
        -text {[ 17 ]} 
    vTcl:DefineAlias "$site_11_0.lab101" "Label333" vTcl:WidgetProc "Toplevel1" 1
    place $site_11_0.che177 \
        -in $site_11_0 -x 35 -y 3 -width 18 -height 22 -anchor nw \
        -bordermode ignore 
    place $site_11_0.ent178 \
        -in $site_11_0 -x 55 -y 5 -width 101 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.lab179 \
        -in $site_11_0 -x 159 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.cpd180 \
        -in $site_11_0 -x 232 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.cpd181 \
        -in $site_11_0 -x 305 -y 5 -width 30 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.lab101 \
        -in $site_11_0 -x 5 -y 2 -width 25 -height 21 -anchor nw \
        -bordermode ignore 
    frame $site_10_0.cpd84 \
        -borderwidth 2 -background #EFEBEF -height 30 -width 310 
    vTcl:DefineAlias "$site_10_0.cpd84" "Frame137" vTcl:WidgetProc "Toplevel1" 1
    set site_11_0 $site_10_0.cpd84
    checkbutton $site_11_0.che177 \
        -background #EFEBEF -takefocus 0 -variable g_socket_check18 
    vTcl:DefineAlias "$site_11_0.che177" "ckb_socket18" vTcl:WidgetProc "Toplevel1" 1
    entry $site_11_0.ent178 \
        -background white -takefocus 0 -textvariable g_socket18 
    vTcl:DefineAlias "$site_11_0.ent178" "g_ent_socket18" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.lab179 \
        -background #7f7ff0f09f9f -textvariable g_socket_touch18 
    vTcl:DefineAlias "$site_11_0.lab179" "Label334" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.cpd180 \
        -background #f0f0aeaeeeee -textvariable g_socket_limit18 
    vTcl:DefineAlias "$site_11_0.cpd180" "Label335" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.cpd181 \
        -background #9999b3b3ffff -textvariable g_socket_ext18 
    vTcl:DefineAlias "$site_11_0.cpd181" "Label336" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.lab101 \
        \
        -font [vTcl:font:getFontFromDescr "-family Arial -size 9 -weight normal -slant roman -underline 0 -overstrike 0"] \
        -text {[ 18 ]} 
    vTcl:DefineAlias "$site_11_0.lab101" "Label337" vTcl:WidgetProc "Toplevel1" 1
    place $site_11_0.che177 \
        -in $site_11_0 -x 35 -y 3 -width 18 -height 22 -anchor nw \
        -bordermode ignore 
    place $site_11_0.ent178 \
        -in $site_11_0 -x 55 -y 5 -width 101 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.lab179 \
        -in $site_11_0 -x 159 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.cpd180 \
        -in $site_11_0 -x 232 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.cpd181 \
        -in $site_11_0 -x 305 -y 5 -width 30 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.lab101 \
        -in $site_11_0 -x 5 -y 2 -width 25 -height 21 -anchor nw \
        -bordermode ignore 
    frame $site_10_0.cpd85 \
        -borderwidth 2 -background #EFEBEF -height 30 -width 310 
    vTcl:DefineAlias "$site_10_0.cpd85" "Frame138" vTcl:WidgetProc "Toplevel1" 1
    set site_11_0 $site_10_0.cpd85
    checkbutton $site_11_0.che177 \
        -background #EFEBEF -takefocus 0 -variable g_socket_check19 
    vTcl:DefineAlias "$site_11_0.che177" "ckb_socket19" vTcl:WidgetProc "Toplevel1" 1
    entry $site_11_0.ent178 \
        -background white -takefocus 0 -textvariable g_socket19 
    vTcl:DefineAlias "$site_11_0.ent178" "g_ent_socket19" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.lab179 \
        -background #7f7ff0f09f9f -textvariable g_socket_touch19 
    vTcl:DefineAlias "$site_11_0.lab179" "Label338" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.cpd180 \
        -background #f0f0aeaeeeee -textvariable g_socket_limit19 
    vTcl:DefineAlias "$site_11_0.cpd180" "Label339" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.cpd181 \
        -background #9999b3b3ffff -textvariable g_socket_ext19 
    vTcl:DefineAlias "$site_11_0.cpd181" "Label340" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.lab101 \
        \
        -font [vTcl:font:getFontFromDescr "-family Arial -size 9 -weight normal -slant roman -underline 0 -overstrike 0"] \
        -text {[ 19 ]} 
    vTcl:DefineAlias "$site_11_0.lab101" "Label341" vTcl:WidgetProc "Toplevel1" 1
    place $site_11_0.che177 \
        -in $site_11_0 -x 35 -y 3 -width 18 -height 22 -anchor nw \
        -bordermode ignore 
    place $site_11_0.ent178 \
        -in $site_11_0 -x 55 -y 5 -width 101 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.lab179 \
        -in $site_11_0 -x 159 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.cpd180 \
        -in $site_11_0 -x 232 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.cpd181 \
        -in $site_11_0 -x 305 -y 5 -width 30 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.lab101 \
        -in $site_11_0 -x 5 -y 2 -width 25 -height 21 -anchor nw \
        -bordermode ignore 
    frame $site_10_0.cpd86 \
        -borderwidth 2 -background #EFEBEF -height 30 -width 310 
    vTcl:DefineAlias "$site_10_0.cpd86" "Frame139" vTcl:WidgetProc "Toplevel1" 1
    set site_11_0 $site_10_0.cpd86
    checkbutton $site_11_0.che177 \
        -background #EFEBEF -takefocus 0 -variable g_socket_check20 
    vTcl:DefineAlias "$site_11_0.che177" "ckb_socket20" vTcl:WidgetProc "Toplevel1" 1
    entry $site_11_0.ent178 \
        -background white -takefocus 0 -textvariable g_socket20 
    vTcl:DefineAlias "$site_11_0.ent178" "g_ent_socket20" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.lab179 \
        -background #7f7ff0f09f9f -textvariable g_socket_touch20 
    vTcl:DefineAlias "$site_11_0.lab179" "Label342" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.cpd180 \
        -background #f0f0aeaeeeee -textvariable g_socket_limit20 
    vTcl:DefineAlias "$site_11_0.cpd180" "Label343" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.cpd181 \
        -background #9999b3b3ffff -textvariable g_socket_ext20 
    vTcl:DefineAlias "$site_11_0.cpd181" "Label344" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.lab101 \
        \
        -font [vTcl:font:getFontFromDescr "-family Arial -size 9 -weight normal -slant roman -underline 0 -overstrike 0"] \
        -text {[ 20 ]} 
    vTcl:DefineAlias "$site_11_0.lab101" "Label345" vTcl:WidgetProc "Toplevel1" 1
    place $site_11_0.che177 \
        -in $site_11_0 -x 35 -y 3 -width 18 -height 22 -anchor nw \
        -bordermode ignore 
    place $site_11_0.ent178 \
        -in $site_11_0 -x 55 -y 5 -width 101 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.lab179 \
        -in $site_11_0 -x 159 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.cpd180 \
        -in $site_11_0 -x 232 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.cpd181 \
        -in $site_11_0 -x 305 -y 5 -width 30 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.lab101 \
        -in $site_11_0 -x 5 -y 2 -width 25 -height 21 -anchor nw \
        -bordermode ignore 
    frame $site_10_0.cpd92 \
        -borderwidth 2 -background #EFEBEF -height 30 -width 310 
    vTcl:DefineAlias "$site_10_0.cpd92" "Frame140" vTcl:WidgetProc "Toplevel1" 1
    set site_11_0 $site_10_0.cpd92
    checkbutton $site_11_0.che177 \
        -background #EFEBEF -takefocus 0 -variable g_socket_check21 
    vTcl:DefineAlias "$site_11_0.che177" "ckb_socket21" vTcl:WidgetProc "Toplevel1" 1
    entry $site_11_0.ent178 \
        -background white -takefocus 0 -textvariable g_socket21 
    vTcl:DefineAlias "$site_11_0.ent178" "g_ent_socket21" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.lab179 \
        -background #7f7ff0f09f9f -textvariable g_socket_touch21 
    vTcl:DefineAlias "$site_11_0.lab179" "Label346" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.cpd180 \
        -background #f0f0aeaeeeee -textvariable g_socket_limit21 
    vTcl:DefineAlias "$site_11_0.cpd180" "Label347" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.cpd181 \
        -background #9999b3b3ffff -textvariable g_socket_ext21 
    vTcl:DefineAlias "$site_11_0.cpd181" "Label348" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.lab101 \
        \
        -font [vTcl:font:getFontFromDescr "-family Arial -size 9 -weight normal -slant roman -underline 0 -overstrike 0"] \
        -text {[ 21 ]} 
    vTcl:DefineAlias "$site_11_0.lab101" "Label349" vTcl:WidgetProc "Toplevel1" 1
    place $site_11_0.che177 \
        -in $site_11_0 -x 35 -y 3 -width 18 -height 22 -anchor nw \
        -bordermode ignore 
    place $site_11_0.ent178 \
        -in $site_11_0 -x 55 -y 5 -width 101 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.lab179 \
        -in $site_11_0 -x 159 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.cpd180 \
        -in $site_11_0 -x 232 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.cpd181 \
        -in $site_11_0 -x 305 -y 5 -width 30 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.lab101 \
        -in $site_11_0 -x 5 -y 2 -width 25 -height 21 -anchor nw \
        -bordermode ignore 
    frame $site_10_0.cpd96 \
        -borderwidth 2 -background #EFEBEF -height 30 -width 310 
    vTcl:DefineAlias "$site_10_0.cpd96" "Frame141" vTcl:WidgetProc "Toplevel1" 1
    set site_11_0 $site_10_0.cpd96
    checkbutton $site_11_0.che177 \
        -background #EFEBEF -takefocus 0 -variable g_socket_check22 
    vTcl:DefineAlias "$site_11_0.che177" "ckb_socket22" vTcl:WidgetProc "Toplevel1" 1
    entry $site_11_0.ent178 \
        -background white -takefocus 0 -textvariable g_socket22 
    vTcl:DefineAlias "$site_11_0.ent178" "g_ent_socket22" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.lab179 \
        -background #7f7ff0f09f9f -textvariable g_socket_touch22 
    vTcl:DefineAlias "$site_11_0.lab179" "Label350" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.cpd180 \
        -background #f0f0aeaeeeee -textvariable g_socket_limit22 
    vTcl:DefineAlias "$site_11_0.cpd180" "Label351" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.cpd181 \
        -background #9999b3b3ffff -textvariable g_socket_ext22 
    vTcl:DefineAlias "$site_11_0.cpd181" "Label352" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.lab101 \
        \
        -font [vTcl:font:getFontFromDescr "-family Arial -size 9 -weight normal -slant roman -underline 0 -overstrike 0"] \
        -text {[ 22 ]} 
    vTcl:DefineAlias "$site_11_0.lab101" "Label353" vTcl:WidgetProc "Toplevel1" 1
    place $site_11_0.che177 \
        -in $site_11_0 -x 35 -y 3 -width 18 -height 22 -anchor nw \
        -bordermode ignore 
    place $site_11_0.ent178 \
        -in $site_11_0 -x 55 -y 5 -width 101 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.lab179 \
        -in $site_11_0 -x 159 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.cpd180 \
        -in $site_11_0 -x 232 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.cpd181 \
        -in $site_11_0 -x 305 -y 5 -width 30 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.lab101 \
        -in $site_11_0 -x 5 -y 2 -width 25 -height 21 -anchor nw \
        -bordermode ignore 
    frame $site_10_0.cpd93 \
        -borderwidth 2 -background #EFEBEF -height 30 -width 310 
    vTcl:DefineAlias "$site_10_0.cpd93" "Frame142" vTcl:WidgetProc "Toplevel1" 1
    set site_11_0 $site_10_0.cpd93
    checkbutton $site_11_0.che177 \
        -background #EFEBEF -takefocus 0 -variable g_socket_check23 
    vTcl:DefineAlias "$site_11_0.che177" "ckb_socket23" vTcl:WidgetProc "Toplevel1" 1
    entry $site_11_0.ent178 \
        -background white -takefocus 0 -textvariable g_socket23 
    vTcl:DefineAlias "$site_11_0.ent178" "g_ent_socket23" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.lab179 \
        -background #7f7ff0f09f9f -textvariable g_socket_touch23 
    vTcl:DefineAlias "$site_11_0.lab179" "Label354" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.cpd180 \
        -background #f0f0aeaeeeee -textvariable g_socket_limit23 
    vTcl:DefineAlias "$site_11_0.cpd180" "Label355" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.cpd181 \
        -background #9999b3b3ffff -textvariable g_socket_ext23 
    vTcl:DefineAlias "$site_11_0.cpd181" "Label356" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.lab101 \
        \
        -font [vTcl:font:getFontFromDescr "-family Arial -size 9 -weight normal -slant roman -underline 0 -overstrike 0"] \
        -text {[ 23 ]} 
    vTcl:DefineAlias "$site_11_0.lab101" "Label357" vTcl:WidgetProc "Toplevel1" 1
    place $site_11_0.che177 \
        -in $site_11_0 -x 35 -y 3 -width 18 -height 22 -anchor nw \
        -bordermode ignore 
    place $site_11_0.ent178 \
        -in $site_11_0 -x 55 -y 5 -width 101 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.lab179 \
        -in $site_11_0 -x 159 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.cpd180 \
        -in $site_11_0 -x 232 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.cpd181 \
        -in $site_11_0 -x 305 -y 5 -width 30 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.lab101 \
        -in $site_11_0 -x 5 -y 2 -width 25 -height 21 -anchor nw \
        -bordermode ignore 
    frame $site_10_0.cpd94 \
        -borderwidth 2 -background #EFEBEF -height 30 -width 310 
    vTcl:DefineAlias "$site_10_0.cpd94" "Frame143" vTcl:WidgetProc "Toplevel1" 1
    set site_11_0 $site_10_0.cpd94
    checkbutton $site_11_0.che177 \
        -background #EFEBEF -takefocus 0 -variable g_socket_check24 
    vTcl:DefineAlias "$site_11_0.che177" "ckb_socket24" vTcl:WidgetProc "Toplevel1" 1
    entry $site_11_0.ent178 \
        -background white -takefocus 0 -textvariable g_socket24 
    vTcl:DefineAlias "$site_11_0.ent178" "g_ent_socket24" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.lab179 \
        -background #7f7ff0f09f9f -textvariable g_socket_touch24 
    vTcl:DefineAlias "$site_11_0.lab179" "Label358" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.cpd180 \
        -background #f0f0aeaeeeee -textvariable g_socket_limit24 
    vTcl:DefineAlias "$site_11_0.cpd180" "Label359" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.cpd181 \
        -background #9999b3b3ffff -textvariable g_socket_ext24 
    vTcl:DefineAlias "$site_11_0.cpd181" "Label360" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.lab101 \
        \
        -font [vTcl:font:getFontFromDescr "-family Arial -size 9 -weight normal -slant roman -underline 0 -overstrike 0"] \
        -text {[ 24 ]} 
    vTcl:DefineAlias "$site_11_0.lab101" "Label361" vTcl:WidgetProc "Toplevel1" 1
    place $site_11_0.che177 \
        -in $site_11_0 -x 35 -y 3 -width 18 -height 22 -anchor nw \
        -bordermode ignore 
    place $site_11_0.ent178 \
        -in $site_11_0 -x 55 -y 5 -width 101 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.lab179 \
        -in $site_11_0 -x 159 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.cpd180 \
        -in $site_11_0 -x 232 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.cpd181 \
        -in $site_11_0 -x 305 -y 5 -width 30 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.lab101 \
        -in $site_11_0 -x 5 -y 2 -width 25 -height 21 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd87 \
        -in $site_10_0 -x 5 -y 10 -anchor nw -bordermode inside 
    place $site_10_0.cpd88 \
        -in $site_10_0 -x 61 -y 10 -anchor nw -bordermode inside 
    place $site_10_0.cpd89 \
        -in $site_10_0 -x 169 -y 11 -width 50 -height 22 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd90 \
        -in $site_10_0 -x 250 -y 11 -width 37 -height 22 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd91 \
        -in $site_10_0 -x 307 -y 11 -width 29 -height 22 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd83 \
        -in $site_10_0 -x 3 -y 40 -width 340 -height 30 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd84 \
        -in $site_10_0 -x 3 -y 72 -width 340 -height 30 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd85 \
        -in $site_10_0 -x 3 -y 105 -width 340 -height 30 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd86 \
        -in $site_10_0 -x 3 -y 139 -width 340 -height 30 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd92 \
        -in $site_10_0 -x 3 -y 173 -width 340 -height 30 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd96 \
        -in $site_10_0 -x 3 -y 207 -width 340 -height 30 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd93 \
        -in $site_10_0 -x 3 -y 239 -width 340 -height 30 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd94 \
        -in $site_10_0 -x 3 -y 272 -width 340 -height 30 -anchor nw \
        -bordermode ignore 
    frame $site_9_0.fra85 \
        -borderwidth 2 -relief groove -background #EFEBEF -height 305 \
        -width 320 
    vTcl:DefineAlias "$site_9_0.fra85" "Frame135" vTcl:WidgetProc "Toplevel1" 1
    set site_10_0 $site_9_0.fra85
    label $site_10_0.cpd83 \
        -background #EFEBEF -font {Arial 9} -text SITE 
    vTcl:DefineAlias "$site_10_0.cpd83" "Label329" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.cpd84 \
        -background #EFEBEF -font {Arial 9} -text SOCKET 
    vTcl:DefineAlias "$site_10_0.cpd84" "Label362" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.cpd85 \
        -background #EFEBEF -font {Arial 10} -text TOUCH 
    vTcl:DefineAlias "$site_10_0.cpd85" "Label363" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.cpd86 \
        -background #EFEBEF -font {Arial 10} -text LIMIT 
    vTcl:DefineAlias "$site_10_0.cpd86" "Label364" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.cpd87 \
        -background #EFEBEF -font {Arial 10} -text EXT 
    vTcl:DefineAlias "$site_10_0.cpd87" "Label365" vTcl:WidgetProc "Toplevel1" 1
    frame $site_10_0.cpd88 \
        -borderwidth 2 -background #EFEBEF -height 30 -width 310 
    vTcl:DefineAlias "$site_10_0.cpd88" "Frame144" vTcl:WidgetProc "Toplevel1" 1
    set site_11_0 $site_10_0.cpd88
    checkbutton $site_11_0.che177 \
        -background #EFEBEF -takefocus 0 -variable g_socket_check25 
    vTcl:DefineAlias "$site_11_0.che177" "ckb_socket25" vTcl:WidgetProc "Toplevel1" 1
    entry $site_11_0.ent178 \
        -background white -takefocus 0 -textvariable g_socket25 
    vTcl:DefineAlias "$site_11_0.ent178" "g_ent_socket25" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.lab179 \
        -background #7f7ff0f09f9f -textvariable g_socket_touch25 
    vTcl:DefineAlias "$site_11_0.lab179" "Label366" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.cpd180 \
        -background #f0f0aeaeeeee -textvariable g_socket_limit25 
    vTcl:DefineAlias "$site_11_0.cpd180" "Label367" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.cpd181 \
        -background #9999b3b3ffff -textvariable g_socket_ext25 
    vTcl:DefineAlias "$site_11_0.cpd181" "Label368" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.lab101 \
        \
        -font [vTcl:font:getFontFromDescr "-family Arial -size 9 -weight normal -slant roman -underline 0 -overstrike 0"] \
        -text {[ 25 ]} 
    vTcl:DefineAlias "$site_11_0.lab101" "Label369" vTcl:WidgetProc "Toplevel1" 1
    place $site_11_0.che177 \
        -in $site_11_0 -x 35 -y 3 -width 18 -height 22 -anchor nw \
        -bordermode ignore 
    place $site_11_0.ent178 \
        -in $site_11_0 -x 55 -y 5 -width 101 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.lab179 \
        -in $site_11_0 -x 159 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.cpd180 \
        -in $site_11_0 -x 232 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.cpd181 \
        -in $site_11_0 -x 305 -y 5 -width 30 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.lab101 \
        -in $site_11_0 -x 5 -y 2 -width 25 -height 21 -anchor nw \
        -bordermode ignore 
    frame $site_10_0.cpd89 \
        -borderwidth 2 -background #EFEBEF -height 30 -width 310 
    vTcl:DefineAlias "$site_10_0.cpd89" "Frame145" vTcl:WidgetProc "Toplevel1" 1
    set site_11_0 $site_10_0.cpd89
    checkbutton $site_11_0.che177 \
        -background #EFEBEF -takefocus 0 -variable g_socket_check26 
    vTcl:DefineAlias "$site_11_0.che177" "ckb_socket26" vTcl:WidgetProc "Toplevel1" 1
    entry $site_11_0.ent178 \
        -background white -takefocus 0 -textvariable g_socket26 
    vTcl:DefineAlias "$site_11_0.ent178" "g_ent_socket26" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.lab179 \
        -background #7f7ff0f09f9f -textvariable g_socket_touch26 
    vTcl:DefineAlias "$site_11_0.lab179" "Label370" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.cpd180 \
        -background #f0f0aeaeeeee -textvariable g_socket_limit26 
    vTcl:DefineAlias "$site_11_0.cpd180" "Label371" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.cpd181 \
        -background #9999b3b3ffff -textvariable g_socket_ext26 
    vTcl:DefineAlias "$site_11_0.cpd181" "Label372" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.lab101 \
        \
        -font [vTcl:font:getFontFromDescr "-family Arial -size 9 -weight normal -slant roman -underline 0 -overstrike 0"] \
        -text {[ 26 ]} 
    vTcl:DefineAlias "$site_11_0.lab101" "Label373" vTcl:WidgetProc "Toplevel1" 1
    place $site_11_0.che177 \
        -in $site_11_0 -x 35 -y 3 -width 18 -height 22 -anchor nw \
        -bordermode ignore 
    place $site_11_0.ent178 \
        -in $site_11_0 -x 55 -y 5 -width 101 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.lab179 \
        -in $site_11_0 -x 159 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.cpd180 \
        -in $site_11_0 -x 232 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.cpd181 \
        -in $site_11_0 -x 305 -y 5 -width 30 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.lab101 \
        -in $site_11_0 -x 5 -y 2 -width 25 -height 21 -anchor nw \
        -bordermode ignore 
    frame $site_10_0.cpd90 \
        -borderwidth 2 -background #EFEBEF -height 30 -width 310 
    vTcl:DefineAlias "$site_10_0.cpd90" "Frame146" vTcl:WidgetProc "Toplevel1" 1
    set site_11_0 $site_10_0.cpd90
    checkbutton $site_11_0.che177 \
        -background #EFEBEF -takefocus 0 -variable g_socket_check27 
    vTcl:DefineAlias "$site_11_0.che177" "ckb_socket27" vTcl:WidgetProc "Toplevel1" 1
    entry $site_11_0.ent178 \
        -background white -takefocus 0 -textvariable g_socket27 
    vTcl:DefineAlias "$site_11_0.ent178" "g_ent_socket27" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.lab179 \
        -background #7f7ff0f09f9f -textvariable g_socket_touch27 
    vTcl:DefineAlias "$site_11_0.lab179" "Label374" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.cpd180 \
        -background #f0f0aeaeeeee -textvariable g_socket_limit27 
    vTcl:DefineAlias "$site_11_0.cpd180" "Label375" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.cpd181 \
        -background #9999b3b3ffff -textvariable g_socket_ext27 
    vTcl:DefineAlias "$site_11_0.cpd181" "Label376" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.lab101 \
        \
        -font [vTcl:font:getFontFromDescr "-family Arial -size 9 -weight normal -slant roman -underline 0 -overstrike 0"] \
        -text {[ 27 ]} 
    vTcl:DefineAlias "$site_11_0.lab101" "Label377" vTcl:WidgetProc "Toplevel1" 1
    place $site_11_0.che177 \
        -in $site_11_0 -x 35 -y 3 -width 18 -height 22 -anchor nw \
        -bordermode ignore 
    place $site_11_0.ent178 \
        -in $site_11_0 -x 55 -y 5 -width 101 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.lab179 \
        -in $site_11_0 -x 159 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.cpd180 \
        -in $site_11_0 -x 232 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.cpd181 \
        -in $site_11_0 -x 305 -y 5 -width 30 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.lab101 \
        -in $site_11_0 -x 5 -y 2 -width 25 -height 21 -anchor nw \
        -bordermode ignore 
    frame $site_10_0.cpd91 \
        -borderwidth 2 -background #EFEBEF -height 30 -width 310 
    vTcl:DefineAlias "$site_10_0.cpd91" "Frame147" vTcl:WidgetProc "Toplevel1" 1
    set site_11_0 $site_10_0.cpd91
    checkbutton $site_11_0.che177 \
        -background #EFEBEF -takefocus 0 -variable g_socket_check28 
    vTcl:DefineAlias "$site_11_0.che177" "ckb_socket28" vTcl:WidgetProc "Toplevel1" 1
    entry $site_11_0.ent178 \
        -background white -takefocus 0 -textvariable g_socket28 
    vTcl:DefineAlias "$site_11_0.ent178" "g_ent_socket28" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.lab179 \
        -background #7f7ff0f09f9f -textvariable g_socket_touch28 
    vTcl:DefineAlias "$site_11_0.lab179" "Label378" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.cpd180 \
        -background #f0f0aeaeeeee -textvariable g_socket_limit28 
    vTcl:DefineAlias "$site_11_0.cpd180" "Label379" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.cpd181 \
        -background #9999b3b3ffff -textvariable g_socket_ext28 
    vTcl:DefineAlias "$site_11_0.cpd181" "Label380" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.lab101 \
        \
        -font [vTcl:font:getFontFromDescr "-family Arial -size 9 -weight normal -slant roman -underline 0 -overstrike 0"] \
        -text {[ 28 ]} 
    vTcl:DefineAlias "$site_11_0.lab101" "Label381" vTcl:WidgetProc "Toplevel1" 1
    place $site_11_0.che177 \
        -in $site_11_0 -x 35 -y 3 -width 18 -height 22 -anchor nw \
        -bordermode ignore 
    place $site_11_0.ent178 \
        -in $site_11_0 -x 55 -y 5 -width 101 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.lab179 \
        -in $site_11_0 -x 159 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.cpd180 \
        -in $site_11_0 -x 232 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.cpd181 \
        -in $site_11_0 -x 305 -y 5 -width 30 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.lab101 \
        -in $site_11_0 -x 5 -y 2 -width 25 -height 21 -anchor nw \
        -bordermode ignore 
    frame $site_10_0.cpd92 \
        -borderwidth 2 -background #EFEBEF -height 30 -width 310 
    vTcl:DefineAlias "$site_10_0.cpd92" "Frame148" vTcl:WidgetProc "Toplevel1" 1
    set site_11_0 $site_10_0.cpd92
    checkbutton $site_11_0.che177 \
        -background #EFEBEF -takefocus 0 -variable g_socket_check29 
    vTcl:DefineAlias "$site_11_0.che177" "ckb_socket29" vTcl:WidgetProc "Toplevel1" 1
    entry $site_11_0.ent178 \
        -background white -takefocus 0 -textvariable g_socket29 
    vTcl:DefineAlias "$site_11_0.ent178" "g_ent_socket29" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.lab179 \
        -background #7f7ff0f09f9f -textvariable g_socket_touch29 
    vTcl:DefineAlias "$site_11_0.lab179" "Label382" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.cpd180 \
        -background #f0f0aeaeeeee -textvariable g_socket_limit29 
    vTcl:DefineAlias "$site_11_0.cpd180" "Label383" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.cpd181 \
        -background #9999b3b3ffff -textvariable g_socket_ext29 
    vTcl:DefineAlias "$site_11_0.cpd181" "Label384" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.lab101 \
        \
        -font [vTcl:font:getFontFromDescr "-family Arial -size 9 -weight normal -slant roman -underline 0 -overstrike 0"] \
        -text {[ 29 ]} 
    vTcl:DefineAlias "$site_11_0.lab101" "Label385" vTcl:WidgetProc "Toplevel1" 1
    place $site_11_0.che177 \
        -in $site_11_0 -x 35 -y 3 -width 18 -height 22 -anchor nw \
        -bordermode ignore 
    place $site_11_0.ent178 \
        -in $site_11_0 -x 55 -y 5 -width 101 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.lab179 \
        -in $site_11_0 -x 159 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.cpd180 \
        -in $site_11_0 -x 232 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.cpd181 \
        -in $site_11_0 -x 305 -y 5 -width 30 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.lab101 \
        -in $site_11_0 -x 5 -y 2 -width 25 -height 21 -anchor nw \
        -bordermode ignore 
    frame $site_10_0.cpd93 \
        -borderwidth 2 -background #EFEBEF -height 30 -width 310 
    vTcl:DefineAlias "$site_10_0.cpd93" "Frame149" vTcl:WidgetProc "Toplevel1" 1
    set site_11_0 $site_10_0.cpd93
    checkbutton $site_11_0.che177 \
        -background #EFEBEF -takefocus 0 -variable g_socket_check30 
    vTcl:DefineAlias "$site_11_0.che177" "ckb_socket30" vTcl:WidgetProc "Toplevel1" 1
    entry $site_11_0.ent178 \
        -background white -takefocus 0 -textvariable g_socket30 
    vTcl:DefineAlias "$site_11_0.ent178" "g_ent_socket30" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.lab179 \
        -background #7f7ff0f09f9f -textvariable g_socket_touch30 
    vTcl:DefineAlias "$site_11_0.lab179" "Label386" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.cpd180 \
        -background #f0f0aeaeeeee -textvariable g_socket_limit30 
    vTcl:DefineAlias "$site_11_0.cpd180" "Label387" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.cpd181 \
        -background #9999b3b3ffff -textvariable g_socket_ext30 
    vTcl:DefineAlias "$site_11_0.cpd181" "Label388" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.lab101 \
        \
        -font [vTcl:font:getFontFromDescr "-family Arial -size 9 -weight normal -slant roman -underline 0 -overstrike 0"] \
        -text {[ 30 ]} 
    vTcl:DefineAlias "$site_11_0.lab101" "Label389" vTcl:WidgetProc "Toplevel1" 1
    place $site_11_0.che177 \
        -in $site_11_0 -x 35 -y 3 -width 18 -height 22 -anchor nw \
        -bordermode ignore 
    place $site_11_0.ent178 \
        -in $site_11_0 -x 55 -y 5 -width 101 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.lab179 \
        -in $site_11_0 -x 159 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.cpd180 \
        -in $site_11_0 -x 232 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.cpd181 \
        -in $site_11_0 -x 305 -y 5 -width 30 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.lab101 \
        -in $site_11_0 -x 5 -y 2 -width 25 -height 21 -anchor nw \
        -bordermode ignore 
    frame $site_10_0.cpd94 \
        -borderwidth 2 -background #EFEBEF -height 30 -width 310 
    vTcl:DefineAlias "$site_10_0.cpd94" "Frame150" vTcl:WidgetProc "Toplevel1" 1
    set site_11_0 $site_10_0.cpd94
    checkbutton $site_11_0.che177 \
        -background #EFEBEF -takefocus 0 -variable g_socket_check31 
    vTcl:DefineAlias "$site_11_0.che177" "ckb_socket31" vTcl:WidgetProc "Toplevel1" 1
    entry $site_11_0.ent178 \
        -background white -takefocus 0 -textvariable g_socket31 
    vTcl:DefineAlias "$site_11_0.ent178" "g_ent_socket31" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.lab179 \
        -background #7f7ff0f09f9f -textvariable g_socket_touch31 
    vTcl:DefineAlias "$site_11_0.lab179" "Label390" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.cpd180 \
        -background #f0f0aeaeeeee -textvariable g_socket_limit31 
    vTcl:DefineAlias "$site_11_0.cpd180" "Label391" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.cpd181 \
        -background #9999b3b3ffff -textvariable g_socket_ext31 
    vTcl:DefineAlias "$site_11_0.cpd181" "Label392" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.lab101 \
        \
        -font [vTcl:font:getFontFromDescr "-family Arial -size 9 -weight normal -slant roman -underline 0 -overstrike 0"] \
        -text {[ 31 ]} 
    vTcl:DefineAlias "$site_11_0.lab101" "Label393" vTcl:WidgetProc "Toplevel1" 1
    place $site_11_0.che177 \
        -in $site_11_0 -x 35 -y 3 -width 18 -height 22 -anchor nw \
        -bordermode ignore 
    place $site_11_0.ent178 \
        -in $site_11_0 -x 55 -y 5 -width 101 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.lab179 \
        -in $site_11_0 -x 159 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.cpd180 \
        -in $site_11_0 -x 232 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.cpd181 \
        -in $site_11_0 -x 305 -y 5 -width 30 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.lab101 \
        -in $site_11_0 -x 5 -y 2 -width 25 -height 21 -anchor nw \
        -bordermode ignore 
    frame $site_10_0.cpd95 \
        -borderwidth 2 -background #EFEBEF -height 30 -width 310 
    vTcl:DefineAlias "$site_10_0.cpd95" "Frame151" vTcl:WidgetProc "Toplevel1" 1
    set site_11_0 $site_10_0.cpd95
    checkbutton $site_11_0.che177 \
        -background #EFEBEF -takefocus 0 -variable g_socket_check32 
    vTcl:DefineAlias "$site_11_0.che177" "ckb_socket32" vTcl:WidgetProc "Toplevel1" 1
    entry $site_11_0.ent178 \
        -background white -takefocus 0 -textvariable g_socket32 
    vTcl:DefineAlias "$site_11_0.ent178" "g_ent_socket32" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.lab179 \
        -background #7f7ff0f09f9f -textvariable g_socket_touch32 
    vTcl:DefineAlias "$site_11_0.lab179" "Label394" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.cpd180 \
        -background #f0f0aeaeeeee -textvariable g_socket_limit32 
    vTcl:DefineAlias "$site_11_0.cpd180" "Label395" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.cpd181 \
        -background #9999b3b3ffff -textvariable g_socket_ext32 
    vTcl:DefineAlias "$site_11_0.cpd181" "Label396" vTcl:WidgetProc "Toplevel1" 1
    label $site_11_0.lab101 \
        \
        -font [vTcl:font:getFontFromDescr "-family Arial -size 9 -weight normal -slant roman -underline 0 -overstrike 0"] \
        -text {[ 32 ]} 
    vTcl:DefineAlias "$site_11_0.lab101" "Label397" vTcl:WidgetProc "Toplevel1" 1
    place $site_11_0.che177 \
        -in $site_11_0 -x 35 -y 3 -width 18 -height 22 -anchor nw \
        -bordermode ignore 
    place $site_11_0.ent178 \
        -in $site_11_0 -x 55 -y 5 -width 101 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.lab179 \
        -in $site_11_0 -x 159 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.cpd180 \
        -in $site_11_0 -x 232 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.cpd181 \
        -in $site_11_0 -x 305 -y 5 -width 30 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_11_0.lab101 \
        -in $site_11_0 -x 5 -y 2 -width 25 -height 21 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd83 \
        -in $site_10_0 -x 5 -y 10 -anchor nw -bordermode inside 
    place $site_10_0.cpd84 \
        -in $site_10_0 -x 61 -y 10 -anchor nw -bordermode inside 
    place $site_10_0.cpd85 \
        -in $site_10_0 -x 168 -y 11 -width 50 -height 22 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd86 \
        -in $site_10_0 -x 247 -y 11 -width 37 -height 22 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd87 \
        -in $site_10_0 -x 305 -y 11 -width 29 -height 22 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd88 \
        -in $site_10_0 -x 2 -y 39 -width 340 -height 30 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd89 \
        -in $site_10_0 -x 2 -y 71 -width 340 -height 30 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd90 \
        -in $site_10_0 -x 2 -y 104 -width 340 -height 30 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd91 \
        -in $site_10_0 -x 2 -y 138 -width 340 -height 30 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd92 \
        -in $site_10_0 -x 2 -y 172 -width 340 -height 30 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd93 \
        -in $site_10_0 -x 2 -y 206 -width 340 -height 30 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd94 \
        -in $site_10_0 -x 2 -y 239 -width 340 -height 30 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd95 \
        -in $site_10_0 -x 2 -y 271 -width 340 -height 30 -anchor nw \
        -bordermode ignore 
    place $site_9_0.fra84 \
        -in $site_9_0 -x 8 -y 5 -width 350 -height 305 -anchor nw \
        -bordermode ignore 
    place $site_9_0.fra85 \
        -in $site_9_0 -x 361 -y 5 -width 350 -height 305 -anchor nw \
        -bordermode ignore 
    place $site_8_1.fra83 \
        -in $site_8_1 -x 0 -y 4 -width 715 -height 315 -anchor nw \
        -bordermode ignore 
    set site_8_2 [$site_6_0.not173 getframe page4]
    set site_8_3 [$site_6_0.not173 getframe page3]
    $site_6_0.not173 raise page1
    frame $site_6_0.fra202 \
        -borderwidth 2 -relief groove -background #EFEBEF -height 70 \
        -width 605 
    vTcl:DefineAlias "$site_6_0.fra202" "Frame60" vTcl:WidgetProc "Toplevel1" 1
    set site_7_0 $site_6_0.fra202
    button $site_7_0.but203 \
        -background #BFFF00 \
        -command {global g_operation 

if { [string match -nocase "*TEST*" $g_operation] == 0 && [string match -nocase "*TSQA*" $g_operation] == 0  } { return }

global g_testing_flag

if { $g_testing_flag != "TESTING" } {
    #set msg {"Fail to Clear Socket!newlinenewlineOnly when tester is running,   newlinenewline You can clear socket.   " "\xAC\xB9\x4C\xD1\xA4\xC2\xB8\xD2\x20\x00\xF5\xAC\x15\xC8\x20\x00\xDD\xC0\x31\xC1\xD0\xC5\x20\x00\xE4\xC2\x28\xD3\x58\xD5\x00\xC6\xB5\xC2\xC8\xB2\xE4\xB2\x21\x00"}
    #set choice [ tk_messageBox -title "Clear Socket Error" -icon error -message [FM "" $msg ""] ]
    FD "g_testing_flag is not testing!"
    return
}

global g_rfid_flag

if { $g_rfid_flag != "TRUE" } {
    #set msg {"Fail to Clear Socket!newlinenewlineThis test is not started with RFID.   " "\xAC\xB9\x4C\xD1\xA4\xC2\xB8\xD2\x20\x00\xF5\xAC\x15\xC8\x20\x00\xDD\xC0\x31\xC1\xD0\xC5\x20\x00\xE4\xC2\x28\xD3\x58\xD5\x00\xC6\xB5\xC2\xC8\xB2\xE4\xB2\x21\x00"}
    #set choice [ tk_messageBox -title "Clear Socket Error" -icon error -message [FM "" $msg ""] ]
    FD "g_rfid_flag is off!"
    return
}


FUNC_RFID_INITIALIZE
FUNC_RFID_REFRESH} \
        -font {Arial 10 bold} -pady 0 -takefocus 0 \
        -text {REFRESH SOCKET STATUS} 
    vTcl:DefineAlias "$site_7_0.but203" "Button25" vTcl:WidgetProc "Toplevel1" 1
    label $site_7_0.lab204 \
        -background #EFEBEF -font {Arial 10} -text {OPERATOR ID :} 
    vTcl:DefineAlias "$site_7_0.lab204" "Label220" vTcl:WidgetProc "Toplevel1" 1
    entry $site_7_0.ent205 \
        -background white -takefocus 0 -textvariable g_socket_operator 
    vTcl:DefineAlias "$site_7_0.ent205" "Entry28" vTcl:WidgetProc "Toplevel1" 1
    button $site_7_0.but206 \
        -background #F6CEE3 -command FUNC_RFID_CLEAR_SOCKETTOUCHCOUNT \
        -font {Arial 10 bold} -pady 0 -takefocus 0 -text {SOCKET CLEAR} 
    vTcl:DefineAlias "$site_7_0.but206" "Button26" vTcl:WidgetProc "Toplevel1" 1
    button $site_7_0.cpd207 \
        -background #CEE3F6 -command FUNC_RFID_EXTEND_SOCKETLIMIT \
        -font {Arial 10 bold} -pady 0 -takefocus 0 -text {SOCKET EXTEND} 
    vTcl:DefineAlias "$site_7_0.cpd207" "Button27" vTcl:WidgetProc "Toplevel1" 1
    place $site_7_0.but203 \
        -in $site_7_0 -x 5 -y 6 -width 594 -height 26 -anchor nw \
        -bordermode ignore 
    place $site_7_0.lab204 \
        -in $site_7_0 -x 7 -y 40 -width 110 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_7_0.ent205 \
        -in $site_7_0 -x 120 -y 40 -width 120 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_7_0.but206 \
        -in $site_7_0 -x 261 -y 37 -width 160 -height 26 -anchor nw \
        -bordermode ignore 
    place $site_7_0.cpd207 \
        -in $site_7_0 -x 438 -y 36 -width 160 -height 26 -anchor nw \
        -bordermode ignore 
    place $site_6_0.fra161 \
        -in $site_6_0 -x 5 -y 5 -width 670 -height 55 -anchor nw \
        -bordermode ignore 
    place $site_6_0.not173 \
        -in $site_6_0 -x 10 -y 60 -width 724 -height 348 -anchor nw \
        -bordermode ignore 
    place $site_6_0.fra202 \
        -in $site_6_0 -x 5 -y 415 -width 605 -height 70 -anchor nw \
        -bordermode ignore 
    set site_6_1 [$site_4_1.not85 getframe page2]
    NoteBook $site_6_1.not83 \
        -background #EFEBEF -font {Arial 10} -height 478 -width 669 
    vTcl:DefineAlias "$site_6_1.not83" "NoteBook8" vTcl:WidgetProc "Toplevel1" 1
    $site_6_1.not83 insert end page1 \
        -text {PROBE COUNT} 
    $site_6_1.not83 insert end page2 \
        -text {PROBE ALERT} 
    $site_6_1.not83 insert end page3 \
        -text {CORE COUNT} 
    set site_8_0 [$site_6_1.not83 getframe page1]
    frame $site_8_0.fra137 \
        -borderwidth 2 -relief groove -background #EFEBEF -height 65 \
        -width 585 
    vTcl:DefineAlias "$site_8_0.fra137" "Frame34" vTcl:WidgetProc "Toplevel1" 1
    set site_9_0 $site_8_0.fra137
    label $site_9_0.lab138 \
        -background #EFEBEF -font {Arial 10} -text {PROBE LOCATION :} \
        -width 50 
    vTcl:DefineAlias "$site_9_0.lab138" "Label140" vTcl:WidgetProc "Toplevel1" 1
    label $site_9_0.cpd139 \
        -background #EFEBEF -font {Arial 10} -text {PROBE NO :} -width 50 
    vTcl:DefineAlias "$site_9_0.cpd139" "Label141" vTcl:WidgetProc "Toplevel1" 1
    label $site_9_0.cpd140 \
        -background #EFEBEF -font {Arial 10} -text {PROBE DESCRIPTION :} \
        -width 50 
    vTcl:DefineAlias "$site_9_0.cpd140" "Label142" vTcl:WidgetProc "Toplevel1" 1
    label $site_9_0.cpd141 \
        -background #B0E0E6 -font {Arial 10} -textvariable g_probe -width 106 
    vTcl:DefineAlias "$site_9_0.cpd141" "Label143" vTcl:WidgetProc "Toplevel1" 1
    label $site_9_0.cpd142 \
        -background #B0E0E6 -font {Arial 10} -textvariable g_probeno \
        -width 145 
    vTcl:DefineAlias "$site_9_0.cpd142" "Label144" vTcl:WidgetProc "Toplevel1" 1
    label $site_9_0.cpd144 \
        -background #B0E0E6 -font {Arial 10} -textvariable g_probedescription \
        -width 412 
    vTcl:DefineAlias "$site_9_0.cpd144" "Label145" vTcl:WidgetProc "Toplevel1" 1
    place $site_9_0.lab138 \
        -in $site_9_0 -x 6 -y 7 -width 150 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_9_0.cpd139 \
        -in $site_9_0 -x 317 -y 7 -width 110 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_9_0.cpd140 \
        -in $site_9_0 -x 6 -y 34 -width 150 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_9_0.cpd141 \
        -in $site_9_0 -x 164 -y 7 -width 145 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_9_0.cpd142 \
        -in $site_9_0 -x 430 -y 5 -width 145 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_9_0.cpd144 \
        -in $site_9_0 -x 162 -y 34 -width 414 -height 19 -anchor nw \
        -bordermode ignore 
    frame $site_8_0.fra145 \
        -borderwidth 2 -relief groove -background #EFEBEF -height 35 \
        -width 585 
    vTcl:DefineAlias "$site_8_0.fra145" "Frame35" vTcl:WidgetProc "Toplevel1" 1
    set site_9_0 $site_8_0.fra145
    label $site_9_0.cpd146 \
        -background #EFEBEF -font {Arial 10} -text {TOUCH :} -width 111 
    vTcl:DefineAlias "$site_9_0.cpd146" "Label146" vTcl:WidgetProc "Toplevel1" 1
    label $site_9_0.cpd147 \
        -background #B0E0E6 -textvariable g_probe_touch -width 71 
    vTcl:DefineAlias "$site_9_0.cpd147" "Label147" vTcl:WidgetProc "Toplevel1" 1
    label $site_9_0.cpd148 \
        -background #EFEBEF -font {Arial 10} -text {LIMIT :} -width 66 
    vTcl:DefineAlias "$site_9_0.cpd148" "Label148" vTcl:WidgetProc "Toplevel1" 1
    label $site_9_0.cpd149 \
        -background #B0E0E6 -textvariable g_probe_limit -width 86 
    vTcl:DefineAlias "$site_9_0.cpd149" "Label149" vTcl:WidgetProc "Toplevel1" 1
    label $site_9_0.cpd150 \
        -background #EFEBEF -font {Arial 10} -text {EXT :} -width 96 
    vTcl:DefineAlias "$site_9_0.cpd150" "Label150" vTcl:WidgetProc "Toplevel1" 1
    label $site_9_0.cpd151 \
        -background #B0E0E6 -textvariable g_probe_ext -width 101 
    vTcl:DefineAlias "$site_9_0.cpd151" "Label151" vTcl:WidgetProc "Toplevel1" 1
    place $site_9_0.cpd146 \
        -in $site_9_0 -x 5 -y 7 -width 80 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_9_0.cpd147 \
        -in $site_9_0 -x 93 -y 7 -width 100 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_9_0.cpd148 \
        -in $site_9_0 -x 198 -y 7 -width 80 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_9_0.cpd149 \
        -in $site_9_0 -x 283 -y 7 -width 100 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_9_0.cpd150 \
        -in $site_9_0 -x 387 -y 7 -width 80 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_9_0.cpd151 \
        -in $site_9_0 -x 472 -y 7 -width 100 -height 19 -anchor nw \
        -bordermode ignore 
    frame $site_8_0.fra152 \
        -borderwidth 2 -relief groove -background #EFEBEF -height 45 \
        -width 585 
    vTcl:DefineAlias "$site_8_0.fra152" "Frame36" vTcl:WidgetProc "Toplevel1" 1
    set site_9_0 $site_8_0.fra152
    button $site_9_0.but153 \
        -background #BFFF00 \
        -command {global g_operation 

if { [string match -nocase "*prob*" $g_operation] == 0 } { return }

global g_testing_flag

if { $g_testing_flag != "TESTING" } {
    #set msg {"Fail to Clear Socket!newlinenewlineOnly when tester is running,   newlinenewline You can clear socket.   " "\xAC\xB9\x4C\xD1\xA4\xC2\xB8\xD2\x20\x00\xF5\xAC\x15\xC8\x20\x00\xDD\xC0\x31\xC1\xD0\xC5\x20\x00\xE4\xC2\x28\xD3\x58\xD5\x00\xC6\xB5\xC2\xC8\xB2\xE4\xB2\x21\x00"}
    #set choice [ tk_messageBox -title "Clear Socket Error" -icon error -message [FM "" $msg ""] ]
    return
}

global g_rfid_flag

if { $g_rfid_flag != "TRUE" } {
    #set msg {"Fail to Clear Socket!newlinenewlineThis test is not started with RFID.   " "\xAC\xB9\x4C\xD1\xA4\xC2\xB8\xD2\x20\x00\xF5\xAC\x15\xC8\x20\x00\xDD\xC0\x31\xC1\xD0\xC5\x20\x00\xE4\xC2\x28\xD3\x58\xD5\x00\xC6\xB5\xC2\xC8\xB2\xE4\xB2\x21\x00"}
    #set choice [ tk_messageBox -title "Clear Socket Error" -icon error -message [FM "" $msg ""] ]
    return
}


FUNC_RFID_INITIALIZE
FUNC_RFID_REFRESH} \
        -font {Arial 11 bold} -pady 0 -takefocus 0 \
        -text {REFRESH PROBE STATUS} 
    vTcl:DefineAlias "$site_9_0.but153" "Button22" vTcl:WidgetProc "Toplevel1" 1
    place $site_9_0.but153 \
        -in $site_9_0 -x 8 -y 7 -width 569 -height 31 -anchor nw \
        -bordermode ignore 
    frame $site_8_0.fra154 \
        -borderwidth 2 -relief groove -background #EFEBEF -height 75 \
        -width 585 
    vTcl:DefineAlias "$site_8_0.fra154" "Frame37" vTcl:WidgetProc "Toplevel1" 1
    set site_9_0 $site_8_0.fra154
    label $site_9_0.cpd155 \
        -background #EFEBEF -font {Arial 10} -text {OPERATOR ID :} -width 116 
    vTcl:DefineAlias "$site_9_0.cpd155" "Label152" vTcl:WidgetProc "Toplevel1" 1
    label $site_9_0.cpd156 \
        -background #EFEBEF -font {Arial 10} -text {COMMENT :} -width 152 
    vTcl:DefineAlias "$site_9_0.cpd156" "Label153" vTcl:WidgetProc "Toplevel1" 1
    entry $site_9_0.ent157 \
        -background white -takefocus 0 -textvariable g_probe_operator 
    vTcl:DefineAlias "$site_9_0.ent157" "Entry10" vTcl:WidgetProc "Toplevel1" 1
    entry $site_9_0.ent158 \
        -background white -takefocus 0 -textvariable g_probe_comment 
    vTcl:DefineAlias "$site_9_0.ent158" "Entry11" vTcl:WidgetProc "Toplevel1" 1
    button $site_9_0.but159 \
        -background #F6CEE3 -command FUNC_RFID_CLEAR_PROBETOUCHDOWN \
        -font {Arial 11 bold} -pady 0 -takefocus 0 -text {PROBE CLEAR} 
    vTcl:DefineAlias "$site_9_0.but159" "Button23" vTcl:WidgetProc "Toplevel1" 1
    button $site_9_0.cpd160 \
        -background #A9D0F5 -command FUNC_RFID_EXTEND_PROBELIMIT \
        -font {Arial 11 bold} -pady 0 -takefocus 0 -text {PROBE EXTEND} 
    vTcl:DefineAlias "$site_9_0.cpd160" "Button24" vTcl:WidgetProc "Toplevel1" 1
    place $site_9_0.cpd155 \
        -in $site_9_0 -x 5 -y 5 -width 120 -height 19 -anchor nw \
        -bordermode inside 
    place $site_9_0.cpd156 \
        -in $site_9_0 -x 222 -y 7 -width 90 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_9_0.ent157 \
        -in $site_9_0 -x 134 -y 7 -width 81 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_9_0.ent158 \
        -in $site_9_0 -x 319 -y 7 -width 251 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_9_0.but159 \
        -in $site_9_0 -x 10 -y 35 -width 265 -height 30 -anchor nw \
        -bordermode ignore 
    place $site_9_0.cpd160 \
        -in $site_9_0 -x 304 -y 35 -width 265 -height 30 -anchor nw \
        -bordermode ignore 
    place $site_8_0.fra137 \
        -in $site_8_0 -x 8 -y 7 -width 585 -height 65 -anchor nw \
        -bordermode ignore 
    place $site_8_0.fra145 \
        -in $site_8_0 -x 8 -y 78 -width 585 -height 35 -anchor nw \
        -bordermode ignore 
    place $site_8_0.fra152 \
        -in $site_8_0 -x 8 -y 120 -width 585 -height 45 -anchor nw \
        -bordermode ignore 
    place $site_8_0.fra154 \
        -in $site_8_0 -x 8 -y 173 -width 585 -height 75 -anchor nw \
        -bordermode ignore 
    set site_8_1 [$site_6_1.not83 getframe page2]
    frame $site_8_1.fra125 \
        -borderwidth 2 -relief groove -background #EFEBEF -height 285 \
        -width 590 
    vTcl:DefineAlias "$site_8_1.fra125" "Frame31" vTcl:WidgetProc "Toplevel1" 1
    set site_9_0 $site_8_1.fra125
    label $site_9_0.lab126 \
        -background #EFEBEF -font {Arial 14 bold} -foreground #FE2E2E \
        -text {PROBE TOUCH DOWN COUNT ALERT!} 
    vTcl:DefineAlias "$site_9_0.lab126" "Label133" vTcl:WidgetProc "Toplevel1" 1
    frame $site_9_0.fra127 \
        -borderwidth 2 -background #EFEBEF -height 70 -width 575 
    vTcl:DefineAlias "$site_9_0.fra127" "Frame32" vTcl:WidgetProc "Toplevel1" 1
    set site_10_0 $site_9_0.fra127
    label $site_10_0.lab129 \
        -background #EFEBEF -font {Arial 10} -text {TOUCH COUNT :} -width 160 
    vTcl:DefineAlias "$site_10_0.lab129" "Label135" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.cpd130 \
        -background #B0E0E6 -font {Arial 10} -textvariable g_probe_touch 
    vTcl:DefineAlias "$site_10_0.cpd130" "Label136" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.cpd131 \
        -background #EFEBEF -font {Arial 10} -text {RECORDED COUNT :} \
        -width 160 
    vTcl:DefineAlias "$site_10_0.cpd131" "Label137" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.cpd132 \
        -background #B0E0E6 -font {Arial 10} \
        -textvariable g_probe_recordcount 
    vTcl:DefineAlias "$site_10_0.cpd132" "Label138" vTcl:WidgetProc "Toplevel1" 1
    place $site_10_0.lab129 \
        -in $site_10_0 -x 10 -y 9 -width 200 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd130 \
        -in $site_10_0 -x 227 -y 9 -width 340 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd131 \
        -in $site_10_0 -x 10 -y 37 -width 200 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd132 \
        -in $site_10_0 -x 227 -y 37 -width 340 -height 19 -anchor nw \
        -bordermode ignore 
    label $site_9_0.lab128 \
        -background #EFEBEF -font {Arial 14 bold} \
        -textvariable g_probe_warning 
    vTcl:DefineAlias "$site_9_0.lab128" "Label134" vTcl:WidgetProc "Toplevel1" 1
    frame $site_9_0.fra133 \
        -borderwidth 2 -background #EFEBEF -height 90 -width 575 
    vTcl:DefineAlias "$site_9_0.fra133" "Frame33" vTcl:WidgetProc "Toplevel1" 1
    set site_10_0 $site_9_0.fra133
    label $site_10_0.cpd134 \
        -background #EFEBEF -font {Arial 10} -text {OPERATOR ID :} 
    vTcl:DefineAlias "$site_10_0.cpd134" "Label139" vTcl:WidgetProc "Toplevel1" 1
    entry $site_10_0.ent135 \
        -background white -takefocus 0 -textvariable g_probe_operatorid 
    vTcl:DefineAlias "$site_10_0.ent135" "Entry9" vTcl:WidgetProc "Toplevel1" 1
    button $site_10_0.but136 \
        -background #CEE3F6 \
        -command [list vTcl:DoCmdOption $site_10_0.but136 {FUNC_BIND_WIDGET

Window show .top95
set a [expr {int([winfo screenwidth .] * 0.5)}]
set b [expr {int([winfo screenheight .] * 0.5)}]
wm geometry .top95 [format "%sx%s+%s+%s" 691 346 [expr $a - 691/2] [expr $b - 346/2]]}] \
        -font {Arial 14 bold} -pady 0 -takefocus 0 -text OK 
    vTcl:DefineAlias "$site_10_0.but136" "Button18" vTcl:WidgetProc "Toplevel1" 1
    place $site_10_0.cpd134 \
        -in $site_10_0 -x 7 -y 5 -width 200 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.ent135 \
        -in $site_10_0 -x 227 -y 5 -width 340 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.but136 \
        -in $site_10_0 -x 8 -y 43 -width 559 -height 36 -anchor nw \
        -bordermode ignore 
    place $site_9_0.lab126 \
        -in $site_9_0 -x 5 -y 7 -width 578 -height 44 -anchor nw \
        -bordermode ignore 
    place $site_9_0.fra127 \
        -in $site_9_0 -x 5 -y 110 -width 575 -height 70 -anchor nw \
        -bordermode ignore 
    place $site_9_0.lab128 \
        -in $site_9_0 -x 6 -y 58 -width 575 -height 40 -anchor nw \
        -bordermode ignore 
    place $site_9_0.fra133 \
        -in $site_9_0 -x 5 -y 185 -width 575 -height 90 -anchor nw \
        -bordermode ignore 
    place $site_8_1.fra125 \
        -in $site_8_1 -x 5 -y 5 -width 590 -height 285 -anchor nw \
        -bordermode ignore 
    set site_8_2 [$site_6_1.not83 getframe page3]
    frame $site_8_2.cpd84 \
        -borderwidth 2 -relief groove -background #EFEBEF -height 30 \
        -width 655 
    vTcl:DefineAlias "$site_8_2.cpd84" "Frame130" vTcl:WidgetProc "Toplevel1" 1
    set site_9_0 $site_8_2.cpd84
    label $site_9_0.cpd162 \
        -background #EFEBEF -font {Arial 10} -text {PROBER :} 
    vTcl:DefineAlias "$site_9_0.cpd162" "Label316" vTcl:WidgetProc "Toplevel1" 1
    label $site_9_0.cpd163 \
        -background #B0E0E6 -font {Arial 10} -textvariable g_prober 
    vTcl:DefineAlias "$site_9_0.cpd163" "Label317" vTcl:WidgetProc "Toplevel1" 1
    label $site_9_0.cpd164 \
        -background #EFEBEF -font {Arial 10} -text {PCB BOARD :} 
    vTcl:DefineAlias "$site_9_0.cpd164" "Label318" vTcl:WidgetProc "Toplevel1" 1
    label $site_9_0.cpd165 \
        -background #B0E0E6 -font {Arial 10} -textvariable g_pcbboard 
    vTcl:DefineAlias "$site_9_0.cpd165" "Label319" vTcl:WidgetProc "Toplevel1" 1
    place $site_9_0.cpd162 \
        -in $site_9_0 -x 4 -y 5 -width 90 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_9_0.cpd163 \
        -in $site_9_0 -x 99 -y 5 -width 100 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_9_0.cpd164 \
        -in $site_9_0 -x 214 -y 5 -width 90 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_9_0.cpd165 \
        -in $site_9_0 -x 315 -y 5 -width 195 -height 19 -anchor nw \
        -bordermode ignore 
    frame $site_8_2.cpd85 \
        -borderwidth 2 -relief groove -background #EFEBEF -height 305 \
        -width 325 
    vTcl:DefineAlias "$site_8_2.cpd85" "Frame109" vTcl:WidgetProc "Toplevel1" 1
    set site_9_0 $site_8_2.cpd85
    frame $site_9_0.fra176 \
        -borderwidth 2 -background #EFEBEF -height 30 -width 280 
    vTcl:DefineAlias "$site_9_0.fra176" "Frame110" vTcl:WidgetProc "Toplevel1" 1
    set site_10_0 $site_9_0.fra176
    checkbutton $site_10_0.che177 \
        -background #EFEBEF -takefocus 0 -variable g_core_check1 
    vTcl:DefineAlias "$site_10_0.che177" "ckb_core1" vTcl:WidgetProc "Toplevel1" 1
    entry $site_10_0.ent178 \
        -background white -takefocus 0 -textvariable g_core1 
    vTcl:DefineAlias "$site_10_0.ent178" "g_ent_core1" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.lab179 \
        -background #7f7ff0f09f9f -textvariable g_core_touch1 
    vTcl:DefineAlias "$site_10_0.lab179" "Label242" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.cpd180 \
        -background #f0f0aeaeeeee -textvariable g_core_limit1 
    vTcl:DefineAlias "$site_10_0.cpd180" "Label243" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.cpd181 \
        -background #9999b3b3ffff -textvariable g_core_ext1 
    vTcl:DefineAlias "$site_10_0.cpd181" "Label244" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.lab101 \
        \
        -font [vTcl:font:getFontFromDescr "-family Arial -size 9 -weight normal -slant roman -underline 0 -overstrike 0"] \
        -text {[ 1 ]} 
    vTcl:DefineAlias "$site_10_0.lab101" "Label245" vTcl:WidgetProc "Toplevel1" 1
    place $site_10_0.che177 \
        -in $site_10_0 -x 35 -y 3 -width 18 -height 22 -anchor nw \
        -bordermode ignore 
    place $site_10_0.ent178 \
        -in $site_10_0 -x 55 -y 5 -width 66 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.lab179 \
        -in $site_10_0 -x 124 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd180 \
        -in $site_10_0 -x 197 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd181 \
        -in $site_10_0 -x 270 -y 5 -width 40 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.lab101 \
        -in $site_10_0 -x 5 -y 2 -width 25 -height 21 -anchor nw \
        -bordermode ignore 
    frame $site_9_0.cpd184 \
        -borderwidth 2 -background #EFEBEF -height 30 -width 280 
    vTcl:DefineAlias "$site_9_0.cpd184" "Frame111" vTcl:WidgetProc "Toplevel1" 1
    set site_10_0 $site_9_0.cpd184
    checkbutton $site_10_0.che177 \
        -background #EFEBEF -takefocus 0 -variable g_core_check2 
    vTcl:DefineAlias "$site_10_0.che177" "ckb_core2" vTcl:WidgetProc "Toplevel1" 1
    entry $site_10_0.ent178 \
        -background white -takefocus 0 -textvariable g_core2 
    vTcl:DefineAlias "$site_10_0.ent178" "g_ent_core2" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.lab179 \
        -background #7f7ff0f09f9f -textvariable g_core_touch2 
    vTcl:DefineAlias "$site_10_0.lab179" "Label246" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.cpd180 \
        -background #f0f0aeaeeeee -textvariable g_core_limit2 
    vTcl:DefineAlias "$site_10_0.cpd180" "Label247" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.cpd181 \
        -background #9999b3b3ffff -textvariable g_core_ext2 
    vTcl:DefineAlias "$site_10_0.cpd181" "Label248" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.lab102 \
        \
        -font [vTcl:font:getFontFromDescr "-family Arial -size 9 -weight normal -slant roman -underline 0 -overstrike 0"] \
        -text {[ 2 ]} 
    vTcl:DefineAlias "$site_10_0.lab102" "Label249" vTcl:WidgetProc "Toplevel1" 1
    place $site_10_0.che177 \
        -in $site_10_0 -x 35 -y 0 -width 18 -height 22 -anchor nw \
        -bordermode ignore 
    place $site_10_0.ent178 \
        -in $site_10_0 -x 55 -y 5 -width 66 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.lab179 \
        -in $site_10_0 -x 124 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd180 \
        -in $site_10_0 -x 197 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd181 \
        -in $site_10_0 -x 270 -y 5 -width 40 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.lab102 \
        -in $site_10_0 -x 5 -y 2 -width 25 -height 21 -anchor nw \
        -bordermode ignore 
    frame $site_9_0.cpd185 \
        -borderwidth 2 -background #EFEBEF -height 30 -width 280 
    vTcl:DefineAlias "$site_9_0.cpd185" "Frame112" vTcl:WidgetProc "Toplevel1" 1
    set site_10_0 $site_9_0.cpd185
    checkbutton $site_10_0.che177 \
        -background #EFEBEF -takefocus 0 -variable g_core_check3 
    vTcl:DefineAlias "$site_10_0.che177" "ckb_core3" vTcl:WidgetProc "Toplevel1" 1
    entry $site_10_0.ent178 \
        -background white -takefocus 0 -textvariable g_core3 
    vTcl:DefineAlias "$site_10_0.ent178" "g_ent_core3" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.lab179 \
        -background #7f7ff0f09f9f -textvariable g_core_touch3 
    vTcl:DefineAlias "$site_10_0.lab179" "Label250" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.cpd180 \
        -background #f0f0aeaeeeee -textvariable g_core_limit3 
    vTcl:DefineAlias "$site_10_0.cpd180" "Label251" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.cpd181 \
        -background #9999b3b3ffff -textvariable g_core_ext3 
    vTcl:DefineAlias "$site_10_0.cpd181" "Label252" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.lab103 \
        \
        -font [vTcl:font:getFontFromDescr "-family Arial -size 9 -weight normal -slant roman -underline 0 -overstrike 0"] \
        -text {[ 3 ]} 
    vTcl:DefineAlias "$site_10_0.lab103" "Label253" vTcl:WidgetProc "Toplevel1" 1
    place $site_10_0.che177 \
        -in $site_10_0 -x 35 -y 3 -width 18 -height 22 -anchor nw \
        -bordermode ignore 
    place $site_10_0.ent178 \
        -in $site_10_0 -x 55 -y 5 -width 66 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.lab179 \
        -in $site_10_0 -x 124 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd180 \
        -in $site_10_0 -x 197 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd181 \
        -in $site_10_0 -x 270 -y 5 -width 40 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.lab103 \
        -in $site_10_0 -x 5 -y 2 -width 25 -height 21 -anchor nw \
        -bordermode ignore 
    frame $site_9_0.cpd186 \
        -borderwidth 2 -background #EFEBEF -height 30 -width 280 
    vTcl:DefineAlias "$site_9_0.cpd186" "Frame113" vTcl:WidgetProc "Toplevel1" 1
    set site_10_0 $site_9_0.cpd186
    checkbutton $site_10_0.che177 \
        -background #EFEBEF -takefocus 0 -variable g_core_check4 
    vTcl:DefineAlias "$site_10_0.che177" "ckb_core4" vTcl:WidgetProc "Toplevel1" 1
    entry $site_10_0.ent178 \
        -background white -takefocus 0 -textvariable g_core4 
    vTcl:DefineAlias "$site_10_0.ent178" "g_ent_core4" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.lab179 \
        -background #7f7ff0f09f9f -textvariable g_core_touch4 
    vTcl:DefineAlias "$site_10_0.lab179" "Label254" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.cpd180 \
        -background #f0f0aeaeeeee -textvariable g_core_limit4 
    vTcl:DefineAlias "$site_10_0.cpd180" "Label255" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.cpd181 \
        -background #9999b3b3ffff -textvariable g_core_ext4 
    vTcl:DefineAlias "$site_10_0.cpd181" "Label256" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.lab104 \
        \
        -font [vTcl:font:getFontFromDescr "-family Arial -size 9 -weight normal -slant roman -underline 0 -overstrike 0"] \
        -text {[ 4 ]} 
    vTcl:DefineAlias "$site_10_0.lab104" "Label257" vTcl:WidgetProc "Toplevel1" 1
    place $site_10_0.che177 \
        -in $site_10_0 -x 35 -y 3 -width 18 -height 22 -anchor nw \
        -bordermode ignore 
    place $site_10_0.ent178 \
        -in $site_10_0 -x 55 -y 5 -width 66 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.lab179 \
        -in $site_10_0 -x 124 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd180 \
        -in $site_10_0 -x 197 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd181 \
        -in $site_10_0 -x 270 -y 5 -width 40 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.lab104 \
        -in $site_10_0 -x 5 -y 2 -width 25 -height 21 -anchor nw \
        -bordermode ignore 
    frame $site_9_0.cpd187 \
        -borderwidth 2 -background #EFEBEF -height 30 -width 280 
    vTcl:DefineAlias "$site_9_0.cpd187" "Frame114" vTcl:WidgetProc "Toplevel1" 1
    set site_10_0 $site_9_0.cpd187
    checkbutton $site_10_0.che177 \
        -background #EFEBEF -takefocus 0 -variable g_core_check5 
    vTcl:DefineAlias "$site_10_0.che177" "ckb_core5" vTcl:WidgetProc "Toplevel1" 1
    entry $site_10_0.ent178 \
        -background white -takefocus 0 -textvariable g_core5 
    vTcl:DefineAlias "$site_10_0.ent178" "g_ent_core5" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.lab179 \
        -background #7f7ff0f09f9f -textvariable g_core_touch5 
    vTcl:DefineAlias "$site_10_0.lab179" "Label258" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.cpd180 \
        -background #f0f0aeaeeeee -textvariable g_core_limit5 
    vTcl:DefineAlias "$site_10_0.cpd180" "Label259" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.cpd181 \
        -background #9999b3b3ffff -textvariable g_core_ext5 
    vTcl:DefineAlias "$site_10_0.cpd181" "Label260" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.lab105 \
        \
        -font [vTcl:font:getFontFromDescr "-family Arial -size 9 -weight normal -slant roman -underline 0 -overstrike 0"] \
        -text {[ 5 ]} 
    vTcl:DefineAlias "$site_10_0.lab105" "Label261" vTcl:WidgetProc "Toplevel1" 1
    place $site_10_0.che177 \
        -in $site_10_0 -x 35 -y 3 -width 18 -height 22 -anchor nw \
        -bordermode ignore 
    place $site_10_0.ent178 \
        -in $site_10_0 -x 55 -y 5 -width 66 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.lab179 \
        -in $site_10_0 -x 124 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd180 \
        -in $site_10_0 -x 197 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd181 \
        -in $site_10_0 -x 270 -y 5 -width 40 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.lab105 \
        -in $site_10_0 -x 4 -y 2 -width 25 -height 21 -anchor nw \
        -bordermode ignore 
    frame $site_9_0.cpd188 \
        -borderwidth 2 -background #EFEBEF -height 30 -width 280 
    vTcl:DefineAlias "$site_9_0.cpd188" "Frame115" vTcl:WidgetProc "Toplevel1" 1
    set site_10_0 $site_9_0.cpd188
    checkbutton $site_10_0.che177 \
        -background #EFEBEF -takefocus 0 -variable g_core_check6 
    vTcl:DefineAlias "$site_10_0.che177" "ckb_core6" vTcl:WidgetProc "Toplevel1" 1
    entry $site_10_0.ent178 \
        -background white -takefocus 0 -textvariable g_core6 
    vTcl:DefineAlias "$site_10_0.ent178" "g_ent_core6" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.lab179 \
        -background #7f7ff0f09f9f -textvariable g_core_touch6 
    vTcl:DefineAlias "$site_10_0.lab179" "Label262" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.cpd180 \
        -background #f0f0aeaeeeee -textvariable g_core_limit6 
    vTcl:DefineAlias "$site_10_0.cpd180" "Label263" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.cpd181 \
        -background #9999b3b3ffff -textvariable g_core_ext6 
    vTcl:DefineAlias "$site_10_0.cpd181" "Label264" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.lab107 \
        \
        -font [vTcl:font:getFontFromDescr "-family Arial -size 9 -weight normal -slant roman -underline 0 -overstrike 0"] \
        -text {[ 6 ]} 
    vTcl:DefineAlias "$site_10_0.lab107" "Label265" vTcl:WidgetProc "Toplevel1" 1
    place $site_10_0.che177 \
        -in $site_10_0 -x 35 -y 3 -width 18 -height 22 -anchor nw \
        -bordermode ignore 
    place $site_10_0.ent178 \
        -in $site_10_0 -x 55 -y 5 -width 66 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.lab179 \
        -in $site_10_0 -x 124 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd180 \
        -in $site_10_0 -x 197 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd181 \
        -in $site_10_0 -x 270 -y 5 -width 40 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.lab107 \
        -in $site_10_0 -x 5 -y 2 -anchor nw -bordermode ignore 
    frame $site_9_0.cpd189 \
        -borderwidth 2 -background #EFEBEF -height 30 -width 280 
    vTcl:DefineAlias "$site_9_0.cpd189" "Frame116" vTcl:WidgetProc "Toplevel1" 1
    set site_10_0 $site_9_0.cpd189
    checkbutton $site_10_0.che177 \
        -background #EFEBEF -takefocus 0 -variable g_core_check7 
    vTcl:DefineAlias "$site_10_0.che177" "ckb_core7" vTcl:WidgetProc "Toplevel1" 1
    entry $site_10_0.ent178 \
        -background white -takefocus 0 -textvariable g_core7 
    vTcl:DefineAlias "$site_10_0.ent178" "g_ent_core7" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.lab179 \
        -background #7f7ff0f09f9f -textvariable g_core_touch7 
    vTcl:DefineAlias "$site_10_0.lab179" "Label266" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.cpd180 \
        -background #f0f0aeaeeeee -textvariable g_core_limit7 
    vTcl:DefineAlias "$site_10_0.cpd180" "Label267" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.cpd181 \
        -background #9999b3b3ffff -textvariable g_core_ext7 
    vTcl:DefineAlias "$site_10_0.cpd181" "Label268" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.lab108 \
        \
        -font [vTcl:font:getFontFromDescr "-family Arial -size 9 -weight normal -slant roman -underline 0 -overstrike 0"] \
        -text {[ 7 ]} 
    vTcl:DefineAlias "$site_10_0.lab108" "Label269" vTcl:WidgetProc "Toplevel1" 1
    place $site_10_0.che177 \
        -in $site_10_0 -x 35 -y 3 -width 18 -height 22 -anchor nw \
        -bordermode ignore 
    place $site_10_0.ent178 \
        -in $site_10_0 -x 55 -y 5 -width 66 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.lab179 \
        -in $site_10_0 -x 124 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd180 \
        -in $site_10_0 -x 197 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd181 \
        -in $site_10_0 -x 270 -y 5 -width 40 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.lab108 \
        -in $site_10_0 -x 5 -y 2 -anchor nw -bordermode ignore 
    frame $site_9_0.cpd190 \
        -borderwidth 2 -background #EFEBEF -height 30 -width 280 
    vTcl:DefineAlias "$site_9_0.cpd190" "Frame117" vTcl:WidgetProc "Toplevel1" 1
    set site_10_0 $site_9_0.cpd190
    checkbutton $site_10_0.che177 \
        -background #EFEBEF -takefocus 0 -variable g_core_check8 
    vTcl:DefineAlias "$site_10_0.che177" "ckb_core8" vTcl:WidgetProc "Toplevel1" 1
    entry $site_10_0.ent178 \
        -background white -takefocus 0 -textvariable g_core8 
    vTcl:DefineAlias "$site_10_0.ent178" "g_ent_core8" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.lab179 \
        -background #7f7ff0f09f9f -textvariable g_core_touch8 
    vTcl:DefineAlias "$site_10_0.lab179" "Label270" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.cpd180 \
        -background #f0f0aeaeeeee -textvariable g_core_limit8 
    vTcl:DefineAlias "$site_10_0.cpd180" "Label271" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.cpd181 \
        -background #9999b3b3ffff -textvariable g_core_ext8 
    vTcl:DefineAlias "$site_10_0.cpd181" "Label272" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.lab109 \
        \
        -font [vTcl:font:getFontFromDescr "-family Arial -size 9 -weight normal -slant roman -underline 0 -overstrike 0"] \
        -text {[ 8 ]} 
    vTcl:DefineAlias "$site_10_0.lab109" "Label273" vTcl:WidgetProc "Toplevel1" 1
    place $site_10_0.che177 \
        -in $site_10_0 -x 35 -y 3 -width 18 -height 22 -anchor nw \
        -bordermode ignore 
    place $site_10_0.ent178 \
        -in $site_10_0 -x 55 -y 5 -width 66 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.lab179 \
        -in $site_10_0 -x 124 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd180 \
        -in $site_10_0 -x 197 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd181 \
        -in $site_10_0 -x 270 -y 5 -width 40 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.lab109 \
        -in $site_10_0 -x 5 -y 2 -anchor nw -bordermode ignore 
    frame $site_9_0.fra191 \
        -borderwidth 2 -background #EFEBEF -height 30 -width 280 
    vTcl:DefineAlias "$site_9_0.fra191" "Frame118" vTcl:WidgetProc "Toplevel1" 1
    set site_10_0 $site_9_0.fra191
    label $site_10_0.lab192 \
        -background #EFEBEF -font {Arial 9} -text CORE 
    vTcl:DefineAlias "$site_10_0.lab192" "Label274" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.lab193 \
        -background #EFEBEF -font {Arial 10} -text TOUCH 
    vTcl:DefineAlias "$site_10_0.lab193" "Label275" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.lab194 \
        -background #EFEBEF -font {Arial 10} -text LIMIT 
    vTcl:DefineAlias "$site_10_0.lab194" "Label276" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.lab195 \
        -background #EFEBEF -font {Arial 10} -text EXT 
    vTcl:DefineAlias "$site_10_0.lab195" "Label277" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.cpd100 \
        -background #EFEBEF -font {Arial 9} -text SITE 
    vTcl:DefineAlias "$site_10_0.cpd100" "Label278" vTcl:WidgetProc "Toplevel1" 1
    place $site_10_0.lab192 \
        -in $site_10_0 -x 56 -y 5 -width 60 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.lab193 \
        -in $site_10_0 -x 128 -y 5 -width 60 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.lab194 \
        -in $site_10_0 -x 201 -y 5 -width 60 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.lab195 \
        -in $site_10_0 -x 269 -y 5 -width 40 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd100 \
        -in $site_10_0 -x 0 -y 4 -width 37 -height 21 -anchor nw \
        -bordermode ignore 
    place $site_9_0.fra176 \
        -in $site_9_0 -x 4 -y 40 -width 315 -height 30 -anchor nw \
        -bordermode ignore 
    place $site_9_0.cpd184 \
        -in $site_9_0 -x 4 -y 73 -width 315 -height 30 -anchor nw \
        -bordermode ignore 
    place $site_9_0.cpd185 \
        -in $site_9_0 -x 4 -y 107 -width 315 -height 30 -anchor nw \
        -bordermode ignore 
    place $site_9_0.cpd186 \
        -in $site_9_0 -x 4 -y 141 -width 315 -height 30 -anchor nw \
        -bordermode ignore 
    place $site_9_0.cpd187 \
        -in $site_9_0 -x 5 -y 174 -width 315 -height 30 -anchor nw \
        -bordermode ignore 
    place $site_9_0.cpd188 \
        -in $site_9_0 -x 4 -y 209 -width 315 -height 30 -anchor nw \
        -bordermode ignore 
    place $site_9_0.cpd189 \
        -in $site_9_0 -x 4 -y 240 -width 315 -height 30 -anchor nw \
        -bordermode ignore 
    place $site_9_0.cpd190 \
        -in $site_9_0 -x 4 -y 272 -width 315 -height 30 -anchor nw \
        -bordermode ignore 
    place $site_9_0.fra191 \
        -in $site_9_0 -x 5 -y 8 -width 315 -height 30 -anchor nw \
        -bordermode ignore 
    frame $site_8_2.cpd87 \
        -borderwidth 2 -relief groove -background #EFEBEF -height 305 \
        -width 325 
    vTcl:DefineAlias "$site_8_2.cpd87" "Frame119" vTcl:WidgetProc "Toplevel1" 1
    set site_9_0 $site_8_2.cpd87
    frame $site_9_0.fra176 \
        -borderwidth 2 -background #EFEBEF -height 30 -width 315 
    vTcl:DefineAlias "$site_9_0.fra176" "Frame120" vTcl:WidgetProc "Toplevel1" 1
    set site_10_0 $site_9_0.fra176
    checkbutton $site_10_0.che177 \
        -background #EFEBEF -takefocus 0 -variable g_core_check9 
    vTcl:DefineAlias "$site_10_0.che177" "ckb_core9" vTcl:WidgetProc "Toplevel1" 1
    entry $site_10_0.ent178 \
        -background white -takefocus 0 -textvariable g_core9 
    vTcl:DefineAlias "$site_10_0.ent178" "g_ent_core9" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.lab179 \
        -background #7f7ff0f09f9f -textvariable g_core_touch9 
    vTcl:DefineAlias "$site_10_0.lab179" "Label279" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.cpd180 \
        -background #f0f0aeaeeeee -textvariable g_core_limit9 
    vTcl:DefineAlias "$site_10_0.cpd180" "Label280" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.cpd181 \
        -background #9999b3b3ffff -textvariable g_core_ext9 
    vTcl:DefineAlias "$site_10_0.cpd181" "Label281" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.lab91 \
        \
        -font [vTcl:font:getFontFromDescr "-family Arial -size 9 -weight normal -slant roman -underline 0 -overstrike 0"] \
        -text {[ 9 ]} 
    vTcl:DefineAlias "$site_10_0.lab91" "Label282" vTcl:WidgetProc "Toplevel1" 1
    place $site_10_0.che177 \
        -in $site_10_0 -x 35 -y 3 -width 18 -height 22 -anchor nw \
        -bordermode ignore 
    place $site_10_0.ent178 \
        -in $site_10_0 -x 55 -y 5 -width 66 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.lab179 \
        -in $site_10_0 -x 124 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd180 \
        -in $site_10_0 -x 197 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd181 \
        -in $site_10_0 -x 270 -y 5 -width 40 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.lab91 \
        -in $site_10_0 -x 5 -y 3 -width 28 -height 19 -anchor nw \
        -bordermode ignore 
    frame $site_9_0.cpd184 \
        -borderwidth 2 -background #EFEBEF -height 30 -width 280 
    vTcl:DefineAlias "$site_9_0.cpd184" "Frame121" vTcl:WidgetProc "Toplevel1" 1
    set site_10_0 $site_9_0.cpd184
    checkbutton $site_10_0.che177 \
        -background #EFEBEF -takefocus 0 -variable g_core_check10 
    vTcl:DefineAlias "$site_10_0.che177" "ckb_core10" vTcl:WidgetProc "Toplevel1" 1
    entry $site_10_0.ent178 \
        -background white -takefocus 0 -textvariable g_core10 
    vTcl:DefineAlias "$site_10_0.ent178" "g_ent_core10" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.lab179 \
        -background #7f7ff0f09f9f -textvariable g_core_touch10 
    vTcl:DefineAlias "$site_10_0.lab179" "Label283" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.cpd180 \
        -background #f0f0aeaeeeee -textvariable g_core_limit10 
    vTcl:DefineAlias "$site_10_0.cpd180" "Label284" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.cpd181 \
        -background #9999b3b3ffff -textvariable g_core_ext10 
    vTcl:DefineAlias "$site_10_0.cpd181" "Label285" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.lab93 \
        \
        -font [vTcl:font:getFontFromDescr "-family Arial -size 9 -weight normal -slant roman -underline 0 -overstrike 0"] \
        -text {[ 10 ]} 
    vTcl:DefineAlias "$site_10_0.lab93" "Label286" vTcl:WidgetProc "Toplevel1" 1
    place $site_10_0.che177 \
        -in $site_10_0 -x 35 -y 3 -width 18 -height 22 -anchor nw \
        -bordermode ignore 
    place $site_10_0.ent178 \
        -in $site_10_0 -x 55 -y 5 -width 66 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.lab179 \
        -in $site_10_0 -x 124 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd180 \
        -in $site_10_0 -x 197 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd181 \
        -in $site_10_0 -x 271 -y 5 -width 40 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.lab93 \
        -in $site_10_0 -x 1 -y 3 -width 30 -height 19 -anchor nw \
        -bordermode ignore 
    frame $site_9_0.cpd185 \
        -borderwidth 2 -background #EFEBEF -height 30 -width 280 
    vTcl:DefineAlias "$site_9_0.cpd185" "Frame122" vTcl:WidgetProc "Toplevel1" 1
    set site_10_0 $site_9_0.cpd185
    checkbutton $site_10_0.che177 \
        -background #EFEBEF -takefocus 0 -variable g_core_check11 
    vTcl:DefineAlias "$site_10_0.che177" "ckb_core11" vTcl:WidgetProc "Toplevel1" 1
    entry $site_10_0.ent178 \
        -background white -takefocus 0 -textvariable g_core11 
    vTcl:DefineAlias "$site_10_0.ent178" "g_ent_core11" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.lab179 \
        -background #7f7ff0f09f9f -textvariable g_core_touch11 
    vTcl:DefineAlias "$site_10_0.lab179" "Label287" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.cpd180 \
        -background #f0f0aeaeeeee -textvariable g_core_limit11 
    vTcl:DefineAlias "$site_10_0.cpd180" "Label288" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.cpd181 \
        -background #9999b3b3ffff -textvariable g_core_ext11 
    vTcl:DefineAlias "$site_10_0.cpd181" "Label289" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.lab94 \
        \
        -font [vTcl:font:getFontFromDescr "-family Arial -size 9 -weight normal -slant roman -underline 0 -overstrike 0"] \
        -text {[ 11 ]} 
    vTcl:DefineAlias "$site_10_0.lab94" "Label290" vTcl:WidgetProc "Toplevel1" 1
    place $site_10_0.che177 \
        -in $site_10_0 -x 35 -y 3 -width 18 -height 22 -anchor nw \
        -bordermode ignore 
    place $site_10_0.ent178 \
        -in $site_10_0 -x 55 -y 5 -width 66 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.lab179 \
        -in $site_10_0 -x 124 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd180 \
        -in $site_10_0 -x 197 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd181 \
        -in $site_10_0 -x 270 -y 5 -width 40 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.lab94 \
        -in $site_10_0 -x 0 -y 2 -width 32 -height 21 -anchor nw \
        -bordermode ignore 
    frame $site_9_0.cpd186 \
        -borderwidth 2 -background #EFEBEF -height 30 -width 280 
    vTcl:DefineAlias "$site_9_0.cpd186" "Frame123" vTcl:WidgetProc "Toplevel1" 1
    set site_10_0 $site_9_0.cpd186
    checkbutton $site_10_0.che177 \
        -background #EFEBEF -takefocus 0 -variable g_core_check12 
    vTcl:DefineAlias "$site_10_0.che177" "ckb_core12" vTcl:WidgetProc "Toplevel1" 1
    entry $site_10_0.ent178 \
        -background white -takefocus 0 -textvariable g_core12 
    vTcl:DefineAlias "$site_10_0.ent178" "g_ent_core12" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.lab179 \
        -background #7f7ff0f09f9f -textvariable g_core_touch12 
    vTcl:DefineAlias "$site_10_0.lab179" "Label291" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.cpd180 \
        -background #f0f0aeaeeeee -textvariable g_core_limit12 
    vTcl:DefineAlias "$site_10_0.cpd180" "Label292" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.cpd181 \
        -background #9999b3b3ffff -textvariable g_core_ext12 
    vTcl:DefineAlias "$site_10_0.cpd181" "Label293" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.lab95 \
        \
        -font [vTcl:font:getFontFromDescr "-family Arial -size 9 -weight normal -slant roman -underline 0 -overstrike 0"] \
        -text {[ 12 ]} 
    vTcl:DefineAlias "$site_10_0.lab95" "Label294" vTcl:WidgetProc "Toplevel1" 1
    place $site_10_0.che177 \
        -in $site_10_0 -x 35 -y 3 -width 18 -height 22 -anchor nw \
        -bordermode ignore 
    place $site_10_0.ent178 \
        -in $site_10_0 -x 55 -y 5 -width 66 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.lab179 \
        -in $site_10_0 -x 124 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd180 \
        -in $site_10_0 -x 197 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd181 \
        -in $site_10_0 -x 270 -y 5 -width 40 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.lab95 \
        -in $site_10_0 -x 0 -y 2 -width 32 -height 21 -anchor nw \
        -bordermode ignore 
    frame $site_9_0.cpd187 \
        -borderwidth 2 -background #EFEBEF -height 30 -width 280 
    vTcl:DefineAlias "$site_9_0.cpd187" "Frame124" vTcl:WidgetProc "Toplevel1" 1
    set site_10_0 $site_9_0.cpd187
    checkbutton $site_10_0.che177 \
        -background #EFEBEF -takefocus 0 -variable g_core_check13 
    vTcl:DefineAlias "$site_10_0.che177" "ckb_core13" vTcl:WidgetProc "Toplevel1" 1
    entry $site_10_0.ent178 \
        -background white -takefocus 0 -textvariable g_core13 
    vTcl:DefineAlias "$site_10_0.ent178" "g_ent_core13" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.lab179 \
        -background #7f7ff0f09f9f -textvariable g_core_touch13 
    vTcl:DefineAlias "$site_10_0.lab179" "Label295" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.cpd180 \
        -background #f0f0aeaeeeee -textvariable g_core_limit13 
    vTcl:DefineAlias "$site_10_0.cpd180" "Label296" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.cpd181 \
        -background #9999b3b3ffff -textvariable g_core_ext13 
    vTcl:DefineAlias "$site_10_0.cpd181" "Label297" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.lab96 \
        \
        -font [vTcl:font:getFontFromDescr "-family Arial -size 9 -weight normal -slant roman -underline 0 -overstrike 0"] \
        -text {[ 13 ]} 
    vTcl:DefineAlias "$site_10_0.lab96" "Label298" vTcl:WidgetProc "Toplevel1" 1
    place $site_10_0.che177 \
        -in $site_10_0 -x 35 -y 5 -width 18 -height 22 -anchor nw \
        -bordermode ignore 
    place $site_10_0.ent178 \
        -in $site_10_0 -x 55 -y 5 -width 66 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.lab179 \
        -in $site_10_0 -x 124 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd180 \
        -in $site_10_0 -x 197 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd181 \
        -in $site_10_0 -x 270 -y 5 -width 40 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.lab96 \
        -in $site_10_0 -x -1 -y 4 -width 32 -height 21 -anchor nw \
        -bordermode ignore 
    frame $site_9_0.cpd188 \
        -borderwidth 2 -background #EFEBEF -height 30 -width 280 
    vTcl:DefineAlias "$site_9_0.cpd188" "Frame125" vTcl:WidgetProc "Toplevel1" 1
    set site_10_0 $site_9_0.cpd188
    checkbutton $site_10_0.che177 \
        -background #EFEBEF -takefocus 0 -variable g_core_check14 
    vTcl:DefineAlias "$site_10_0.che177" "ckb_core14" vTcl:WidgetProc "Toplevel1" 1
    entry $site_10_0.ent178 \
        -background white -takefocus 0 -textvariable g_core14 
    vTcl:DefineAlias "$site_10_0.ent178" "g_ent_core14" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.lab179 \
        -background #7f7ff0f09f9f -textvariable g_core_touch14 
    vTcl:DefineAlias "$site_10_0.lab179" "Label299" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.cpd180 \
        -background #f0f0aeaeeeee -textvariable g_core_limit14 
    vTcl:DefineAlias "$site_10_0.cpd180" "Label300" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.cpd181 \
        -background #9999b3b3ffff -textvariable g_core_ext14 
    vTcl:DefineAlias "$site_10_0.cpd181" "Label301" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.lab97 \
        \
        -font [vTcl:font:getFontFromDescr "-family Arial -size 9 -weight normal -slant roman -underline 0 -overstrike 0"] \
        -text {[ 14 ]} 
    vTcl:DefineAlias "$site_10_0.lab97" "Label302" vTcl:WidgetProc "Toplevel1" 1
    place $site_10_0.che177 \
        -in $site_10_0 -x 35 -y 3 -width 18 -height 22 -anchor nw \
        -bordermode ignore 
    place $site_10_0.ent178 \
        -in $site_10_0 -x 55 -y 5 -width 66 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.lab179 \
        -in $site_10_0 -x 124 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd180 \
        -in $site_10_0 -x 197 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd181 \
        -in $site_10_0 -x 270 -y 5 -width 40 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.lab97 \
        -in $site_10_0 -x -1 -y 2 -width 32 -height 21 -anchor nw \
        -bordermode ignore 
    frame $site_9_0.cpd189 \
        -borderwidth 2 -background #EFEBEF -height 30 -width 280 
    vTcl:DefineAlias "$site_9_0.cpd189" "Frame126" vTcl:WidgetProc "Toplevel1" 1
    set site_10_0 $site_9_0.cpd189
    checkbutton $site_10_0.che177 \
        -background #EFEBEF -takefocus 0 -variable g_core_check15 
    vTcl:DefineAlias "$site_10_0.che177" "ckb_core15" vTcl:WidgetProc "Toplevel1" 1
    entry $site_10_0.ent178 \
        -background white -takefocus 0 -textvariable g_core15 
    vTcl:DefineAlias "$site_10_0.ent178" "g_ent_core15" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.lab179 \
        -background #7f7ff0f09f9f -textvariable g_core_touch15 
    vTcl:DefineAlias "$site_10_0.lab179" "Label303" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.cpd180 \
        -background #f0f0aeaeeeee -textvariable g_core_limit15 
    vTcl:DefineAlias "$site_10_0.cpd180" "Label304" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.cpd181 \
        -background #9999b3b3ffff -textvariable g_core_ext15 
    vTcl:DefineAlias "$site_10_0.cpd181" "Label305" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.lab98 \
        \
        -font [vTcl:font:getFontFromDescr "-family Arial -size 9 -weight normal -slant roman -underline 0 -overstrike 0"] \
        -text {[ 15 ]} 
    vTcl:DefineAlias "$site_10_0.lab98" "Label306" vTcl:WidgetProc "Toplevel1" 1
    place $site_10_0.che177 \
        -in $site_10_0 -x 35 -y 3 -width 18 -height 22 -anchor nw \
        -bordermode ignore 
    place $site_10_0.ent178 \
        -in $site_10_0 -x 55 -y 5 -width 66 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.lab179 \
        -in $site_10_0 -x 124 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd180 \
        -in $site_10_0 -x 197 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd181 \
        -in $site_10_0 -x 270 -y 5 -width 40 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.lab98 \
        -in $site_10_0 -x 0 -y 2 -width 32 -height 21 -anchor nw \
        -bordermode ignore 
    frame $site_9_0.cpd190 \
        -borderwidth 2 -background #EFEBEF -height 30 -width 280 
    vTcl:DefineAlias "$site_9_0.cpd190" "Frame127" vTcl:WidgetProc "Toplevel1" 1
    set site_10_0 $site_9_0.cpd190
    checkbutton $site_10_0.che177 \
        -background #EFEBEF -takefocus 0 -variable g_core_check16 
    vTcl:DefineAlias "$site_10_0.che177" "ckb_core16" vTcl:WidgetProc "Toplevel1" 1
    entry $site_10_0.ent178 \
        -background white -takefocus 0 -textvariable g_core16 
    vTcl:DefineAlias "$site_10_0.ent178" "g_ent_core16" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.lab179 \
        -background #7f7ff0f09f9f -textvariable g_core_touch16 
    vTcl:DefineAlias "$site_10_0.lab179" "Label307" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.cpd180 \
        -background #f0f0aeaeeeee -textvariable g_core_limit16 
    vTcl:DefineAlias "$site_10_0.cpd180" "Label308" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.cpd181 \
        -background #9999b3b3ffff -textvariable g_core_ext16 
    vTcl:DefineAlias "$site_10_0.cpd181" "Label309" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.lab99 \
        \
        -font [vTcl:font:getFontFromDescr "-family Arial -size 9 -weight normal -slant roman -underline 0 -overstrike 0"] \
        -text {[ 16 ]} 
    vTcl:DefineAlias "$site_10_0.lab99" "Label310" vTcl:WidgetProc "Toplevel1" 1
    place $site_10_0.che177 \
        -in $site_10_0 -x 35 -y 3 -width 18 -height 22 -anchor nw \
        -bordermode ignore 
    place $site_10_0.ent178 \
        -in $site_10_0 -x 55 -y 5 -width 66 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.lab179 \
        -in $site_10_0 -x 124 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd180 \
        -in $site_10_0 -x 197 -y 5 -width 70 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd181 \
        -in $site_10_0 -x 270 -y 5 -width 40 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.lab99 \
        -in $site_10_0 -x 0 -y 2 -width 32 -height 21 -anchor nw \
        -bordermode ignore 
    frame $site_9_0.fra191 \
        -borderwidth 2 -background #EFEBEF -height 30 -width 280 
    vTcl:DefineAlias "$site_9_0.fra191" "Frame128" vTcl:WidgetProc "Toplevel1" 1
    set site_10_0 $site_9_0.fra191
    label $site_10_0.lab192 \
        -background #EFEBEF -font {Arial 9} -text CORE 
    vTcl:DefineAlias "$site_10_0.lab192" "Label311" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.lab193 \
        -background #EFEBEF -font {Arial 10} -text TOUCH 
    vTcl:DefineAlias "$site_10_0.lab193" "Label312" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.lab194 \
        -background #EFEBEF -font {Arial 10} -text LIMIT 
    vTcl:DefineAlias "$site_10_0.lab194" "Label313" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.lab195 \
        -background #EFEBEF -font {Arial 10} -text EXT 
    vTcl:DefineAlias "$site_10_0.lab195" "Label314" vTcl:WidgetProc "Toplevel1" 1
    label $site_10_0.cpd83 \
        -background #EFEBEF -font {Arial 9} -text SITE 
    vTcl:DefineAlias "$site_10_0.cpd83" "Label315" vTcl:WidgetProc "Toplevel1" 1
    place $site_10_0.lab192 \
        -in $site_10_0 -x 56 -y 5 -width 60 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.lab193 \
        -in $site_10_0 -x 128 -y 5 -width 60 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.lab194 \
        -in $site_10_0 -x 201 -y 5 -width 60 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.lab195 \
        -in $site_10_0 -x 269 -y 5 -width 40 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_10_0.cpd83 \
        -in $site_10_0 -x 0 -y 4 -width 37 -height 21 -anchor nw \
        -bordermode ignore 
    place $site_9_0.fra176 \
        -in $site_9_0 -x 4 -y 40 -width 315 -height 30 -anchor nw \
        -bordermode ignore 
    place $site_9_0.cpd184 \
        -in $site_9_0 -x 4 -y 73 -width 315 -height 30 -anchor nw \
        -bordermode ignore 
    place $site_9_0.cpd185 \
        -in $site_9_0 -x 4 -y 107 -width 315 -height 30 -anchor nw \
        -bordermode ignore 
    place $site_9_0.cpd186 \
        -in $site_9_0 -x 4 -y 141 -width 315 -height 30 -anchor nw \
        -bordermode ignore 
    place $site_9_0.cpd187 \
        -in $site_9_0 -x 5 -y 172 -width 315 -height 30 -anchor nw \
        -bordermode ignore 
    place $site_9_0.cpd188 \
        -in $site_9_0 -x 5 -y 208 -width 315 -height 30 -anchor nw \
        -bordermode ignore 
    place $site_9_0.cpd189 \
        -in $site_9_0 -x 4 -y 240 -width 315 -height 30 -anchor nw \
        -bordermode ignore 
    place $site_9_0.cpd190 \
        -in $site_9_0 -x 4 -y 273 -width 315 -height 30 -anchor nw \
        -bordermode ignore 
    place $site_9_0.fra191 \
        -in $site_9_0 -x 5 -y 8 -width 315 -height 30 -anchor nw \
        -bordermode ignore 
    label $site_8_2.lab89 \
        -font {Arial 10 bold} -text CORE(16) 
    vTcl:DefineAlias "$site_8_2.lab89" "Label320" vTcl:WidgetProc "Toplevel1" 1
    frame $site_8_2.cpd83 \
        -borderwidth 2 -relief groove -background #EFEBEF -height 70 \
        -width 605 
    vTcl:DefineAlias "$site_8_2.cpd83" "Frame132" vTcl:WidgetProc "Toplevel1" 1
    set site_9_0 $site_8_2.cpd83
    button $site_9_0.but203 \
        -background #BFFF00 \
        -command {global g_operation 

if { [string match -nocase "*PROB*" $g_operation] == 0 } { return }

global g_testing_flag

if { $g_testing_flag != "TESTING" } {
    #set msg {"Fail to Clear Socket!newlinenewlineOnly when tester is running,   newlinenewline You can clear socket.   " "\xAC\xB9\x4C\xD1\xA4\xC2\xB8\xD2\x20\x00\xF5\xAC\x15\xC8\x20\x00\xDD\xC0\x31\xC1\xD0\xC5\x20\x00\xE4\xC2\x28\xD3\x58\xD5\x00\xC6\xB5\xC2\xC8\xB2\xE4\xB2\x21\x00"}
    #set choice [ tk_messageBox -title "Clear Socket Error" -icon error -message [FM "" $msg ""] ]
    FD "g_testing_flag is not testing!"
    return
}

global g_rfid_flag

if { $g_rfid_flag != "TRUE" } {
    #set msg {"Fail to Clear Socket!newlinenewlineThis test is not started with RFID.   " "\xAC\xB9\x4C\xD1\xA4\xC2\xB8\xD2\x20\x00\xF5\xAC\x15\xC8\x20\x00\xDD\xC0\x31\xC1\xD0\xC5\x20\x00\xE4\xC2\x28\xD3\x58\xD5\x00\xC6\xB5\xC2\xC8\xB2\xE4\xB2\x21\x00"}
    #set choice [ tk_messageBox -title "Clear Socket Error" -icon error -message [FM "" $msg ""] ]
    FD "g_rfid_flag is off!"
    return
}


FUNC_RFID_INITIALIZE
FUNC_RFID_REFRESH} \
        -font {Arial 10 bold} -pady 0 -takefocus 0 \
        -text {REFRESH CORE STATUS} 
    vTcl:DefineAlias "$site_9_0.but203" "Button56" vTcl:WidgetProc "Toplevel1" 1
    label $site_9_0.lab204 \
        -background #EFEBEF -font {Arial 10} -text {OPERATOR ID :} 
    vTcl:DefineAlias "$site_9_0.lab204" "Label323" vTcl:WidgetProc "Toplevel1" 1
    entry $site_9_0.ent205 \
        -background white -takefocus 0 -textvariable g_core_operator 
    vTcl:DefineAlias "$site_9_0.ent205" "Entry31" vTcl:WidgetProc "Toplevel1" 1
    button $site_9_0.but206 \
        -background #F6CEE3 -command FUNC_RFID_CLEAR_CORETOUCHCOUNT \
        -font {Arial 10 bold} -pady 0 -takefocus 0 -text {CORE CLEAR} 
    vTcl:DefineAlias "$site_9_0.but206" "Button57" vTcl:WidgetProc "Toplevel1" 1
    button $site_9_0.cpd207 \
        -background #CEE3F6 -command FUNC_RFID_EXTEND_CORELIMIT \
        -font {Arial 10 bold} -pady 0 -takefocus 0 -text {CORE EXTEND} 
    vTcl:DefineAlias "$site_9_0.cpd207" "Button58" vTcl:WidgetProc "Toplevel1" 1
    place $site_9_0.but203 \
        -in $site_9_0 -x 5 -y 6 -width 594 -height 26 -anchor nw \
        -bordermode ignore 
    place $site_9_0.lab204 \
        -in $site_9_0 -x 7 -y 40 -width 110 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_9_0.ent205 \
        -in $site_9_0 -x 120 -y 40 -width 120 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_9_0.but206 \
        -in $site_9_0 -x 261 -y 37 -width 160 -height 26 -anchor nw \
        -bordermode ignore 
    place $site_9_0.cpd207 \
        -in $site_9_0 -x 438 -y 36 -width 160 -height 26 -anchor nw \
        -bordermode ignore 
    place $site_8_2.cpd84 \
        -in $site_8_2 -x 5 -y 8 -width 655 -height 30 -anchor nw \
        -bordermode ignore 
    place $site_8_2.cpd85 \
        -in $site_8_2 -x 5 -y 68 -width 325 -height 305 -anchor nw \
        -bordermode ignore 
    place $site_8_2.cpd87 \
        -in $site_8_2 -x 334 -y 68 -width 325 -height 305 -anchor nw \
        -bordermode ignore 
    place $site_8_2.lab89 \
        -in $site_8_2 -x 5 -y 47 -width 68 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_8_2.cpd83 \
        -in $site_8_2 -x 5 -y 378 -width 605 -height 70 -anchor nw \
        -bordermode ignore 
    $site_6_1.not83 raise page1
    place $site_6_1.not83 \
        -in $site_6_1 -x 5 -y 5 -width 669 -height 478 -anchor nw \
        -bordermode ignore 
    $site_4_1.not85 raise page1
    place $site_4_1.not85 \
        -in $site_4_1 -x 5 -y 5 -width 744 -height 513 -anchor nw \
        -bordermode ignore 
    set site_4_2 [$top.not84 getframe page5]
    NoteBook $site_4_2.not83 \
        -activebackground #cad3ec -background #EFEBEF -font {Arial 10 bold} \
        -height 513 -width 619 
    vTcl:DefineAlias "$site_4_2.not83" "NoteBook5" vTcl:WidgetProc "Toplevel1" 1
    $site_4_2.not83 insert end page2 \
        -text VARIABLE 
    $site_4_2.not83 insert end page3 \
        -text DEBUG 
    set site_6_0 [$site_4_2.not83 getframe page2]
    frame $site_6_0.fra83 \
        -borderwidth 2 -relief groove -background #EFEBEF -height 410 \
        -width 600 
    vTcl:DefineAlias "$site_6_0.fra83" "Frame15" vTcl:WidgetProc "Toplevel1" 1
    set site_7_0 $site_6_0.fra83
    button $site_7_0.but83 \
        -background #BFFF00 -command FUNC_CREATE_CONFIGFILE -pady 0 \
        -text {CREATE CONFIG FILE} 
    vTcl:DefineAlias "$site_7_0.but83" "Button6" vTcl:WidgetProc "Toplevel1" 1
    frame $site_7_0.fra83 \
        -borderwidth 2 -relief groove -background #EFEBEF -height 370 \
        -width 290 
    vTcl:DefineAlias "$site_7_0.fra83" "Frame28" vTcl:WidgetProc "Toplevel1" 1
    set site_8_0 $site_7_0.fra83
    frame $site_8_0.fra85 \
        -borderwidth 2 -background #EFEBEF -height 25 -width 290 
    vTcl:DefineAlias "$site_8_0.fra85" "Frame29" vTcl:WidgetProc "Toplevel1" 1
    set site_9_0 $site_8_0.fra85
    label $site_9_0.lab86 \
        -background #EFEBEF -text {g_release_flag :} 
    vTcl:DefineAlias "$site_9_0.lab86" "Label19" vTcl:WidgetProc "Toplevel1" 1
    label $site_9_0.cpd88 \
        -background #CEE3F6 -text OFF -textvariable g_release_flag 
    vTcl:DefineAlias "$site_9_0.cpd88" "Label55" vTcl:WidgetProc "Toplevel1" 1
    place $site_9_0.lab86 \
        -in $site_9_0 -x 5 -y 3 -width 98 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_9_0.cpd88 \
        -in $site_9_0 -x 105 -y 2 -width 181 -height 19 -anchor nw \
        -bordermode ignore 
    frame $site_8_0.cpd89 \
        -borderwidth 2 -background #EFEBEF -height 25 -width 290 
    vTcl:DefineAlias "$site_8_0.cpd89" "Frame30" vTcl:WidgetProc "Toplevel1" 1
    set site_9_0 $site_8_0.cpd89
    label $site_9_0.lab86 \
        -background #EFEBEF -text {g_refreshperiod :} 
    vTcl:DefineAlias "$site_9_0.lab86" "Label57" vTcl:WidgetProc "Toplevel1" 1
    label $site_9_0.cpd88 \
        -background #CEE3F6 -text 60000 -textvariable g_refreshperiod 
    vTcl:DefineAlias "$site_9_0.cpd88" "Label58" vTcl:WidgetProc "Toplevel1" 1
    place $site_9_0.lab86 \
        -in $site_9_0 -x 5 -y 3 -width 98 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_9_0.cpd88 \
        -in $site_9_0 -x 105 -y 2 -width 181 -height 19 -anchor nw \
        -bordermode ignore 
    frame $site_8_0.cpd90 \
        -borderwidth 2 -background #EFEBEF -height 25 -width 290 
    vTcl:DefineAlias "$site_8_0.cpd90" "Frame79" vTcl:WidgetProc "Toplevel1" 1
    set site_9_0 $site_8_0.cpd90
    label $site_9_0.lab86 \
        -background #EFEBEF -text {g_scopsversion :} 
    vTcl:DefineAlias "$site_9_0.lab86" "Label59" vTcl:WidgetProc "Toplevel1" 1
    label $site_9_0.cpd88 \
        -background #CEE3F6 -text 1 -textvariable g_scopsversion 
    vTcl:DefineAlias "$site_9_0.cpd88" "Label60" vTcl:WidgetProc "Toplevel1" 1
    place $site_9_0.lab86 \
        -in $site_9_0 -x 5 -y 3 -width 98 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_9_0.cpd88 \
        -in $site_9_0 -x 105 -y 2 -width 181 -height 19 -anchor nw \
        -bordermode ignore 
    frame $site_8_0.cpd91 \
        -borderwidth 2 -background #EFEBEF -height 25 -width 290 
    vTcl:DefineAlias "$site_8_0.cpd91" "Frame80" vTcl:WidgetProc "Toplevel1" 1
    set site_9_0 $site_8_0.cpd91
    label $site_9_0.lab86 \
        -background #EFEBEF -text {g_sscopsnewversion :} 
    vTcl:DefineAlias "$site_9_0.lab86" "Label61" vTcl:WidgetProc "Toplevel1" 1
    label $site_9_0.cpd88 \
        -background #CEE3F6 -text 1 -textvariable g_scopsnewversion 
    vTcl:DefineAlias "$site_9_0.cpd88" "Label62" vTcl:WidgetProc "Toplevel1" 1
    place $site_9_0.lab86 \
        -in $site_9_0 -x 5 -y 3 -width 123 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_9_0.cpd88 \
        -in $site_9_0 -x 135 -y 2 -width 151 -height 19 -anchor nw \
        -bordermode ignore 
    frame $site_8_0.cpd92 \
        -borderwidth 2 -background #EFEBEF -height 25 -width 290 
    vTcl:DefineAlias "$site_8_0.cpd92" "Frame81" vTcl:WidgetProc "Toplevel1" 1
    set site_9_0 $site_8_0.cpd92
    label $site_9_0.lab86 \
        -background #EFEBEF -text {g_scopspath :} 
    vTcl:DefineAlias "$site_9_0.lab86" "Label63" vTcl:WidgetProc "Toplevel1" 1
    label $site_9_0.cpd88 \
        -background #CEE3F6 -textvariable g_scopspath 
    vTcl:DefineAlias "$site_9_0.cpd88" "Label64" vTcl:WidgetProc "Toplevel1" 1
    place $site_9_0.lab86 \
        -in $site_9_0 -x 5 -y 3 -width 98 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_9_0.cpd88 \
        -in $site_9_0 -x 105 -y 2 -width 181 -height 19 -anchor nw \
        -bordermode ignore 
    frame $site_8_0.cpd93 \
        -borderwidth 2 -background #EFEBEF -height 25 -width 290 
    vTcl:DefineAlias "$site_8_0.cpd93" "Frame82" vTcl:WidgetProc "Toplevel1" 1
    set site_9_0 $site_8_0.cpd93
    label $site_9_0.lab86 \
        -background #EFEBEF -text {g_apl_flag :} 
    vTcl:DefineAlias "$site_9_0.lab86" "Label65" vTcl:WidgetProc "Toplevel1" 1
    label $site_9_0.cpd88 \
        -background #CEE3F6 -text OFF -textvariable g_apl_flag 
    vTcl:DefineAlias "$site_9_0.cpd88" "Label66" vTcl:WidgetProc "Toplevel1" 1
    place $site_9_0.lab86 \
        -in $site_9_0 -x 5 -y 3 -width 98 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_9_0.cpd88 \
        -in $site_9_0 -x 105 -y 2 -width 181 -height 19 -anchor nw \
        -bordermode ignore 
    frame $site_8_0.cpd94 \
        -borderwidth 2 -background #EFEBEF -height 25 -width 290 
    vTcl:DefineAlias "$site_8_0.cpd94" "Frame83" vTcl:WidgetProc "Toplevel1" 1
    set site_9_0 $site_8_0.cpd94
    label $site_9_0.lab86 \
        -background #EFEBEF -text {g_apl_path :} 
    vTcl:DefineAlias "$site_9_0.lab86" "Label67" vTcl:WidgetProc "Toplevel1" 1
    label $site_9_0.cpd88 \
        -background #CEE3F6 -textvariable g_apl_path 
    vTcl:DefineAlias "$site_9_0.cpd88" "Label68" vTcl:WidgetProc "Toplevel1" 1
    place $site_9_0.lab86 \
        -in $site_9_0 -x 5 -y 3 -width 98 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_9_0.cpd88 \
        -in $site_9_0 -x 105 -y 2 -width 181 -height 19 -anchor nw \
        -bordermode ignore 
    frame $site_8_0.cpd95 \
        -borderwidth 2 -background #EFEBEF -height 25 -width 290 
    vTcl:DefineAlias "$site_8_0.cpd95" "Frame84" vTcl:WidgetProc "Toplevel1" 1
    set site_9_0 $site_8_0.cpd95
    label $site_9_0.lab86 \
        -background #EFEBEF -text {g_update_flag :} 
    vTcl:DefineAlias "$site_9_0.lab86" "Label69" vTcl:WidgetProc "Toplevel1" 1
    label $site_9_0.cpd88 \
        -background #CEE3F6 -text OFF -textvariable g_update_flag 
    vTcl:DefineAlias "$site_9_0.cpd88" "Label70" vTcl:WidgetProc "Toplevel1" 1
    place $site_9_0.lab86 \
        -in $site_9_0 -x 5 -y 3 -width 98 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_9_0.cpd88 \
        -in $site_9_0 -x 105 -y 2 -width 181 -height 19 -anchor nw \
        -bordermode ignore 
    frame $site_8_0.cpd96 \
        -borderwidth 2 -background #EFEBEF -height 25 -width 290 
    vTcl:DefineAlias "$site_8_0.cpd96" "Frame85" vTcl:WidgetProc "Toplevel1" 1
    set site_9_0 $site_8_0.cpd96
    label $site_9_0.lab86 \
        -background #EFEBEF -text {g_database :} 
    vTcl:DefineAlias "$site_9_0.lab86" "Label71" vTcl:WidgetProc "Toplevel1" 1
    label $site_9_0.cpd88 \
        -background #CEE3F6 -text {} -textvariable g_database 
    vTcl:DefineAlias "$site_9_0.cpd88" "Label72" vTcl:WidgetProc "Toplevel1" 1
    place $site_9_0.lab86 \
        -in $site_9_0 -x 5 -y 3 -width 98 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_9_0.cpd88 \
        -in $site_9_0 -x 105 -y 2 -width 181 -height 19 -anchor nw \
        -bordermode ignore 
    frame $site_8_0.cpd97 \
        -borderwidth 2 -background #EFEBEF -height 25 -width 290 
    vTcl:DefineAlias "$site_8_0.cpd97" "Frame86" vTcl:WidgetProc "Toplevel1" 1
    set site_9_0 $site_8_0.cpd97
    label $site_9_0.lab86 \
        -background #EFEBEF -text {g_datastream_flag :} 
    vTcl:DefineAlias "$site_9_0.lab86" "Label73" vTcl:WidgetProc "Toplevel1" 1
    label $site_9_0.cpd88 \
        -background #CEE3F6 -text OFF -textvariable g_datastream_flag 
    vTcl:DefineAlias "$site_9_0.cpd88" "Label74" vTcl:WidgetProc "Toplevel1" 1
    place $site_9_0.lab86 \
        -in $site_9_0 -x 5 -y 3 -width 98 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_9_0.cpd88 \
        -in $site_9_0 -x 105 -y 2 -width 181 -height 19 -anchor nw \
        -bordermode ignore 
    frame $site_8_0.cpd98 \
        -borderwidth 2 -background #EFEBEF -height 25 -width 290 
    vTcl:DefineAlias "$site_8_0.cpd98" "Frame87" vTcl:WidgetProc "Toplevel1" 1
    set site_9_0 $site_8_0.cpd98
    label $site_9_0.lab86 \
        -background #EFEBEF -text {g_manual_flag :} 
    vTcl:DefineAlias "$site_9_0.lab86" "Label75" vTcl:WidgetProc "Toplevel1" 1
    label $site_9_0.cpd88 \
        -background #CEE3F6 -text OFF -textvariable g_manual_flag 
    vTcl:DefineAlias "$site_9_0.cpd88" "Label76" vTcl:WidgetProc "Toplevel1" 1
    place $site_9_0.lab86 \
        -in $site_9_0 -x 5 -y 3 -width 98 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_9_0.cpd88 \
        -in $site_9_0 -x 105 -y 2 -width 181 -height 19 -anchor nw \
        -bordermode ignore 
    frame $site_8_0.cpd99 \
        -borderwidth 2 -background #EFEBEF -height 25 -width 290 
    vTcl:DefineAlias "$site_8_0.cpd99" "Frame88" vTcl:WidgetProc "Toplevel1" 1
    set site_9_0 $site_8_0.cpd99
    label $site_9_0.lab86 \
        -background #EFEBEF -text {g_hsf_flag :} 
    vTcl:DefineAlias "$site_9_0.lab86" "Label77" vTcl:WidgetProc "Toplevel1" 1
    label $site_9_0.cpd88 \
        -background #CEE3F6 -text OFF -textvariable g_hsf_flag 
    vTcl:DefineAlias "$site_9_0.cpd88" "Label78" vTcl:WidgetProc "Toplevel1" 1
    place $site_9_0.lab86 \
        -in $site_9_0 -x 5 -y 3 -width 98 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_9_0.cpd88 \
        -in $site_9_0 -x 105 -y 2 -width 181 -height 19 -anchor nw \
        -bordermode ignore 
    frame $site_8_0.cpd100 \
        -borderwidth 2 -background #EFEBEF -height 25 -width 290 
    vTcl:DefineAlias "$site_8_0.cpd100" "Frame89" vTcl:WidgetProc "Toplevel1" 1
    set site_9_0 $site_8_0.cpd100
    label $site_9_0.lab86 \
        -background #EFEBEF -text {g_sbl_flag :} 
    vTcl:DefineAlias "$site_9_0.lab86" "Label79" vTcl:WidgetProc "Toplevel1" 1
    label $site_9_0.cpd88 \
        -background #CEE3F6 -text OFF -textvariable g_sbl_flag 
    vTcl:DefineAlias "$site_9_0.cpd88" "Label80" vTcl:WidgetProc "Toplevel1" 1
    place $site_9_0.lab86 \
        -in $site_9_0 -x 5 -y 3 -width 98 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_9_0.cpd88 \
        -in $site_9_0 -x 105 -y 2 -width 181 -height 19 -anchor nw \
        -bordermode ignore 
    frame $site_8_0.cpd101 \
        -borderwidth 2 -background #EFEBEF -height 25 -width 290 
    vTcl:DefineAlias "$site_8_0.cpd101" "Frame90" vTcl:WidgetProc "Toplevel1" 1
    set site_9_0 $site_8_0.cpd101
    label $site_9_0.lab86 \
        -background #EFEBEF -text {g_drl_flag :} 
    vTcl:DefineAlias "$site_9_0.lab86" "Label81" vTcl:WidgetProc "Toplevel1" 1
    label $site_9_0.cpd88 \
        -background #CEE3F6 -text OFF -textvariable g_drl_flag 
    vTcl:DefineAlias "$site_9_0.cpd88" "Label88" vTcl:WidgetProc "Toplevel1" 1
    place $site_9_0.lab86 \
        -in $site_9_0 -x 5 -y 3 -width 98 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_9_0.cpd88 \
        -in $site_9_0 -x 105 -y 2 -width 181 -height 19 -anchor nw \
        -bordermode ignore 
    frame $site_8_0.cpd102 \
        -borderwidth 2 -background #EFEBEF -height 25 -width 290 
    vTcl:DefineAlias "$site_8_0.cpd102" "Frame91" vTcl:WidgetProc "Toplevel1" 1
    set site_9_0 $site_8_0.cpd102
    label $site_9_0.lab86 \
        -background #EFEBEF -text {g_tpa_flag :} 
    vTcl:DefineAlias "$site_9_0.lab86" "Label89" vTcl:WidgetProc "Toplevel1" 1
    label $site_9_0.cpd88 \
        -background #CEE3F6 -text OFF -textvariable g_tpa_flag 
    vTcl:DefineAlias "$site_9_0.cpd88" "Label90" vTcl:WidgetProc "Toplevel1" 1
    place $site_9_0.lab86 \
        -in $site_9_0 -x 5 -y 3 -width 98 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_9_0.cpd88 \
        -in $site_9_0 -x 105 -y 2 -width 181 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_8_0.fra85 \
        -in $site_8_0 -x 0 -y 0 -width 290 -height 25 -anchor nw \
        -bordermode ignore 
    place $site_8_0.cpd89 \
        -in $site_8_0 -x 0 -y 24 -width 290 -height 25 -anchor nw \
        -bordermode ignore 
    place $site_8_0.cpd90 \
        -in $site_8_0 -x 0 -y 48 -width 290 -height 25 -anchor nw \
        -bordermode ignore 
    place $site_8_0.cpd91 \
        -in $site_8_0 -x 0 -y 72 -width 290 -height 25 -anchor nw \
        -bordermode ignore 
    place $site_8_0.cpd92 \
        -in $site_8_0 -x 0 -y 96 -width 290 -height 25 -anchor nw \
        -bordermode ignore 
    place $site_8_0.cpd93 \
        -in $site_8_0 -x 0 -y 120 -width 290 -height 25 -anchor nw \
        -bordermode ignore 
    place $site_8_0.cpd94 \
        -in $site_8_0 -x 0 -y 144 -width 290 -height 25 -anchor nw \
        -bordermode ignore 
    place $site_8_0.cpd95 \
        -in $site_8_0 -x 0 -y 168 -width 290 -height 25 -anchor nw \
        -bordermode ignore 
    place $site_8_0.cpd96 \
        -in $site_8_0 -x 0 -y 192 -width 290 -height 25 -anchor nw \
        -bordermode ignore 
    place $site_8_0.cpd97 \
        -in $site_8_0 -x 0 -y 216 -width 290 -height 25 -anchor nw \
        -bordermode ignore 
    place $site_8_0.cpd98 \
        -in $site_8_0 -x 0 -y 240 -width 290 -height 25 -anchor nw \
        -bordermode ignore 
    place $site_8_0.cpd99 \
        -in $site_8_0 -x 0 -y 264 -width 290 -height 25 -anchor nw \
        -bordermode ignore 
    place $site_8_0.cpd100 \
        -in $site_8_0 -x 0 -y 288 -width 290 -height 25 -anchor nw \
        -bordermode ignore 
    place $site_8_0.cpd101 \
        -in $site_8_0 -x 0 -y 312 -width 290 -height 25 -anchor nw \
        -bordermode ignore 
    place $site_8_0.cpd102 \
        -in $site_8_0 -x 0 -y 335 -width 290 -height 25 -anchor nw \
        -bordermode ignore 
    frame $site_7_0.cpd103 \
        -borderwidth 2 -relief groove -background #EFEBEF -height 370 \
        -width 290 
    vTcl:DefineAlias "$site_7_0.cpd103" "Frame92" vTcl:WidgetProc "Toplevel1" 1
    set site_8_0 $site_7_0.cpd103
    frame $site_8_0.fra85 \
        -borderwidth 2 -background #EFEBEF -height 25 -width 290 
    vTcl:DefineAlias "$site_8_0.fra85" "Frame93" vTcl:WidgetProc "Toplevel1" 1
    set site_9_0 $site_8_0.fra85
    label $site_9_0.lab86 \
        -background #EFEBEF -text {g_monitor_flag :} 
    vTcl:DefineAlias "$site_9_0.lab86" "Label91" vTcl:WidgetProc "Toplevel1" 1
    label $site_9_0.cpd88 \
        -background #CEE3F6 -textvariable g_monitor_flag 
    vTcl:DefineAlias "$site_9_0.cpd88" "Label92" vTcl:WidgetProc "Toplevel1" 1
    place $site_9_0.lab86 \
        -in $site_9_0 -x 5 -y 3 -width 98 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_9_0.cpd88 \
        -in $site_9_0 -x 105 -y 2 -width 181 -height 19 -anchor nw \
        -bordermode ignore 
    frame $site_8_0.cpd89 \
        -borderwidth 2 -background #EFEBEF -height 25 -width 290 
    vTcl:DefineAlias "$site_8_0.cpd89" "Frame94" vTcl:WidgetProc "Toplevel1" 1
    set site_9_0 $site_8_0.cpd89
    label $site_9_0.lab86 \
        -background #EFEBEF -text {g_scopsserver :} 
    vTcl:DefineAlias "$site_9_0.lab86" "Label93" vTcl:WidgetProc "Toplevel1" 1
    label $site_9_0.cpd88 \
        -background #CEE3F6 -text 10.201.16.50 -textvariable g_scopsserver 
    vTcl:DefineAlias "$site_9_0.cpd88" "Label95" vTcl:WidgetProc "Toplevel1" 1
    place $site_9_0.lab86 \
        -in $site_9_0 -x 5 -y 3 -width 98 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_9_0.cpd88 \
        -in $site_9_0 -x 105 -y 2 -width 181 -height 19 -anchor nw \
        -bordermode ignore 
    frame $site_8_0.cpd90 \
        -borderwidth 2 -background #EFEBEF -height 25 -width 290 
    vTcl:DefineAlias "$site_8_0.cpd90" "Frame95" vTcl:WidgetProc "Toplevel1" 1
    set site_9_0 $site_8_0.cpd90
    label $site_9_0.lab86 \
        -background #EFEBEF -text {g_scopsversion :} 
    vTcl:DefineAlias "$site_9_0.lab86" "Label97" vTcl:WidgetProc "Toplevel1" 1
    label $site_9_0.cpd88 \
        -background #CEE3F6 -text 1 -textvariable g_scopsversion 
    vTcl:DefineAlias "$site_9_0.cpd88" "Label98" vTcl:WidgetProc "Toplevel1" 1
    place $site_9_0.lab86 \
        -in $site_9_0 -x 5 -y 3 -width 98 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_9_0.cpd88 \
        -in $site_9_0 -x 105 -y 2 -width 181 -height 19 -anchor nw \
        -bordermode ignore 
    frame $site_8_0.cpd91 \
        -borderwidth 2 -background #EFEBEF -height 25 -width 290 
    vTcl:DefineAlias "$site_8_0.cpd91" "Frame96" vTcl:WidgetProc "Toplevel1" 1
    set site_9_0 $site_8_0.cpd91
    label $site_9_0.lab86 \
        -background #EFEBEF -text {g_sscopsnewversion :} 
    vTcl:DefineAlias "$site_9_0.lab86" "Label107" vTcl:WidgetProc "Toplevel1" 1
    label $site_9_0.cpd88 \
        -background #CEE3F6 -text 1 -textvariable g_scopsnewversion 
    vTcl:DefineAlias "$site_9_0.cpd88" "Label108" vTcl:WidgetProc "Toplevel1" 1
    place $site_9_0.lab86 \
        -in $site_9_0 -x 5 -y 3 -width 123 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_9_0.cpd88 \
        -in $site_9_0 -x 135 -y 2 -width 151 -height 19 -anchor nw \
        -bordermode ignore 
    frame $site_8_0.cpd92 \
        -borderwidth 2 -background #EFEBEF -height 25 -width 290 
    vTcl:DefineAlias "$site_8_0.cpd92" "Frame97" vTcl:WidgetProc "Toplevel1" 1
    set site_9_0 $site_8_0.cpd92
    label $site_9_0.lab86 \
        -background #EFEBEF -text {g_scopspath :} 
    vTcl:DefineAlias "$site_9_0.lab86" "Label109" vTcl:WidgetProc "Toplevel1" 1
    label $site_9_0.cpd88 \
        -background #CEE3F6 -textvariable g_scopspath 
    vTcl:DefineAlias "$site_9_0.cpd88" "Label110" vTcl:WidgetProc "Toplevel1" 1
    place $site_9_0.lab86 \
        -in $site_9_0 -x 5 -y 3 -width 98 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_9_0.cpd88 \
        -in $site_9_0 -x 105 -y 2 -width 181 -height 19 -anchor nw \
        -bordermode ignore 
    frame $site_8_0.cpd93 \
        -borderwidth 2 -background #EFEBEF -height 25 -width 290 
    vTcl:DefineAlias "$site_8_0.cpd93" "Frame98" vTcl:WidgetProc "Toplevel1" 1
    set site_9_0 $site_8_0.cpd93
    label $site_9_0.lab86 \
        -background #EFEBEF -text {g_apl_flag :} 
    vTcl:DefineAlias "$site_9_0.lab86" "Label111" vTcl:WidgetProc "Toplevel1" 1
    label $site_9_0.cpd88 \
        -background #CEE3F6 -text OFF -textvariable g_apl_flag 
    vTcl:DefineAlias "$site_9_0.cpd88" "Label112" vTcl:WidgetProc "Toplevel1" 1
    place $site_9_0.lab86 \
        -in $site_9_0 -x 5 -y 3 -width 98 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_9_0.cpd88 \
        -in $site_9_0 -x 105 -y 2 -width 181 -height 19 -anchor nw \
        -bordermode ignore 
    frame $site_8_0.cpd94 \
        -borderwidth 2 -background #EFEBEF -height 25 -width 290 
    vTcl:DefineAlias "$site_8_0.cpd94" "Frame99" vTcl:WidgetProc "Toplevel1" 1
    set site_9_0 $site_8_0.cpd94
    label $site_9_0.lab86 \
        -background #EFEBEF -text {g_apl_path :} 
    vTcl:DefineAlias "$site_9_0.lab86" "Label113" vTcl:WidgetProc "Toplevel1" 1
    label $site_9_0.cpd88 \
        -background #CEE3F6 -textvariable g_apl_path 
    vTcl:DefineAlias "$site_9_0.cpd88" "Label114" vTcl:WidgetProc "Toplevel1" 1
    place $site_9_0.lab86 \
        -in $site_9_0 -x 5 -y 3 -width 98 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_9_0.cpd88 \
        -in $site_9_0 -x 105 -y 2 -width 181 -height 19 -anchor nw \
        -bordermode ignore 
    frame $site_8_0.cpd95 \
        -borderwidth 2 -background #EFEBEF -height 25 -width 290 
    vTcl:DefineAlias "$site_8_0.cpd95" "Frame100" vTcl:WidgetProc "Toplevel1" 1
    set site_9_0 $site_8_0.cpd95
    label $site_9_0.lab86 \
        -background #EFEBEF -text {g_update_flag :} 
    vTcl:DefineAlias "$site_9_0.lab86" "Label115" vTcl:WidgetProc "Toplevel1" 1
    label $site_9_0.cpd88 \
        -background #CEE3F6 -text OFF -textvariable g_update_flag 
    vTcl:DefineAlias "$site_9_0.cpd88" "Label116" vTcl:WidgetProc "Toplevel1" 1
    place $site_9_0.lab86 \
        -in $site_9_0 -x 5 -y 3 -width 98 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_9_0.cpd88 \
        -in $site_9_0 -x 105 -y 2 -width 181 -height 19 -anchor nw \
        -bordermode ignore 
    frame $site_8_0.cpd96 \
        -borderwidth 2 -background #EFEBEF -height 25 -width 290 
    vTcl:DefineAlias "$site_8_0.cpd96" "Frame101" vTcl:WidgetProc "Toplevel1" 1
    set site_9_0 $site_8_0.cpd96
    label $site_9_0.lab86 \
        -background #EFEBEF -text {g_database :} 
    vTcl:DefineAlias "$site_9_0.lab86" "Label117" vTcl:WidgetProc "Toplevel1" 1
    label $site_9_0.cpd88 \
        -background #CEE3F6 -text {} -textvariable g_database 
    vTcl:DefineAlias "$site_9_0.cpd88" "Label118" vTcl:WidgetProc "Toplevel1" 1
    place $site_9_0.lab86 \
        -in $site_9_0 -x 5 -y 3 -width 98 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_9_0.cpd88 \
        -in $site_9_0 -x 105 -y 2 -width 181 -height 19 -anchor nw \
        -bordermode ignore 
    frame $site_8_0.cpd97 \
        -borderwidth 2 -background #EFEBEF -height 25 -width 290 
    vTcl:DefineAlias "$site_8_0.cpd97" "Frame102" vTcl:WidgetProc "Toplevel1" 1
    set site_9_0 $site_8_0.cpd97
    label $site_9_0.lab86 \
        -background #EFEBEF -text {g_datastream_flag :} 
    vTcl:DefineAlias "$site_9_0.lab86" "Label119" vTcl:WidgetProc "Toplevel1" 1
    label $site_9_0.cpd88 \
        -background #CEE3F6 -text OFF -textvariable g_datastream_flag 
    vTcl:DefineAlias "$site_9_0.cpd88" "Label120" vTcl:WidgetProc "Toplevel1" 1
    place $site_9_0.lab86 \
        -in $site_9_0 -x 5 -y 3 -width 98 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_9_0.cpd88 \
        -in $site_9_0 -x 105 -y 2 -width 181 -height 19 -anchor nw \
        -bordermode ignore 
    frame $site_8_0.cpd98 \
        -borderwidth 2 -background #EFEBEF -height 25 -width 290 
    vTcl:DefineAlias "$site_8_0.cpd98" "Frame103" vTcl:WidgetProc "Toplevel1" 1
    set site_9_0 $site_8_0.cpd98
    label $site_9_0.lab86 \
        -background #EFEBEF -text {g_manual_flag :} 
    vTcl:DefineAlias "$site_9_0.lab86" "Label121" vTcl:WidgetProc "Toplevel1" 1
    label $site_9_0.cpd88 \
        -background #CEE3F6 -text OFF -textvariable g_manual_flag 
    vTcl:DefineAlias "$site_9_0.cpd88" "Label122" vTcl:WidgetProc "Toplevel1" 1
    place $site_9_0.lab86 \
        -in $site_9_0 -x 5 -y 3 -width 98 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_9_0.cpd88 \
        -in $site_9_0 -x 105 -y 2 -width 181 -height 19 -anchor nw \
        -bordermode ignore 
    frame $site_8_0.cpd99 \
        -borderwidth 2 -background #EFEBEF -height 25 -width 290 
    vTcl:DefineAlias "$site_8_0.cpd99" "Frame104" vTcl:WidgetProc "Toplevel1" 1
    set site_9_0 $site_8_0.cpd99
    label $site_9_0.lab86 \
        -background #EFEBEF -text {g_hsf_flag :} 
    vTcl:DefineAlias "$site_9_0.lab86" "Label123" vTcl:WidgetProc "Toplevel1" 1
    label $site_9_0.cpd88 \
        -background #CEE3F6 -text OFF -textvariable g_hsf_flag 
    vTcl:DefineAlias "$site_9_0.cpd88" "Label124" vTcl:WidgetProc "Toplevel1" 1
    place $site_9_0.lab86 \
        -in $site_9_0 -x 5 -y 3 -width 98 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_9_0.cpd88 \
        -in $site_9_0 -x 105 -y 2 -width 181 -height 19 -anchor nw \
        -bordermode ignore 
    frame $site_8_0.cpd100 \
        -borderwidth 2 -background #EFEBEF -height 25 -width 290 
    vTcl:DefineAlias "$site_8_0.cpd100" "Frame105" vTcl:WidgetProc "Toplevel1" 1
    set site_9_0 $site_8_0.cpd100
    label $site_9_0.lab86 \
        -background #EFEBEF -text {g_sbl_flag :} 
    vTcl:DefineAlias "$site_9_0.lab86" "Label125" vTcl:WidgetProc "Toplevel1" 1
    label $site_9_0.cpd88 \
        -background #CEE3F6 -text OFF -textvariable g_sbl_flag 
    vTcl:DefineAlias "$site_9_0.cpd88" "Label126" vTcl:WidgetProc "Toplevel1" 1
    place $site_9_0.lab86 \
        -in $site_9_0 -x 5 -y 3 -width 98 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_9_0.cpd88 \
        -in $site_9_0 -x 105 -y 2 -width 181 -height 19 -anchor nw \
        -bordermode ignore 
    frame $site_8_0.cpd101 \
        -borderwidth 2 -background #EFEBEF -height 25 -width 290 
    vTcl:DefineAlias "$site_8_0.cpd101" "Frame106" vTcl:WidgetProc "Toplevel1" 1
    set site_9_0 $site_8_0.cpd101
    label $site_9_0.lab86 \
        -background #EFEBEF -text {g_drl_flag :} 
    vTcl:DefineAlias "$site_9_0.lab86" "Label127" vTcl:WidgetProc "Toplevel1" 1
    label $site_9_0.cpd88 \
        -background #CEE3F6 -text OFF -textvariable g_drl_flag 
    vTcl:DefineAlias "$site_9_0.cpd88" "Label128" vTcl:WidgetProc "Toplevel1" 1
    place $site_9_0.lab86 \
        -in $site_9_0 -x 5 -y 3 -width 98 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_9_0.cpd88 \
        -in $site_9_0 -x 105 -y 2 -width 181 -height 19 -anchor nw \
        -bordermode ignore 
    frame $site_8_0.cpd102 \
        -borderwidth 2 -background #EFEBEF -height 25 -width 290 
    vTcl:DefineAlias "$site_8_0.cpd102" "Frame107" vTcl:WidgetProc "Toplevel1" 1
    set site_9_0 $site_8_0.cpd102
    label $site_9_0.lab86 \
        -background #EFEBEF -text {g_tpa_flag :} 
    vTcl:DefineAlias "$site_9_0.lab86" "Label129" vTcl:WidgetProc "Toplevel1" 1
    label $site_9_0.cpd88 \
        -background #CEE3F6 -text OFF -textvariable g_tpa_flag 
    vTcl:DefineAlias "$site_9_0.cpd88" "Label130" vTcl:WidgetProc "Toplevel1" 1
    place $site_9_0.lab86 \
        -in $site_9_0 -x 5 -y 3 -width 98 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_9_0.cpd88 \
        -in $site_9_0 -x 105 -y 2 -width 181 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_8_0.fra85 \
        -in $site_8_0 -x 0 -y 0 -width 290 -height 25 -anchor nw \
        -bordermode ignore 
    place $site_8_0.cpd89 \
        -in $site_8_0 -x 0 -y 24 -width 290 -height 25 -anchor nw \
        -bordermode ignore 
    place $site_8_0.cpd90 \
        -in $site_8_0 -x 0 -y 48 -width 290 -height 25 -anchor nw \
        -bordermode ignore 
    place $site_8_0.cpd91 \
        -in $site_8_0 -x 0 -y 72 -width 290 -height 25 -anchor nw \
        -bordermode ignore 
    place $site_8_0.cpd92 \
        -in $site_8_0 -x 0 -y 96 -width 290 -height 25 -anchor nw \
        -bordermode ignore 
    place $site_8_0.cpd93 \
        -in $site_8_0 -x 0 -y 120 -width 290 -height 25 -anchor nw \
        -bordermode ignore 
    place $site_8_0.cpd94 \
        -in $site_8_0 -x 0 -y 144 -width 290 -height 25 -anchor nw \
        -bordermode ignore 
    place $site_8_0.cpd95 \
        -in $site_8_0 -x 0 -y 168 -width 290 -height 25 -anchor nw \
        -bordermode ignore 
    place $site_8_0.cpd96 \
        -in $site_8_0 -x 0 -y 192 -width 290 -height 25 -anchor nw \
        -bordermode ignore 
    place $site_8_0.cpd97 \
        -in $site_8_0 -x 0 -y 216 -width 290 -height 25 -anchor nw \
        -bordermode ignore 
    place $site_8_0.cpd98 \
        -in $site_8_0 -x 0 -y 240 -width 290 -height 25 -anchor nw \
        -bordermode ignore 
    place $site_8_0.cpd99 \
        -in $site_8_0 -x 0 -y 264 -width 290 -height 25 -anchor nw \
        -bordermode ignore 
    place $site_8_0.cpd100 \
        -in $site_8_0 -x 0 -y 288 -width 290 -height 25 -anchor nw \
        -bordermode ignore 
    place $site_8_0.cpd101 \
        -in $site_8_0 -x 0 -y 312 -width 290 -height 25 -anchor nw \
        -bordermode ignore 
    place $site_8_0.cpd102 \
        -in $site_8_0 -x 0 -y 336 -width 290 -height 25 -anchor nw \
        -bordermode ignore 
    place $site_7_0.but83 \
        -in $site_7_0 -x 365 -y 380 -width 225 -height 20 -anchor nw \
        -bordermode ignore 
    place $site_7_0.fra83 \
        -in $site_7_0 -x 8 -y 5 -width 290 -height 370 -anchor nw \
        -bordermode ignore 
    place $site_7_0.cpd103 \
        -in $site_7_0 -x 303 -y 4 -width 290 -height 370 -anchor nw \
        -bordermode ignore 
    place $site_6_0.fra83 \
        -in $site_6_0 -x 10 -y 5 -width 600 -height 410 -anchor nw \
        -bordermode ignore 
    set site_6_1 [$site_4_2.not83 getframe page3]
    frame $site_6_1.fra83 \
        -borderwidth 2 -relief groove -background #EFEBEF -height 40 \
        -width 600 
    vTcl:DefineAlias "$site_6_1.fra83" "Frame17" vTcl:WidgetProc "Toplevel1" 1
    set site_7_0 $site_6_1.fra83
    button $site_7_0.cpd84 \
        -background #CEE3F6 -command FUNC_DEBUG_CLEAR \
        -font {helvetica 9 bold} -pady 0 -takefocus 0 -text {CLEAR MSG} 
    vTcl:DefineAlias "$site_7_0.cpd84" "Button12" vTcl:WidgetProc "Toplevel1" 1
    button $site_7_0.cpd85 \
        -background #F4FA58 -command FUNC_DEBUG_SAVE -font {helvetica 9 bold} \
        -pady 0 -takefocus 0 -text {SAVE MSG} 
    vTcl:DefineAlias "$site_7_0.cpd85" "Button13" vTcl:WidgetProc "Toplevel1" 1
    button $site_7_0.cpd86 \
        -background #F6CEE3 \
        -command {global g_debug_flag

if { $g_debug_flag != "ON" } {
    set g_debug_flag "ON"
} else {
    set g_debug_flag "OFF"
}} \
        -font {helvetica 9 bold} -pady 0 -takefocus 0 -text {DEBUG ON} 
    vTcl:DefineAlias "$site_7_0.cpd86" "Button14" vTcl:WidgetProc "Toplevel1" 1
    label $site_7_0.cpd87 \
        -background #EFEBEF -font {helvetica 10 bold} -text ON \
        -textvariable g_debug_flag 
    vTcl:DefineAlias "$site_7_0.cpd87" "Label36" vTcl:WidgetProc "Toplevel1" 1
    button $site_7_0.but85 \
        -background #BFFF00 -command FUNC_DEBUG_SENDFILE \
        -font {helvetica 9 bold} -pady 0 -takefocus 0 -text {MAIL TO ADMIN} 
    vTcl:DefineAlias "$site_7_0.but85" "Button40" vTcl:WidgetProc "Toplevel1" 1
    button $site_7_0.but86 \
        -command FUNC_DEBUG_DELETEFILE -font {helvetica 9 bold} -pady 0 \
        -takefocus 0 -text {DEL FILE} 
    vTcl:DefineAlias "$site_7_0.but86" "Button41" vTcl:WidgetProc "Toplevel1" 1
    place $site_7_0.cpd84 \
        -in $site_7_0 -x 6 -y 5 -width 85 -height 30 -anchor nw \
        -bordermode ignore 
    place $site_7_0.cpd85 \
        -in $site_7_0 -x 98 -y 5 -width 80 -height 30 -anchor nw \
        -bordermode ignore 
    place $site_7_0.cpd86 \
        -in $site_7_0 -x 376 -y 5 -width 75 -height 30 -anchor nw \
        -bordermode ignore 
    place $site_7_0.cpd87 \
        -in $site_7_0 -x 461 -y 4 -width 50 -height 30 -anchor nw \
        -bordermode ignore 
    place $site_7_0.but85 \
        -in $site_7_0 -x 269 -y 5 -width 100 -height 30 -anchor nw \
        -bordermode ignore 
    place $site_7_0.but86 \
        -in $site_7_0 -x 184 -y 5 -width 80 -height 30 -anchor nw \
        -bordermode ignore 
    frame $site_6_1.fra84 \
        -borderwidth 2 -relief groove -background #EFEBEF -height 205 \
        -width 600 
    vTcl:DefineAlias "$site_6_1.fra84" "Frame69" vTcl:WidgetProc "Toplevel1" 1
    set site_7_0 $site_6_1.fra84
    tixScrolledListBox $site_7_0.tix86 \
        -browsecmd FUNC_SELECT_DEBUG_LISTBOX -takefocus 0 -scrollbar auto \
        -borderwidth 1 -height 193 -width 588 
    bind $site_7_0.tix86 <FocusIn> {
        focus %W.listbox
    }
    place $site_7_0.tix86 \
        -in $site_7_0 -x 5 -y 5 -width 588 -height 193 -anchor nw \
        -bordermode ignore 
    frame $site_6_1.fra87 \
        -borderwidth 2 -relief groove -background #EFEBEF -height 30 \
        -width 600 
    vTcl:DefineAlias "$site_6_1.fra87" "Frame70" vTcl:WidgetProc "Toplevel1" 1
    set site_7_0 $site_6_1.fra87
    entry $site_7_0.ent88 \
        -background white -takefocus 0 -textvariable g_lst_debug_msg 
    vTcl:DefineAlias "$site_7_0.ent88" "Entry29" vTcl:WidgetProc "Toplevel1" 1
    place $site_7_0.ent88 \
        -in $site_7_0 -x 5 -y 5 -width 591 -height 19 -anchor nw \
        -bordermode ignore 
    frame $site_6_1.cpd83 \
        -borderwidth 2 -relief groove -background #EFEBEF -height 55 \
        -width 600 
    vTcl:DefineAlias "$site_6_1.cpd83" "Frame18" vTcl:WidgetProc "Toplevel1" 1
    set site_7_0 $site_6_1.cpd83
    entry $site_7_0.ent90 \
        -background white -textvariable {} 
    vTcl:DefineAlias "$site_7_0.ent90" "ent_checkvalues1" vTcl:WidgetProc "Toplevel1" 1
    entry $site_7_0.ent91 \
        -background white 
    vTcl:DefineAlias "$site_7_0.ent91" "ent_checkvalues2" vTcl:WidgetProc "Toplevel1" 1
    label $site_7_0.lab92 \
        -background #ffffff -textvariable g_check_value1 
    vTcl:DefineAlias "$site_7_0.lab92" "Label83" vTcl:WidgetProc "Toplevel1" 1
    label $site_7_0.lab93 \
        -background #ffffff -textvariable g_check_value2 
    vTcl:DefineAlias "$site_7_0.lab93" "Label84" vTcl:WidgetProc "Toplevel1" 1
    button $site_7_0.cpd94 \
        -background #CEE3F6 \
        -command {global g_check_value1

if { [catch {
    set g_check_value1 "[subst $[ent_checkvalues1 get]]"
} err] } {
    set g_check_value1 "This is not global variable!"
    puts "err : $err"
}} \
        -pady 0 -text {GET VALUE} 
    vTcl:DefineAlias "$site_7_0.cpd94" "Button10" vTcl:WidgetProc "Toplevel1" 1
    button $site_7_0.cpd95 \
        -background #CEE3F6 \
        -command {global g_check_value2

if { [catch {
    set g_check_value2 "[subst $[ent_checkvalues2 get]]"
} err] } {
    set g_check_value2 "This is not global variable!"
    puts "err : $err"
}} \
        -pady 0 -text {GET VALUE} 
    vTcl:DefineAlias "$site_7_0.cpd95" "Button17" vTcl:WidgetProc "Toplevel1" 1
    place $site_7_0.ent90 \
        -in $site_7_0 -x 10 -y 5 -width 130 -height 20 -anchor nw \
        -bordermode ignore 
    place $site_7_0.ent91 \
        -in $site_7_0 -x 10 -y 29 -width 130 -height 20 -anchor nw \
        -bordermode ignore 
    place $site_7_0.lab92 \
        -in $site_7_0 -x 147 -y 5 -width 295 -height 20 -anchor nw \
        -bordermode ignore 
    place $site_7_0.lab93 \
        -in $site_7_0 -x 147 -y 29 -width 295 -height 20 -anchor nw \
        -bordermode ignore 
    place $site_7_0.cpd94 \
        -in $site_7_0 -x 450 -y 5 -width 138 -height 20 -anchor nw \
        -bordermode ignore 
    place $site_7_0.cpd95 \
        -in $site_7_0 -x 450 -y 29 -width 138 -height 20 -anchor nw \
        -bordermode ignore 
    frame $site_6_1.cpd84 \
        -borderwidth 2 -relief groove -background #EFEBEF -height 55 \
        -width 600 
    vTcl:DefineAlias "$site_6_1.cpd84" "Frame20" vTcl:WidgetProc "Toplevel1" 1
    set site_7_0 $site_6_1.cpd84
    entry $site_7_0.ent90 \
        -background white -textvariable g_setvariable1 
    vTcl:DefineAlias "$site_7_0.ent90" "ent_setvalues1" vTcl:WidgetProc "Toplevel1" 1
    entry $site_7_0.ent91 \
        -background white -textvariable g_setvariable2 
    vTcl:DefineAlias "$site_7_0.ent91" "ent_setvalues2" vTcl:WidgetProc "Toplevel1" 1
    button $site_7_0.cpd94 \
        -background #F6CEE3 \
        -command {if { [string trim $g_setvariable1] == "" || [string trim $g_setvalue1] == "" } {
    return
}

if { [catch {
    global $g_setvariable1
    set $g_setvariable1 $g_setvalue1
    set choice [ tk_messageBox -title "Success to Set the Value" -icon warning -message "Variable : $g_setvariable1   \n\nValue : $g_setvalue1   "]
    
} err] } {
    FD "SET VALUE1 : $err"
}} \
        -pady 0 -text {SET VALUE} 
    vTcl:DefineAlias "$site_7_0.cpd94" "Button20" vTcl:WidgetProc "Toplevel1" 1
    button $site_7_0.cpd95 \
        -background #F6CEE3 \
        -command {if { [string trim $g_setvariable2] == "" || [string trim $g_setvalue2] == "" } {
    return
}

if { [catch {
    global $g_setvariable2
    set $g_setvariable2 $g_setvalue2
    set choice [ tk_messageBox -title "Success to Set the Value" -icon warning -message "Variable : $g_setvariable2   \n\nValue : $g_setvalue2   "]
    
} err] } {
    FD "SET VALUE2 : $err"
}} \
        -pady 0 -text {SET VALUE} 
    vTcl:DefineAlias "$site_7_0.cpd95" "Button21" vTcl:WidgetProc "Toplevel1" 1
    entry $site_7_0.cpd98 \
        -background white -textvariable g_setvalue1 
    vTcl:DefineAlias "$site_7_0.cpd98" "ent_setvalues11" vTcl:WidgetProc "Toplevel1" 1
    entry $site_7_0.cpd99 \
        -background white -textvariable g_setvalue2 
    vTcl:DefineAlias "$site_7_0.cpd99" "ent_setvalues22" vTcl:WidgetProc "Toplevel1" 1
    place $site_7_0.ent90 \
        -in $site_7_0 -x 10 -y 4 -width 130 -height 20 -anchor nw \
        -bordermode ignore 
    place $site_7_0.ent91 \
        -in $site_7_0 -x 10 -y 29 -width 130 -height 20 -anchor nw \
        -bordermode ignore 
    place $site_7_0.cpd94 \
        -in $site_7_0 -x 450 -y 5 -width 138 -height 20 -anchor nw \
        -bordermode ignore 
    place $site_7_0.cpd95 \
        -in $site_7_0 -x 450 -y 29 -width 138 -height 20 -anchor nw \
        -bordermode ignore 
    place $site_7_0.cpd98 \
        -in $site_7_0 -x 147 -y 5 -width 295 -height 20 -anchor nw \
        -bordermode ignore 
    place $site_7_0.cpd99 \
        -in $site_7_0 -x 147 -y 29 -width 295 -height 20 -anchor nw \
        -bordermode ignore 
    frame $site_6_1.cpd85 \
        -borderwidth 2 -relief groove -background #EFEBEF -height 75 \
        -width 600 
    vTcl:DefineAlias "$site_6_1.cpd85" "Frame13" vTcl:WidgetProc "Toplevel1" 1
    set site_7_0 $site_6_1.cpd85
    entry $site_7_0.ent85 \
        -background white -textvariable g_executefunction1 
    vTcl:DefineAlias "$site_7_0.ent85" "ent_executeFunction1" vTcl:WidgetProc "Toplevel1" 1
    button $site_7_0.but88 \
        -background #D0A9F5 \
        -command {global g_executefunction1

if { [string trim $g_executefunction1] == "" } {
    return
}

set arg_count [llength $g_executefunction1]

if { $arg_count == 1 } {
    #if { [catch {
        [lindex $g_executefunction1 0]
    #} err] } {
    #    FD "ERROR1 : $err"
    #}
}

if { $arg_count == 2 } {
    #if { [catch {
        [lindex $g_executefunction1 0] [lindex $g_executefunction1 1]
    #} err] } {
    #    FD "ERROR1 : $err"
    #}
}

if { $arg_count == 3 } {
    #if { [catch {
        [lindex $g_executefunction1 0] [lindex $g_executefunction1 1] [lindex $g_executefunction1 2]
    #} err] } {
    #    FD "ERROR1 : $err"
    #}
}} \
        -pady 0 -text {EXECUTE FUNC} 
    vTcl:DefineAlias "$site_7_0.but88" "Button8" vTcl:WidgetProc "Toplevel1" 1
    ComboBox $site_7_0.com84 \
        -entrybg white -takefocus 1 -text FUNC_GET_HOSTSTATUS \
        -textvariable g_executefunction3 
    vTcl:DefineAlias "$site_7_0.com84" "cmb_debug2" vTcl:WidgetProc "Toplevel1" 1
    bindtags $site_7_0.com84 "$site_7_0.com84 BwComboBox $top all"
    button $site_7_0.but85 \
        -background #D0A9F5 \
        -command {global g_executefunction3

if { [string trim $g_executefunction3] == "" } {
    return
}

set arg_count [llength $g_executefunction3]

if { $arg_count == 1 } {
    if { [catch {
        [lindex $g_executefunction3 0]
    } err] } {
        FD "ERROR3 : $err"
    }
}

if { $arg_count == 2 } {
    if { [catch {
        [lindex $g_executefunction3 0] [lindex $g_executefunction3 1]
    } err] } {
        FD "ERROR3 : $err"
    }
}

if { $arg_count == 3 } {
    if { [catch {
        [lindex $g_executefunction3 0] [lindex $g_executefunction3 1] [lindex $g_executefunction3 2]
    } err] } {
        FD "ERROR3 : $err"
    }
}} \
        -pady 0 -text {EXECUTE FUNC} 
    vTcl:DefineAlias "$site_7_0.but85" "Button15" vTcl:WidgetProc "Toplevel1" 1
    button $site_7_0.but83 \
        -background #F4FA58 -command FUNC_LOAD_FUNCTIONS -pady 0 \
        -text {LOAD } 
    vTcl:DefineAlias "$site_7_0.but83" "Button16" vTcl:WidgetProc "Toplevel1" 1
    ComboBox $site_7_0.cpd83 \
        -entrybg white -takefocus 1 -textvariable g_executefunction2 
    vTcl:DefineAlias "$site_7_0.cpd83" "cmb_debug1" vTcl:WidgetProc "Toplevel1" 1
    bindtags $site_7_0.cpd83 "$site_7_0.cpd83 BwComboBox $top all"
    button $site_7_0.cpd85 \
        -background #D0A9F5 \
        -command {global g_executefunction2


if { [string trim $g_executefunction2] == "" } {
    return
}

set arg_count [llength $g_executefunction2]

if { $arg_count == 1 } {
    if { [catch {
        [lindex $g_executefunction2 0]
    } err] } {
        FD "ERROR2 : $err"
    }
}

if { $arg_count == 2 } {
    if { [catch {
        [lindex $g_executefunction2 0] [lindex $g_executefunction2 1]
    } err] } {
        FD "ERROR2 : $err"
    }
}

if { $arg_count == 3 } {
    if { [catch {
        [lindex $g_executefunction2 0] [lindex $g_executefunction2 1] [lindex $g_executefunction2 2]
    } err] } {
        FD "ERROR2 : $err"
    }
}} \
        -pady 0 -text {EXECUTE FUNC} 
    vTcl:DefineAlias "$site_7_0.cpd85" "Button19" vTcl:WidgetProc "Toplevel1" 1
    place $site_7_0.ent85 \
        -in $site_7_0 -x 12 -y 4 -width 431 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_7_0.but88 \
        -in $site_7_0 -x 450 -y 4 -width 140 -height 20 -anchor nw \
        -bordermode ignore 
    place $site_7_0.com84 \
        -in $site_7_0 -x 12 -y 47 -width 351 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_7_0.but85 \
        -in $site_7_0 -x 450 -y 47 -width 140 -height 20 -anchor nw \
        -bordermode ignore 
    place $site_7_0.but83 \
        -in $site_7_0 -x 368 -y 26 -width 74 -height 40 -anchor nw \
        -bordermode ignore 
    place $site_7_0.cpd83 \
        -in $site_7_0 -x 12 -y 25 -width 351 -height 19 -anchor nw \
        -bordermode ignore 
    place $site_7_0.cpd85 \
        -in $site_7_0 -x 450 -y 26 -width 140 -height 20 -anchor nw \
        -bordermode ignore 
    place $site_6_1.fra83 \
        -in $site_6_1 -x 10 -y 444 -width 600 -height 40 -anchor nw \
        -bordermode ignore 
    place $site_6_1.fra84 \
        -in $site_6_1 -x 10 -y 200 -width 600 -height 205 -anchor nw \
        -bordermode ignore 
    place $site_6_1.fra87 \
        -in $site_6_1 -x 10 -y 410 -width 600 -height 30 -anchor nw \
        -bordermode ignore 
    place $site_6_1.cpd83 \
        -in $site_6_1 -x 10 -y 9 -width 600 -height 55 -anchor nw \
        -bordermode ignore 
    place $site_6_1.cpd84 \
        -in $site_6_1 -x 10 -y 66 -width 600 -height 55 -anchor nw \
        -bordermode ignore 
    place $site_6_1.cpd85 \
        -in $site_6_1 -x 10 -y 123 -width 600 -height 75 -anchor nw \
        -bordermode ignore 
    $site_4_2.not83 raise page2
    place $site_4_2.not83 \
        -in $site_4_2 -x 5 -y 5 -width 619 -height 513 -anchor nw \
        -bordermode ignore 
    $top.not84 raise page1
    ###################
    # SETTING GEOMETRY
    ###################
    place $top.not84 \
        -in $top -x 5 -y 5 -width 760 -height 550 -anchor nw \
        -bordermode ignore 

    vTcl:FireEvent $base <<Ready>>
}

proc vTclWindow.top85 {base} {
    if {$base == ""} {
        set base .top85
    }
    if {[winfo exists $base]} {
        wm deiconify $base; return
    }
    set top $base
    ###################
    # CREATING WIDGETS
    ###################
    vTcl:toplevel $top -class Toplevel \
        -background #EFEBEF 
    wm withdraw $top
    wm focusmodel $top passive
    wm geometry $top 393x160+480+270; update
    wm maxsize $top 2724 1009
    wm minsize $top 120 1
    wm overrideredirect $top 0
    wm resizable $top 1 1
    wm title $top "RFID Search Lot"
    vTcl:DefineAlias "$top" "Toplevel3" vTcl:Toplevel:WidgetProc "" 1
    bindtags $top "$top Toplevel all _TopLevel"
    vTcl:FireEvent $top <<Create>>
    wm protocol $top WM_DELETE_WINDOW "vTcl:FireEvent $top <<DeleteWindow>>"

    frame $top.fra86 \
        -borderwidth 2 -relief groove -background #EFEBEF -height 145 \
        -width 285 
    vTcl:DefineAlias "$top.fra86" "Frame1" vTcl:WidgetProc "Toplevel3" 1
    set site_3_0 $top.fra86
    entry $site_3_0.ent87 \
        -background white -font {helvetica 12 bold} \
        -textvariable g_rfidconformation 
    vTcl:DefineAlias "$site_3_0.ent87" "Entry1" vTcl:WidgetProc "Toplevel3" 1
    button $site_3_0.but88 \
        -background #CEE3F6 -command FUNC_RFID_COMPARE_LOTS \
        -font {helvetica 12 bold} -pady 0 -text OK 
    vTcl:DefineAlias "$site_3_0.but88" "Button1" vTcl:WidgetProc "Toplevel3" 1
    label $site_3_0.lab83 \
        -background #EFEBEF -font {helvetica 14 bold} -text {Input Lot Name!} 
    vTcl:DefineAlias "$site_3_0.lab83" "Label1" vTcl:WidgetProc "Toplevel3" 1
    canvas $site_3_0.can83 \
        -background #f0f0f0f0f0f0 -borderwidth 2 -closeenough 1.0 -confine 0 \
        -height 43 -relief ridge -width 356 
    vTcl:DefineAlias "$site_3_0.can83" "Canvas1" vTcl:WidgetProc "Toplevel3" 1
    place $site_3_0.ent87 \
        -in $site_3_0 -x 17 -y 65 -width 351 -height 34 -anchor nw \
        -bordermode ignore 
    place $site_3_0.but88 \
        -in $site_3_0 -x 17 -y 106 -width 349 -height 31 -anchor nw \
        -bordermode ignore 
    place $site_3_0.lab83 \
        -in $site_3_0 -x 14 -y 15 -width 353 -height 39 -anchor nw \
        -bordermode ignore 
    place $site_3_0.can83 \
        -in $site_3_0 -x 15 -y 10 -width 356 -height 43 -anchor nw \
        -bordermode ignore 
    ###################
    # SETTING GEOMETRY
    ###################
    place $top.fra86 \
        -in $top -x 6 -y 8 -width 380 -height 145 -anchor nw \
        -bordermode ignore 

    vTcl:FireEvent $base <<Ready>>
}

proc vTclWindow.top86 {base} {
    if {$base == ""} {
        set base .top86
    }
    if {[winfo exists $base]} {
        wm deiconify $base; return
    }
    set top $base
    ###################
    # CREATING WIDGETS
    ###################
    vTcl:toplevel $top -class Toplevel \
        -background #EFEBEF 
    wm withdraw $top
    wm focusmodel $top passive
    wm geometry $top 730x540+480+230; update
    wm maxsize $top 2700 1000
    wm minsize $top 120 1
    wm overrideredirect $top 0
    wm resizable $top 1 1
    wm title $top "Confirmation For Validations"
    vTcl:DefineAlias "$top" "Toplevel4" vTcl:Toplevel:WidgetProc "" 1
    bindtags $top "$top Toplevel all _TopLevel"
    vTcl:FireEvent $top <<Create>>
    wm protocol $top WM_DELETE_WINDOW "vTcl:FireEvent $top <<DeleteWindow>>"

    frame $top.fra87 \
        -borderwidth 2 -relief groove -background #EFEBEF -height 130 \
        -width 695 
    vTcl:DefineAlias "$top.fra87" "Frame1" vTcl:WidgetProc "Toplevel4" 1
    set site_3_0 $top.fra87
    tixScrolledListBox $site_3_0.tix83 \
        -scrollbar auto -borderwidth 1 -height 117 -width 682 
    bind $site_3_0.tix83 <FocusIn> {
        focus %W.listbox
    }
    place $site_3_0.tix83 \
        -in $site_3_0 -x 5 -y 5 -width 682 -height 117 -anchor nw \
        -bordermode ignore 
    frame $top.fra83 \
        -borderwidth 2 -relief groove -background #EFEBEF -height 125 \
        -width 341 
    vTcl:DefineAlias "$top.fra83" "Frame2" vTcl:WidgetProc "Toplevel4" 1
    set site_3_0 $top.fra83
    button $site_3_0.but91 \
        -background #F6CEE3 -command {FUNC_CONFIRM_VALIDATION_LOG "NO"} \
        -font {helvetica 14 bold} -pady 0 -text NO 
    vTcl:DefineAlias "$site_3_0.but91" "Button2" vTcl:WidgetProc "Toplevel4" 1
    place $site_3_0.but91 \
        -in $site_3_0 -x 10 -y 70 -width 324 -height 46 -anchor nw \
        -bordermode ignore 
    frame $top.fra84 \
        -borderwidth 2 -relief groove -background #EFEBEF -height 125 \
        -width 351 
    vTcl:DefineAlias "$top.fra84" "Frame3" vTcl:WidgetProc "Toplevel4" 1
    set site_3_0 $top.fra84
    label $site_3_0.cpd85 \
        -background #EFEBEF -font {helvetica 12 bold} -foreground #990099 \
        -text {Input Your Operator ID!} 
    vTcl:DefineAlias "$site_3_0.cpd85" "Label2" vTcl:WidgetProc "Toplevel4" 1
    entry $site_3_0.cpd86 \
        -background white -font {helvetica 12 bold} -justify center \
        -textvariable g_confirm_operatorid 
    vTcl:DefineAlias "$site_3_0.cpd86" "Entry1" vTcl:WidgetProc "Toplevel4" 1
    button $site_3_0.but90 \
        -background #CEE3F6 -command {FUNC_CONFIRM_VALIDATION_LOG "YES"} \
        -font {helvetica 14 bold} -pady 0 -text YES 
    vTcl:DefineAlias "$site_3_0.but90" "Button1" vTcl:WidgetProc "Toplevel4" 1
    place $site_3_0.cpd85 \
        -in $site_3_0 -x 10 -y 6 -width 320 -height 30 -anchor nw \
        -bordermode ignore 
    place $site_3_0.cpd86 \
        -in $site_3_0 -x 12 -y 41 -width 321 -height 25 -anchor nw \
        -bordermode ignore 
    place $site_3_0.but90 \
        -in $site_3_0 -x 10 -y 70 -width 324 -height 46 -anchor nw \
        -bordermode ignore 
    canvas $top.can93 \
        -background #ffffff -borderwidth 2 -closeenough 1.0 -height 218 \
        -width 636 
    vTcl:DefineAlias "$top.can93" "Canvas1" vTcl:WidgetProc "Toplevel4" 1
    menu $top.m83 \
        -activeborderwidth 1 -borderwidth 1 -font {{??: ????} 9} -tearoff 1 
    ###################
    # SETTING GEOMETRY
    ###################
    place $top.fra87 \
        -in $top -x 15 -y 265 -width 695 -height 130 -anchor nw \
        -bordermode ignore 
    place $top.fra83 \
        -in $top -x 364 -y 399 -width 345 -height 125 -anchor nw \
        -bordermode ignore 
    place $top.fra84 \
        -in $top -x 15 -y 399 -width 345 -height 125 -anchor nw \
        -bordermode ignore 
    place $top.can93 \
        -in $top -x 12 -y 10 -width 700 -height 250 -anchor nw \
        -bordermode ignore 

    vTcl:FireEvent $base <<Ready>>
}

proc vTclWindow.top95 {base} {
    if {$base == ""} {
        set base .top95
    }
    if {[winfo exists $base]} {
        wm deiconify $base; return
    }
    set top $base
    ###################
    # CREATING WIDGETS
    ###################
    vTcl:toplevel $top -class Toplevel \
        -menu "$top.m83" 
    wm withdraw $top
    wm focusmodel $top passive
    wm geometry $top 743x374+589+353; update
    wm maxsize $top 3282 1054
    wm minsize $top 120 1
    wm overrideredirect $top 0
    wm resizable $top 1 1
    wm title $top "Probe Touch Down Count Limit Over"
    vTcl:DefineAlias "$top" "Toplevel13" vTcl:Toplevel:WidgetProc "" 1
    bindtags $top "$top Toplevel all _TopLevel"
    vTcl:FireEvent $top <<Create>>
    wm protocol $top WM_DELETE_WINDOW "vTcl:FireEvent $top <<DeleteWindow>>"

    frame $top.fra96 \
        -borderwidth 2 -relief groove -height 360 -width 725 
    vTcl:DefineAlias "$top.fra96" "Frame1" vTcl:WidgetProc "Toplevel13" 1
    set site_3_0 $top.fra96
    label $site_3_0.lab97 \
        -font {Arial 20 bold} -foreground #ff0000 \
        -text {PROBE TOUCH DOWN COUNT LIMIT OVER!} 
    vTcl:DefineAlias "$site_3_0.lab97" "Label1" vTcl:WidgetProc "Toplevel13" 1
    label $site_3_0.lab98 \
        -font {Arial 16 bold} -text {PROBE CARD :} 
    vTcl:DefineAlias "$site_3_0.lab98" "Label2" vTcl:WidgetProc "Toplevel13" 1
    label $site_3_0.lab99 \
        -background #e7ade7ade7ad -font {Arial 16 bold} -textvariable g_probe 
    vTcl:DefineAlias "$site_3_0.lab99" "Label3" vTcl:WidgetProc "Toplevel13" 1
    label $site_3_0.cpd100 \
        -font {Arial 16 bold} -foreground #0000ff -text {TOUCH :} 
    vTcl:DefineAlias "$site_3_0.cpd100" "Label4" vTcl:WidgetProc "Toplevel13" 1
    label $site_3_0.cpd101 \
        -background #e7ade7ade7ad -font {Arial 16 bold} \
        -textvariable g_probe_touch 
    vTcl:DefineAlias "$site_3_0.cpd101" "Label5" vTcl:WidgetProc "Toplevel13" 1
    label $site_3_0.cpd102 \
        -font {Arial 16 bold} -foreground #ff0000 -text {LIMIT :} 
    vTcl:DefineAlias "$site_3_0.cpd102" "Label6" vTcl:WidgetProc "Toplevel13" 1
    label $site_3_0.cpd103 \
        -background #e7ade7ade7ad -font {Arial 16 bold} \
        -textvariable g_probe_limit 
    vTcl:DefineAlias "$site_3_0.cpd103" "Label7" vTcl:WidgetProc "Toplevel13" 1
    label $site_3_0.cpd104 \
        -font {Arial 14 bold} -text {OPERATOR ID :} 
    vTcl:DefineAlias "$site_3_0.cpd104" "Label8" vTcl:WidgetProc "Toplevel13" 1
    entry $site_3_0.ent105 \
        -background white -takefocus 0 -textvariable g_probe_td_operatorid 
    vTcl:DefineAlias "$site_3_0.ent105" "Entry1" vTcl:WidgetProc "Toplevel13" 1
    button $site_3_0.but106 \
        -background #CEE3F6 -command FUNC_PROBE_TD_OVER_CONFIRM \
        -font {Arial 16 bold} -pady 0 -text OK 
    vTcl:DefineAlias "$site_3_0.but106" "Button1" vTcl:WidgetProc "Toplevel13" 1
    label $site_3_0.cpd83 \
        -font {Arial 14 bold} -text {COMMENT :} 
    vTcl:DefineAlias "$site_3_0.cpd83" "Label9" vTcl:WidgetProc "Toplevel13" 1
    entry $site_3_0.cpd84 \
        -background white -takefocus 0 -textvariable g_probe_td_comment 
    vTcl:DefineAlias "$site_3_0.cpd84" "Entry2" vTcl:WidgetProc "Toplevel13" 1
    place $site_3_0.lab97 \
        -in $site_3_0 -x 58 -y 23 -width 618 -height 39 -anchor nw \
        -bordermode ignore 
    place $site_3_0.lab98 \
        -in $site_3_0 -x 135 -y 70 -width 196 -height 40 -anchor nw \
        -bordermode ignore 
    place $site_3_0.lab99 \
        -in $site_3_0 -x 370 -y 70 -width 196 -height 40 -anchor nw \
        -bordermode ignore 
    place $site_3_0.cpd100 \
        -in $site_3_0 -x 135 -y 120 -width 196 -height 40 -anchor nw \
        -bordermode ignore 
    place $site_3_0.cpd101 \
        -in $site_3_0 -x 370 -y 120 -width 196 -height 40 -anchor nw \
        -bordermode ignore 
    place $site_3_0.cpd102 \
        -in $site_3_0 -x 135 -y 170 -width 196 -height 40 -anchor nw \
        -bordermode ignore 
    place $site_3_0.cpd103 \
        -in $site_3_0 -x 370 -y 170 -width 196 -height 40 -anchor nw \
        -bordermode ignore 
    place $site_3_0.cpd104 \
        -in $site_3_0 -x 32 -y 242 -width 150 -height 28 -anchor nw \
        -bordermode ignore 
    place $site_3_0.ent105 \
        -in $site_3_0 -x 189 -y 243 -width 106 -height 24 -anchor nw \
        -bordermode ignore 
    place $site_3_0.but106 \
        -in $site_3_0 -x 30 -y 296 -width 671 -height 40 -anchor nw \
        -bordermode ignore 
    place $site_3_0.cpd83 \
        -in $site_3_0 -x 320 -y 240 -width 120 -height 28 -anchor nw \
        -bordermode ignore 
    place $site_3_0.cpd84 \
        -in $site_3_0 -x 455 -y 245 -width 246 -height 24 -anchor nw \
        -bordermode ignore 
    menu $top.m83 \
        -activeborderwidth 1 -borderwidth 1 -tearoff 1 
    ###################
    # SETTING GEOMETRY
    ###################
    place $top.fra96 \
        -in $top -x 10 -y 10 -width 725 -height 360 -anchor nw \
        -bordermode ignore 

    vTcl:FireEvent $base <<Ready>>
}

#############################################################################
## Binding tag:  _TopLevel

bind "_TopLevel" <<Create>> {
    if {![info exists _topcount]} {set _topcount 0}; incr _topcount
}
bind "_TopLevel" <<DeleteWindow>> {
    if {[set ::%W::_modal]} {
                vTcl:Toplevel:WidgetProc %W endmodal
            } else {
                destroy %W; if {$_topcount == 0} {exit}
            }
}
bind "_TopLevel" <Destroy> {
    if {[winfo toplevel %W] == "%W"} {incr _topcount -1}
}
#############################################################################
## Binding tag:  _vTclBalloon


if {![info exists vTcl(sourcing)]} {
bind "_vTclBalloon" <<KillBalloon>> {
    namespace eval ::vTcl::balloon {
        after cancel $id
        if {[winfo exists .vTcl.balloon]} {
            destroy .vTcl.balloon
        }
        set set 0
    }
}
bind "_vTclBalloon" <<vTclBalloon>> {
    if {$::vTcl::balloon::first != 1} {break}

    namespace eval ::vTcl::balloon {
        set first 2
        if {![winfo exists .vTcl]} {
            toplevel .vTcl; wm withdraw .vTcl
        }
        if {![winfo exists .vTcl.balloon]} {
            toplevel .vTcl.balloon -bg black
        }
        wm overrideredirect .vTcl.balloon 1
        label .vTcl.balloon.l  -text ${%W} -relief flat  -bg #ffffaa -fg black -padx 2 -pady 0 -anchor w
        pack .vTcl.balloon.l -side left -padx 1 -pady 1
        wm geometry  .vTcl.balloon  +[expr {[winfo rootx %W]+[winfo width %W]/2}]+[expr {[winfo rooty %W]+[winfo height %W]+4}]
        set set 1
    }
}
bind "_vTclBalloon" <Button> {
    namespace eval ::vTcl::balloon {
        set first 0
    }
    vTcl:FireEvent %W <<KillBalloon>>
}
bind "_vTclBalloon" <Enter> {
    namespace eval ::vTcl::balloon {
        ## self defining balloon?
        if {![info exists %W]} {
            vTcl:FireEvent %W <<SetBalloon>>
        }
        set set 0
        set first 1
        set id [after 500 {vTcl:FireEvent %W <<vTclBalloon>>}]
    }
}
bind "_vTclBalloon" <Leave> {
    namespace eval ::vTcl::balloon {
        set first 0
    }
    vTcl:FireEvent %W <<KillBalloon>>
}
bind "_vTclBalloon" <Motion> {
    namespace eval ::vTcl::balloon {
        if {!$set} {
            after cancel $id
            set id [after 500 {vTcl:FireEvent %W <<vTclBalloon>>}]
        }
    }
}
}

Window show .
Window show .top83
Window show .top85
Window show .top86
Window show .top95

main $argc $argv
