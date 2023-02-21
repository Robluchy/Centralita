package com.fempa.web.controller;

import com.fempa.web.model.Registro;
import com.fempa.web.repositorios.RegistroRepositoy;
import com.fempa.web.repositorios.UsuarioRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.*;

@Controller
public class RegistroController {
    @Autowired
    private RegistroRepositoy registroRepository;
    @Autowired
    private UsuarioRepository usuarioRepository;
    @GetMapping("/registro")
    public String registro(Registro registro, Model model) {
        model.addAttribute("manyregistros", registroRepository.findAll());
        model.addAttribute("atendido_por", usuarioRepository.findAll());
        model.addAttribute("empleado", usuarioRepository.findAll());
        return "registro";
    }

    @GetMapping("/registro/delete/{id}")
    public String deleteRegistro(@PathVariable("id") Integer id, Model model) {
        Registro registro = registroRepository.findById(Long.valueOf(id))
                .orElseThrow(() -> new IllegalArgumentException("Id de registro no válido: " + id));;
        if(registro != null)
            registroRepository.delete(registro);
        return "redirect:/registro";
    }

    @PostMapping("/registro")
    public String addRegistro(
            @ModelAttribute Registro registro,
            Model model,
            @RequestParam("atendido_por") String atendido_por,
            @RequestParam("empleado") String empleado) {
        model.addAttribute("atendido_por", usuarioRepository.findAll());
        model.addAttribute("empleado", usuarioRepository.findAll());
        registro.setAtendido_por(usuarioRepository.findById(Long.valueOf(atendido_por)).get());
        registro.setEmpleado(usuarioRepository.findById(Long.valueOf(empleado)).get());
        registro.setFecha_hora(String.valueOf(new java.sql.Date(new java.util.Date().getTime())));
        registroRepository.save(registro);
        return "redirect:/registro";
    }

    @PostMapping("/registro/edit/{id}")
    public String updateRegistro(
            @ModelAttribute Registro registro,
            Model model,
            @RequestParam("atendido_por") String atendido_por,
            @RequestParam("empleado") String empleado) {
        model.addAttribute("atendido_por", usuarioRepository.findAll());
        model.addAttribute("empleado", usuarioRepository.findAll());
        registro.setAtendido_por(usuarioRepository.findById(Long.valueOf(atendido_por)).get());
        registro.setEmpleado(usuarioRepository.findById(Long.valueOf(empleado)).get());
        registro.setFecha_hora(String.valueOf(new java.sql.Date(new java.util.Date().getTime())));
        registroRepository.save(registro);
        return "redirect:/registro";
    }

    @GetMapping("/registro/edit/{id}")
    public String showUpdateForm(@PathVariable("id") Integer id, Model model) {
        Registro registro = registroRepository.findById(Long.valueOf(id))
                .orElseThrow(() -> new IllegalArgumentException("Id de registro no válido: " + id));
        model.addAttribute("registro", registro);
        model.addAttribute("manyregistros", registroRepository.findAll());
        model.addAttribute("atendido_por", usuarioRepository.findAll());
        model.addAttribute("empleado", usuarioRepository.findAll());
        return "editRegistro";
    }


}
